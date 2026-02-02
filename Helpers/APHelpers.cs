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
                // if you are booting and already in the game, run any reset functions
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
            if (client.CurrentSession == null)
            {
                return;
            }

            // turn back on later when you can differentiate the menu's being open.

            //if (!isInTheGame())
            //{
            //    Console.WriteLine($"Player is not in a valid location. Delaying {args.Item.Name}");
            //    App.delayedItems.Add(args);
            //    return;
            //}

#if DEBUG
            Console.WriteLine($"ItemReceived Firing. Itemcount: {client.CurrentSession.Items.AllItemsReceived.Count}");
#endif

            string firstWord = args.Item.Name.Split(' ')[0];

            // 2. Check if any value in the dictionary matches that word
            // We use StringComparison.OrdinalIgnoreCase to be user-friendly with casing
            var materialExists = ItemHelpers.MaterialReference.FirstOrDefault(x =>
                string.Equals(x.Value, firstWord, StringComparison.OrdinalIgnoreCase));

            // 3. If the key is not default (or if we found a match), return it

            string result = null;

            if (materialExists.Value is not null)
            {
                string[] parts = args.Item.Name.Split(' ', 2);
                result = parts.Length > 1 ? parts[1] : "";
            }
            else
            {
                result = args.Item.Name;
            }

            Console.WriteLine(result);

            switch (args.Item)
            {
                case var x when ItemHelpers.ItemReference.Any(itm => itm.Value == x.Name): ItemHelpers.handleInventoryItem(args); break;
                case var x when ItemHelpers.GemReference.Any(itm => itm.Value == x.Name): ItemHelpers.handleInventoryGem(args); break;
                case var x when ItemHelpers.ArmorReference.Any(itm => itm.Value == result): ItemHelpers.handleInventoryArmor(args); break;
                case var x when ItemHelpers.ShieldReference.Any(itm => itm.Value == result): ItemHelpers.handleInventoryShield(args); break;
                case var x when ItemHelpers.CraftingBladeReference.Any(itm => itm.Value == result): ItemHelpers.handleInventoryCraftingBlade(args); break;
                //case var x when x.Name.ContainsAny("Charge:"): ItemHandlers.ReceiveChargeType(x, breakChargeLimitOption); break;
                //case var x when ItemHandlers.ListOfWeaponStrings.Any(wpn => wpn == x.Name) || ItemHandlers.ListOfShieldStrings.Any(wpn => wpn == x.Name): ItemHandlers.ReceiveEquipment(x); break;
                //case var x when x.Name.ContainsAny("Life Bottle"): ItemHandlers.ReceiveLifeBottle(); break;
                //case var x when ItemHandlers.ListOfKeyItemStrings.Any(key => key == x.Name): ItemHandlers.ReceiveKeyItem(x); break;
                //case var x when x.Name.ContainsAny("Gold Coins"): ItemHandlers.ReceiveGold(x); break;
                //case var x when x.Name.ContainsAny("Health", "Energy:"): ItemHandlers.ReceiveEnergy(x); break;
                //case var x when x.Name.Contains("Trap: Heavy Dan"): TrapHandlers.HeavyDanTrap(); break;
                //case var x when x.Name.Contains("Trap: Light Dan"): TrapHandlers.LightDanTrap(); break;
                //case var x when x.Name.Contains("Trap: Lag"): TrapHandlers.RunLagTrap(); break;
                //case null: Console.WriteLine("Received an item with null data. Skipping."); break;
                default: Console.WriteLine($"Item not recognised. ({args.Item.Name}) Skipping"); break;
            };

            //PlayerStateHelpers.UpdatePlayerState(client, false);
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