using Archipelago.Core.Util;
using VagrantStoryArchipelago.Enums;
namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryArmorData
    {
        public string ArmorName { get; set; }
        [MemoryOffset(0x00)]
        public byte ArmorID { get; set; }
        [MemoryOffset(0x01)]
        public byte ArmorType { get; set; }
        [MemoryOffset(0x02)]
        public ushort ArmorMaxDP { get; set; }  // 16-bit value
        [MemoryOffset(0x06)]
        public byte ArmorCurrentDP { get; set; }
        [MemoryOffset(0x0b)]
        public byte ArmorStrStat { get; set; }
        [MemoryOffset(0x0c)]
        public byte ArmorIntStat { get; set; }
        [MemoryOffset(0x0d)]
        public byte ArmorAgiStat { get; set; }
        [MemoryOffset(0x0f)]
        public byte ArmorBluntDefStat { get; set; }
        [MemoryOffset(0x10)]
        public byte ArmorEdgedDefStat { get; set; }
        [MemoryOffset(0x11)]
        public byte ArmorPiercingDefStat { get; set; }
        [MemoryOffset(0x12)]
        public byte ArmorHumanStat { get; set; }
        [MemoryOffset(0x13)]
        public byte ArmorBeastStat { get; set; }
        [MemoryOffset(0x14)]
        public byte ArmorUndeadStat { get; set; }
        [MemoryOffset(0x15)]
        public byte ArmorPhantomStat { get; set; }
        [MemoryOffset(0x16)]
        public byte ArmorDragonStat { get; set; }
        [MemoryOffset(0x17)]
        public byte ArmorEvilStat { get; set; }
        [MemoryOffset(0x1a)]
        public byte ArmorPhysicalStat { get; set; }
        [MemoryOffset(0x1b)]
        public byte ArmorAirStat { get; set; }
        [MemoryOffset(0x1c)]
        public byte ArmorFireStat { get; set; }
        [MemoryOffset(0x1d)]
        public byte ArmorEarthStat { get; set; }
        [MemoryOffset(0x1e)]
        public byte ArmorWaterStat { get; set; }
        [MemoryOffset(0x1f)]
        public byte ArmorLightStat { get; set; }
        [MemoryOffset(0x20)]
        public byte ArmorDarkStat { get; set; }
        [MemoryOffset(0x22)]
        public byte ArmorMaterial { get; set; }
        [MemoryOffset(0x24)]
        public byte ArmorEquipStatus { get; set; }  // 00 = Not equipped, 01 = Slot 1, 02 = Slot 2

        public InventoryArmorData(
            string name,
            byte armorID,
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
            ArmorID = armorID;
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