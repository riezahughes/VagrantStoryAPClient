using Archipelago.Core.Util;
using VagrantStoryArchipelago.Enums;
namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryGripData
    {

        // IMPORTANT NOTE - THESE WON'T UPDATE IF YOU HAVE THE ITEM EQUIPPED. THEY ARE THEN STORED IN DIFFERENT SLOTS TO THIS AND THIS IS JUST A DUPLICATE
        public string GripName { get; set; }
        [MemoryOffset(0x00)]  // 0x607cf - Grip Slot
        public byte GripInventorySlot { get; set; }

        [MemoryOffset(0x01)]  // 0x607f6 - Equip Status
        public byte GripEquipStatus { get; set; }

        [MemoryOffset(0x04)]  // 0x607d1 - Item ID (note: 16-bit, spans 0x02-0x03)
        public uint GripID { get; set; }

        [MemoryOffset(0x07)]  // 0x607d4 - Max DP start (16-bit)
        public ushort GripMaxDP { get; set; }

        [MemoryOffset(0x09)]  // 0x607d4 - Max DP start (16-bit)
        public ushort GripMaxPP { get; set; }

        [MemoryOffset(0x0b)]  // 0x607d8 - Current DP
        public ushort GripCurrentPP { get; set; }

        [MemoryOffset(0x0d)]  // 0x607d8 - Current DP
        public ushort GripCurrentDP { get; set; }

        [MemoryOffset(0x10)]  // 0x607dd - STR
        public byte GripGemSlotQuantity { get; set; }

        [MemoryOffset(0x11)]  // 0x607dd - STR
        public byte GripStrStat { get; set; }

        [MemoryOffset(0x12)]  // 0x607de - INT
        public byte GripIntStat { get; set; }

        [MemoryOffset(0x13)]  // 0x607df - AGI
        public byte GripAgiStat { get; set; }

        [MemoryOffset(0x14)]  // 0x607e1 - Blunt
        public byte GripBluntDefStat { get; set; }

        [MemoryOffset(0x15)]  // 0x607e2 - Edged
        public byte GripEdgedDefStat { get; set; }

        [MemoryOffset(0x16)]  // 0x607e3 - Piercing
        public byte GripPiercingDefStat { get; set; }

        [MemoryOffset(0x18)]  // 0x607e4 - Human
        public byte GripHumanStat { get; set; }

        [MemoryOffset(0x19)]  // 0x607e5 - Beast
        public byte GripBeastStat { get; set; }

        [MemoryOffset(0x1a)]  // 0x607e6 - Undead
        public byte GripUndeadStat { get; set; }

        [MemoryOffset(0x1b)]  // 0x607e7 - Phantom
        public byte GripPhantomStat { get; set; }

        [MemoryOffset(0x1c)]  // 0x607e8 - Dragon
        public byte GripDragonStat { get; set; }

        [MemoryOffset(0x1d)]  // 0x607e9 - Evil
        public byte GripEvilStat { get; set; }

        [MemoryOffset(0x20)]  // 0x607ec - Physical
        public byte GripPhysicalStat { get; set; }

        [MemoryOffset(0x21)]  // 0x607ed - Air
        public byte GripAirStat { get; set; }

        [MemoryOffset(0x22)]  // 0x607ee - Fire
        public byte GripFireStat { get; set; }

        [MemoryOffset(0x23)]  // 0x607ef - Earth
        public byte GripEarthStat { get; set; }

        [MemoryOffset(0x24)]  // 0x607f0 - Water
        public byte GripWaterStat { get; set; }

        [MemoryOffset(0x25)]  // 0x607f1 - Light
        public byte GripLightStat { get; set; }

        [MemoryOffset(0x26)]  // 0x607f2 - Dark
        public byte GripDarkStat { get; set; }

        [MemoryOffset(0x28)]  // 0x607f4 - Material
        public byte GripMaterial { get; set; }

        [MemoryOffset(0x2c)]  // 0x607f4 - Gem slot reference 1
        public byte InventoryGemSlotReference1 { get; set; }
        [MemoryOffset(0x2d)]  // 0x607f4 - Gem slot reference 2
        public byte InventoryGemSlotReference2 { get; set; }
        [MemoryOffset(0x2e)]  // 0x607f4 - Gem slot reference 3
        public byte InventoryGemSlotReference3 { get; set; }

        public InventoryGripData(
            string name,
            byte gripInventorySlot,
            byte gripEquipStatus,
            GripID gripID,
            ushort gripMaxDP,
            ushort gripMaxPP,
            ushort gripCurrentPP,
            ushort gripCurrentDP,
            byte gemSlotQuantity,
            byte gripStrStat,
            byte gripIntStat,
            byte gripAgiStat,
            byte gripBluntDefStat,
            byte gripEdgedDefStat,
            byte gripPiercingDefStat,
            byte gripHumanStat,
            byte gripBeastStat,
            byte gripUndeadStat,
            byte gripPhantomStat,
            byte gripDragonStat,
            byte gripEvilStat,
            byte gripPhysicalStat,
            byte gripAirStat,
            byte gripFireStat,
            byte gripEarthStat,
            byte gripWaterStat,
            byte gripLightStat,
            byte gripDarkStat,
            ItemMaterials gripMaterial,
            byte inventoryGemSlotReference1,
            byte inventoryGemSlotReference2,
            byte inventoryGemSlotReference3
        )
        {
            GripName = name;
            GripInventorySlot = gripInventorySlot;
            GripEquipStatus = gripEquipStatus;
            GripID = Convert.ToByte(GripID);
            GripGemSlotQuantity = gemSlotQuantity;
            GripMaxDP = gripMaxDP;
            GripMaxPP = gripMaxPP;
            GripCurrentPP = gripCurrentPP;
            GripCurrentDP = gripCurrentDP;
            GripStrStat = gripStrStat;
            GripIntStat = gripIntStat;
            GripAgiStat = gripAgiStat;
            GripBluntDefStat = gripBluntDefStat;
            GripEdgedDefStat = gripEdgedDefStat;
            GripPiercingDefStat = gripPiercingDefStat;
            GripHumanStat = gripHumanStat;
            GripBeastStat = gripBeastStat;
            GripUndeadStat = gripUndeadStat;
            GripPhantomStat = gripPhantomStat;
            GripDragonStat = gripDragonStat;
            GripEvilStat = gripEvilStat;
            GripPhysicalStat = gripPhysicalStat;
            GripAirStat = gripAirStat;
            GripFireStat = gripFireStat;
            GripEarthStat = gripEarthStat;
            GripWaterStat = gripWaterStat;
            GripLightStat = gripLightStat;
            GripDarkStat = gripDarkStat;
            GripMaterial = (byte)GripMaterial;
            InventoryGemSlotReference1 = inventoryGemSlotReference1;
            InventoryGemSlotReference2 = inventoryGemSlotReference2;
            InventoryGemSlotReference3 = inventoryGemSlotReference3;
        }
    }
}