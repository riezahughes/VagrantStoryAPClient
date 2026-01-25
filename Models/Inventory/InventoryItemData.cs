using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryItemData
    {
        public string Name { get; set; }
        [MemoryOffset(0x00)]
        public byte ItemID { get; set; }
        [MemoryOffset(0x01)]
        public byte FreeSlot { get; set; }
        [MemoryOffset(0x02)]
        public byte Quantity { get; set; }
        [MemoryOffset(0x03)]
        public byte ItemSlot { get; set; }

        public InventoryItemData(string name, byte itemID, byte freeSlot, byte quantity, byte itemSlot)
        {
            Name = name;
            ItemID = itemID;
            FreeSlot = freeSlot;
            Quantity = quantity;
            ItemSlot = itemSlot;
        }

        public uint UseFullAddress()
        {
            byte[] bytes = new byte[4]; // ulong is 8 bytes
            bytes[3] = ItemID;
            bytes[2] = FreeSlot;
            bytes[1] = Quantity;
            bytes[0] = ItemSlot;

            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}
