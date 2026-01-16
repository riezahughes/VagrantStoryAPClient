// See https://aka.ms/new-console-template for more information

using Archipelago.Core;
using Archipelago.Core.GameClients;
using Archipelago.Core.Models;
using Archipelago.Core.Util;
using VagrantStoryArchipelago.Helpers;
using Helpers;
using Spectre.Console;

internal class Program
{
    private static async Task Main(string[] args)
    {

        // Connection details
        string url;
        string port;
        string slot;
        string password;
        string gameName = "Vagrant Story";

        DuckstationClient gameClient = null;
        List<ILocation> GameLocations = null;

        ////////////////////////////
        //
        // Main Program Flow
        //
        ////////////////////////////

        // Make sure the connect is initialised

        var clientLayout = CliHelpers.CreateGridLayout();
        //AnsiConsole.Write(layout);
        var mainMessages = new List<Markup>();

        int retryAttempt = 0;

        AnsiConsole.Live(clientLayout)
            .StartAsync(async ctx =>
            {

                bool clientInitializedAndConnected = false;
                int retryAttempt = 0;

                while (!clientInitializedAndConnected)
                {
                    retryAttempt++;
                    CliHelpers.AddMessageToLeftPanel(clientLayout, mainMessages, $"Attempt #{retryAttempt} to connect...");

                    try
                    {
                        gameClient = new DuckstationClient();
                        clientInitializedAndConnected = true;
                        CliHelpers.AddMessageToLeftPanel(clientLayout, mainMessages, "Connected!");
                        ctx.Refresh();
                    }
                    catch (Exception)
                    {
                        CliHelpers.AddMessageToLeftPanel(clientLayout, mainMessages, "Could not find Duckstation open.");
                        ctx.Refresh();

                        Thread.Sleep(5000);
                    }
                }
            });


        bool connected = gameClient.Connect();
        var archipelagoClient = new ArchipelagoClient(gameClient);

        archipelagoClient.CancelMonitors();
        archipelagoClient.Connected -= (sender, args) => APHelpers.OnConnectedLogic(sender, args, archipelagoClient);
        archipelagoClient.Disconnected -= (sender, args) => APHelpers.OnDisconnectedLogic(sender, args, archipelagoClient);
        archipelagoClient.ItemReceived -= (sender, args) => APHelpers.ItemReceivedLogic(sender, args, archipelagoClient);
        archipelagoClient.LocationCompleted -= (sender, args) => APHelpers.Client_LocationCompletedLogic(sender, args, archipelagoClient);

        CliHelpers.AddMessageToLeftPanel(clientLayout, mainMessages, "Successfully connected to Duckstation.");

        // get the duckstation offset
        try
        {
            Memory.GlobalOffset = Memory.GetDuckstationOffset();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while getting Duckstation memory offset: {ex.Message}");
            Console.WriteLine(ex); // Print full exception for debugging
        }

        url = AnsiConsole.Ask<string>("Enter AP url:", "archipelago.gg");
        port = AnsiConsole.Ask<string>("Enter Port:");
        slot = AnsiConsole.Ask<string>("Enter Slot Name:");
        password = AnsiConsole.Prompt(new TextPrompt<string>("Enter Password:").Secret().AllowEmpty());

        //Console.WriteLine("Details:");
        //Console.WriteLine($"URL:{url}:{port}");
        //Console.WriteLine($"Slot: {slot}");
        //Console.WriteLine($"Password: {password}");

        if (string.IsNullOrWhiteSpace(slot))
        {
            Console.WriteLine("Slot name cannot be empty. Please provide a valid slot name.");
            return;
        }

        CliHelpers.AddMessageToLeftPanel(clientLayout, mainMessages, "Got the details! Attempting to connect to Archipelagos main server");

        // Register event handlers
        archipelagoClient.Connected += (sender, args) => APHelpers.OnConnectedLogic(sender, args, archipelagoClient);
        archipelagoClient.Disconnected += (sender, args) => APHelpers.OnDisconnectedLogic(sender, args, archipelagoClient);
        archipelagoClient.ItemReceived += (sender, args) => APHelpers.ItemReceivedLogic(sender, args, archipelagoClient);
        archipelagoClient.MessageReceived += (sender, args) => APHelpers.Client_MessageReceivedLogic(sender, args, archipelagoClient);
        archipelagoClient.LocationCompleted += (sender, args) => APHelpers.Client_LocationCompletedLogic(sender, args, archipelagoClient);
        archipelagoClient.EnableLocationsCondition = () => Helpers.APHelpers.isInTheGame();

        var cts = new CancellationTokenSource();
        try
        {
            // 
            await archipelagoClient.Connect(url + ":" + port, gameName);
            CliHelpers.AddMessageToLeftPanel(clientLayout, mainMessages, "Connected. Attempting to Log in...");

            await archipelagoClient?.Login(slot, password);
            CliHelpers.AddMessageToLeftPanel(clientLayout, mainMessages, "Logged in!");

            while (archipelagoClient.CurrentSession == null)
            {
                CliHelpers.AddMessageToLeftPanel(clientLayout, mainMessages, "Waiting for current session...");
                Thread.Sleep(1000);
            }

            archipelagoClient.CurrentSession.Locations.CheckedLocationsUpdated += APHelpers.Locations_CheckedLocationsUpdated;

            GameLocations = LocationHelpers.BuildLocationList(archipelagoClient.Options);

            // underscore runs the monitor locations task in the background. You can cane _= to await if you want to watch it more directly. 
            _ = archipelagoClient.MonitorLocations(GameLocations); 

            // Simple commands for interacting can go here
            while (!cts.Token.IsCancellationRequested)
            {
                var input = Console.ReadLine();
                if (input?.Trim().ToLower() == "exit")
                {
                    cts.Cancel();
                    break;
                }
                else if (input?.Trim().ToLower().Contains("hint") == true)
                {

                    string hintString = input?.Trim().ToLower() == "hint" ? "!hint" : $"!hint {input.Substring(5).Trim()}";
                    archipelagoClient.SendMessage(hintString);
                }
                else if (input?.Trim().ToLower() == "update")
                {
                    if (archipelagoClient.LocationState.CompletedLocations != null)
                    {
                        PlayerStateHelpers.UpdatePlayerState(archipelagoClient.CurrentSession.Items.AllItemsReceived);
                        Console.WriteLine($"Player state updated. Total Count: {archipelagoClient.CurrentSession.Items.AllItemsReceived.Count}");
                    }
                    else
                    {
                        Console.WriteLine("Cannot update player state: GameState or CompletedLocations is null.");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"Unknown command: '{input}'");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while connecting to Archipelago: {ex.Message}");
            Console.WriteLine(ex); // Print full exception for debugging
        }
        finally
        {
            // Perform any necessary cleanup here
            Console.WriteLine("Shutting down...");

        }

    }
}