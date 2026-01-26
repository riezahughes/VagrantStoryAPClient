using Archipelago.Core.Util;
using VagrantStoryArchipelago.Enums;
namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryArmorData
    {

        // IMPORTANT NOTE - THESE WON'T UPDATE IF YOU HAVE THE ITEM EQUIPPED. THEY ARE THEN STORED IN DIFFERENT SLOTS TO THIS AND THIS IS JUST A DUPLICATE
        public string ArmorName { get; set; }
        [MemoryOffset(0x00)]  // 0x607cf - Armor Slot
        public byte ArmorInventorySlot { get; set; }

        [MemoryOffset(0x01)]  // 0x607d1 - Item ID (note: 16-bit, spans 0x02-0x03)
        public uint ArmorID { get; set; }

        [MemoryOffset(0x04)]  // 0x607d3 - Type
        public byte ArmorType { get; set; }

        [MemoryOffset(0x05)]  // 0x607d4 - Max DP start (16-bit)
        public ushort ArmorMaxDP { get; set; }

        [MemoryOffset(0x09)]  // 0x607d8 - Current DP
        public byte ArmorCurrentDP { get; set; }

        [MemoryOffset(0x0e)]  // 0x607dd - STR
        public byte ArmorStrStat { get; set; }

        [MemoryOffset(0x0f)]  // 0x607de - INT
        public byte ArmorIntStat { get; set; }

        [MemoryOffset(0x10)]  // 0x607df - AGI
        public byte ArmorAgiStat { get; set; }

        [MemoryOffset(0x12)]  // 0x607e1 - Blunt
        public byte ArmorBluntDefStat { get; set; }

        [MemoryOffset(0x13)]  // 0x607e2 - Edged
        public byte ArmorEdgedDefStat { get; set; }

        [MemoryOffset(0x14)]  // 0x607e3 - Piercing
        public byte ArmorPiercingDefStat { get; set; }

        [MemoryOffset(0x15)]  // 0x607e4 - Human
        public byte ArmorHumanStat { get; set; }

        [MemoryOffset(0x16)]  // 0x607e5 - Beast
        public byte ArmorBeastStat { get; set; }

        [MemoryOffset(0x17)]  // 0x607e6 - Undead
        public byte ArmorUndeadStat { get; set; }

        [MemoryOffset(0x18)]  // 0x607e7 - Phantom
        public byte ArmorPhantomStat { get; set; }

        [MemoryOffset(0x19)]  // 0x607e8 - Dragon
        public byte ArmorDragonStat { get; set; }

        [MemoryOffset(0x1a)]  // 0x607e9 - Evil
        public byte ArmorEvilStat { get; set; }

        [MemoryOffset(0x1d)]  // 0x607ec - Physical
        public byte ArmorPhysicalStat { get; set; }

        [MemoryOffset(0x1e)]  // 0x607ed - Air
        public byte ArmorAirStat { get; set; }

        [MemoryOffset(0x1f)]  // 0x607ee - Fire
        public byte ArmorFireStat { get; set; }

        [MemoryOffset(0x20)]  // 0x607ef - Earth
        public byte ArmorEarthStat { get; set; }

        [MemoryOffset(0x21)]  // 0x607f0 - Water
        public byte ArmorWaterStat { get; set; }

        [MemoryOffset(0x22)]  // 0x607f1 - Light
        public byte ArmorLightStat { get; set; }

        [MemoryOffset(0x23)]  // 0x607f2 - Dark
        public byte ArmorDarkStat { get; set; }

        [MemoryOffset(0x25)]  // 0x607f4 - Material
        public byte ArmorMaterial { get; set; }

        [MemoryOffset(0x27)]  // 0x607f6 - Equip Status
        public byte ArmorEquipStatus { get; set; }

        public InventoryArmorData(
            string name,
            byte armorInventorySlot,
            object armorID,
            ArmorType armorType,
            ushort armorMaxDP,
            byte armorCurrentDP,
            byte armorStrStat,
            byte armorIntStat,
            byte armorAgiStat,
            byte armorBluntDefStat,
            byte armorEdgedDefStat,
            byte armorPiercingDefStat,
            byte armorHumanStat,
            byte armorBeastStat,
            byte armorUndeadStat,
            byte armorPhantomStat,
            byte armorDragonStat,
            byte armorEvilStat,
            byte armorPhysicalStat,
            byte armorAirStat,
            byte armorFireStat,
            byte armorEarthStat,
            byte armorWaterStat,
            byte armorLightStat,
            byte armorDarkStat,
            ArmorMaterials armorMaterial,
            byte armorEquipStatus
        )
        {
            ArmorName = name;
            ArmorInventorySlot = armorInventorySlot;
            ArmorID = Convert.ToByte(armorID);
            ArmorType = (byte)armorType;
            ArmorMaxDP = armorMaxDP;
            ArmorCurrentDP = armorCurrentDP;
            ArmorStrStat = armorStrStat;
            ArmorIntStat = armorIntStat;
            ArmorAgiStat = armorAgiStat;
            ArmorBluntDefStat = armorBluntDefStat;
            ArmorEdgedDefStat = armorEdgedDefStat;
            ArmorPiercingDefStat = armorPiercingDefStat;
            ArmorHumanStat = armorHumanStat;
            ArmorBeastStat = armorBeastStat;
            ArmorUndeadStat = armorUndeadStat;
            ArmorPhantomStat = armorPhantomStat;
            ArmorDragonStat = armorDragonStat;
            ArmorEvilStat = armorEvilStat;
            ArmorPhysicalStat = armorPhysicalStat;
            ArmorAirStat = armorAirStat;
            ArmorFireStat = armorFireStat;
            ArmorEarthStat = armorEarthStat;
            ArmorWaterStat = armorWaterStat;
            ArmorLightStat = armorLightStat;
            ArmorDarkStat = armorDarkStat;
            ArmorMaterial = (byte)armorMaterial;
            ArmorEquipStatus = armorEquipStatus;
        }
    }
}