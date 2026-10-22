using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Archipelago.Core.Util.Overlay;

namespace VagrantStoryArchipelago.Helpers
{
    // wraps the game overlay so it can be switched on and off from the CLI. On by default.
    // Turning it off closes the overlay window completely and turning it on opens a new one, because a disposed overlay can't be reused.
    public class ToggleableOverlayService : IOverlayService
    {
        private const string OverlayWindowClass = "GLFW30"; // the window class GLFW gives Core's overlay window
        private const uint WM_CLOSE = 0x0010;

        private readonly Func<IOverlayService> _create;
        private readonly object _lock = new();
        private IOverlayService? _inner;
        private Task? _closing;
        private IntPtr _targetWindowHandle;
        private bool _enabled = true;

        public ToggleableOverlayService(Func<IOverlayService> create)
        {
            _create = create;
            _inner = create();
        }

        public bool Enabled
        {
            get => _enabled;
            set
            {
                lock (_lock)
                {
                    if (value == _enabled) return;
                    _enabled = value;

                    // a failure here must never take the client down, so report it and carry on
                    try
                    {
                        if (value)
                        {
                            // let a close that's still finishing complete before opening a new window
                            _closing?.Wait(TimeSpan.FromSeconds(3));
                            Open();
                        }
                        else
                        {
                            // closed in the background so the CLI never waits on the overlay's own thread
                            var overlay = _inner;
                            _inner = null;
                            _closing = Task.Run(() => Close(overlay));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"The overlay couldn't be {(value ? "opened" : "closed")}: {ex.Message}");
                    }
                }
            }
        }

        private void Open()
        {
            _inner = _create();
            if (_targetWindowHandle != IntPtr.Zero) _inner.AttachToWindow(_targetWindowHandle);
        }

        private static void Close(IOverlayService? overlay)
        {
            try
            {
                overlay?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The overlay reported a problem while closing: {ex.Message}");
            }

            CloseOverlayWindows();
        }

        // asks the overlay window to close from its own thread's message queue, which is safe from any thread
        private static void CloseOverlayWindows()
        {
            if (!OperatingSystem.IsWindows()) return;

            int processId = Environment.ProcessId;
            EnumWindows((hWnd, _) =>
            {
                GetWindowThreadProcessId(hWnd, out uint windowProcessId);
                if (windowProcessId != processId) return true;

                // the class name is read without messaging the window's thread, unlike the title
                var className = new StringBuilder(32);
                GetClassName(hWnd, className, className.Capacity);
                if (className.ToString() == OverlayWindowClass) PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                return true;
            }, IntPtr.Zero);
        }

        public bool AttachToWindow(IntPtr targetWindowHandle)
        {
            lock (_lock)
            {
                _targetWindowHandle = targetWindowHandle;
                return _inner?.AttachToWindow(targetWindowHandle) ?? false;
            }
        }

        public void AddTextPopup(string text) => _inner?.AddTextPopup(text);

        public void AddRichTextPopup(List<ColoredTextSpan> spans) => _inner?.AddRichTextPopup(spans);

        public void SetPosition(float x, float y) => _inner?.SetPosition(x, y);

        public void SetSize(float width, float height) => _inner?.SetSize(width, height);

        public void SetSizeAndPosition(float x, float y, float width, float height) => _inner?.SetSizeAndPosition(x, y, width, height);

        public void Dispose()
        {
            lock (_lock)
            {
                var overlay = _inner;
                _inner = null;
                try { overlay?.Dispose(); } catch { /* shutting down anyway */ }
            }
        }

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
