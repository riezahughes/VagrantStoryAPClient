using Archipelago.Core;
using Archipelago.Core.Util;
using Helpers;
using VagrantStoryArchipelago;
using VagrantStoryArchipelago.Data;
using VagrantStoryArchipelago.Models.MapData; // Assuming your Memory class is here

public class MapHelper
{
    /// <summary>
    /// Sets the bit corresponding to the mapId to 1 (Seen/Visited).
    /// </summary>
    /// 

    private static ushort _lastMapIdChest = 0xFFFF; // Store last known map ID
    private static uint _lastPointerValueBoss = 0xFFFFFFFF; // Store last known map ID

    public static void StartMapBossListener(Dictionary<string, object> options)
    {
        Memory.MonitorAddressForAction<uint>(
            Addresses.MapBossDataPointer,
            () =>
            {
                ushort mapId = Memory.ReadUShort(Addresses.CurrentMapandRoomID);
                uint pointerValue = Memory.ReadUInt(Addresses.MapBossDataPointer);

                if (APHelpers.isInTheGame() && APHelpers.isProcessingItems() == false && MapsWithBosses.Contains(mapId))
                {
                    uint bossPointerLocation = Memory.ReadUInt(Addresses.MapBossDataPointer);
                    uint bossAddress = (bossPointerLocation & 0x0FFFFFFF);
                    Console.WriteLine($"Current Map ID: {mapId:X4} - Boss Drops Updating");
                    UpdateBossInMap(bossAddress, options);
                    _lastPointerValueBoss = pointerValue;
                }
                Thread.Sleep(500);
                StartMapBossListener(options);
            },
            value => value != _lastPointerValueBoss);
    }

    public static void UpdateBossInMap(uint currentPointerValue, Dictionary<string, object> options)
    {
        int dropChoice = Int32.Parse(options?.GetValueOrDefault("boss_item_choices", "0").ToString());
        var replacementBossItems = new MapBossData();
        var item1 = ItemDatabase.Items["Cure Root"];
        var item2 = ItemDatabase.Items["Vera Root"];
        var item3 = ItemDatabase.Items["Alchemist's Reagent"];

        if (dropChoice == DropItemChoice.HEALING_HEAVY)
        {
            replacementBossItems.Item1_Id = item1.ItemID;
            replacementBossItems.Item1_Qty = 0x01;
            replacementBossItems.Item2_Id = item2.ItemID;
            replacementBossItems.Item2_Qty = 0x01;
            replacementBossItems.Item3_Id = item3.ItemID;
            replacementBossItems.Item3_Qty = 0x01;
        }

        else if (dropChoice == DropItemChoice.RISK_HEAVY)
        {

            replacementBossItems.Item1_Id = item1.ItemID;
            replacementBossItems.Item1_Qty = 0x01;
            replacementBossItems.Item2_Id = item2.ItemID;
            replacementBossItems.Item2_Qty = 0x01;
            replacementBossItems.Item3_Id = item3.ItemID;
            replacementBossItems.Item3_Qty = 0x01;
        }

        Memory.WriteObject<MapBossData>(currentPointerValue, replacementBossItems);
    }

    public static void StartMapChestListener(Dictionary<string, object> options)
    {
        Memory.MonitorAddressForAction<ushort>(
            Addresses.CurrentMapandRoomID,
            () =>
            {
                ushort mapId = Memory.ReadUShort(Addresses.CurrentMapandRoomID);

                if (APHelpers.isInTheGame() && APHelpers.isProcessingItems() == false && MapsWithChests.Contains(mapId))
                {
                    Thread.Sleep(3000);
                    uint chestPointerLocation = Memory.ReadUInt(Addresses.MapChestDataPointer);
                    uint chestAddress = (chestPointerLocation & 0x0FFFFFFF) + 0x14;
                    Console.WriteLine($"Current Map ID: {mapId:X4} - Chest Drops Updating");

                    UpdateChestsInMap(chestAddress, options);
                    _lastMapIdChest = mapId;
                }
                Thread.Sleep(500);
                StartMapChestListener(options);
            },
            value => value != _lastMapIdChest);
    }

    public static void UpdateChestsInMap(uint currentPointerValue, Dictionary<string, object> options)
    {

        int dropChoice = Int32.Parse(options?.GetValueOrDefault("chest_item_choices", "0").ToString());

        var replacementChestItems = new MapChestData();
        var item1 = ItemDatabase.Items["Cure Root"];
        var item2 = ItemDatabase.Items["Vera Root"];
        var item3 = ItemDatabase.Items["Alchemist's Reagent"];



        if (dropChoice == DropItemChoice.HEALING_HEAVY)
        {
            replacementChestItems.Misc1_Exists = 0x03;
            replacementChestItems.Misc2_Exists = 0x03;
            replacementChestItems.Misc3_Exists = 0x03;
            replacementChestItems.Misc1_ID = item1.ItemID;
            replacementChestItems.Misc2_ID = item2.ItemID;
            replacementChestItems.Misc3_ID = item3.ItemID;
            replacementChestItems.Misc1_Qty = 0x05;
            replacementChestItems.Misc2_Qty = 0x03;
            replacementChestItems.Misc3_Qty = 0x01;
            replacementChestItems.Misc1_Confirm = 0x01;
            replacementChestItems.Misc2_Confirm = 0x01;
            replacementChestItems.Misc3_Confirm = 0x01;
        }

        else if (dropChoice == DropItemChoice.RISK_HEAVY)
        {
            replacementChestItems.Misc1_Exists = 0x03;
            replacementChestItems.Misc2_Exists = 0x03;
            replacementChestItems.Misc3_Exists = 0x03;
            replacementChestItems.Misc1_ID = item1.ItemID;
            replacementChestItems.Misc2_ID = item2.ItemID;
            replacementChestItems.Misc3_ID = item3.ItemID;
            replacementChestItems.Misc1_Qty = 0x03;
            replacementChestItems.Misc2_Qty = 0x05;
            replacementChestItems.Misc3_Qty = 0x01;
            replacementChestItems.Misc1_Confirm = 0x01;
            replacementChestItems.Misc2_Confirm = 0x01;
            replacementChestItems.Misc3_Confirm = 0x01;
        }

        Memory.WriteObject<MapChestData>(currentPointerValue, replacementChestItems);
    }

    public static List<ushort> MapsWithBosses = new List<ushort>
    {
        0x000B, // The Hero's Winehall - Dullahan
        0x000C, // The Gallows - Minotaur
        0x0010, // Hall of Sacrilege - Golem
        0x0011, // The Cleansing Chantry - Dragon
        0x0016, // Sanity and Madness - Iron Crab
        0x0018, // The Flayed Confessional - Djinn
        0x0119, // What Ails You, Kills You - Nightmare
        0x0135, // Dream of the Holy Land - Water Elemental
        0x0229, // Nature's Womb - Damascus Crab
        0x0231, // Bazaar of the Bizarre - Lich
        0x0233, // The Miner's End - Air Elemental
        0x0320, // Tircolas Flow - Father Duane, Sarjik and Bejart
        0x0330, // Underdark Fishmarket - Giant Crab
        0x0416, // Truth and Lies - Ifrit
        0x0418, // A Light in the Dark - Arch Dragon
        0x0531, // Gemsword Blackmarket - Nightstalker
        0x0632, // The Battle's Beginning - Wyvern
        0x0633, // Dining in Darkness - Sky Dragon
        0x0737, // Spanish Tickler - Wyvern Knight
        0x0B18, // The Hall of Broken Vows - Flame Dragon
        0x0C37, // Burial - Iron Golem
        0x0E33, // Tomb of the Reborn - Earth Elemental
        0x0F18, // Hopes of the Idealist - Dao
        0x0F30, // Fear of the Fall - Dark Elemental
        0x1132, // The Smeltry - Fire Elemental
        0x1628, // Return to the Land - Earth Dragon
        0x1632, // Traitor's Parting - Ogre
        0x1638, // The Iron Maiden - Asura
        0x1735, // Torture Without End - Ogre Lord
        0x1D35, // Hall of the Wage-Paying - Snow Dragon
        // NG+
        0x0136, // Slaugher of the Innocent - Damascus Golem (Evil)
        0x0138, // Ordeal By Fire - Dark Dragon (Dragon)
        0x0229, // Nature's Womb - Damascus Crab (Beast) [Also regular boss]
        0x041D, // Urge the Boy On - Marid and Ifrit (Phantoms) [Time Trial]
        0x051D, // A Taste of the Spoils - Damascus Crab & Damascus Golem (Beast/Evil) [Time Trial]
        0x0538, // Pressing - Ravana (Human)
        0x061D, // Wiping Blood from Blades - Death, Ogre Zombie & Asura (Evil/Undead/Human) [Time Trial]
        0x0A38, // The Saw - Dragon Zombie (Undead)
        0x0E38, // The Shin-Vice - Ogre Zombie (Undead)
        0x1237, // Knotting - Wyvern Queen (Dragon)
        0x1638, // The Iron Maiden - Asura (Human) [Also regular final boss]
        0x1A30, // Bite the Master's Wounds - Death (Evil)
    };

    public static List<ushort> MapsWithChests = new List<ushort>
    {
           // Wine Cellar
        0x1009, // Worker's Breakroom
        0x0909, // The Reckoning Room
        0x1109, // Blackmarket of Wines
        0x000C, // The Gallows
        0x000B, // The Hero's Winehall
        
        // Catacombs
        0x050D, // Rodent-Ridden Chamber
        0x040D, // The Lamenting Mother
        0x090D, // Bandits' Hideout
        
        // Sanctum
        0x030F, // Alchemists' Laboratory
        
        // Abandoned Mines B1
        0x0132, // Miners' Resting Hall
        0x0A32, // Coal Mine Storage
        0x0E32, // Rust in Peace
        0x1032, // Mining Regrets
        
        // Abandoned Mines B2
        0x0533, // Delusions of Happiness
        0x0833, // Hidden Resources
        0x0B33, // Acolyte's Burial Vault
        0x1633, // Suicidal Desires
        
        // Limestone Quarry
        0x0535, // Bonds of Friendship
        0x1635, // Stone and Sulfurous Fire
        0x1935, // Excavated Hollow
        0x1435, // Drowned in Fleeting Joy
        0x0F35, // Companions in Arms
        
        // Temple of Kiltia
        0x031E, // The Chapel of Meschaunce
        
        // Great Cathedral L1
        0x0218, // Where Darkness Spreads
        0x0018, // The Flayed Confessional
        
        // Great Cathedral L2
        0x0019, // An Arrow into Darkness
        
        // Forgotten Pathway
        0x0236, // The Fallen Knight
        0x0436, // Awaiting Retribution
        
        // Escapeway
        0x0734, // Where Body and Soul Part
        0x0134, // Buried Alive
        
        // Iron Maiden B1
        0x1437, // The Wheel
        0x1537, // The Judas Cradle
        0x1637, // The Ducking Stool
        0x1337, // The Branks
        
        // Iron Maiden B2
        0x1138, // Lead Sprinkler
        0x0F38, // Squassation
        
        // Iron Maiden B3
        0x1738, // Saint Elmo's Belt
        0x1938, // Dunking the Witch
        
        // Undercity West
        0x1430, // The Children's Hideout
        0x0730, // Larder for a Lean Winter
        0x1530, // The Crumbling Market
        
        // Undercity East
        0x0831, // Weapons Not Allowed
        0x0731, // Sale of the Sword
        0x0C31, // Catspaw Blackmarket
        
        // The Keep
        0x001D, // The Warrior's Rest
        
        // Snowfly Forest
        0x1728, // Forest River
        0x1828, // Hewn from Nature
        
        // Snowfly Forest East
        0x0229, // Nature's Womb
        
        // Town Centre South
        0x0025, // The House Khazabas
        
        // Town Centre East
        0x0024, // Gharmes Walk
        0x0026, // The House Gilgitte
    };

    public static Dictionary<int, ushort> StartingLocationAddress = new Dictionary<int, ushort>
    {
        { 0, 0x002b },
        { 1, 0x0005 },
        { 2, 0x002d },
        { 3, 0x002f },
        { 4, 0x002c },
        { 5, 0x002a }
    };

    public static void SetStartingLocation(CancellationTokenSource cts, ArchipelagoClient client)
    {
        if (cts.Token.IsCancellationRequested) return;

        Memory.MonitorAddressForAction<ushort>(
            Addresses.CurrentMapandRoomID,
            () =>
            {

                int startingLocation = Int32.Parse(client.Options?.GetValueOrDefault("open_world_option", "0").ToString());

                int count = 0;
                while (count < 10)
                {
                    var address = StartingLocationAddress[startingLocation];
                    Memory.Write(Addresses.CurrentMapandRoomID, address);
                    count++;
                }
            },
            value => value >= 1);
    }

    public static void MarkMapAsSeen(int mapId)
    {
        // Data Crystal Formula:
        // Address = 0x8005FFD8 + (MapID / 8)
        // Bit = MapID % 8

        uint byteOffset = (uint)(mapId / 8);
        int bitNumber = mapId % 8;
        ulong targetAddress = Addresses.MapStatusAddress01 + byteOffset;

        // Use the existing WriteBit utility
        // value: true sets the bit to 1
        Memory.WriteBit(targetAddress, bitNumber, true);

    }

    /// <summary>
    /// Flips the bits for a collection of map IDs to "silence" them.
    /// </summary>
    public static void SilenceCutsceneRange(IEnumerable<int> mapIds)
    {
        foreach (var id in mapIds)
        {
            MarkMapAsSeen(id);
        }
    }
}