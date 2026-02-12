using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.MapData
{
    public class MapBossData
    {
        [MemoryOffset(0x1a)]
        public byte Item1_Id { get; set; }
        [MemoryOffset(0x1b)]
        public byte Item1_Qty { get; set; }
        [MemoryOffset(0x1c)]
        public byte Item2_Id { get; set; }
        [MemoryOffset(0x1d)]
        public byte Item2_Qty { get; set; }
        [MemoryOffset(0x1e)]
        public byte Item3_Id { get; set; }
        [MemoryOffset(0x1f)]
        public byte Item3_Qty { get; set; }
    }
}