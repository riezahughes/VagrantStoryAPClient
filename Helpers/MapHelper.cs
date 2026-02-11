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

    private static ushort _lastMapId = 0xFFFF; // Store last known map ID

    public static void StartMapListener()
    {
        Memory.MonitorAddressForAction<ushort>(
            Addresses.CurrentMapandRoomID,
            () =>
            {
                ushort mapId = Memory.ReadUShort(Addresses.CurrentMapandRoomID);
                Console.WriteLine($"Current Map ID: {mapId:X4}");
                if (APHelpers.isInTheGame() && APHelpers.isProcessingItems() == false && MapsWithChests.Contains(mapId))
                {
#if DEBUG
                    Thread.Sleep(3000);
                    Console.WriteLine("Map changed - Updating Chests");
#endif

                    uint chestPointerLocation = Memory.ReadUInt(Addresses.MapChestDataPointer);
                    uint chestAddress = (chestPointerLocation & 0x0FFFFFFF) + 0x14;
#if DEBUG
                    Console.WriteLine($"Map ID: {mapId:X4}");
                    Console.WriteLine($"Pointer: 0x{chestPointerLocation:X8}, Chest Base: 0x{chestAddress:X8}");
                    Console.WriteLine($"Misc1 should be at: 0x{chestAddress + 0x214:X8}");
#endif
                    UpdateChestsInMap(chestAddress);
                    _lastMapId = mapId;
                }
                Thread.Sleep(1000);
                StartMapListener();
            },
            value => value != _lastMapId);
    }

    public static void UpdateChestsInMap(uint currentPointerValue)
    {
#if DEBUG
        Console.WriteLine($"Writing to base: 0x{currentPointerValue:X8}");
#endif

        var replacementChestItems = new MapChestData();
        var item1 = ItemDatabase.Items["Cure Root"];
        var item2 = ItemDatabase.Items["Vera Root"];
        var item3 = ItemDatabase.Items["Alchemist´s Reagent"];

        replacementChestItems.Misc1_Exists = 0x03;
        replacementChestItems.Misc2_Exists = 0x03;
        replacementChestItems.Misc3_Exists = 0x03;
        replacementChestItems.Misc1_ID = item1.ItemID;
        replacementChestItems.Misc2_ID = item2.ItemID;
        replacementChestItems.Misc3_ID = item3.ItemID;
        replacementChestItems.Misc1_Qty = 0x03;
        replacementChestItems.Misc2_Qty = 0x02;
        replacementChestItems.Misc3_Qty = 0x01;
        replacementChestItems.Misc1_Confirm = 0x01;
        replacementChestItems.Misc2_Confirm = 0x01;
        replacementChestItems.Misc3_Confirm = 0x01;

        Memory.WriteObject<MapChestData>(currentPointerValue, replacementChestItems);

#if DEBUG
        // Verify what was written
        var verify = Memory.ReadObject<MapChestData>(currentPointerValue);
        Console.WriteLine($"Verified Misc1_Exists at 0x{currentPointerValue + 0x222:X8}: {verify.Misc1_Exists:X2}");
#endif
    }

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