using Archipelago.Core;
using Serilog;
using Helpers;
using Archipelago.Core.Models;
using VagrantStoryArchipelago;
using Archipelago.Core.Util;
using Kokuban;

namespace Helpers
{
    public class APHelpers
    {
        public static Boolean isInTheGame()
        {
            ulong currentGameStatus = Memory.ReadUInt(Addresses.InGameCheck);
            
            if(currentGameStatus == 0x01)
            {
                return true;
            }
            return false;
        }

        public static async void OnConnectedLogic(object sender, EventArgs args, ArchipelagoClient client)
        {
            if (client.CurrentSession == null)
            {
                return;
            }
            Log.Logger.Information("Connected to Archipelago");
            Log.Logger.Information($"Playing {client.CurrentSession.ConnectionInfo.Game} as {client.CurrentSession.Players.GetPlayerName(client.CurrentSession.ConnectionInfo.Slot)}");

            // if deathlink goes here
            int deathlink = int.Parse(client.Options?.GetValueOrDefault("deathlink", 0).ToString());

            if (deathlink == 1)
            {
                var deathLink = client.EnableDeathLink();
                deathLink.OnDeathLinkReceived += (args) => PlayerStateHelpers.KillPlayer();
            }

            if (isInTheGame())
            {
                // if you are booting and already in the game, run any reset functions
            }
        }

        public static async void OnDisconnectedLogic(object sender, ConnectionChangedEventArgs args, ArchipelagoClient client)
        {
            if (client.CurrentSession != null)
            {
                return;
            }
            Console.WriteLine("Disconnected from Archipelago.");
        }

        public static void ItemReceivedLogic(object sender, ItemReceivedEventArgs args, ArchipelagoClient client)
        {
            if (client.CurrentSession == null)
            {
                return;
            }
            Console.WriteLine("Item Received");
        }

        public static void Client_MessageReceivedLogic(object sender, MessageReceivedEventArgs e, ArchipelagoClient client, string slot)
        {

            if (client.CurrentSession == null)
            {
                return;
            }

            var message = string.Join("", e.Message.Parts.Select(p => p.Text));

            var timestamp = DateTime.Now.ToString("HH:mm:ss");

            //client.AddOverlayMessage(e.Message.ToString());

            // adds coloured messages to terminal

            string prefix;
             Kokuban.AnsiEscape.AnsiStyle bg;
             Kokuban.AnsiEscape.AnsiStyle fg;

            if (message.Contains($"{slot} found") || message.Contains($"{slot} sent"))
            {
                bg = message.Contains("Trap:") ? Chalk.BgRed : message.Contains("Congratulations") ? Chalk.Yellow : Chalk.BgBlue;
                fg = Chalk.White;
                prefix = " >> ";
            }
            else
            {
                bg = message.Contains("Trap:") ? Chalk.BgRed : message.Contains("Congratulations") ? Chalk.Yellow : Chalk.BgGreen;
                fg = Chalk.White;
                prefix = " << ";
            }

            Console.WriteLine(bg + (fg + $"[{timestamp}]{prefix}{message}"));
        }

        public static void Client_LocationCompletedLogic(object sender, LocationCompletedEventArgs e, ArchipelagoClient client)
        {
            if (client.CurrentSession == null)
            {
                return;
            }
            Console.WriteLine("Location Completed");
        }
        public static void Locations_CheckedLocationsUpdated(System.Collections.ObjectModel.ReadOnlyCollection<long> newCheckedLocations)
        {
            Console.WriteLine($"Location CheckedLocationsUpdated Firing.");
        }
    }
}