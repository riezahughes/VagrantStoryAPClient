using Archipelago.Core;
using Archipelago.Core.Models;
using Archipelago.Core.Util;
using Kokuban;
using Serilog;
using VagrantStoryArchipelago;
using VagrantStoryArchipelago.Helpers;
using VagrantStoryArchipelago.Models;

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

            if (!isInTheGame())
            {
                Console.WriteLine($"Player is not in a valid location. Delaying {args.Item.Name}");
                App.delayedItems.Add(args);
                return;
            }

#if DEBUG
            Console.WriteLine($"ItemReceived Firing. Itemcount: {client.CurrentSession.Items.AllItemsReceived.Count}");
#endif


            // Specifically only for inventory items. Does not include weapons/armour/etc

            var listOfSlots = ItemHelpers.GetInventoryItemSlots();

            Console.WriteLine($"{listOfSlots.Count} slots found");

            if (listOfSlots.Count >= 64)
            {
                Console.WriteLine($"Inventory full. Delaying {args.Item.Name}");
                App.delayedItems.Add(args);
                return;
            }

            InventoryItemData matchingItem = listOfSlots.FirstOrDefault(inGameItem => inGameItem.Name == args.Item.Name, null);


            InventoryItemData itemData;

            if (matchingItem is not null && matchingItem.Name != "Unknown Item")
            {
                Console.WriteLine($"{matchingItem.Name} has been found: Adding 5 to the quantity in slot {matchingItem.ItemSlot}");
                itemData = new InventoryItemData(matchingItem.Name, matchingItem.ItemSlot, (byte)(matchingItem.Quantity + 0x05), matchingItem.FreeSlot, matchingItem.ItemID);
            }
            else
            {
                Console.WriteLine($"No Item has been found: Adding 5 of the item to the quantity in slot {listOfSlots.Count + 1}");
                byte itemID = ItemHelpers.ItemReference.FirstOrDefault(itm => itm.Value == args.Item.Name).Key;
                itemData = new InventoryItemData(args.Item.Name, (byte)(listOfSlots.Count + 1), 0x05, 0x01, itemID);
            }



            switch (args.Item)
            {
                case var x when ItemHelpers.ItemReference.Any(itm => itm.Value == x.Name) && matchingItem is null: ItemHelpers.SetNextFreeInventorySlot(itemData); break;
                case var x when ItemHelpers.ItemReference.Any(itm => itm.Value == x.Name) && matchingItem is not null: ItemHelpers.SetInventorySlot(itemData, matchingItem.ItemSlot); break;
                    //case var x when x.Name.ContainsAny("Ammo:"): ItemHandlers.ReceiveCountType(x, breakAmmoLimitOption); break;
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
                    //default: Console.WriteLine($"Item not recognised. ({args.Item.Name}) Skipping"); break;
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