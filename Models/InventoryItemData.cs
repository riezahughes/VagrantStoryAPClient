
namespace VagrantStoryArchipelago.Models
{
    public class InventoryItemData
    {
        public string Name { get; set; }
        public byte ItemSlot { get; set; }
        public byte Quantity { get; set; }
        public byte FreeSlot { get; set; }
        public byte ItemID { get; set; }

        public InventoryItemData(string name, byte itemSlot, byte quantity, byte freeSlot, byte itemID)
        {
            Name = name;
            ItemSlot = itemSlot;
            Quantity = quantity;
            FreeSlot = freeSlot;
            ItemID = itemID;
        }

        public uint UseFullAddress()
        {
            byte[] bytes = new byte[4]; // ulong is 8 bytes
            bytes[0] = this.ItemSlot;
            bytes[1] = this.Quantity;
            bytes[2] = this.FreeSlot;
            bytes[3] = this.ItemID;
            Array.Reverse(bytes);

            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}
