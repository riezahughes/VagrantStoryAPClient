using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.MapData
{
    /// <summary>
    /// One 0x14 byte lock entry from the room's "section A" (array pointed to by Addresses.RoomLockPointer, byte length at
    /// Addresses.RoomLockLength, count = length / 0x14). Layout confirmed against rood-reverse (mpd.h _mpdRoomSectionA,
    /// func_80073AFC) and the MPD files. The entry for a door is found by tile, not by order.
    /// </summary>
    public class MapLockedDoorData
    {
        public const uint EntrySize = 0x14;

        [MemoryOffset(0x00)]
        public ushort TileX { get; set; }
        [MemoryOffset(0x02)]
        public ushort TileZ { get; set; }
        [MemoryOffset(0x04)]
        public ushort TileSurface { get; set; }
        // 4-7 = the lock also covers the neighbouring tile (4: z-1, 5: x+1, 6: z+1, 7: x-1)
        [MemoryOffset(0x06)]
        public ushort Direction { get; set; }
        // 0 = open, 1 = needs key/sigil, 2 = magic lock (chest), 3 = locked (key opens it as well, different message)
        [MemoryOffset(0x08)]
        public byte LockState { get; set; }
        [MemoryOffset(0x09)]
        public byte Unknown_Byte_1 { get; set; }
        // 0xE7 on every entry seen; the first entry of the array must be non-zero here
        [MemoryOffset(0x0a)]
        public byte Marker { get; set; }
        [MemoryOffset(0x0b)]
        public byte Unknown_Byte_2 { get; set; }
        // Full game item id: 0x100 | inventory id (Chamomile Sigil 0x1D2). Sigils (>= 0x1D2) are consumed on use.
        [MemoryOffset(0x0c)]
        public ushort Door_Lock_Item_Id { get; set; }
        // must be 0 (and 0x12 must be 0) for the entry to act as a door lock
        [MemoryOffset(0x0e)]
        public ushort Unknown_Short_1 { get; set; }
        [MemoryOffset(0x10)]
        public ushort Unknown_Short_2 { get; set; }
        [MemoryOffset(0x12)]
        public byte Unknown_Byte_3 { get; set; }
        [MemoryOffset(0x13)]
        public byte Unknown_Byte_4 { get; set; }
    }
}
