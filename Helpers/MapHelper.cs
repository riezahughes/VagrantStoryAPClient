using Archipelago.Core;
using Archipelago.Core.Util;
using VagrantStoryArchipelago; // Assuming your Memory class is here

public class MapHelper
{
    /// <summary>
    /// Sets the bit corresponding to the mapId to 1 (Seen/Visited).
    /// </summary>
    /// 

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