using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.MapData
{
    public class MapFloorTrapData
    {
        [MemoryOffset(0x00)]
        public byte NextTileAvailable { get; set; }
        [MemoryOffset(0x01)]
        public byte TypeOfEntity { get; set; }
        [MemoryOffset(0x02)]
        public byte TileTriggered { get; set; }
        [MemoryOffset(0x03)]
        public byte TileAnimationState { get; set; }
        [MemoryOffset(0x04)]
        public uint PossibleRoomCoordinates { get; set; } // this might actually be the type in here as well!
        [MemoryOffset(0x08)]
        public uint UnknownBytes { get; set; }
    }
}
