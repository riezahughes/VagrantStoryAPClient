using Archipelago.Core;
using Archipelago.Core.GameClients;
using Archipelago.Core.Models;
using Helpers;
using Spectre.Console;
using System.Collections.Concurrent;
using System.Text;

// This is a complete structure showing how to organize your Archipelago client UI

public class ArchipelagoUI
{
    private Layout _layout;
    private ConcurrentQueue<string> _messages = new();
    private ConcurrentQueue<string> _itemsReceived = new();
    private ConcurrentQueue<string> _itemsSent = new();
    private bool _isConnected = false;
    private int _maxMessages = 15;
    private int _maxItems = 10;

    public async Task Run()
    {
        // Step 1: Get login details BEFORE starting live display
        var (url, port, slot, password) = GetLoginDetails();

        // Step 2: Clear and start the live display
        AnsiConsole.Clear();
        _layout = CreateLayout();

        var cts = new CancellationTokenSource();

        // Step 3: Start the live display in a background task
        var displayTask = Task.Run(async () =>
        {
            await AnsiConsole.Live(_layout)
                .AutoClear(false)
                .StartAsync(async ctx =>
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        UpdateLayout();
                        ctx.UpdateTarget(_layout);
                        await Task.Delay(100); // Refresh 10 times per second
                    }
                });
        });


        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Medievil 2 Archipelago Client";

        // set values
        const byte US_OFFSET = 0x38; // this is ADDED to addresses to get their US location
        const byte JP_OFFSET = 0; // could add more offsfets here



        bool playerStateUpdating = false;

        bool firstRun = true;

        CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        List<ILocation> GameLocations = null;

        ////////////////////////////
        //
        // Main Program Flow
        //
        ////////////////////////////

        // Make sure the connect is initialised


        DuckstationClient gameClient = null;
        bool clientInitializedAndConnected = false; // Renamed for clarity
        int retryAttempt = 0;

        while (!clientInitializedAndConnected)
        {
            Console.Clear();
            retryAttempt++;
            Console.WriteLine($"\nAttempt #{retryAttempt}:");

            try
            {
                gameClient = new DuckstationClient();
                clientInitializedAndConnected = true;
            }
            catch (Exception ex)
            {
                // Catch any exception thrown during the DuckstationClient constructor call
                // or any other unexpected error during the try block.
                Console.WriteLine($"Could not find Duckstation open.");

                // Wait for 5 seconds before the next retry
                Thread.Sleep(5000); // 5000 milliseconds = 5 seconds
            }
        }

#if DEBUG
#else
            Console.Clear();
#endif

        bool connected = gameClient.Connect();

        var archipelagoClient = new ArchipelagoClient(gameClient);

        // Register event handlers
        archipelagoClient.Connected += (sender, args) => APHelpers.OnConnectedLogic(sender, args, archipelagoClient);
        archipelagoClient.Disconnected += (sender, args) => APHelpers.OnDisconnectedLogic(sender, args, archipelagoClient);
        archipelagoClient.ItemReceived += (sender, args) => APHelpers.ItemReceivedLogic(sender, args, archipelagoClient);
        archipelagoClient.MessageReceived += (sender, args) => APHelpers.Client_MessageReceivedLogic(sender, args, archipelagoClient, slot);
        archipelagoClient.LocationCompleted += (sender, args) => APHelpers.Client_LocationCompletedLogic(sender, args, archipelagoClient);


        // Step 4: Connect to your services
        AddMessage("Connecting to Archipelago...");
        await ConnectToArchipelago(archipelagoClient, url, port, slot, password);

        // Step 5: Start background tasks for monitoring
        var monitorTask = MonitorGameEvents(cts.Token);

        // Step 6: Command loop runs OUTSIDE the live display
        await CommandLoop(cts);

        // Cleanup
        cts.Cancel();
        await Task.WhenAll(displayTask, monitorTask);
        AnsiConsole.MarkupLine("[yellow]Shutting down...[/]");
    }

    private (string url, string port, string username, string password) GetLoginDetails()
    {
        AnsiConsole.Write(new FigletText("Vagrant Story").Color(Color.Cyan1));
        AnsiConsole.MarkupLine("[dim]Archipelago Client[/]\n");

        var url = AnsiConsole.Ask<string>("Enter AP url:", "archipelago.gg");
        var port = AnsiConsole.Ask<string>("Enter Port:", "38281");
        var slot = AnsiConsole.Ask<string>("Enter Slot Name:");
        var password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter Password:")
                .Secret()
                .AllowEmpty());

        return (url, port, slot, password);
    }

    private Layout CreateLayout()
    {
        var layout = new Layout("Root")
            .SplitRows(
                new Layout("Header").Size(5),
                new Layout("Body"),
                new Layout("Input").Size(3)
            );

        layout["Body"].SplitColumns(
            new Layout("Left"),
            new Layout("Right")
        );

        layout["Right"].SplitRows(
            new Layout("ItemsReceived"),
            new Layout("ItemsSent")
        );

        return layout;
    }

    private void UpdateLayout()
    {
        // Header with title and connection status
        var statusColor = _isConnected ? "green" : "red";
        var statusText = _isConnected ? "CONNECTED" : "DISCONNECTED";

        var headerTable = new Table()
            .Border(TableBorder.None)
            .AddColumn(new TableColumn("").Width(40))
            .AddColumn(new TableColumn("").RightAligned())
            .HideHeaders();

        headerTable.AddRow(
            new Markup("[cyan1]VAGRANT STORY[/]\n[dim]Archipelago Client[/]"),
            new Markup($"[{statusColor}]● {statusText}[/]")
        );

        _layout["Header"].Update(
            new Panel(headerTable)
                .BorderColor(Color.Blue)
                .Padding(1, 0)
        );

        // Messages panel (left)
        var messageText = string.Join("\n", _messages.TakeLast(_maxMessages));
        _layout["Left"].Update(
            new Panel(new Markup(messageText))
                .Header("Messages")
                .BorderColor(Color.Yellow)
        );

        // Items Received panel (top right)
        var receivedText = string.Join("\n", _itemsReceived.TakeLast(_maxItems));
        _layout["ItemsReceived"].Update(
            new Panel(new Markup(receivedText.Length > 0 ? receivedText : "[dim]No items received yet[/]"))
                .Header("Items Received")
                .BorderColor(Color.Green)
        );

        // Items Sent panel (bottom right)
        var sentText = string.Join("\n", _itemsSent.TakeLast(_maxItems));
        _layout["ItemsSent"].Update(
            new Panel(new Markup(sentText.Length > 0 ? sentText : "[dim]No items sent yet[/]"))
                .Header("Items Sent")
                .BorderColor(Color.Red)
        );

        // Input hint
        _layout["Input"].Update(
            new Panel("[dim]Type 'help' for commands, 'exit' to quit[/]")
                .BorderColor(Color.Grey)
        );
    }

    private async Task ConnectToArchipelago(ArchipelagoClient client, string url, string port, string slot, string password)
    {
        // Simulate connection
        try
        {



            await client.Connect(url + ":" + port, "Medievil 2");
            Thread.Sleep(1000);

            await client?.Login(slot, password);


            int retryCount = 0;
            Console.WriteLine("Waiting for connection...");
            while (client.IsLoggedIn == false)
            {

                if (retryCount >= 10)
                {
                    throw new Exception("The Medievil Client was unable to log into Archipelago. Please make sure your room is running, that you are putting in the correct details and that you are online.");

                }
                await client?.Login(slot, password);
                retryCount++;
                Console.Write(".");
                Thread.Sleep(1000);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while connecting to Archipelago: {ex.Message}");
#if DEBUG
            Console.WriteLine(ex); // Print full exception for debugging
#endif
            Console.ReadKey();
            Environment.Exit(1);

        }
    }

    private async Task MonitorGameEvents(CancellationToken token)
    {
        // This would be your actual game monitoring logic
        // For demo purposes, simulate some events
        int itemCount = 0;
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(5000);

            if (_isConnected && itemCount < 5)
            {
                itemCount++;
                AddItemReceived($"[green]• Iron Sword[/] from [cyan]Player{itemCount}[/]");
                AddMessage($"[yellow]Received item from Player{itemCount}[/]");
            }
        }
    }

    private async Task CommandLoop(CancellationTokenSource cts)
    {
        AddMessage("[cyan]Ready! Enter commands below the display.[/]");

        while (!cts.Token.IsCancellationRequested)
        {
            // This reads from BELOW the live display area
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input)) continue;

            switch (input.ToLower())
            {
                case "exit":
                case "quit":
                    AddMessage("[red]Shutting down...[/]");
                    cts.Cancel();
                    break;

                case "help":
                    AddMessage("[cyan]Commands: exit, help, hint [item], update, clear[/]");
                    break;

                case "clear":
                    _messages.Clear();
                    AddMessage("[dim]Messages cleared[/]");
                    break;

                case "update":
                    AddMessage("[yellow]Updating player state...[/]");
                    break;

                default:
                    if (input.StartsWith("hint"))
                    {
                        var hintItem = input.Length > 5 ? input.Substring(5).Trim() : "";
                        AddMessage($"[magenta]Requesting hint for: {hintItem}[/]");
                        // Send hint request to Archipelago
                    }
                    else
                    {
                        AddMessage($"[red]Unknown command: {input}[/]");
                    }
                    break;
            }
        }
    }

    public void AddMessage(string message)
    {
        _messages.Enqueue($"[dim]{DateTime.Now:HH:mm:ss}[/] {message}");
    }

    public void AddItemReceived(string item)
    {
        _itemsReceived.Enqueue(item);
    }

    public void AddItemSent(string item)
    {
        _itemsSent.Enqueue(item);
    }
}

// Usage in Program.cs:
class Program
{
    static async Task Main(string[] args)
    {
        var ui = new ArchipelagoUI();
        await ui.Run();
    }
}
