using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.MapData
{
    public class MapLockedDoorData
    {
        // there is clearly more than this available, but htese ar ethe only things that are mapped at the moment for this offset
        [MemoryOffset(0x00)]
        public byte Unknown_Byte_1 { get; set; }
        [MemoryOffset(0x01)]
        public byte Unknown_Byte_2 { get; set; }
        [MemoryOffset(0x02)]
        public byte NextLockExists { get; set; }
        [MemoryOffset(0x03)]
        public int Unknown_Section_1 { get; set; }
        [MemoryOffset(0x08)]
        public ushort Unknown_Short_1 { get; set; }
        [MemoryOffset(0x0a)]
        public ushort Unknown_Short_2 { get; set; }
        [MemoryOffset(0x0c)]
        public byte Door_Lock_Item_Id { get; set; }
        [MemoryOffset(0x0d)]
        public byte Unknown_Byte_3 { get; set; }
        [MemoryOffset(0x0e)]
        public byte Door_Unlocked { get; set; }
    }
}