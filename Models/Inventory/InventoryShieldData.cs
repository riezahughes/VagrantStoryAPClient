using Archipelago.Core.Util;
using VagrantStoryArchipelago.Enums;
namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryShieldData
    {

        // IMPORTANT NOTE - THESE WON'T UPDATE IF YOU HAVE THE ITEM EQUIPPED. THEY ARE THEN STORED IN DIFFERENT SLOTS TO THIS AND THIS IS JUST A DUPLICATE
        public string ShieldName { get; set; }
        [MemoryOffset(0x00)]  // 0x607cf - Shield Slot
        public byte ShieldInventorySlot { get; set; }

        [MemoryOffset(0x01)]  // 0x607f6 - Equip Status
        public byte ShieldEquipStatus { get; set; }

        [MemoryOffset(0x04)]  // 0x607d1 - Item ID (note: 16-bit, spans 0x02-0x03)
        public uint ShieldID { get; set; }

        [MemoryOffset(0x07)]  // 0x607d4 - Max DP start (16-bit)
        public ushort ShieldMaxDP { get; set; }

        [MemoryOffset(0x09)]  // 0x607d4 - Max DP start (16-bit)
        public ushort ShieldMaxPP { get; set; }

        [MemoryOffset(0x0b)]  // 0x607d8 - Current DP
        public ushort ShieldCurrentPP { get; set; }

        [MemoryOffset(0x0d)]  // 0x607d8 - Current DP
        public ushort ShieldCurrentDP { get; set; }

        [MemoryOffset(0x10)]  // 0x607dd - STR
        public byte ShieldGemSlotQuantity { get; set; }

        [MemoryOffset(0x11)]  // 0x607dd - STR
        public byte ShieldStrStat { get; set; }

        [MemoryOffset(0x12)]  // 0x607de - INT
        public byte ShieldIntStat { get; set; }

        [MemoryOffset(0x13)]  // 0x607df - AGI
        public byte ShieldAgiStat { get; set; }

        [MemoryOffset(0x14)]  // 0x607e1 - Blunt
        public byte ShieldBluntDefStat { get; set; }

        [MemoryOffset(0x15)]  // 0x607e2 - Edged
        public byte ShieldEdgedDefStat { get; set; }

        [MemoryOffset(0x16)]  // 0x607e3 - Piercing
        public byte ShieldPiercingDefStat { get; set; }

        [MemoryOffset(0x18)]  // 0x607e4 - Human
        public byte ShieldHumanStat { get; set; }

        [MemoryOffset(0x19)]  // 0x607e5 - Beast
        public byte ShieldBeastStat { get; set; }

        [MemoryOffset(0x1a)]  // 0x607e6 - Undead
        public byte ShieldUndeadStat { get; set; }

        [MemoryOffset(0x1b)]  // 0x607e7 - Phantom
        public byte ShieldPhantomStat { get; set; }

        [MemoryOffset(0x1c)]  // 0x607e8 - Dragon
        public byte ShieldDragonStat { get; set; }

        [MemoryOffset(0x1d)]  // 0x607e9 - Evil
        public byte ShieldEvilStat { get; set; }

        [MemoryOffset(0x20)]  // 0x607ec - Physical
        public byte ShieldPhysicalStat { get; set; }

        [MemoryOffset(0x21)]  // 0x607ed - Air
        public byte ShieldAirStat { get; set; }

        [MemoryOffset(0x22)]  // 0x607ee - Fire
        public byte ShieldFireStat { get; set; }

        [MemoryOffset(0x23)]  // 0x607ef - Earth
        public byte ShieldEarthStat { get; set; }

        [MemoryOffset(0x24)]  // 0x607f0 - Water
        public byte ShieldWaterStat { get; set; }

        [MemoryOffset(0x25)]  // 0x607f1 - Light
        public byte ShieldLightStat { get; set; }

        [MemoryOffset(0x26)]  // 0x607f2 - Dark
        public byte ShieldDarkStat { get; set; }

        [MemoryOffset(0x28)]  // 0x607f4 - Material
        public byte ShieldMaterial { get; set; }

        [MemoryOffset(0x2c)]  // 0x607f4 - Gem slot reference 1
        public byte InventoryGemSlotReference1 { get; set; }
        [MemoryOffset(0x2d)]  // 0x607f4 - Gem slot reference 2
        public byte InventoryGemSlotReference2 { get; set; }
        [MemoryOffset(0x2e)]  // 0x607f4 - Gem slot reference 3
        public byte InventoryGemSlotReference3 { get; set; }

        public InventoryShieldData(
            string name,
            byte shieldInventorySlot,
            byte shieldEquipStatus,
            ShieldID shieldID,
            ushort shieldMaxDP,
            ushort shieldMaxPP,
            ushort shieldCurrentPP,
            ushort shieldCurrentDP,
            byte gemSlotQuantity,
            byte shieldStrStat,
            byte shieldIntStat,
            byte shieldAgiStat,
            byte shieldBluntDefStat,
            byte shieldEdgedDefStat,
            byte shieldPiercingDefStat,
            byte shieldHumanStat,
            byte shieldBeastStat,
            byte shieldUndeadStat,
            byte shieldPhantomStat,
            byte shieldDragonStat,
            byte shieldEvilStat,
            byte shieldPhysicalStat,
            byte shieldAirStat,
            byte shieldFireStat,
            byte shieldEarthStat,
            byte shieldWaterStat,
            byte shieldLightStat,
            byte shieldDarkStat,
            ItemMaterials shieldMaterial,
            byte inventoryGemSlotReference1,
            byte inventoryGemSlotReference2,
            byte inventoryGemSlotReference3
        )
        {
            ShieldName = name;
            ShieldInventorySlot = shieldInventorySlot;
            ShieldEquipStatus = shieldEquipStatus;
            ShieldID = Convert.ToByte(shieldID);
            ShieldGemSlotQuantity = gemSlotQuantity;
            ShieldMaxDP = shieldMaxDP;
            ShieldMaxPP = shieldMaxPP;
            ShieldCurrentPP = shieldCurrentPP;
            ShieldCurrentDP = shieldCurrentDP;
            ShieldStrStat = shieldStrStat;
            ShieldIntStat = shieldIntStat;
            ShieldAgiStat = shieldAgiStat;
            ShieldBluntDefStat = shieldBluntDefStat;
            ShieldEdgedDefStat = shieldEdgedDefStat;
            ShieldPiercingDefStat = shieldPiercingDefStat;
            ShieldHumanStat = shieldHumanStat;
            ShieldBeastStat = shieldBeastStat;
            ShieldUndeadStat = shieldUndeadStat;
            ShieldPhantomStat = shieldPhantomStat;
            ShieldDragonStat = shieldDragonStat;
            ShieldEvilStat = shieldEvilStat;
            ShieldPhysicalStat = shieldPhysicalStat;
            ShieldAirStat = shieldAirStat;
            ShieldFireStat = shieldFireStat;
            ShieldEarthStat = shieldEarthStat;
            ShieldWaterStat = shieldWaterStat;
            ShieldLightStat = shieldLightStat;
            ShieldDarkStat = shieldDarkStat;
            ShieldMaterial = (byte)shieldMaterial;
            InventoryGemSlotReference1 = inventoryGemSlotReference1;
            InventoryGemSlotReference2 = inventoryGemSlotReference2;
            InventoryGemSlotReference3 = inventoryGemSlotReference3;
        }
    }
}