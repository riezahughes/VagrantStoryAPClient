using Archipelago.Core.Util;
using VagrantStoryArchipelago; // Assuming your Memory class is here

public class MapHelper
{
    /// <summary>
    /// Sets the bit corresponding to the mapId to 1 (Seen/Visited).
    /// </summary>
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

        Console.WriteLine($"Map {mapId}: Bit {bitNumber} set at {targetAddress:X8}.");
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