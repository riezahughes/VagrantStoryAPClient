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

        [MemoryOffset(0x02)]  // 0x607cf - Grip Slot
        public byte GripInventorySlot { get; set; }

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
        [MemoryOffset(0x09)]  // 0x607df - AGI
        public byte GripBluntStat { get; set; }
        [MemoryOffset(0x0a)]  // 0x607df - AGI
        public byte GripEdgedStat { get; set; }
        [MemoryOffset(0x0b)]  // 0x607df - AGI                 
        public byte GripPierceStat { get; set; }

        [MemoryOffset(0x0c)]  // 0x607f6 - Equip Status
        public byte GripEquipStatus { get; set; }

        [MemoryOffset(0x0d)]  // 0x607f6 - Equip Status
        public byte GripSetStatus { get; set; }

        public InventoryGripData(
            string name,
            GripID gripID,
            byte gripInventorySlot,
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
            GripInventorySlot = gripInventorySlot;
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