using Archipelago.Core;
using Archipelago.Core.Util;
using VagrantStoryArchipelago;
using VagrantStoryArchipelago.Data;
using VagrantStoryArchipelago.Models.MapData; // Assuming your Memory class is here

public class MapHelper
{
    /// <summary>
    /// Sets the bit corresponding to the mapId to 1 (Seen/Visited).
    /// </summary>
    /// 

    public static void StartMapListener()
    {
        Memory.MonitorAddressForAction<ushort>(
            Addresses.CurrentMapandRoomID,
            () =>
            {
#if DEBUG
                Console.WriteLine("Updating Chests");
#endif
                int mapId = Memory.ReadByte(Addresses.CurrentMapandRoomID);
                uint chestPointerLocation = Memory.ReadUInt(Addresses.MapChestDataPointer);
                uint chestAddress = (chestPointerLocation & 0x0FFFFFFF) + 0x14;

#if DEBUG
                Console.WriteLine($"Pointer: 0x{chestPointerLocation:X8}, Chest Base: 0x{chestAddress:X8}");
                Console.WriteLine($"Misc1 should be at: 0x{chestAddress + 0x214:X8}");
#endif

                UpdateChestsInMap(chestAddress);
            },
            value => true);
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