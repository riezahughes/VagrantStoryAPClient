using System.Collections.ObjectModel;
using Archipelago.Core;
using Archipelago.Core.Util;
using Archipelago.MultiClient.Net.Models;
using Helpers;
using Kokuban;
using VagrantStoryArchipelago.Data;
using VagrantStoryArchipelago.Enums;
using VagrantStoryArchipelago.Helpers.EntityLists;
using VagrantStoryArchipelago.Models.Inventory;

namespace VagrantStoryArchipelago.Helpers
{
    public class ItemHelpers
    {

        private static bool TryGiveItem(ItemInfo item, ArchipelagoClient client)
        {
            string firstWord = item.ItemName.Split(' ')[0];
            var materialExists = ItemHelpers.MaterialReference.FirstOrDefault(x =>
                string.Equals(x.Value, firstWord, StringComparison.OrdinalIgnoreCase));

            string result = null;
            if (materialExists.Value is not null)
            {
                string[] parts = item.ItemName.Split(' ', 2);
                result = parts.Length > 1 ? parts[1] : "";
            }
            else
            {
                result = item.ItemName;
            }

            // Try to handle the item based on type
            if (result.Contains("Teleport"))
                return handleTeleportItem();
            if (result.Contains("Rood Inverse"))
                return handleRoodInverseItem();
            if (ItemHelpers.ItemReference.Any(itm => itm.Value == item.ItemName && itm.Value.Contains("Grimoire")))
                return ItemHelpers.handleGrimoireUnlock(item, client.CurrentSession.Items.AllItemsReceived);
            if (ItemHelpers.ItemReference.Any(itm => itm.Value == item.ItemName))
                return ItemHelpers.handleInventoryItem(item);
            else if (ItemHelpers.GemReference.Any(itm => itm.Value == item.ItemName))
                return ItemHelpers.handleInventoryGem(item);
            else if (ItemHelpers.ArmorReference.Any(itm => itm.Value == result))
                return ItemHelpers.handleInventoryArmor(item);
            else if (ItemHelpers.ShieldReference.Any(itm => itm.Value == result))
                return ItemHelpers.handleInventoryShield(item);
            else if (ItemHelpers.CraftingBladeReference.Any(itm => itm.Value == result))
                return ItemHelpers.handleInventoryCraftingBlade(item);
            else if (ItemHelpers.CraftingGripReference.Any(itm => itm.Value == item.ItemName))
                return ItemHelpers.handleInventoryCraftingGrip(item);
            else if (ItemHelpers.ChainAbilityUnlockReference.Any(itm => itm.Key == item.ItemName))
                return ItemHelpers.handleChainAbility(item.ItemName);
            else if (ItemHelpers.DefenceAbilityUnlockReference.Any(itm => itm.Key == item.ItemName))
                return ItemHelpers.handleDefenceAbility(item.ItemName);
            else if (ItemHelpers.BreakArtsFlattenedDictionary.Any(itm => itm.Key == item.ItemName))
                return ItemHelpers.handleBreakArt(item.ItemName);
            else
            {
                Console.WriteLine($"Item not recognised. ({item.ItemName}) Skipping");
                return true; // Skip unrecognized items
            }
        }

        public static bool handleRoodInverseItem()
        {
            Memory.WriteByte(Addresses.RoodInverseActive, 0x0);
            return true;
        }

        public static bool handleTeleportItem()
        {
            Memory.WriteByte(Addresses.TeleportToggle, 0x01);
            return true;
        }


        public static void ProcessPendingItems(ArchipelagoClient client)
        {
            if (client.CurrentSession == null)
            {
                return;
            }

            var allItems = client.CurrentSession.Items.AllItemsReceived;

            // Process items from our last saved index up to what we've received
            while (App.ProcessedItemIndex < allItems.Count)
            {
                var itemToProcess = allItems[App.ProcessedItemIndex];

                // Try to give the item
                bool success = TryGiveItem(itemToProcess, client);

                if (success)
                {
                    // Only increment if we successfully gave the item
                    App.ProcessedItemIndex++;
                    Memory.Write(Addresses.ItemIndexStorage, (ushort)App.ProcessedItemIndex);
#if DEBUG
                    Console.WriteLine($"Successfully processed item {App.ProcessedItemIndex}/{allItems.Count}");
#endif
                }
                else
                {
                    // Inventory full - stop processing and wait
                    Kokuban.AnsiEscape.AnsiStyle bg = Chalk.BgMagenta;
                    Kokuban.AnsiEscape.AnsiStyle fg = Chalk.White;
                    Console.WriteLine(bg + (fg + $"⚠️ Cannot process item {itemToProcess.ItemName} - inventory full. Will retry later."));
                    break; // Exit the loop, we'll try again later
                }
            }
            APHelpers.PROCESSING_ITEM_LIST = false;
        }

        public static InventoryItemData CheckInventoryItemSlot(int slot)
        {
            // needs rewritten
            var slots = InventoryItemSlotReference;
            var slotData = Memory.ReadULong(slots[slot]);
            byte[] bytes = BitConverter.GetBytes(slotData);
            Array.Reverse(bytes);
            string itemName = ItemReference.ContainsKey(bytes[3]) ? ItemReference[bytes[3]] : "Unknown Item";
            return new InventoryItemData(itemName, bytes[0], bytes[1], bytes[2], bytes[3]);
        }

        public static List<InventoryItemData> GetInventoryItemSlots()
        {
            var slots = InventoryItemSlotReference;
            var itemList = new List<InventoryItemData>();

            foreach (var slot in slots)
            {
                var slotData = Memory.ReadUInt(slot.Value);
                byte[] bytes = BitConverter.GetBytes(slotData);

                if (bytes[0] == 0x00)
                {
                    break;
                }

                string itemName = ItemReference.ContainsKey(bytes[0]) ? ItemReference[bytes[0]] : "Unknown Item";
                var itemData = ItemDatabase.Items[itemName];
                itemData.ItemSlot = (byte)slot.Key;
                itemList.Add(itemData);
            }

            return itemList;
        }

        public static List<InventoryGemData> GetInventoryGemSlots()
        {
            var slots = InventoryGemSlotReference;
            var gemList = new List<InventoryGemData>();

            foreach (var slot in slots)
            {
                ulong slotData = Memory.ReadUInt(slot.Value + 0x04);

                //Console.WriteLine($"{slotData:X}");

                byte[] bytes = BitConverter.GetBytes(slotData);
                Array.Reverse(bytes);

                if (bytes[7] == 0x00)
                {
                    break;
                }
                string gemName = GemReference.ContainsKey(bytes[7]) ? GemReference[bytes[7]] : "Unknown Gem";
                var gemData = GemDatabase.Gems.FirstOrDefault(gem => gem.Key == gemName);
                gemList.Add(gemData.Value);
            }

            return gemList;
        }

        public static List<InventoryShieldData> GetInventoryShieldSlots()
        {
            var slots = InventoryShieldSlotReference;
            var shieldList = new List<InventoryShieldData>();

            foreach (var slot in slots)
            {
                ulong slotData = Memory.ReadUInt(slot.Value + 0x03);
                byte shieldMaterial = Memory.ReadByte(slot.Value + 0x28);

                //Console.WriteLine($"{slotData:X}");

                byte[] bytes = BitConverter.GetBytes(slotData);

                if (bytes[0] == 0x00)
                {
                    break;
                }

                string shieldName = ShieldReference.ContainsKey(bytes[0]) ? ShieldReference[bytes[0]] : "Unknown Helmet"; // this is wrong.

                string fullShieldPieceName = shieldMaterial == 0x00 ? shieldName : MaterialReference[shieldMaterial] + " " + shieldName;

                var shieldData = ShieldDatabase.Shields.FirstOrDefault(shield => shield.Key == fullShieldPieceName);

                shieldList.Add(shieldData.Value);
            }

            return shieldList;
        }


        public static List<InventoryBladeData> GetInventoryBladeSlots()
        {
            var slots = InventoryBladeSlotReference;
            var bladeList = new List<InventoryBladeData>();

            foreach (var slot in slots)
            {
                ulong slotData = Memory.ReadUInt(slot.Value);
                byte bladeMaterial = Memory.ReadByte(slot.Value + 0x28);

                //Console.WriteLine($"{slotData:X}");

                byte[] bytes = BitConverter.GetBytes(slotData);

                if (bytes[0] == 0x00 && bytes[1] == 0x00)
                {
                    break;
                }

                string bladeName = CraftingBladeReference.ContainsKey(bytes[0]) ? CraftingBladeReference[bytes[0]] : "Unknown Blade"; // this is wrong.

                string fullBladePieceName = bladeMaterial == 0x00 ? bladeName : MaterialReference[bladeMaterial] + " " + bladeName;

                var bladeData = BladeDatabase.Blades.FirstOrDefault(blade => blade.Key == fullBladePieceName);

                bladeList.Add(bladeData.Value);
            }

            return bladeList;
        }

        public static List<InventoryGripData> GetInventoryGripSlots()
        {
            var slots = InventoryGripSlotReference;
            var gripList = new List<InventoryGripData>();

            foreach (var slot in slots)
            {
                ulong slotData = Memory.ReadUInt(slot.Value);

                //Console.WriteLine($"{slotData:X}");

                byte[] bytes = BitConverter.GetBytes(slotData);

                if (bytes[0] == 0x00)
                {
                    break;
                }

                string gripName = CraftingGripReference.ContainsKey(bytes[0]) ? CraftingGripReference[bytes[0]] : "Unknown Grip";
                var gripData = GripDatabase.Grips.FirstOrDefault(grip => grip.Key == gripName);
                gripList.Add(gripData.Value);
            }

            return gripList;
        }


        public static List<InventoryArmorData> GetInventoryArmorSlots()
        {
            var slots = InventoryArmorSlotReference;
            var armorList = new List<InventoryArmorData>();

            foreach (var slot in slots)
            {
                ulong slotData = Memory.ReadUInt(slot.Value);
                byte type = Memory.ReadByte(slot.Value + 0x04);
                byte armorMaterial = Memory.ReadByte(slot.Value + 0x25);

                byte[] bytes = BitConverter.GetBytes(slotData);

                //Console.WriteLine($"{bytes[1]:X}, {bytes[2]:X}");
                //Console.WriteLine($"{armorMaterial:X}");

                if (bytes[1] == 0x00 && bytes[2] == 0x00)
                {
                    break;
                }


                string armorName = ArmorReference.ContainsKey(bytes[2]) ? ArmorReference[bytes[2]] : "Unknown Armor";

                if (armorName is null || armorName == "Unknown Armor")
                {
                    Console.WriteLine("Could not find armour reference");
                    armorList.Add(HelmetDatabase.Helmets["Leather Bandana"]);
                    continue;
                }

                string fullArmorPieceName = armorMaterial == 0x00 ? armorName : MaterialReference[armorMaterial] + " " + armorName;

                InventoryArmorData armorData = null;


                switch ((ArmorType)type)
                {
                    case 0x00:
                        armorData = HelmetDatabase.Helmets["Leather Bandana"]; // just adding a slot for the sake of it. Way less hassle if i do this.
                        armorData.ArmorInventorySlot = bytes[0];
                        armorList.Add(armorData);
                        break;
                    case ArmorType.HELM:
                        HelmetDatabase.Helmets.TryGetValue(fullArmorPieceName, out armorData);
                        armorData.ArmorInventorySlot = bytes[0];
                        armorList.Add(armorData);
                        break;
                    case ArmorType.ARM:
                        GloveDatabase.Gloves.TryGetValue(fullArmorPieceName, out armorData);
                        armorList.Add(armorData);
                        break;
                    case ArmorType.CHEST:
                        ChestpieceDatabase.Chestpieces.TryGetValue(fullArmorPieceName, out armorData);
                        armorList.Add(armorData);
                        break;
                    case ArmorType.LEG:
                        LeggingDatabase.Leggings.TryGetValue(fullArmorPieceName, out armorData);
                        armorList.Add(armorData);
                        break;
                    case ArmorType.ACCESSORY:
                        AccessoriesDatabase.Accessories.TryGetValue(fullArmorPieceName, out armorData);
                        armorList.Add(armorData);
                        break;
                    default:
                        armorData = HelmetDatabase.Helmets["Leather Bandana"]; // just adding a slot for the sake of it. Way less hassle if i do this.
                        armorData.ArmorInventorySlot = bytes[0];
                        armorList.Add(armorData);
                        break;


                }
            }

            return armorList;
        }

        public static int GetNextFreeInventoryItemSlot()
        {
            var listOfSlots = ItemHelpers.GetInventoryItemSlots();

            if (listOfSlots.Count > 64)
            {
                return 0xFF;
            }
            return listOfSlots.Count;
        }

        public static void SetInventoryItemSlot(InventoryItemData item, int slot)
        {
            if (slot != 0xff)
            {
                Memory.Write(InventoryItemSlotReference[slot - 1], item.UseFullAddress());
            }
        }

        public static void SetNextFreeInventoryItemSlot(InventoryItemData item)
        {
            var slot = GetNextFreeInventoryItemSlot();

            if (slot != 0xff)
            {
                Memory.Write(InventoryItemSlotReference[slot], item.UseFullAddress());
            }

        }

        public static bool handleGrimoireUnlock(ItemInfo item, ReadOnlyCollection<ItemInfo> itemsRecieved)
        {
            if (GrimoireReference.TryGetValue(item.ItemName, out GrimoireData grimoire))
            {
                if (grimoire.Address.Count == 1)
                {
                    Memory.WriteByte(grimoire.Address[0], grimoire.Value);
                    return true;
                }
                else
                {
                    // take the items recieved, take the current state, count how many of the item appear between 0 and state, run through each update

                    var count = itemsRecieved.Take(App.ProcessedItemIndex + 1).Count(itm => itm.ItemName == item.ItemName);
                    count = count > 4 ? 4 : count;

                    for (int i = 0; i < count; i++)
                    {
                        Memory.WriteByte(grimoire.Address[i], grimoire.Value);
                    }

                    return true;
                }
            }
            else
            {
                Console.WriteLine($"Grimoire {item.ItemName} not recognised. Skipping.");
                return true;
            }
        }

        public static bool handleInventoryItem(ItemInfo item)
        {
            // Specifically only for inventory items. Does not include weapons/armour/etc

            var listOfSlots = GetInventoryItemSlots();

            var match = listOfSlots.FirstOrDefault(kvp => kvp.Name == item.ItemName);

            if (listOfSlots.Count >= 64 && match?.Name == null)
            {
#if DEBUG
                Console.WriteLine($"Inventory full. Cannot add {item.ItemName}");
#endif
                return false;
            }

            InventoryItemData matchingItem = listOfSlots.FirstOrDefault(inGameItem => inGameItem.Name == item.ItemName, null);

            if (matchingItem is not null && matchingItem.Name != "Unknown Item")
            {
                //Console.WriteLine($"{matchingItem.Name} has been found: Adding 5 to the quantity in slot {matchingItem.ItemSlot}");
                byte itemID = ItemHelpers.ItemReference.FirstOrDefault(itm => itm.Value == item.ItemName).Key;
                InventoryItemData itemData = ItemDatabase.Items[item.ItemName];
                itemData.ItemSlot = matchingItem.ItemSlot;
                itemData.Quantity = (byte)(matchingItem.Quantity + 0x01);
                Memory.WriteObject<InventoryItemData>(InventoryItemSlotReference[matchingItem.ItemSlot], itemData);
                return true;
            }
            else
            {
                //Console.WriteLine($"No Item has been found: Adding 5 of the item to the quantity in slot {listOfSlots.Count + 1}");
                byte itemID = ItemReference.FirstOrDefault(itm => itm.Value == item.ItemName).Key;
                InventoryItemData itemData = ItemDatabase.Items[item.ItemName];
                itemData.ItemSlot = (byte)(listOfSlots.Count + 1);
                Memory.WriteObject<InventoryItemData>(InventoryItemSlotReference[listOfSlots.Count], itemData);
                return true;
            }
        }

        public static bool handleInventoryGem(ItemInfo item)
        {
            // Specifically only for gems

            var listOfSlots = ItemHelpers.GetInventoryGemSlots();

            //Console.WriteLine($"{listOfSlots.Count} gem slots found");

            if (listOfSlots.Count >= 48)
            {
#if DEBUG
                Console.WriteLine($"Inventory full. Cannot add {item.ItemName}");
#endif
                return false;
            }

            InventoryGemData matchingItem = listOfSlots.FirstOrDefault(inGameItem => inGameItem.GemName == item.ItemName, null);

            if (matchingItem is not null && matchingItem.GemName != "Unknown Gem")
            {
                //Console.WriteLine($"{matchingItem.GemName} has been found already: Ignoring Gem {matchingItem.GemInventorySlot}");
                return true;
            }
            else
            {
                byte itemID = ItemHelpers.GemReference.FirstOrDefault(itm => itm.Value == item.ItemName).Key;
                InventoryGemData gem = GemDatabase.Gems[item.ItemName];
                gem.GemInventorySlot = (byte)(listOfSlots.Count);
                //Console.WriteLine($"No Gem has been found: Adding {gem.GemName} with Agi {gem.GemAgiStat} to slot {listOfSlots.Count}");
                Memory.WriteObject<InventoryGemData>(InventoryGemSlotReference[listOfSlots.Count], GemDatabase.Gems[item.ItemName]);
                return true;
            }
        }

        public static bool handleInventoryShield(ItemInfo item)
        {
            // Specifically only for shields

            var listOfSlots = ItemHelpers.GetInventoryShieldSlots();

            //Console.WriteLine($"{listOfSlots.Count} shield slots found");

            if (listOfSlots.Count >= 8)
            {
#if DEBUG
                Console.WriteLine($"Inventory full. Cannot add {item.ItemName}");
#endif
                return false;
            }

            InventoryShieldData matchingItem = listOfSlots.FirstOrDefault(inGameItem => inGameItem.ShieldName == item.ItemName, null);

            if (matchingItem is not null && matchingItem.ShieldName != "Unknown Shield")
            {
                //Console.WriteLine($"{matchingItem.ShieldName} has been found already: Ignoring Shield {matchingItem.ShieldInventorySlot}");
                return true;
            }
            else
            {
                byte itemID = ItemHelpers.ShieldReference.FirstOrDefault(itm => itm.Value == item.ItemName).Key;
                InventoryShieldData shield = ShieldDatabase.Shields[item.ItemName];
                shield.ShieldInventorySlot = (byte)(listOfSlots.Count + 1);
                //Console.WriteLine($"No Shields has been found: Adding {shield.ShieldName} with Agi {shield.ShieldAgiStat} to slot {listOfSlots.Count}");
                Memory.WriteObject<InventoryShieldData>(InventoryShieldSlotReference[listOfSlots.Count], ShieldDatabase.Shields[item.ItemName]);
                return true;
            }
        }

        public static bool handleInventoryCraftingBlade(ItemInfo item)
        {
            // Specifically only for blades

            var listOfSlots = ItemHelpers.GetInventoryBladeSlots();

            Console.WriteLine($"{listOfSlots.Count} blade slots found");

            if (listOfSlots.Count >= 16)
            {
#if DEBUG
                Console.WriteLine($"Inventory full. Cannot add {item.ItemName}");
#endif
                return false;
            }

            InventoryBladeData matchingItem = listOfSlots.FirstOrDefault(inGameItem => inGameItem.BladeName == item.ItemName, null);

            if (matchingItem is not null && matchingItem.BladeName != "Unknown Blade")
            {
                Console.WriteLine($"{matchingItem.BladeName} has been found already: Ignoring Blade {matchingItem.BladeInventorySlot}");
                return true;
            }
            else
            {
                byte itemID = ItemHelpers.CraftingBladeReference.FirstOrDefault(itm => itm.Value == item.ItemName).Key;
                InventoryBladeData blade = BladeDatabase.Blades[item.ItemName];
                blade.BladeInventorySlot = (byte)(listOfSlots.Count + 1);
                Console.WriteLine($"No Blades has been found: Adding {blade.BladeName} with Agi {blade.BladeAgiStat} to slot {listOfSlots.Count}");
                Memory.WriteObject<InventoryBladeData>(InventoryBladeSlotReference[listOfSlots.Count], BladeDatabase.Blades[item.ItemName]);
                return true;
            }
        }

        public static bool handleInventoryCraftingGrip(ItemInfo item)
        {
            // Specifically only for grips

            var listOfSlots = ItemHelpers.GetInventoryGripSlots();

            //Console.WriteLine($"{listOfSlots.Count} grip slots found");

            if (listOfSlots.Count >= 16)
            {
#if DEBUG
                Console.WriteLine($"Inventory full. Cannot add {item.ItemName}");
#endif
                return false;
            }

            InventoryGripData matchingItem = listOfSlots.FirstOrDefault(inGameItem => inGameItem.GripName == item.ItemName, null);

            if (matchingItem is not null && matchingItem.GripName != "Unknown Grip")
            {
                //Console.WriteLine($"{matchingItem.GripName} has been found already: Ignoring Grip {matchingItem.GripInventorySlot}");
                return true;
            }
            else
            {
                byte itemID = ItemHelpers.CraftingGripReference.FirstOrDefault(itm => itm.Value == item.ItemName).Key;
                InventoryGripData grip = GripDatabase.Grips[item.ItemName];
                grip.GripInventorySlot = (byte)(listOfSlots.Count + 1);
                //Console.WriteLine($"No grips has been found: Adding {grip.GripName} with Agi {grip.GripAgiStat} to slot {listOfSlots.Count}");
                Memory.WriteObject<InventoryGripData>(InventoryGripSlotReference[listOfSlots.Count], GripDatabase.Grips[item.ItemName]);
                return true;
            }
        }

        public static bool handleInventoryArmor(ItemInfo item)
        {
            // Specifically only for armor

            var listOfSlots = ItemHelpers.GetInventoryArmorSlots();

            //Console.WriteLine($"{listOfSlots.Count} armor slots found");

            if (listOfSlots.Count >= 16)
            {
#if DEBUG
                Console.WriteLine($"Inventory full. Cannot add {item.ItemName}");
#endif
                return false;
            }

            InventoryArmorData matchingArmor = listOfSlots.FirstOrDefault(inGameItem => inGameItem.ArmorName == item.ItemName, null);

            InventoryArmorData armorData = null;

            if (matchingArmor is not null)
            {
                switch ((ArmorType)matchingArmor.ArmorType)
                {
                    case 0x00:
                        Console.WriteLine("Armour type not set up yet");
                        armorData = HelmetDatabase.Helmets["Leather Bandana"]; // just adding a slot for the sake of it. Way less hassle if i do this.
                        break;
                    case ArmorType.HELM:
                        HelmetDatabase.Helmets.TryGetValue(item.ItemName, out armorData);
                        break;
                    case ArmorType.ARM:
                        GloveDatabase.Gloves.TryGetValue(item.ItemName, out armorData);
                        break;
                    case ArmorType.CHEST:
                        ChestpieceDatabase.Chestpieces.TryGetValue(item.ItemName, out armorData);
                        break;
                    case ArmorType.LEG:
                        LeggingDatabase.Leggings.TryGetValue(item.ItemName, out armorData);
                        break;
                    case ArmorType.ACCESSORY:
                        AccessoriesDatabase.Accessories.TryGetValue(item.ItemName, out armorData);
                        break;
                }

                //Console.WriteLine($"{matchingArmor.ArmorName} has been found already: Adding to newer slot {listOfSlots.Count + 1}");
                armorData.ArmorInventorySlot = (byte)(listOfSlots.Count);
                Memory.WriteObject<InventoryArmorData>(InventoryArmorSlotReference[listOfSlots.Count], armorData);
                return true;
            }
            else
            {
                InventoryArmorData foundArmor = null;

                // Define the list using your specific Armor Data type
                var allDicts = new List<Dictionary<string, InventoryArmorData>>
                {
                    HelmetDatabase.Helmets,
                    GloveDatabase.Gloves,
                    ChestpieceDatabase.Chestpieces,
                    LeggingDatabase.Leggings,
                    AccessoriesDatabase.Accessories
                };

                foreach (var dict in allDicts)
                {
                    // TryGetValue is more efficient as it checks and grabs the item in one go
                    if (dict.TryGetValue(item.ItemName, out var armorDictData))
                    {
                        foundArmor = armorDictData;
                        break;
                    }
                }

                foundArmor.ArmorInventorySlot = (byte)(listOfSlots.Count);

                //Console.WriteLine($"Armor does not exist: Adding {foundArmor.ArmorName} with material of {foundArmor.ArmorMaterial} to slot {listOfSlots.Count + 1}");

                Memory.WriteObject<InventoryArmorData>(InventoryArmorSlotReference[listOfSlots.Count], foundArmor);
                return true;
            }
        }

        public static bool handleChainAbility(string abilityName)
        {
            // TryGetValue prevents a KeyNotFoundException if the name is invalid
            if (ChainAbilityUnlockReference.TryGetValue(abilityName, out uint address))
            {
                Memory.WriteByte(address, 0x80);
                return true;
            }
            return false;
        }

        public static bool handleDefenceAbility(string abilityName)
        {
            // Same guard pattern for Defence Abilities
            if (DefenceAbilityUnlockReference.TryGetValue(abilityName, out uint address))
            {
                Memory.WriteByte(address, 0x90);
                return true;
            }
            return false;
        }



        public static bool handleBreakArt(string breakArtName)
        {
            // breakArtName is "Mistral Edge Break Art"
            if (BreakArtsFlattenedDictionary.TryGetValue(breakArtName, out var info))
            {
                Memory.WriteByte(info.Address, info.Value);
                return true;
            }

            return false;
        }

        public static Dictionary<int, uint> InventoryItemSlotReference = new Dictionary<int, uint>()
        {
            [0] = Addresses.InventoryItemSlot1,
            [1] = Addresses.InventoryItemSlot2,
            [2] = Addresses.InventoryItemSlot3,
            [3] = Addresses.InventoryItemSlot4,
            [4] = Addresses.InventoryItemSlot5,
            [5] = Addresses.InventoryItemSlot6,
            [6] = Addresses.InventoryItemSlot7,
            [7] = Addresses.InventoryItemSlot8,
            [8] = Addresses.InventoryItemSlot9,
            [9] = Addresses.InventoryItemSlot10,
            [10] = Addresses.InventoryItemSlot11,
            [11] = Addresses.InventoryItemSlot12,
            [12] = Addresses.InventoryItemSlot13,
            [13] = Addresses.InventoryItemSlot14,
            [14] = Addresses.InventoryItemSlot15,
            [15] = Addresses.InventoryItemSlot16,
            [16] = Addresses.InventoryItemSlot17,
            [17] = Addresses.InventoryItemSlot18,
            [18] = Addresses.InventoryItemSlot19,
            [19] = Addresses.InventoryItemSlot20,
            [20] = Addresses.InventoryItemSlot21,
            [21] = Addresses.InventoryItemSlot22,
            [22] = Addresses.InventoryItemSlot23,
            [23] = Addresses.InventoryItemSlot24,
            [24] = Addresses.InventoryItemSlot25,
            [25] = Addresses.InventoryItemSlot26,
            [26] = Addresses.InventoryItemSlot27,
            [27] = Addresses.InventoryItemSlot28,
            [28] = Addresses.InventoryItemSlot29,
            [29] = Addresses.InventoryItemSlot30,
            [30] = Addresses.InventoryItemSlot31,
            [31] = Addresses.InventoryItemSlot32,
            [32] = Addresses.InventoryItemSlot33,
            [33] = Addresses.InventoryItemSlot34,
            [34] = Addresses.InventoryItemSlot35,
            [35] = Addresses.InventoryItemSlot36,
            [36] = Addresses.InventoryItemSlot37,
            [37] = Addresses.InventoryItemSlot38,
            [38] = Addresses.InventoryItemSlot39,
            [39] = Addresses.InventoryItemSlot40,
            [40] = Addresses.InventoryItemSlot41,
            [41] = Addresses.InventoryItemSlot42,
            [42] = Addresses.InventoryItemSlot43,
            [43] = Addresses.InventoryItemSlot44,
            [44] = Addresses.InventoryItemSlot45,
            [45] = Addresses.InventoryItemSlot46,
            [46] = Addresses.InventoryItemSlot47,
            [47] = Addresses.InventoryItemSlot48,
            [48] = Addresses.InventoryItemSlot49,
            [49] = Addresses.InventoryItemSlot50,
            [50] = Addresses.InventoryItemSlot51,
            [51] = Addresses.InventoryItemSlot52,
            [52] = Addresses.InventoryItemSlot53,
            [53] = Addresses.InventoryItemSlot54,
            [54] = Addresses.InventoryItemSlot55,
            [55] = Addresses.InventoryItemSlot56,
            [56] = Addresses.InventoryItemSlot57,
            [57] = Addresses.InventoryItemSlot58,
            [58] = Addresses.InventoryItemSlot59,
            [59] = Addresses.InventoryItemSlot60,
            [60] = Addresses.InventoryItemSlot61,
            [61] = Addresses.InventoryItemSlot62,
            [62] = Addresses.InventoryItemSlot63,
            [63] = Addresses.InventoryItemSlot64,
        };

        public static Dictionary<int, uint> InventoryGemSlotReference = new Dictionary<int, uint>()
        {
            [0] = Addresses.InventoryGemSlot01,
            [1] = Addresses.InventoryGemSlot02,
            [2] = Addresses.InventoryGemSlot03,
            [3] = Addresses.InventoryGemSlot04,
            [4] = Addresses.InventoryGemSlot05,
            [5] = Addresses.InventoryGemSlot06,
            [6] = Addresses.InventoryGemSlot07,
            [7] = Addresses.InventoryGemSlot08,
            [8] = Addresses.InventoryGemSlot09,
            [9] = Addresses.InventoryGemSlot10,
            [10] = Addresses.InventoryGemSlot11,
            [11] = Addresses.InventoryGemSlot12,
            [12] = Addresses.InventoryGemSlot13,
            [13] = Addresses.InventoryGemSlot14,
            [14] = Addresses.InventoryGemSlot15,
            [15] = Addresses.InventoryGemSlot16,
            [16] = Addresses.InventoryGemSlot17,
            [17] = Addresses.InventoryGemSlot18,
            [18] = Addresses.InventoryGemSlot19,
            [19] = Addresses.InventoryGemSlot20,
            [20] = Addresses.InventoryGemSlot21,
            [21] = Addresses.InventoryGemSlot22,
            [22] = Addresses.InventoryGemSlot23,
            [23] = Addresses.InventoryGemSlot24,
            [24] = Addresses.InventoryGemSlot25,
            [25] = Addresses.InventoryGemSlot26,
            [26] = Addresses.InventoryGemSlot27,
            [27] = Addresses.InventoryGemSlot28,
            [28] = Addresses.InventoryGemSlot29,
            [29] = Addresses.InventoryGemSlot30,
            [30] = Addresses.InventoryGemSlot31,
            [31] = Addresses.InventoryGemSlot32,
            [32] = Addresses.InventoryGemSlot33,
            [33] = Addresses.InventoryGemSlot34,
            [34] = Addresses.InventoryGemSlot35,
            [35] = Addresses.InventoryGemSlot36,
            [36] = Addresses.InventoryGemSlot37,
            [37] = Addresses.InventoryGemSlot38,
            [38] = Addresses.InventoryGemSlot39,
            [39] = Addresses.InventoryGemSlot40,
            [40] = Addresses.InventoryGemSlot41,
            [41] = Addresses.InventoryGemSlot42,
            [42] = Addresses.InventoryGemSlot43,
            [43] = Addresses.InventoryGemSlot44,
            [44] = Addresses.InventoryGemSlot45,
            [45] = Addresses.InventoryGemSlot46,
            [46] = Addresses.InventoryGemSlot47,
            [47] = Addresses.InventoryGemSlot48
        };

        public static Dictionary<int, uint> InventoryArmorSlotReference = new Dictionary<int, uint>()
        {
            [0] = Addresses.InventoryArmorSlot01,
            [1] = Addresses.InventoryArmorSlot02,
            [2] = Addresses.InventoryArmorSlot03,
            [3] = Addresses.InventoryArmorSlot04,
            [4] = Addresses.InventoryArmorSlot05,
            [5] = Addresses.InventoryArmorSlot06,
            [6] = Addresses.InventoryArmorSlot07,
            [7] = Addresses.InventoryArmorSlot08,
            [8] = Addresses.InventoryArmorSlot09,
            [9] = Addresses.InventoryArmorSlot10,
            [10] = Addresses.InventoryArmorSlot11,
            [11] = Addresses.InventoryArmorSlot12,
            [12] = Addresses.InventoryArmorSlot13,
            [13] = Addresses.InventoryArmorSlot14,
            [14] = Addresses.InventoryArmorSlot15,
            [15] = Addresses.InventoryArmorSlot16,
        };

        public static Dictionary<int, uint> InventoryShieldSlotReference = new Dictionary<int, uint>()
        {
            [0] = Addresses.InventoryShieldSlot01,
            [1] = Addresses.InventoryShieldSlot02,
            [2] = Addresses.InventoryShieldSlot03,
            [3] = Addresses.InventoryShieldSlot04,
            [4] = Addresses.InventoryShieldSlot05,
            [5] = Addresses.InventoryShieldSlot06,
            [6] = Addresses.InventoryShieldSlot07,
            [7] = Addresses.InventoryShieldSlot08
        };

        public static Dictionary<int, uint> InventoryBladeSlotReference = new Dictionary<int, uint>()
        {
            [0] = Addresses.InventoryBladeSlot01,
            [1] = Addresses.InventoryBladeSlot02,
            [2] = Addresses.InventoryBladeSlot03,
            [3] = Addresses.InventoryBladeSlot04,
            [4] = Addresses.InventoryBladeSlot05,
            [5] = Addresses.InventoryBladeSlot06,
            [6] = Addresses.InventoryBladeSlot07,
            [7] = Addresses.InventoryBladeSlot08,
            [8] = Addresses.InventoryBladeSlot09,
            [9] = Addresses.InventoryBladeSlot10,
            [10] = Addresses.InventoryBladeSlot11,
            [11] = Addresses.InventoryBladeSlot12,
            [12] = Addresses.InventoryBladeSlot13,
            [13] = Addresses.InventoryBladeSlot14,
            [14] = Addresses.InventoryBladeSlot15,
            [15] = Addresses.InventoryBladeSlot16,
        };

        public static Dictionary<int, uint> InventoryGripSlotReference = new Dictionary<int, uint>()
        {
            [0] = Addresses.InventoryGripSlot01,
            [1] = Addresses.InventoryGripSlot02,
            [2] = Addresses.InventoryGripSlot03,
            [3] = Addresses.InventoryGripSlot04,
            [4] = Addresses.InventoryGripSlot05,
            [5] = Addresses.InventoryGripSlot06,
            [6] = Addresses.InventoryGripSlot07,
            [7] = Addresses.InventoryGripSlot08,
            [8] = Addresses.InventoryGripSlot09,
            [9] = Addresses.InventoryGripSlot10,
            [10] = Addresses.InventoryGripSlot11,
            [11] = Addresses.InventoryGripSlot12,
            [12] = Addresses.InventoryGripSlot13,
            [13] = Addresses.InventoryGripSlot14,
            [14] = Addresses.InventoryGripSlot15,
            [15] = Addresses.InventoryGripSlot16,
        };

        public static readonly Dictionary<int, uint> ChainAbilityThresholds = new Dictionary<int, uint>
        {
            [1] = Addresses.ChainAbilityThreshold1,
            [2] = Addresses.ChainAbilityThreshold2,
            [3] = Addresses.ChainAbilityThreshold3,
            [4] = Addresses.ChainAbilityThreshold4,
            [5] = Addresses.ChainAbilityThreshold5,
            [6] = Addresses.ChainAbilityThreshold6,
            [7] = Addresses.ChainAbilityThreshold7,
            [8] = Addresses.ChainAbilityThreshold8,
            [9] = Addresses.ChainAbilityThreshold9,
            [10] = Addresses.ChainAbilityThreshold10,
            [11] = Addresses.ChainAbilityThreshold11,
            [12] = Addresses.ChainAbilityThreshold12,
            [13] = Addresses.ChainAbilityThreshold13,
            [14] = Addresses.ChainAbilityThreshold14,
            [15] = Addresses.ChainAbilityThreshold15,
            [16] = Addresses.ChainAbilityThreshold16,
            [17] = Addresses.ChainAbilityThreshold17,
            [18] = Addresses.ChainAbilityThreshold18,
            [19] = Addresses.ChainAbilityThreshold19,
            [20] = Addresses.ChainAbilityThreshold20,
            [21] = Addresses.ChainAbilityThreshold21,
            [22] = Addresses.ChainAbilityThreshold22,
        };

        public static Dictionary<string, uint> ChainAbilityUnlockReference = new Dictionary<string, uint>()
        {
            ["Crimson Pain Chain Ability"] = Addresses.AbilityCrimsonPainUnlock,
            ["Dulling Impact Chain Ability"] = Addresses.AbilityDullingImpactUnlock,
            ["Gain Life Chain Ability"] = Addresses.AbilityGainLifeUnlock,
            ["Gain Magic Chain Ability"] = Addresses.AbilityGainMagicUnlock,
            ["Heavy Shot Chain Ability"] = Addresses.AbilityHeavyShotUnlock,
            ["Instill Chain Ability"] = Addresses.AbilityInstillUnlock,
            ["Mind Ache Chain Ability"] = Addresses.AbilityMindAcheUnlock,
            ["Mind Assault Chain Ability"] = Addresses.AbilityMindAssaultUnlock,
            ["Numbing Claw Chain Ability"] = Addresses.AbilityNumbingClawUnlock,
            ["Paralysis Pulse Chain Ability"] = Addresses.AbilityParalysisPulseUnlock,
            ["Phantom Pain Chain Ability"] = Addresses.AbilityPhantomPainUnlock,
            ["Raging Ache Chain Ability"] = Addresses.AbilityRagingAcheUnlock,
            ["Snake Venom Chain Ability"] = Addresses.AbilitySnakeVenomUnlock,
            ["Temper Chain Ability"] = Addresses.AbilityTemperUnlock,
        };

        public static Dictionary<string, uint> DefenceAbilityUnlockReference = new Dictionary<string, uint>()
        {
            ["Absorb Damage Defence Ability"] = Addresses.AbilityAbsorbDamageUnlock,
            ["Absorb Magic Defence Ability"] = Addresses.AbilityAbsorbMagicUnlock,
            ["Aqua Ward Defence Ability"] = Addresses.AbilityAquaWardUnlock,
            ["Demonscale Defence Ability"] = Addresses.AbilityDemonscaleUnlock,
            ["Fireproof Defence Ability"] = Addresses.AbilityFireProofUnlock,
            ["Impact Guard Defence Ability"] = Addresses.AbilityImpactGuardUnlock,
            ["Phantom Shield Defence Ability"] = Addresses.AbilityPhantomShieldUnlock,
            ["Reflect Damage Defence Ability"] = Addresses.AbilityReflectDamageUnlock,
            ["Reflect Magic Defence Ability"] = Addresses.AbilityReflectMagicUnlock,
            ["Shadow Guard Defence Ability"] = Addresses.AbilityShadowGuardUnlock,
            ["Siphon Soul Defence Ability"] = Addresses.AbilitySiphonSoulUnlock,
            ["Terra Ward Defence Ability"] = Addresses.AbilityTerraWardUnlock,
            ["Ward Defence Ability"] = Addresses.AbilityWardUnlock,
            ["Windbreak Defence Ability"] = Addresses.AbilityWindBreakUnlock,
        };

        public class GrimoireData
        {
            public required List<uint> Address { get; set; }
            public required byte Value { get; set; }
        }

        public static Dictionary<string, GrimoireData> GrimoireReference = new Dictionary<string, GrimoireData>()
        {
            ["Grimoire Debile"] = new GrimoireData { Address = [Addresses.GrimoireDegenerateUnlock], Value = 0x90 },
            ["Grimoire Nuageux"] = new GrimoireData { Address = [Addresses.GrimoirePsychodrainUnlock], Value = 0x90 },
            ["Grimoire Tardif"] = new GrimoireData { Address = [Addresses.GrimoireLeadbonesUnlock], Value = 0x90 },
            ["Grimoire Deteriorer"] = new GrimoireData { Address = [Addresses.GrimoireTarnishUnlock], Value = 0x90 },
            ["Grimoire Analyse"] = new GrimoireData { Address = [Addresses.GrimoireAnalyzeUnlock], Value = 0x90 },
            ["Grimoire Intensite"] = new GrimoireData { Address = [Addresses.GrimoireHeraklesUnlock], Value = 0x90 },
            ["Grimoire Terre"] = new GrimoireData { Address = [Addresses.GrimoireVulcanLanceUnlock], Value = 0x90 },
            ["Grimoire Eclairer"] = new GrimoireData { Address = [Addresses.GrimoireEnlightenUnlock], Value = 0x90 },
            ["Grimoire Agilite"] = new GrimoireData { Address = [Addresses.GrimoireInvigorateUnlock], Value = 0x90 },
            ["Grimoire Ameliorer"] = new GrimoireData { Address = [Addresses.GrimoireProstasiaUnlock], Value = 0x90 },
            ["Grimoire Sylphe"] = new GrimoireData { Address = [Addresses.GrimoireLuftFusionUnlock], Value = 0x90 },
            ["Grimoire Salamandre"] = new GrimoireData { Address = [Addresses.GrimoireSparkFusionUnlock], Value = 0x90 },
            ["Grimoire Gnome"] = new GrimoireData { Address = [Addresses.GrimoireSoilFusionUnlock], Value = 0x90 },
            ["Grimoire Undine"] = new GrimoireData { Address = [Addresses.GrimoireFrostFusionUnlock], Value = 0x90 },
            ["Grimoire Parebrise"] = new GrimoireData { Address = [Addresses.GrimoireAeroGuardUnlock], Value = 0x90 },
            ["Grimoire Ignifuge"] = new GrimoireData { Address = [Addresses.GrimoirePyroGuardUnlock], Value = 0x90 },
            ["Grimoire Rempart"] = new GrimoireData { Address = [Addresses.GrimoireTerraGuardUnlock], Value = 0x90 },
            ["Grimoire Barrer"] = new GrimoireData { Address = [Addresses.GrimoireAquaGuardUnlock], Value = 0x90 },
            ["Grimoire Muet"] = new GrimoireData { Address = [Addresses.GrimoireSilenceUnlock], Value = 0x90 },
            ["Grimoire Annuler"] = new GrimoireData { Address = [Addresses.GrimoireMagicWardUnlock], Value = 0x90 },
            ["Grimoire Vie"] = new GrimoireData { Address = [Addresses.GrimoireSurgingBalmUnlock], Value = 0x90 },
            ["Grimoire Halte"] = new GrimoireData { Address = [Addresses.GrimoireFixateUnlock], Value = 0xB0 },
            ["Grimoire Dissiper"] = new GrimoireData { Address = [Addresses.GrimoireDispelUnlock], Value = 0x90 },
            ["Grimoire Paralysie"] = new GrimoireData { Address = [Addresses.GrimoireStunCloudUnlock], Value = 0x90 },
            ["Grimoire Venin"] = new GrimoireData { Address = [Addresses.GrimoirePoisonMistUnlock], Value = 0x90 },
            ["Grimoire Fleau"] = new GrimoireData { Address = [Addresses.GrimoireCurseUnlock], Value = 0x90 },
            ["Grimoire Mollesse"] = new GrimoireData { Address = [Addresses.GrimoireRestorationUnlock], Value = 0x90 },
            ["Grimoire Antidote"] = new GrimoireData { Address = [Addresses.GrimoireAntidoteUnlock], Value = 0x90 },
            ["Grimoire Benir"] = new GrimoireData { Address = [Addresses.GrimoireBlessingUnlock], Value = 0x90 },
            ["Grimoire Purifier"] = new GrimoireData { Address = [Addresses.GrimoireClearanceUnlock], Value = 0x90 },
            ["Grimoire Clef"] = new GrimoireData { Address = [Addresses.GrimoireUnlockUnlock], Value = 0x90 },
            ["Grimoire Visible"] = new GrimoireData { Address = [Addresses.GrimoireEurekaUnlock], Value = 0xB0 },
            ["Grimoire Egout"] = new GrimoireData { Address = [Addresses.GrimoireDrainHeartUnlock], Value = 0x90 },
            ["Grimoire Demance"] = new GrimoireData { Address = [Addresses.GrimoireDrainMindUnlock], Value = 0x90 },
            ["Grimoire Guerir"] = new GrimoireData { Address = [Addresses.GrimoireHealUnlock], Value = 0x90 },
            ["Grimoire Teslae"] = new GrimoireData { Address = [Addresses.GrimoireLightningBoltUnlock], Value = 0xC0 },
            ["Grimoire Lux"] = new GrimoireData { Address = [Addresses.GrimoireSpiritSurgeUnlock], Value = 0xC0 },
            ["Grimoire Exsorcer"] = new GrimoireData { Address = [Addresses.GrimoireExorcismUnlock], Value = 0x90 },

            ["Grimoire Demolir"] = new GrimoireData
            {
                Address = new List<uint> {
                    Addresses.GrimoireExplosionL1,
                    Addresses.GrimoireExplosionL2,
                    Addresses.GrimoireExplosionL3,
                    Addresses.GrimoireExplosionMaxLevel
            },
                Value = 0x80
            },
            ["Grimoire Foudre"] = new GrimoireData
            {
                Address = new List<uint> {
                    Addresses.GrimoireThunderburstL1,
                    Addresses.GrimoireThunderburstL2,
                    Addresses.GrimoireThunderburstL3,
                    Addresses.GrimoireThunderburstMaxLevel
            },
                Value = 0x80
            },
            ["Grimoire Flamme"] = new GrimoireData
            {
                Address = new List<uint> {
                    Addresses.GrimoireFlameSphereL1,
                    Addresses.GrimoireFlameSphereL2,
                    Addresses.GrimoireFlameSphereL3,
                    Addresses.GrimoireFlameSphereMaxLevel
            },
                Value = 0x80
            },
            ["Grimoire Gaea"] = new GrimoireData
            {
                Address = new List<uint> {
                    Addresses.GrimoireGaeaStrikeL1,
                    Addresses.GrimoireGaeaStrikeL2,
                    Addresses.GrimoireGaeaStrikeL3,
                    Addresses.GrimoireGaeaStrikeMaxLevel
            },
                Value = 0x80
            },
            ["Grimoire Avalanche"] = new GrimoireData
            {
                Address = new List<uint> {
                    Addresses.GrimoireAvalancheL1,
                    Addresses.GrimoireAvalancheL2,
                    Addresses.GrimoireAvalancheL3,
                    Addresses.GrimoireAvalancheMaxLevel
            },
                Value = 0x80
            },
            ["Grimoire Radius"] = new GrimoireData
            {
                Address = new List<uint> {
                    Addresses.GrimoireRadialSurgeL1,
                    Addresses.GrimoireRadialSurgeL2,
                    Addresses.GrimoireRadialSurgeL3,
                    Addresses.GrimoireRadialSurgeMaxLevel
            },
                Value = 0x80
            },
            ["Grimoire Meteore"] = new GrimoireData
            {
                Address = new List<uint> {
                    Addresses.GrimoireMeteorL1,
                    Addresses.GrimoireMeteorL2,
                    Addresses.GrimoireMeteorL3,
                    Addresses.GrimoireMeteorMaxLevel
            },
                Value = 0x80
            },
        };

        public struct BreakArtInfo
        {
            public uint Address;
            public uint ThresholdAddress;
            public ushort KillsRequired;
            public byte Value;
        }

        public static Dictionary<string, Dictionary<string, BreakArtInfo>> BreakArtUnlockReference = new Dictionary<string, Dictionary<string, BreakArtInfo>>()
        {
            ["Sword"] = new Dictionary<string, BreakArtInfo>
            {
                ["Rending Gale Break Art"] = new BreakArtInfo { Address = Addresses.BreakRendingGaleUnlock, ThresholdAddress = Addresses.BreakArtThresholdSword1, KillsRequired = 0x0019, Value = 0xC0 },
                ["Vile Scar Break Art"] = new BreakArtInfo { Address = Addresses.BreakVileScarUnlock, ThresholdAddress = Addresses.BreakArtThresholdSword2, KillsRequired = 0x006E, Value = 0xC0 },
                ["Cherry Ronde Break Art"] = new BreakArtInfo { Address = Addresses.BreakCherryRondeUnlock, ThresholdAddress = Addresses.BreakArtThresholdSword3, KillsRequired = 0x0104, Value = 0x80 },
                ["Papillon Reel Break Art"] = new BreakArtInfo { Address = Addresses.BreakPapillonReelUnlock, ThresholdAddress = Addresses.BreakArtThresholdSword4, KillsRequired = 0x01E5, Value = 0xA0 }
            },

            ["Great Sword"] = new Dictionary<string, BreakArtInfo>
            {
                ["Sunder Break Art"] = new BreakArtInfo { Address = Addresses.BreakSunderUnlock, ThresholdAddress = Addresses.BreakArtThresholdGreatSword1, KillsRequired = 0x0012, Value = 0xC0 },
                ["Thunderwave Break Art"] = new BreakArtInfo { Address = Addresses.BreakThunderwaveUnlock, ThresholdAddress = Addresses.BreakArtThresholdGreatSword2, KillsRequired = 0x0050, Value = 0xC0 },
                ["Swallow Slash Break Art"] = new BreakArtInfo { Address = Addresses.BreakSwallowSlashUnlock, ThresholdAddress = Addresses.BreakArtThresholdGreatSword3, KillsRequired = 0x00D2, Value = 0x80 },
                ["Advent Sign Break Art"] = new BreakArtInfo { Address = Addresses.BreakAdventSignUnlock, ThresholdAddress = Addresses.BreakArtThresholdGreatSword4, KillsRequired = 0x01A4, Value = 0xA0 }
            },

            ["Staff"] = new Dictionary<string, BreakArtInfo>
            {
                ["Sirocco Break Art"] = new BreakArtInfo { Address = Addresses.BreakSiroccoUnlock, ThresholdAddress = Addresses.BreakArtThresholdStaff1, KillsRequired = 0x0014, Value = 0xC0 },
                ["Riskbreak Break Art"] = new BreakArtInfo { Address = Addresses.BreakRiskbreakUnlock, ThresholdAddress = Addresses.BreakArtThresholdStaff2, KillsRequired = 0x005F, Value = 0xC0 },
                ["Gravis Aether Break Art"] = new BreakArtInfo { Address = Addresses.BreakGravisAetherUnlock, ThresholdAddress = Addresses.BreakArtThresholdStaff3, KillsRequired = 0x00CD, Value = 0xC0 },
                ["Trinity Pulse Break Art"] = new BreakArtInfo { Address = Addresses.BreakTrinityPulseUnlock, ThresholdAddress = Addresses.BreakArtThresholdStaff4, KillsRequired = 0x0181, Value = 0xE0 }
            },

            ["Polearm"] = new Dictionary<string, BreakArtInfo>
            {
                ["Ruination Break Art"] = new BreakArtInfo { Address = Addresses.BreakRuinationPolearmUnlock, ThresholdAddress = Addresses.BreakArtThresholdPolearm1, KillsRequired = 0x0014, Value = 0xC0 },
                ["Scythe Wind Break Art"] = new BreakArtInfo { Address = Addresses.BreakScytheWindUnlock, ThresholdAddress = Addresses.BreakArtThresholdPolearm2, KillsRequired = 0x005F, Value = 0xC0 },
                ["Giga Tempest Break Art"] = new BreakArtInfo { Address = Addresses.BreakGigaTempestUnlock, ThresholdAddress = Addresses.BreakArtThresholdPolearm3, KillsRequired = 0x00E6, Value = 0xC0 },
                ["Spiral Scourge Break Art"] = new BreakArtInfo { Address = Addresses.BreakSpiralScourgeUnlock, ThresholdAddress = Addresses.BreakArtThresholdPolearm4, KillsRequired = 0x01AE, Value = 0xE0 }
            },

            ["Axe & Mace"] = new Dictionary<string, BreakArtInfo>
            {
                ["Mistral Edge Break Art"] = new BreakArtInfo { Address = Addresses.BreakMistralEdgeUnlock, ThresholdAddress = Addresses.BreakArtThresholdAxeMace1, KillsRequired = 0x0014, Value = 0xC0 },
                ["Glacial Gale Break Art"] = new BreakArtInfo { Address = Addresses.BreakGlacialGaleUnlock, ThresholdAddress = Addresses.BreakArtThresholdAxeMace2, KillsRequired = 0x0064, Value = 0xC0 },
                ["Killer Mantis Break Art"] = new BreakArtInfo { Address = Addresses.BreakKillerMantisUnlock, ThresholdAddress = Addresses.BreakArtThresholdAxeMace3, KillsRequired = 0x00F5, Value = 0x80 },
                ["Black Nebula Break Art"] = new BreakArtInfo { Address = Addresses.BreakBlackNebulaUnlock, ThresholdAddress = Addresses.BreakArtThresholdAxeMace4, KillsRequired = 0x01D1, Value = 0xA0 }
            },

            ["Bare Hands"] = new Dictionary<string, BreakArtInfo>
            {
                ["Lotus Palm Break Art"] = new BreakArtInfo { Address = Addresses.BreakLotusPalmUnlock, ThresholdAddress = Addresses.BreakArtThresholdUnarmed1, KillsRequired = 0x000A, Value = 0xC0 },
                ["Vertigo Break Art"] = new BreakArtInfo { Address = Addresses.BreakVertigoUnlock, ThresholdAddress = Addresses.BreakArtThresholdUnarmed2, KillsRequired = 0x0041, Value = 0xC0 },
                ["Vermillion Aura Break Art"] = new BreakArtInfo { Address = Addresses.BreakVermillionAuraUnlock, ThresholdAddress = Addresses.BreakArtThresholdUnarmed3, KillsRequired = 0x00AF, Value = 0x80 },
                ["Retribution Break Art"] = new BreakArtInfo { Address = Addresses.BreakRetributionUnlock, ThresholdAddress = Addresses.BreakArtThresholdUnarmed4, KillsRequired = 0x0154, Value = 0xA0 }
            },

            ["Crossbow"] = new Dictionary<string, BreakArtInfo>
            {
                ["Brimstone Hail Break Art"] = new BreakArtInfo { Address = Addresses.BreakBrimstoneHailUnlock, ThresholdAddress = Addresses.BreakArtThresholdCrossbow1, KillsRequired = 0x001E, Value = 0xC0 },
                ["Heaven's Scorn Break Art"] = new BreakArtInfo { Address = Addresses.BreakHeavensScornUnlock, ThresholdAddress = Addresses.BreakArtThresholdCrossbow2, KillsRequired = 0x0069, Value = 0xC0 },
                ["Death Wail Break Art"] = new BreakArtInfo { Address = Addresses.BreakDeathWailUnlock, ThresholdAddress = Addresses.BreakArtThresholdCrossbow3, KillsRequired = 0x00FA, Value = 0x80 },
                ["Sanctus Flare Break Art"] = new BreakArtInfo { Address = Addresses.BreakSanctusFlareUnlock, ThresholdAddress = Addresses.BreakArtThresholdCrossbow4, KillsRequired = 0x01CC, Value = 0xA0 }
            },

            ["Great Axe"] = new Dictionary<string, BreakArtInfo>
            {
                ["Bear Claw Break Art"] = new BreakArtInfo { Address = Addresses.BreakBearClawUnlock, ThresholdAddress = Addresses.BreakArtThresholdGreatAxe1, KillsRequired = 0x000F, Value = 0xC0 },
                ["Accursed Umbra Break Art"] = new BreakArtInfo { Address = Addresses.BreakAccursedUmbraUnlock, ThresholdAddress = Addresses.BreakArtThresholdGreatAxe2, KillsRequired = 0x005A, Value = 0xC0 },
                ["Iron Ripper Break Art"] = new BreakArtInfo { Address = Addresses.BreakIronRipperUnlock, ThresholdAddress = Addresses.BreakArtThresholdGreatAxe3, KillsRequired = 0x00D7, Value = 0x80 },
                ["Emetic Bomb Break Art"] = new BreakArtInfo { Address = Addresses.BreakEmeticBombUnlock, ThresholdAddress = Addresses.BreakArtThresholdGreatAxe4, KillsRequired = 0x019A, Value = 0xA0 }
            },

            ["Heavy Mace"] = new Dictionary<string, BreakArtInfo>
            {
                ["Bonecrusher Break Art"] = new BreakArtInfo { Address = Addresses.BreakBonecrusherUnlock, ThresholdAddress = Addresses.BreakArtThresholdHeavyMace1, KillsRequired = 0x0023, Value = 0xC0 },
                ["Quickshock Break Art"] = new BreakArtInfo { Address = Addresses.BreakQuickshockUnlock, ThresholdAddress = Addresses.BreakArtThresholdHeavyMace2, KillsRequired = 0x005F, Value = 0xC0 },
                ["Ignis Wheel Break Art"] = new BreakArtInfo { Address = Addresses.BreakIgnisWheelUnlock, ThresholdAddress = Addresses.BreakArtThresholdHeavyMace3, KillsRequired = 0x00DC, Value = 0x80 },
                ["Hex Flux Break Art"] = new BreakArtInfo { Address = Addresses.BreakHexFluxUnlock, ThresholdAddress = Addresses.BreakArtThresholdHeavyMace4, KillsRequired = 0x0195, Value = 0xA0 }
            },

            ["Dagger"] = new Dictionary<string, BreakArtInfo>
            {
                ["Whistle Sting Break Art"] = new BreakArtInfo { Address = Addresses.BreakWhistleStingUnlock, ThresholdAddress = Addresses.BreakArtThresholdDagger1, KillsRequired = 0x0014, Value = 0xC0 },
                ["Shadowweave Break Art"] = new BreakArtInfo { Address = Addresses.BreakShadoweaveUnlock, ThresholdAddress = Addresses.BreakArtThresholdDagger2, KillsRequired = 0x005A, Value = 0xC0 },
                ["Double Fang Break Art"] = new BreakArtInfo { Address = Addresses.BreakDoubleFangUnlock, ThresholdAddress = Addresses.BreakArtThresholdDagger3, KillsRequired = 0x00EB, Value = 0x80 },
                ["Wyrm Scorn Break Art"] = new BreakArtInfo { Address = Addresses.BreakWyrmScornUnlock, ThresholdAddress = Addresses.BreakArtThresholdDagger4, KillsRequired = 0x01A9, Value = 0xA0 }
            },
        };

        public static readonly Dictionary<string, BreakArtInfo> BreakArtsFlattenedDictionary =
            BreakArtUnlockReference.SelectMany(category => category.Value)
                                   .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);


        public static Dictionary<byte, string> CraftingGripReference = new Dictionary<byte, string>()
        {
            { 0x60, "Short Hilt" },
            { 0x61, "Swept Hilt" },
            { 0x62, "Cross Guard" },
            { 0x63, "Knuckle Guard" },
            { 0x64, "Counter Guard" },
            { 0x65, "Side Ring" },
            { 0x66, "Power Palm" },
            { 0x67, "Murderer's Hilt" },
            { 0x68, "Spiral Hilt" },
            { 0x69, "Wooden Grip" },
            { 0x6A, "Sand Face" },
            { 0x6B, "Czekan Type" },
            { 0x6C, "Sarissa Grip" },
            { 0x6D, "Gendarme" },
            { 0x6E, "Heavy Grip" },
            { 0x6F, "Runkasyle" },
            { 0x70, "Bhuj Type" },
            { 0x71, "Grimoire Grip" },
            { 0x72, "Elephant" },
            { 0x73, "Wooden Pole" },
            { 0x74, "Spiculum Pole" },
            { 0x75, "Winged Pole" },
            { 0x76, "Framea Pole" },
            { 0x77, "Ahlspies" },
            { 0x78, "Spiral Pole" },
            { 0x79, "Simple Bolt" },
            { 0x7A, "Steel Bolt" },
            { 0x7B, "Javelin Bolt" },
            { 0x7C, "Falarica Bolt" },
            { 0x7D, "Stone Bullet" },
            { 0x7E, "Sonic Bullet" }
        };

        public static Dictionary<byte, string> CraftingBladeReference = new Dictionary<byte, string>()
        {
            { 0x01, "Battle Knife" },
            { 0x02, "Scramasax" },
            { 0x03, "Dirk" },
            { 0x04, "Throwing Knife" },
            { 0x05, "Kudi" },
            { 0x06, "Cinquedea" },
            { 0x07, "Kris" },
            { 0x08, "Hatchet" },
            { 0x09, "Khukuri" },
            { 0x0A, "Baselard" },
            { 0x0B, "Stiletto" },
            { 0x0C, "Jamadhar" },
            { 0x0D, "Spatha" },
            { 0x0E, "Scimitar" },
            { 0x0F, "Rapier" },
            { 0x10, "Short Sword" },
            { 0x11, "Firangi" },
            { 0x12, "Shamshir" },
            { 0x13, "Falchion" },
            { 0x14, "Shotel" },
            { 0x15, "Khora" },
            { 0x16, "Khopesh" },
            { 0x17, "Wakizashi" },
            { 0x18, "Romphaia" },
            { 0x19, "Broad Sword" },
            { 0x1A, "Norse Sword" },
            { 0x1B, "Katana" },
            { 0x1C, "Executioner" },
            { 0x1D, "Claymore" },
            { 0x1E, "Schiavona" },
            { 0x1F, "Bastard Sword" },
            { 0x20, "Nodachi" },
            { 0x21, "Rune Blade" },
            { 0x22, "Holy Win" },
            { 0x23, "Hand Axe" },
            { 0x24, "BattleAxe" },
            { 0x25, "Francisca" },
            { 0x26, "Tabarzin" },
            { 0x27, "Chamkaq" },
            { 0x28, "Tabar" },
            { 0x29, "Bullova" },
            { 0x2A, "Crescent" },
            { 0x2B, "Goblin Club" },
            { 0x2C, "Spiked Club" },
            { 0x2D, "Ball Mace" },
            { 0x2E, "Footman's Mace" },
            { 0x2F, "Morning Star" },
            { 0x30, "War Hammer" },
            { 0x31, "Bec de Corbin" },
            { 0x32, "War Maul" },
            { 0x33, "Guisarme" },
            { 0x34, "Large Crescent" },
            { 0x35, "Sabre Halberd" },
            { 0x36, "Balbriggan" },
            { 0x37, "Double Blade" },
            { 0x38, "Halberd" },
            { 0x39, "Wizard Staff" },
            { 0x3A, "Clergy Rod" },
            { 0x3B, "Summoner Baton" },
            { 0x3C, "Shamanic Staff" },
            { 0x3D, "Bishop's Crosier" },
            { 0x3E, "Sage Cane" },
            { 0x3F, "Langdebeve" },
            { 0x40, "Sabre Mace" },
            { 0x41, "Footman's Mace" },
            { 0x42, "Gloomwing" },
            { 0x43, "Mjolnir" },
            { 0x44, "Griever" },
            { 0x45, "Destroyer" },
            { 0x46, "Hand of Light" },
            { 0x47, "Spear" },
            { 0x48, "Glaive" },
            { 0x49, "Scorpion" },
            { 0x4A, "Corcesca" },
            { 0x4B, "Trident" },
            { 0x4C, "Awl Pike" },
            { 0x4D, "Boar Spear" },
            { 0x4E, "Fauchard" },
            { 0x4F, "Voulge" },
            { 0x50, "Pole Axe" },
            { 0x51, "Bardysh" },
            { 0x52, "Brandestoc" },
            { 0x53, "Gastraph Bow" },
            { 0x54, "Light Crossbow" },
            { 0x55, "Target Bow" },
            { 0x56, "Windlass" },
            { 0x57, "Cranequin" },
            { 0x58, "Lug Crossbow" },
            { 0x59, "Siege Bow" },
            { 0x5A, "Arbalest" }
        };

        public static Dictionary<byte, string> ShieldReference = new Dictionary<byte, string>
        {
            { 0x7f, "Buckler" },
            { 0x80, "Pelta Shield" },
            { 0x81, "Targe" },
            { 0x82, "Quad Shield" },
            { 0x83, "Circle Shield" },
            { 0x84, "Tower Shield" },
            { 0x85, "Spiked Shield" },
            { 0x86, "Round Shield" },
            { 0x87, "Kite Shield" },
            { 0x88, "Casserole Shield" },
            { 0x89, "Heater Shield" },
            { 0x8a, "Oval Shield" },
            { 0x8b, "Knight Shield" },
            { 0x8c, "Hoplite Shield" },
            { 0x8d, "Jazeraint Shield" },
            { 0x8e, "Dread Shield" }
        };

        public static Dictionary<byte, string> ArmorReference = new Dictionary<byte, string>
        {
            { 0x11, "Bandana" },
            { 0x12, "Bear Mask" },
            { 0x13, "Wizard Hat" },
            { 0x14, "Bone Helm" },
            { 0x15, "Chain Coif" },
            { 0x16, "Spangenhelm" },
            { 0x17, "Cabasset" },
            { 0x18, "Sallet" },
            { 0x19, "Barbut" },
            { 0x1A, "Basinet" },
            { 0x1B, "Armet" },
            { 0x1C, "Close Helm" },
            { 0x1D, "Burgonet" },
            { 0x1E, "Hoplite Helm" },
            { 0x1F, "Jazeraint Helm" },
            { 0x20, "Dread Helm" },
            { 0x21, "Jerkin" },
            { 0x22, "Hauberk" },
            { 0x23, "Wizard Robe" },
            { 0x24, "Cuirass" },
            { 0x25, "Banded Mail" },
            { 0x26, "Ring Mail" },
            { 0x27, "Chain Mail" },
            { 0x28, "Breastplate" },
            { 0x29, "Segmentata" },
            { 0x2A, "Scale Armour" },
            { 0x2B, "Brigandine" },
            { 0x2C, "Plate Mail" },
            { 0x2D, "Fluted Armour" },
            { 0x2E, "Hoplite Armour" },
            { 0x2F, "Jazeraint Armour" },
            { 0x30, "Dread Armour" },
            { 0x31, "Sandals" },
            { 0x32, "Boots" },
            { 0x33, "Long Boots" },
            { 0x34, "Cuisse" },
            { 0x35, "Light Greave" },
            { 0x36, "Ring Leggings" },
            { 0x37, "Chain Leggings" },
            { 0x38, "Fusskampf" },
            { 0x39, "Poleyn" },
            { 0x3A, "Jambeau" },
            { 0x3B, "Missaglia" },
            { 0x3C, "Plate Leggings" },
            { 0x3D, "Fluted Leggings" },
            { 0x3E, "Hoplite Leggings" },
            { 0x3F, "Jazeraint Leggings" },
            { 0x40, "Dread Leggings" },
            { 0x41, "Bandage" },
            { 0x42, "Leather Glove" },
            { 0x43, "Reinforced Glove" },
            { 0x44, "Knuckles" },
            { 0x45, "Ring Sleeve" },
            { 0x46, "Chain Sleeve" },
            { 0x47, "Gauntlet" },
            { 0x48, "Vambrace" },
            { 0x49, "Plate Glove" },
            { 0x4A, "Rondanche" },
            { 0x4B, "Tilt Glove" },
            { 0x4C, "Freiturnier" },
            { 0x4D, "Fluted Glove" },
            { 0x4E, "Hoplite Glove" },
            { 0x4F, "Jazeraint Glove" },
            { 0x50, "Dread Glove" },
            { 0x61, "Rood Necklace"},
            { 0x62, "Rune Earrings"},
            { 0x63, "Lionhead"},
            { 0x64, "Rusted Nails"},
            { 0x65, "Sylphid Ring"},
            { 0x66, "Marduk"},
            { 0x67, "Salamander Ring"},
            { 0x68, "Tamulis Tongue"},
            { 0x69, "Gnome Bracelet"},
            { 0x6A, "Palolos Ring"},
            { 0x6B, "Undine Bracelet"},
            { 0x6C, "Talian Ring"},
            { 0x6D, "Agriass Balm"},
            { 0x6E, "Kadesh Ring"},
            { 0x6F, "Agrippas Choker"},
            { 0x70, "Diadras Earring"},
            { 0x71, "Titans Ring"},
            { 0x72, "Lau Feis Armlet"},
            { 0x73, "Swan Song"},
            { 0x74, "Pushpaka"},
            { 0x75, "Edgars Earrings"},
            { 0x76, "Cross Choker"},
            { 0x77, "Ghost Hound"},
            { 0x78, "Beaded Anklet"},
            { 0x79, "Dragonhead"},
            { 0x7A, "Faufnirs Tear"},
            { 0x7B, "Agaless Chain"},
            { 0x7C, "Balam Ring"},
            { 0x7D, "Nimje Coif"},
            { 0x7E, "Morgans Nails"},
            { 0x7F, "Marlenes Ring" },
        };

        public static Dictionary<byte, string> GemReference = new Dictionary<byte, string>
        {
            { 0x00, "Bronze" },
            { 0x01, "Iron" },
            { 0x02, "Hagane" },
            { 0x03, "Silver" },
            { 0x04, "Damascus" },
            { 0x05, "Talos Feldspar" },
            { 0x06, "Titan Malachite" },
            { 0x07, "Sylphid Topaz" },
            { 0x08, "Djinn Amber" },
            { 0x09, "Salamander Ruby" },
            { 0x0a, "Ifrit Carnelian" },
            { 0x0b, "Gnome Emerald" },
            { 0x0c, "Dao Moonstone" },
            { 0x0d, "Undine Jasper" },
            { 0x0e, "Marid Aquamarine" },
            { 0x0f, "Angel Pearl" },
            { 0x10, "Seraphim Diamond" },
            { 0x11, "Morlock Jet" },
            { 0x12, "Berial Blackpearl" },
            { 0x13, "Haeralis" },
            { 0x14, "Orlandu" },
            { 0x15, "Orion" },
            { 0x16, "Ogmius" },
            { 0x17, "Iocus" },
            { 0x18, "Balvus" },
            { 0x19, "Trinity" },
            { 0x1a, "Beowulf" },
            { 0x1b, "Dragonite" },
            { 0x1c, "Sigguld" },
            { 0x1d, "Demonia" },
            { 0x1e, "Altema" },
            { 0x1f, "Polaris" },
            { 0x20, "Basivalen" },
            { 0x21, "Galerian" },
            { 0x22, "Vedivier" },
            { 0x23, "Berion" },
            { 0x24, "Gervin" },
            { 0x25, "Tertia" },
            { 0x26, "Lancer" },
            { 0x27, "Arturos" },
            { 0x28, "Braveheart" },
            { 0x29, "Hellraiser" },
            { 0x2a, "Nightkiller" },
            { 0x2b, "Manabreaker" },
            { 0x2c, "Powerfist" },
            { 0x2d, "Brainshield" },
            { 0x2e, "Speedster" },
            { 0x30, "Silent Queen" },
            { 0x31, "Dark Queen" },
            { 0x32, "Death Queen" },
            { 0x33, "White Queen" }
        };

        public static Dictionary<byte, string> MaterialReference = new Dictionary<byte, string>()
        {
            {0x00, "None" },
            {0x01, "Wood" },
            {0x02, "Leather" },
            {0x03, "Bronze" },
            {0x04, "Iron" },
            {0x05, "Hagane" },
            {0x06, "Silver" },
            {0x07, "Damascus" }
        };


        public static Dictionary<byte, string> ItemReference = new Dictionary<byte, string>() {
            { 0x43, "Cure Root" },
            { 0x44, "Cure Bulb" },
            { 0x45, "Cure Tonic" },
            { 0x46, "Cure Potion" },
            { 0x47, "Mana Root" },
            { 0x48, "Mana Bulb" },
            { 0x49, "Mana Tonic" },
            { 0x4A, "Mana Potion" },
            { 0x4B, "Vera Root" },
            { 0x4C, "Vera Bulb" },
            { 0x4D, "Vera Tonic" },
            { 0x4E, "Vera Potion" },
            { 0x4F, "Acolyte's Nostrum" },
            { 0x50, "Saint's Nostrum" },
            { 0x51, "Alchemist's Reagent" },
            { 0x52, "Sorcerer's Reagent" },
            { 0x53, "Yggdrasil's Tears" },
            { 0x54, "Faerie Chortle" },
            { 0x55, "Spirit Orison" },
            { 0x56, "Angelic Paean" },
            { 0x57, "Panacea" },
            { 0x58, "Snowfly Draught" },
            { 0x59, "Faerie Wing" },
            { 0x5A, "Elixir of Kings" },
            { 0x5B, "Elixir of Sages" },
            { 0x5C, "Elixir of Dragoons" },
            { 0x5D, "Elixir of Queens" },
            { 0x5E, "Elixir of Mages" },
            { 0x5F, "Valens" },
            { 0x60, "Prudens" },
            { 0x61, "Volare" },
            { 0x62, "Audentia" },
            { 0x63, "Virtus" },
            { 0x64, "Eye of Argon" },
            { 0x82, "Grimoire Zephyr" },
            { 0x83, "Grimoire Teslae" },
            { 0x84, "Grimoire Incendie" },
            { 0x85, "Grimoire Terre" },
            { 0x86, "Grimoire Glace" },
            { 0x87, "Grimoire Lux" },
            { 0x88, "Grimoire Patir" },
            { 0x89, "Grimoire Exsorcer" },
            { 0x8A, "Grimoire Banish" },
            { 0x8B, "Grimoire Demolir" },
            { 0x8F, "Grimoire Foudre" },
            { 0x93, "Grimoire Flamme" },
            { 0x97, "Grimoire Gaea" },
            { 0x9B, "Grimoire Avalanche" },
            { 0x9F, "Grimoire Radius" },
            { 0xA3, "Grimoire Meteore" },
            { 0xA7, "Grimoire Egout" },
            { 0xA8, "Grimoire Demance" },
            { 0xA9, "Grimoire Guerir" },
            { 0xAA, "Grimoire Mollesse" },
            { 0xAB, "Grimoire Antidote" },
            { 0xAC, "Grimoire Benir" },
            { 0xAD, "Grimoire Purifier" },
            { 0xAE, "Grimoire Vie" },
            { 0xAF, "Grimoire Intensite" },
            { 0xB0, "Grimoire Debile" },
            { 0xB1, "Grimoire Eclairer" },
            { 0xB2, "Grimoire Nuageux" },
            { 0xB3, "Grimoire Agilite" },
            { 0xB4, "Grimoire Tardif" },
            { 0xB5, "Grimoire Ameliorer" },
            { 0xB6, "Grimoire Deterior" },
            { 0xB7, "Grimoire Muet" },
            { 0xB8, "Grimoire Annuler" },
            { 0xB9, "Grimoire Paralysie" },
            { 0xBA, "Grimoire Venin" },
            { 0xBB, "Grimoire Fleau" },
            { 0xBC, "Grimoire Halte" },
            { 0xBD, "Grimoire Dissiper" },
            { 0xBE, "Grimoire Clef" },
            { 0xBF, "Grimoire Visual" },
            { 0xC0, "Grimoire Snalyse" },
            { 0xC1, "Grimoire Sylphe" },
            { 0xC2, "Grimoire Salamander" },
            { 0xC3, "Grimoire Gnome" },
            { 0xC4, "Grimoire Undine" },
            { 0xC5, "Grimoire Parebrise" },
            { 0xC6, "Grimoire Ignifuge" },
            { 0xC7, "Grimoire Rempart" },
            { 0xC8, "Grimoire Barrer" },
            { 0xCA, "Bronze Key" },
            { 0xCB, "Iron Key" },
            { 0xCC, "Silver Key" },
            { 0xCD, "Gold Key" },
            { 0xCE, "Platinum Key" },
            { 0xCF, "Steel Key" },
            { 0xD0, "Crimson Key" },
            { 0xD1, "Chest Key" },
            { 0xD2, "Chamomile Sigil" },
            { 0xD3, "Lily Sigil" },
            { 0xD4, "Tearose Sigil" },
            { 0xD5, "Clematis Sigil" },
            { 0xD6, "Hyacinth Sigil" },
            { 0xD7, "Fern Sigil" },
            { 0xD8, "Aster Sigil" },
            { 0xD9, "Eulelia Sigil" },
            { 0xDA, "Melissa Sigil" },
            { 0xDB, "Calla Sigil" },
            { 0xDC, "Laurel Sigil" },
            { 0xDD, "Acacia Sigil" },
            { 0xDE, "Palm Sigil" },
            { 0xDF, "Kalmia Sigil" },
            { 0xE0, "Colombine Sigil" },
            { 0xE1, "Anemone Sigil" },
            { 0xE2, "Verbena Sigil" },
            { 0xE3, "Schirra Sigil" },
            { 0xE4, "Marigold Sigil" },
            { 0xE5, "Azalea Sigil" },
            { 0xE6, "Tigertail Sigil" },
            { 0xE7, "Stock Sigil" },
            { 0xE8, "Cattleya Sigil" },
            { 0xE9, "Mandrake Sigil" }
        };
    }
}
