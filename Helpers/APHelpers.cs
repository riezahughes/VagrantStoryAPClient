using Archipelago.Core;
using Archipelago.Core.Models;
using Archipelago.Core.Util;
using Kokuban;
using Serilog;
using VagrantStoryArchipelago;
using VagrantStoryArchipelago.Helpers;

namespace Helpers
{
    public class APHelpers
    {
        public static Boolean isInTheGame()
        {
            ulong currentGameStatus = Memory.ReadUInt(Addresses.InGameCheck);

            if (currentGameStatus == 0x01)
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
                MapHelper.SilenceCutsceneRange(new int[]
                { 
                    // Intro, Prologue & Early Game
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 13, 22, 23, 35, 45, 55, 56, 62, 64, 65, 66, 68, 70,

                    // Empty Range (71 - 95)
                    71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95,

                    // Debug & Specific Story Beats
                    96, 97, 98, 99, 100, 

                    // Mostly Empty Range (101 - 249)
                    101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120,
                    121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140,
                    141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160,
                    161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180,
                    181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200,
                    201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
                    221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240,
                    241, 242, 243, 244, 245, 246, 247, 248, 249,

                    // Debug Room & Final Empty Range (250 - 255)
                    250, 251, 252, 253, 254, 255,

                    // High-ID Cutscene Maps (Unmapped)
                    341, 408, 412, 413, 414, 415, 427, 428, 429, 430, 506
                });
            }
        }

        public static async void OnDisconnectedLogic(object sender, ConnectionChangedEventArgs args, ArchipelagoClient client)
        {
            if (client.CurrentSession == null)
            {
                return;
            }
            Console.WriteLine("Disconnected from Archipelago.");
        }



        public static void ItemReceivedLogic(object sender, ItemReceivedEventArgs args, ArchipelagoClient client)
        {

            ItemHelpers.ProcessPendingItems(client);
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