using System.Collections.Concurrent;
using System.Text;
using Archipelago.Core.Util;
using Helpers;

namespace VagrantStoryArchipelago.Helpers
{
    // Shows messages in the game's own notification bar (the black bar at the bottom of the screen used for
    // "Break Art learned", "Locked with key" etc.). It works by filling in the game's text box 7 the same way
    // the game does, so the game draws it itself. Nothing in the game waits on the box, so the player can keep moving.
    // Research notes: rood-reverse, src/BATTLE/BATTLE.PRG/5BF94.c (vs_battle_initTextBox, vs_battle_setTextBox,
    // vs_battle_displaySceneMessage, vs_battle_dismissTextBox and the per-frame box loop func_800CB83C).
    public static class MessageHelper
    {
        // the small label drawn on the bar
        public enum NotificationHeader : byte
        {
            None = 0,
            Caution = 1,
            Information = 2,
            Check = 3,
        }

        // On by default, can be switched with the "notify" CLI command.
        public static bool Enabled { get; set; } = true;

        // How long a message stays fully open before it is closed.
        public static TimeSpan DisplayTime { get; set; } = TimeSpan.FromSeconds(5);

        // A slim one-line bar. The game's own information boxes are 4 lines tall (vs_battle_initInformationTextBox).
        // The game stops drawing at about y = 220 (of 240), so only the part of the bar above that is visible.
        // 3 is the smallest bar with room for a full line of text (12px glyphs including descenders like g/y);
        // with 2 the text gets cut off at the bottom.
        private const int BoxLines = 3;      // bar height = BoxLines * 13 + 4 pixels, measured up from the bottom (240)
        private const int MaxLines = 1;
        private const int TextYOffset = 0;   // nudges the text from where the game would put it; negative = higher on screen
        private const int MaxCharsPerLine = 48; // the font is variable width, so this is a safe estimate for the bar
        private const int MaxMessageBytes = 0xF0; // the text buffer is 0x100 bytes

        // the codes the game puts in front of its own messages: F8 00 = print instantly, FB 04 = centre each line
        private static readonly byte[] MessagePrefix = { 0xF8, 0x00, 0xFB, 0x04 };
        private const byte NewLine = 0xE8;
        private const byte EndOfString = 0xE7;

        // layout of the game's text box struct (vs_battle_textBox, 0x30 bytes)
        private const int BoxSize = 0x30;
        private const uint BoxFlags = 0x00;
        private const uint BoxString = 0x08;
        private const uint BoxState = 0x1C;
        private const uint BoxAnimLength = 0x22;

        private record Notification(string Text, NotificationHeader Header);

        private static readonly ConcurrentQueue<Notification> _queue = new();
        private static readonly SemaphoreSlim _signal = new(0);
        private static Task? _worker;

        public static Dictionary<string, byte> LetterDictionary = new Dictionary<string, byte>
        {
            // Control Codes & Placeholders
            { "[filler byte]", 0xEB },
            { "[end string]", 0xE7 },
            { "[carriage return]", 0xE8 },
            //{ "«p1»", 0xF801 },
            //{ "«p2»", 0xF802 },
            //{ "«p8»", 0xF808 },
            //{ "«p10»", 0xF80A },
            { " ", 0x8f },

            // Numbers
            { "0", 0x00 }, { "1", 0x01 }, { "2", 0x02 }, { "3", 0x03 }, { "4", 0x04 },
            { "5", 0x05 }, { "6", 0x06 }, { "7", 0x07 }, { "8", 0x08 }, { "9", 0x09 },

            // Uppercase
            { "A", 0x0A }, { "B", 0x0B }, { "C", 0x0C }, { "D", 0x0D }, { "E", 0x0E },
            { "F", 0x0F }, { "G", 0x10 }, { "H", 0x11 }, { "I", 0x12 }, { "J", 0x13 },
            { "K", 0x14 }, { "L", 0x15 }, { "M", 0x16 }, { "N", 0x17 }, { "O", 0x18 },
            { "P", 0x19 }, { "Q", 0x1A }, { "R", 0x1B }, { "S", 0x1C }, { "T", 0x1D },
            { "U", 0x1E }, { "V", 0x1F }, { "W", 0x20 }, { "X", 0x21 }, { "Y", 0x22 }, { "Z", 0x23 },

            // Lowercase
            { "a", 0x24 }, { "b", 0x25 }, { "c", 0x26 }, { "d", 0x27 }, { "e", 0x28 },
            { "f", 0x29 }, { "g", 0x2A }, { "h", 0x2B }, { "i", 0x2C }, { "j", 0x2D },
            { "k", 0x2E }, { "l", 0x2F }, { "m", 0x30 }, { "n", 0x31 }, { "o", 0x32 },
            { "p", 0x33 }, { "q", 0x34 }, { "r", 0x35 }, { "s", 0x36 }, { "t", 0x37 },
            { "u", 0x38 }, { "v", 0x39 }, { "w", 0x3A }, { "x", 0x3B }, { "y", 0x3C }, { "z", 0x3D },

            // Special / Accented
            { "Ć", 0x40 }, { "Â", 0x41 }, { "Ä", 0x42 }, { "Ç", 0x43 }, { "È", 0x44 },
            { "É", 0x45 }, { "Ê", 0x46 }, { "Ë", 0x47 }, { "Ì", 0x48 }, { "ő", 0x49 },
            { "Î", 0x4A }, { "í", 0x4B }, { "Ò", 0x4C }, { "Ó", 0x4D }, { "Ô", 0x4E },
            { "Ö", 0x4F }, { "Ù", 0x50 }, { "Ú", 0x51 }, { "Û", 0x52 }, { "Ü", 0x53 },
            { "ß", 0x54 }, { "æ", 0x55 }, { "à", 0x56 }, { "á", 0x57 }, { "â", 0x58 },
            { "ä", 0x59 }, { "ç", 0x5A }, { "è", 0x5B }, { "é", 0x5C }, { "ê", 0x5D },
            { "ë", 0x5E }, { "ì", 0x5F }, { "î", 0x61 }, { "ï", 0x62 }, { "ò", 0x63 },
            { "ó", 0x64 }, { "ô", 0x65 }, { "ö", 0x66 }, { "ù", 0x67 }, { "ú", 0x68 },
            { "û", 0x69 }, { "ü", 0x6A },

            // Symbols & Punctuation
            { "‼", 0x87 }, { "≠", 0x88 }, { "≦", 0x89 }, { "≧", 0x8A }, { "÷", 0x8B },
            { "-", 0xA7 }, { "—", 0x8D }, { "⋯", 0x8E }, { "!", 0x90 }, { "\"", 0x91 },
            { "#", 0x92 }, { "$", 0x93 }, { "%", 0x94 }, { "&", 0x95 }, { "'", 0x96 },
            { "(", 0x97 }, { ")", 0x98 }, { "{", 0xAB }, { "}", 0xAC }, { "[", 0x9B },
            { "]", 0x9C }, { ";", 0x9D }, { ":", 0x9E }, { ",", 0x9F }, { ".", 0xA0 },
            { "/", 0xA1 }, { "\\", 0xA2 }, { ">", 0xA4 }, { "?", 0xA5 }, { "_", 0xA6 },
            { "+", 0xA8 }, { "*", 0xA9 }, { "♪", 0xAD }, { "Lv.", 0xB6 }
        };

        // characters that aren't in the game's font but have a close match
        private static readonly Dictionary<char, char> Substitutes = new()
        {
            { '’', '\'' }, { '‘', '\'' }, { '“', '"' }, { '”', '"' }, { '–', '-' }, { '…', '⋯' }, { '<', '(' },
        };

        // Text colours built into the game's font (control code FB 00-03), confirmed in DuckStation.
        // In message text they're written as {0}-{3}.
        public enum TextColour
        {
            White = 0,  // {0} the normal text colour
            Yellow = 1, // {1}
            Red = 2,    // {2}
            Grey = 3,   // {3} dark blue-grey, hard to read on the black bar
        }

        public const TextColour ItemColour = TextColour.Yellow;
        public const TextColour PlayerColour = TextColour.Red;

        // Wraps text in colour markup, e.g. Colour("Vera Root", TextColour.Yellow) -> "{1}Vera Root{0}"
        public static string Colour(string text, TextColour colour) => $"{{{(int)colour}}}{text}{{0}}";

        // Queues a message for the in-game notification bar. It's a single line; long text is cut off with "⋯".
        // {0}-{3} anywhere in the text switches colour, e.g. "{1}Vera Root{0} found by {2}Bob{0}".
        // Safe to call from any thread; messages show one after another.
        public static void Show(string text, NotificationHeader header = NotificationHeader.None)
        {
            if (!Enabled || string.IsNullOrWhiteSpace(text)) return;
            _queue.Enqueue(new Notification(text, header));
            _signal.Release();
        }

        // fromPlayer is the player whose world the item was found in
        public static void ItemReceived(string itemName, string fromPlayer) =>
            Show($"{Colour(itemName, ItemColour)} found by {Colour(fromPlayer, PlayerColour)}");

        public static void ItemSent(string itemName, string toPlayer) =>
            Show($"Sent {Colour(itemName, ItemColour)} to {Colour(toPlayer, PlayerColour)}");

        public static void ItemFound(string itemName) =>
            Show($"Found {Colour(itemName, ItemColour)}");

        // Starts the background loop that puts queued messages on screen. Call once after connecting.
        public static void Start(CancellationToken token)
        {
            if (_worker != null) return;
            _worker = Task.Run(() => RunAsync(token), token);
        }

        private static async Task RunAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await _signal.WaitAsync(token);

                    // wait until the game can show it: in gameplay, and box 7 not in use by the game
                    while (!CanShow())
                        await Task.Delay(250, token);

                    if (!_queue.TryDequeue(out var next) || !Enabled) continue;

                    await DisplayAsync(next, token);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
                catch (Exception ex)
                {
                    // a failed notification must never take the client down
                    Console.WriteLine($"In-game notification failed: {ex.Message}");
                    await Task.Delay(1000, CancellationToken.None);
                }
            }
        }

        private static bool CanShow()
        {
            if (!APHelpers.isInTheGame()) return false;
            if (Memory.ReadShort(Addresses.InfoTextBox + BoxState) != 0) return false; // box is open or animating
            if (Memory.ReadUInt(Addresses.SceneMessageBuffer) != 0) return false; // the game is showing its own message
            return true;
        }

        private static async Task DisplayAsync(Notification notification, CancellationToken token)
        {
            List<byte[]> lines = EncodeLines(notification.Text);

            var text = new List<byte>(MessagePrefix);
            for (int i = 0; i < lines.Count; i++)
            {
                if (i > 0) text.Add(NewLine);
                text.AddRange(lines[i]);
            }
            text.Add(EndOfString);

            Memory.Write(Addresses.NotificationTextBuffer, text.ToArray());

            // box 7, set up like vs_battle_initTextBox(7, (header << 8) | 4, 0, 1, 0, 4, 0, 0) + vs_battle_setTextBox
            int yIndent = 0xF2 - BoxLines * 13 + TextYOffset;

            byte[] box = new byte[BoxSize];
            // type 4 = bottom bar, header label, 0x20 in the top byte = no voice/sound hookup
            WriteUInt(box, BoxFlags, 0x20000000u | ((uint)notification.Header << 8) | 4u);
            WriteUInt(box, BoxString, PsxAddress(Addresses.NotificationTextBuffer));
            WriteShort(box, 0x0C, 1);       // speed
            WriteShort(box, 0x10, 0x10);    // xIndent
            WriteShort(box, 0x12, (short)yIndent);
            WriteShort(box, 0x14, 0);       // x
            WriteShort(box, 0x16, 1);       // y (non-zero = bottom of the screen)
            WriteShort(box, 0x18, 0xA0);    // centerX
            WriteShort(box, 0x1A, 0xF0);    // centerY
            box[0x1E] = 0x80;               // brightness
            box[0x20] = 0x18;               // charsPerLine
            box[0x21] = BoxLines;           // lineCount (bar height)
            box[BoxAnimLength] = 10;        // open animation length

            // write the whole box while it's inactive (state 0), then switch it on so the game never draws a half-written box
            Memory.Write(Addresses.InfoTextBox, box);
            Memory.Write(Addresses.InfoTextBox + BoxState, (short)1);

            await Task.Delay(DisplayTime, token);

            // only close it if it's still ours; the game may have replaced it with its own message
            if (Memory.ReadUInt(Addresses.InfoTextBox + BoxString) != PsxAddress(Addresses.NotificationTextBuffer)) return;
            if (Memory.ReadShort(Addresses.InfoTextBox + BoxState) <= 0) return;

            // same as vs_battle_dismissTextBox
            uint flags = Memory.ReadUInt(Addresses.InfoTextBox + BoxFlags);
            Memory.Write(Addresses.InfoTextBox + BoxFlags, flags & ~0x30u); // close animation style 0
            Memory.WriteByte(Addresses.InfoTextBox + BoxAnimLength, 8);     // close animation length
            Memory.Write(Addresses.InfoTextBox + BoxState, (short)-1);

            // let the close animation finish before the next message
            for (int i = 0; i < 20 && Memory.ReadShort(Addresses.InfoTextBox + BoxState) != 0; i++)
                await Task.Delay(50, token);
        }

        // splits text into game-encoded lines, wrapping on spaces
        private static List<byte[]> EncodeLines(string text)
        {
            var lines = new List<string>();
            // with a single line, "\n" just becomes a space
            if (MaxLines == 1) text = text.Replace("\r", "").Replace('\n', ' ');

            foreach (var paragraph in text.Replace("\r", "").Split('\n'))
            {
                var current = new StringBuilder();
                foreach (var word in paragraph.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    string w = TruncateVisible(word, MaxCharsPerLine);
                    int currentLength = VisibleLength(current.ToString());
                    if (currentLength > 0 && currentLength + 1 + VisibleLength(w) > MaxCharsPerLine)
                    {
                        lines.Add(current.ToString());
                        current.Clear();
                    }
                    if (current.Length > 0) current.Append(' ');
                    current.Append(w);
                }
                if (current.Length > 0) lines.Add(current.ToString());
            }

            if (lines.Count > MaxLines)
            {
                lines = lines.Take(MaxLines).ToList();
                lines[^1] = TruncateVisible(lines[^1], MaxCharsPerLine - 1) + "{0}⋯";
            }

            var encoded = new List<byte[]>();
            int total = MessagePrefix.Length + 1;
            foreach (var line in lines)
            {
                byte[] bytes = Encode(line);
                total += bytes.Length + 1;
                if (total > MaxMessageBytes) break;
                encoded.Add(bytes);
            }
            if (encoded.Count == 0) encoded.Add(Encode("?"));
            return encoded;
        }

        private static byte[] Encode(string text)
        {
            var bytes = new List<byte>(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                if (IsColourCode(text, i))
                {
                    bytes.Add(FontControl);
                    bytes.Add((byte)(text[i + 1] - '0'));
                    i += 2;
                    continue;
                }

                char c = Substitutes.TryGetValue(text[i], out var sub) ? sub : text[i];
                bytes.Add(LetterDictionary.TryGetValue(c.ToString(), out var b) ? b : LetterDictionary[" "]);
            }
            return bytes.ToArray();
        }

        private const byte FontControl = 0xFB; // FB 00-03 = colour

        // {0}-{3} colour markup at position i
        private static bool IsColourCode(string text, int i) =>
            i + 2 < text.Length && text[i] == '{' && text[i + 1] >= '0' && text[i + 1] <= '3' && text[i + 2] == '}';

        // length of the text as it appears on screen, ignoring colour markup
        private static int VisibleLength(string text)
        {
            int length = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (IsColourCode(text, i)) { i += 2; continue; }
                length++;
            }
            return length;
        }

        // cuts text down to a number of visible characters, keeping colour markup intact
        private static string TruncateVisible(string text, int maxVisible)
        {
            var result = new StringBuilder();
            int visible = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (IsColourCode(text, i)) { result.Append(text, i, 3); i += 2; continue; }
                if (visible == maxVisible) break;
                result.Append(text[i]);
                visible++;
            }
            return result.ToString();
        }

        // the client uses addresses relative to the start of PS1 RAM; the game's own pointers are 0x80xxxxxx
        private static uint PsxAddress(uint address) => 0x80000000u | address;

        private static void WriteUInt(byte[] buffer, uint offset, uint value) => BitConverter.GetBytes(value).CopyTo(buffer, (int)offset);
        private static void WriteShort(byte[] buffer, uint offset, short value) => BitConverter.GetBytes(value).CopyTo(buffer, (int)offset);
    }
}
