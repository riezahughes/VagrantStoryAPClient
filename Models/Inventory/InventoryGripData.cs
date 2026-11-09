using Archipelago.Core.Util;
using VagrantStoryArchipelago.Enums;
namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryGripData
    {

        // IMPORTANT NOTE - THESE WON'T UPDATE IF YOU HAVE THE ITEM EQUIPPED. THEY ARE THEN STORED IN DIFFERENT SLOTS TO THIS AND THIS IS JUST A DUPLICATE
        public string GripName { get; set; }

        [MemoryOffset(0x00)]  // 0x607d1 - Item ID (note: 16-bit, spans 0x02-0x03)
        public uint GripID { get; set; }

        [MemoryOffset(0x02)]  // sub id (was named GripInventorySlot; the slot number belongs in GripIndex)
        public byte GripSubId { get; set; }

        [MemoryOffset(0x03)]  // 0x607cf - Grip Slot
        public byte GripType { get; set; }

        [MemoryOffset(0x04)]  // 0x607dd - STR
        public byte GripGemSlotQuantity { get; set; }

        [MemoryOffset(0x05)]  // 0x607dd - STR
        public byte GripStrStat { get; set; }

        [MemoryOffset(0x06)]  // 0x607de - INT
        public byte GripIntStat { get; set; }

        [MemoryOffset(0x07)]  // 0x607df - AGI
        public byte GripAgiStat { get; set; }
        [MemoryOffset(0x09)]  // types[1] (signed); types[0] is bare hands
        public byte GripBluntStat { get; set; }
        [MemoryOffset(0x0a)]  // types[2] (signed)
        public byte GripEdgedStat { get; set; }
        [MemoryOffset(0x0b)]  // types[3] (signed)
        public byte GripPierceStat { get; set; }

        [MemoryOffset(0x0c)]  // 0x607f6 - Equip Status
        public byte GripEquipStatus { get; set; }

        [MemoryOffset(0x0d)]  // assembledWeaponIndex high byte
        public byte GripSetStatus { get; set; }

        [MemoryOffset(0x0e)]  // index: 1-based position in the grip inventory
        public ushort GripIndex { get; set; }

        public InventoryGripData(
            string name,
            GripID gripID,
            byte gripSubId,
            GripType gripType,
            byte gemSlotQuantity,
            byte gripStrStat,
            byte gripIntStat,
            byte gripAgiStat,
            byte gripBluntStat,
            byte gripEdgedStat,
            byte gripPiercingStat,
            byte gripEquipStatus,
            byte gripSetStatus
        )
        {
            GripName = name;
            GripID = Convert.ToByte(gripID);
            GripSubId = (byte)(Convert.ToByte(gripID) - 95); // the game stores sub id = id - 95 for every grip (the gripSubId argument is no longer used)
            GripType = Convert.ToByte(gripType);
            GripGemSlotQuantity = gemSlotQuantity;
            GripStrStat = gripStrStat;
            GripIntStat = gripIntStat;
            GripAgiStat = gripAgiStat;
            GripBluntStat = gripBluntStat;
            GripEdgedStat = gripEdgedStat;
            GripPierceStat = gripPiercingStat;
            GripEquipStatus = gripEquipStatus;
            GripSetStatus = gripSetStatus;
        }
    }
}