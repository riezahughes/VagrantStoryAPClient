using Archipelago.Core.Models;
using Archipelago.Core.Util;
using VagrantStoryArchipelago.Helpers.EntityLists;
using VagrantStoryArchipelago.Models.Inventory;

namespace VagrantStoryArchipelago.Helpers
{
    public class ItemHelpers
    {

        public static InventoryItemData CheckInventoryItemSlot(int slot)
        {
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
                Array.Reverse(bytes);

                if (bytes[3] == 0x00)
                {
                    break;
                }
                string itemName = ItemReference.ContainsKey(bytes[3]) ? ItemReference[bytes[3]] : "Unknown Item";
                var itemData = new InventoryItemData(itemName, bytes[0], bytes[1], bytes[2], bytes[3]);
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

                Console.WriteLine($"{slotData:X}");

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

        public static List<InventoryArmorData> GetInventoryArmorSlots()
        {
            var slots = InventoryArmorSlotReference;
            var armorList = new List<InventoryArmorData>();

            foreach (var slot in slots)
            {
                ulong slotData = Memory.ReadUInt(slot.Value);

                byte[] bytes = BitConverter.GetBytes(slotData);
                Array.Reverse(bytes);

                if (bytes[7] == 0x00)
                {
                    break;
                }


                string armorName = ArmorReference.ContainsKey(bytes[7]) ? ArmorReference[bytes[7]] : "Unknown Armor";

                //ArmorType armorType = 0;
                InventoryArmorData armorData = null;


                //switch (armorType)
                //{
                //case ArmorType.HELM:
                HelmetDatabase.Helmets.TryGetValue(armorName, out armorData);
                armorList.Add(armorData);
                Console.WriteLine(armorData.ArmorName);
                //break;
                //}
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
        public static void handleInventoryItem(ItemReceivedEventArgs args)
        {
            // Specifically only for inventory items. Does not include weapons/armour/etc

            var listOfSlots = GetInventoryItemSlots();

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
                byte itemID = ItemReference.FirstOrDefault(itm => itm.Value == args.Item.Name).Key;
                itemData = new InventoryItemData(args.Item.Name, (byte)(listOfSlots.Count + 1), 0x05, 0x01, itemID);
            }
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


        public static void handleInventoryGem(ItemReceivedEventArgs args)
        {
            // Specifically only for gems

            var listOfSlots = ItemHelpers.GetInventoryGemSlots();

            Console.WriteLine($"{listOfSlots.Count} gem slots found");

            if (listOfSlots.Count >= 48)
            {
                Console.WriteLine($"Inventory full. Delaying {args.Item.Name}");
                App.delayedItems.Add(args);
                return;
            }

            InventoryGemData matchingItem = listOfSlots.FirstOrDefault(inGameItem => inGameItem.GemName == args.Item.Name, null);


            if (matchingItem is not null && matchingItem.GemName != "Unknown Gem")
            {
                Console.WriteLine($"{matchingItem.GemName} has been found already: Ignoring Gem {matchingItem.GemInventorySlot}");
                return;
            }
            else
            {
                byte itemID = ItemHelpers.GemReference.FirstOrDefault(itm => itm.Value == args.Item.Name).Key;

                InventoryGemData gem = GemDatabase.Gems[args.Item.Name];

                gem.GemInventorySlot = (byte)(listOfSlots.Count);

                Console.WriteLine($"No Gem has been found: Adding {gem.GemName} with Agi {gem.GemAgiStat} to slot {listOfSlots.Count}");

                Memory.WriteObject<InventoryGemData>(InventoryGemSlotReference[listOfSlots.Count], GemDatabase.Gems[args.Item.Name]);
            }
        }

        public static void handleInventoryArmor(ItemReceivedEventArgs args)
        {
            // Specifically only for gems

            var listOfSlots = ItemHelpers.GetInventoryArmorSlots();

            Console.WriteLine($"{listOfSlots.Count} gem slots found");

            if (listOfSlots.Count >= 16)
            {
                Console.WriteLine($"Inventory full. Delaying {args.Item.Name}");
                App.delayedItems.Add(args);
                return;
            }

            InventoryArmorData matchingItem = listOfSlots.FirstOrDefault(inGameItem => inGameItem.ArmorName == args.Item.Name, null);

            InventoryArmorData armorData = null;


            if (matchingItem is not null && matchingItem.ArmorName != "Unknown Armor")
            {
                //Console.WriteLine($"{matchingItem.ArmorName} has been found already: Adding to Newer slot {matchingItem.ArmorInventorySlot}");
                //armorData = new InventoryItemData(matchingItem.Name, matchingItem.ItemSlot, (byte)(matchingItem.Quantity + 0x05), matchingItem.FreeSlot, matchingItem.ItemID);

            }
            else
            {
                //armorID = 
                //byte itemID = ItemHelpers.GemReference.FirstOrDefault(itm => itm.Value == args.Item.Name).Key;

                InventoryArmorData armor = HelmetDatabase.Helmets[args.Item.Name];

                //armor.GemInventorySlot = (byte)(listOfSlots.Count);

                //Console.WriteLine($"No Gem has been found: Adding {gem.GemName} with Agi {gem.GemAgiStat} to slot {listOfSlots.Count}");

                Memory.WriteObject<InventoryArmorData>(InventoryArmorSlotReference[listOfSlots.Count], HelmetDatabase.Helmets[args.Item.Name]);
            }
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


        public static Dictionary<int, Dictionary<string, uint>> InventoryWeaponSlotReference = new Dictionary<int, Dictionary<string, uint>>()
        {
            [0] = new Dictionary<string, uint>
            {
                ["BladeSlot"] = Addresses.InventoryWeaponSlot1_BladeSlot,
                ["GripSlot"] = Addresses.InventoryWeaponSlot1_GripSlot,
                ["Equipped"] = Addresses.InventoryWeaponSlot1_Equipped,
                ["Gem1"] = Addresses.InventoryWeaponSlot1_Gem1,
                ["Gem2"] = Addresses.InventoryWeaponSlot1_Gem2,
                ["Gem3"] = Addresses.InventoryWeaponSlot1_Gem3,
                ["FirstNameStart"] = Addresses.InventoryWeaponSlot1_FirstNameStart,
                ["LastNameStart"] = Addresses.InventoryWeaponSlot1_LastNameStart,
            },
            [1] = new Dictionary<string, uint>
            {
                ["BladeSlot"] = Addresses.InventoryWeaponSlot2_BladeSlot,
                ["GripSlot"] = Addresses.InventoryWeaponSlot2_GripSlot,
                ["Equipped"] = Addresses.InventoryWeaponSlot2_Equipped,
                ["Gem1"] = Addresses.InventoryWeaponSlot2_Gem1,
                ["Gem2"] = Addresses.InventoryWeaponSlot2_Gem2,
                ["Gem3"] = Addresses.InventoryWeaponSlot2_Gem3,
                ["FirstNameStart"] = Addresses.InventoryWeaponSlot2_FirstNameStart,
                ["LastNameStart"] = Addresses.InventoryWeaponSlot2_LastNameStart,
            },
            [2] = new Dictionary<string, uint>
            {
                ["BladeSlot"] = Addresses.InventoryWeaponSlot3_BladeSlot,
                ["GripSlot"] = Addresses.InventoryWeaponSlot3_GripSlot,
                ["Equipped"] = Addresses.InventoryWeaponSlot3_Equipped,
                ["Gem1"] = Addresses.InventoryWeaponSlot3_Gem1,
                ["Gem2"] = Addresses.InventoryWeaponSlot3_Gem2,
                ["Gem3"] = Addresses.InventoryWeaponSlot3_Gem3,
                ["FirstNameStart"] = Addresses.InventoryWeaponSlot3_FirstNameStart,
                ["LastNameStart"] = Addresses.InventoryWeaponSlot3_LastNameStart,
            },
            [3] = new Dictionary<string, uint>
            {
                ["BladeSlot"] = Addresses.InventoryWeaponSlot4_BladeSlot,
                ["GripSlot"] = Addresses.InventoryWeaponSlot4_GripSlot,
                ["Equipped"] = Addresses.InventoryWeaponSlot4_Equipped,
                ["Gem1"] = Addresses.InventoryWeaponSlot4_Gem1,
                ["Gem2"] = Addresses.InventoryWeaponSlot4_Gem2,
                ["Gem3"] = Addresses.InventoryWeaponSlot4_Gem3,
                ["FirstNameStart"] = Addresses.InventoryWeaponSlot4_FirstNameStart,
                ["LastNameStart"] = Addresses.InventoryWeaponSlot4_LastNameStart,
            },
            [4] = new Dictionary<string, uint>
            {
                ["BladeSlot"] = Addresses.InventoryWeaponSlot5_BladeSlot,
                ["GripSlot"] = Addresses.InventoryWeaponSlot5_GripSlot,
                ["Equipped"] = Addresses.InventoryWeaponSlot5_Equipped,
                ["Gem1"] = Addresses.InventoryWeaponSlot5_Gem1,
                ["Gem2"] = Addresses.InventoryWeaponSlot5_Gem2,
                ["Gem3"] = Addresses.InventoryWeaponSlot5_Gem3,
                ["FirstNameStart"] = Addresses.InventoryWeaponSlot5_FirstNameStart,
                ["LastNameStart"] = Addresses.InventoryWeaponSlot5_LastNameStart,
            },
            [5] = new Dictionary<string, uint>
            {
                ["BladeSlot"] = Addresses.InventoryWeaponSlot6_BladeSlot,
                ["GripSlot"] = Addresses.InventoryWeaponSlot6_GripSlot,
                ["Equipped"] = Addresses.InventoryWeaponSlot6_Equipped,
                ["Gem1"] = Addresses.InventoryWeaponSlot6_Gem1,
                ["Gem2"] = Addresses.InventoryWeaponSlot6_Gem2,
                ["Gem3"] = Addresses.InventoryWeaponSlot6_Gem3,
                ["FirstNameStart"] = Addresses.InventoryWeaponSlot6_FirstNameStart,
                ["LastNameStart"] = Addresses.InventoryWeaponSlot6_LastNameStart,
            },
            [6] = new Dictionary<string, uint>
            {
                ["BladeSlot"] = Addresses.InventoryWeaponSlot7_BladeSlot,
                ["GripSlot"] = Addresses.InventoryWeaponSlot7_GripSlot,
                ["Equipped"] = Addresses.InventoryWeaponSlot7_Equipped,
                ["Gem1"] = Addresses.InventoryWeaponSlot7_Gem1,
                ["Gem2"] = Addresses.InventoryWeaponSlot7_Gem2,
                ["Gem3"] = Addresses.InventoryWeaponSlot7_Gem3,
                ["FirstNameStart"] = Addresses.InventoryWeaponSlot7_FirstNameStart,
                ["LastNameStart"] = Addresses.InventoryWeaponSlot7_LastNameStart,
            },
            [7] = new Dictionary<string, uint>
            {
                ["BladeSlot"] = Addresses.InventoryWeaponSlot8_BladeSlot,
                ["GripSlot"] = Addresses.InventoryWeaponSlot8_GripSlot,
                ["Equipped"] = Addresses.InventoryWeaponSlot8_Equipped,
                ["Gem1"] = Addresses.InventoryWeaponSlot8_Gem1,
                ["Gem2"] = Addresses.InventoryWeaponSlot8_Gem2,
                ["Gem3"] = Addresses.InventoryWeaponSlot8_Gem3,
                ["FirstNameStart"] = Addresses.InventoryWeaponSlot8_FirstNameStart,
                ["LastNameStart"] = Addresses.InventoryWeaponSlot8_LastNameStart,
            },
        };

        public static Dictionary<byte, string> CraftingWeaponReference = new Dictionary<byte, string>()
        {
            { 0x01, "BattleKnife" },
            { 0x02, "Scramasax" },
            { 0x03, "Dirk" },
            { 0x04, "ThrowingKnife" },
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
            { 0x10, "ShortSword" },
            { 0x11, "Firangi" },
            { 0x12, "Shamshir" },
            { 0x13, "Falchion" },
            { 0x14, "Shotel" },
            { 0x15, "Khora" },
            { 0x16, "Khopesh" },
            { 0x17, "Wakizashi" },
            { 0x18, "Romphaia" },
            { 0x19, "BroadSword" },
            { 0x1A, "NorseSword" },
            { 0x1B, "Katana" },
            { 0x1C, "Executioner" },
            { 0x1D, "Claymore" },
            { 0x1E, "Schiavona" },
            { 0x1F, "BastardSword" },
            { 0x20, "Nodachi" },
            { 0x21, "RuneBlade" },
            { 0x22, "HolyWin" },
            { 0x23, "HandAxe" },
            { 0x24, "BattleAxe" },
            { 0x25, "Francisca" },
            { 0x26, "Tabarzin" },
            { 0x27, "Chamkaq" },
            { 0x28, "Tabar" },
            { 0x29, "Bullova" },
            { 0x2A, "Crescent" },
            { 0x2B, "GoblinClub" },
            { 0x2C, "SpikedClub" },
            { 0x2D, "BallMace" },
            { 0x2E, "Footman'sMace" },
            { 0x2F, "MorningStar" },
            { 0x30, "WarHammer" },
            { 0x31, "BecdeCorbin" },
            { 0x32, "WarMaul" },
            { 0x33, "Guisarme" },
            { 0x34, "LargeCrescent" },
            { 0x35, "SabreHalberd" },
            { 0x36, "Balbriggan" },
            { 0x37, "DoubleBlade" },
            { 0x38, "Halberd" },
            { 0x39, "WizardStaff" },
            { 0x3A, "ClergyRod" },
            { 0x3B, "SummonerBaton" },
            { 0x3C, "ShamanicStaff" },
            { 0x3D, "Bishop'sCrosier" },
            { 0x3E, "Sage'sCane" },
            { 0x3F, "Langdebeve" },
            { 0x40, "SabreMace" },
            { 0x41, "Footman'sMace" },
            { 0x42, "Gloomwing" },
            { 0x43, "Mjolinir" },
            { 0x44, "Griever" },
            { 0x45, "Destroyer" },
            { 0x46, "HandofLight" },
            { 0x47, "Spear" },
            { 0x48, "Glaive" },
            { 0x49, "Scorpion" },
            { 0x4A, "Corcesca" },
            { 0x4B, "Trident" },
            { 0x4C, "AwlPike" },
            { 0x4D, "BoarSpear" },
            { 0x4E, "Fauchard" },
            { 0x4F, "Voulge" },
            { 0x50, "PoleAxe" },
            { 0x51, "Bardysh" },
            { 0x52, "Brandestoc" },
            { 0x53, "GastraphBow" },
            { 0x54, "LightCrossbow" },
            { 0x55, "TargetBow" },
            { 0x56, "Windlass" },
            { 0x57, "Cranequin" },
            { 0x58, "LugCrossbow" },
            { 0x59, "SiegeBow" },
            { 0x5A, "Arbalest" }
        };

        public static Dictionary<byte, string> ShieldReference = new Dictionary<byte, string>
        {
            { 0x01, "Buckler" },
            { 0x02, "Pelta Shield" },
            { 0x03, "Targe" },
            { 0x04, "Quad Shield" },
            { 0x05, "Circle Shield" },
            { 0x06, "Tower Shield" },
            { 0x07, "Spiked Shield" },
            { 0x08, "Round Shield" },
            { 0x09, "Kite Shield" },
            { 0x0A, "Casserole Shield" },
            { 0x0B, "Heater Shield" },
            { 0x0C, "Oval Shield" },
            { 0x0D, "Knight Shield" },
            { 0x0E, "Hoplite Shield" },
            { 0x0F, "Jazeraint Shield" },
            { 0x10, "Dread Shield" }
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
            { 0x2A, "Scale Armor" },
            { 0x2B, "Brigandine" },
            { 0x2C, "Plate Mail" },
            { 0x2D, "Fluted Armor" },
            { 0x2E, "Hoplite Armor" },
            { 0x2F, "Jazeraint Armor" },
            { 0x30, "Dread Armor" },
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
            { 0x50, "Dread Glove" }
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
            { 0x4F, "Acolyte´s Nostrum" },
            { 0x50, "Saint´s Nostrum" },
            { 0x51, "Alchemist´s Reagent" },
            { 0x52, "Sorcerer´s Reagent" },
            { 0x53, "Yggdrasill´s Tears" },
            { 0x54, "Faerie Chortle" },
            { 0x55, "Spirit Orison" },
            { 0x56, "Angelic Paean" },
            { 0x57, "Panacea" },
            { 0x58, "Snowfly Draught" },
            { 0x59, "Faerie Wing" },
            { 0x5A, "Elixir of Kings" },
            { 0x5B, "Elixir of Sages" },
            { 0x5C, "Elixir of Dragons" },
            { 0x5D, "Elixir of Queens" },
            { 0x5E, "Elixir of Mages" },
            { 0x5F, "Valens (Wine)" },
            { 0x60, "Prudens (Wine)" },
            { 0x61, "Volare (Wine)" },
            { 0x62, "Audentia (Wine)" },
            { 0x63, "Virtus (Wine)" },
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
            { 0x93, "Grimoire Flamme" },
            { 0x97, "Grimoire Gaea" },
            { 0x9B, "Grimoire Avalanche" },
            { 0x9F, "Grimoire Radius" },
            { 0xA1, "Grimoire Meteore" },
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
