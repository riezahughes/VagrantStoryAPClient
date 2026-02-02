using Archipelago.Core.Util; // Assuming utility for memory access

public class MapHelper
{
    // The base address from Data Crystal
    private const uint MAP_FLAG_BASE = 0x8005FFD8;

    public static void MarkMapAsSeen(int mapId)
    {
        // 1. Calculate the address and bit
        int byteOffset = mapId / 8;
        int bitNumber = mapId % 8;
        uint targetAddress = (uint)(MAP_FLAG_BASE + byteOffset);

        // 2. Read the current state of that byte
        // Assuming your Connector/Memory instance is 'mem'
        byte currentByte = Memory.ReadByte(targetAddress);

        // 3. Create a mask for the bit (e.g., bit 3 becomes 00001000)
        byte mask = (byte)(1 << bitNumber);

        // 4. Set the bit using OR (|) and write it back
        byte updatedByte = (byte)(currentByte | mask);

        Memory.WriteByte(targetAddress, updatedByte);

        Console.WriteLine($"Map {mapId}: Bit {bitNumber} set at {targetAddress:X8}.");
    }

    // Example: Silence all missing maps in a specific range
    public static void SilenceCutsceneRange(IEnumerable<int> missingMaps)
    {
        foreach (var id in missingMaps)
        {
            MarkMapAsSeen(id);
        }
    }
}