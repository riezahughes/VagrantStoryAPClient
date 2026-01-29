using Archipelago.Core.Util;
using VagrantStoryArchipelago.Enums;
namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryBladeData
    {

        // IMPORTANT NOTE - THESE WON'T UPDATE IF YOU HAVE THE ITEM EQUIPPED. THEY ARE THEN STORED IN DIFFERENT SLOTS TO THIS AND THIS IS JUST A DUPLICATE
        public string BladeName { get; set; }
        [MemoryOffset(0x00)]  // 0x607cf - Blade Slot
        public byte BladeInventorySlot { get; set; }

        [MemoryOffset(0x01)]  // 0x607d1 - Item ID (note: 16-bit, spans 0x02-0x03)
        public uint BladeID { get; set; }

        [MemoryOffset(0x01)]  // 0x607f6 - Equip Status
        public byte BladeEquipStatus { get; set; }


        [MemoryOffset(0x07)]  // 0x607d4 - Max DP start (16-bit)
        public ushort BladeMaxDP { get; set; }

        [MemoryOffset(0x09)]  // 0x607d4 - Max DP start (16-bit)
        public ushort BladeMaxPP { get; set; }

        [MemoryOffset(0x0b)]  // 0x607d8 - Current DP
        public ushort BladeCurrentPP { get; set; }

        [MemoryOffset(0x0d)]  // 0x607d8 - Current DP
        public ushort BladeCurrentDP { get; set; }

        [MemoryOffset(0x10)]  // 0x607dd - STR
        public byte BladeGemSlotQuantity { get; set; }

        [MemoryOffset(0x11)]  // 0x607dd - STR
        public byte BladeStrStat { get; set; }

        [MemoryOffset(0x12)]  // 0x607de - INT
        public byte BladeIntStat { get; set; }

        [MemoryOffset(0x13)]  // 0x607df - AGI
        public byte BladeAgiStat { get; set; }

        [MemoryOffset(0x14)]  // 0x607e1 - Blunt
        public byte BladeBluntDefStat { get; set; }

        [MemoryOffset(0x15)]  // 0x607e2 - Edged
        public byte BladeEdgedDefStat { get; set; }

        [MemoryOffset(0x16)]  // 0x607e3 - Piercing
        public byte BladePiercingDefStat { get; set; }

        [MemoryOffset(0x18)]  // 0x607e4 - Human
        public byte BladeHumanStat { get; set; }

        [MemoryOffset(0x19)]  // 0x607e5 - Beast
        public byte BladeBeastStat { get; set; }

        [MemoryOffset(0x1a)]  // 0x607e6 - Undead
        public byte BladeUndeadStat { get; set; }

        [MemoryOffset(0x1b)]  // 0x607e7 - Phantom
        public byte BladePhantomStat { get; set; }

        [MemoryOffset(0x1c)]  // 0x607e8 - Dragon
        public byte BladeDragonStat { get; set; }

        [MemoryOffset(0x1d)]  // 0x607e9 - Evil
        public byte BladeEvilStat { get; set; }

        [MemoryOffset(0x20)]  // 0x607ec - Physical
        public byte BladePhysicalStat { get; set; }

        [MemoryOffset(0x21)]  // 0x607ed - Air
        public byte BladeAirStat { get; set; }

        [MemoryOffset(0x22)]  // 0x607ee - Fire
        public byte BladeFireStat { get; set; }

        [MemoryOffset(0x23)]  // 0x607ef - Earth
        public byte BladeEarthStat { get; set; }

        [MemoryOffset(0x24)]  // 0x607f0 - Water
        public byte BladeWaterStat { get; set; }

        [MemoryOffset(0x25)]  // 0x607f1 - Light
        public byte BladeLightStat { get; set; }

        [MemoryOffset(0x26)]  // 0x607f2 - Dark
        public byte BladeDarkStat { get; set; }

        [MemoryOffset(0x28)]  // 0x607f4 - Material
        public byte BladeMaterial { get; set; }

        [MemoryOffset(0x2c)]  // 0x607f4 - Gem slot reference 1
        public byte InventoryGemSlotReference1 { get; set; }
        [MemoryOffset(0x2d)]  // 0x607f4 - Gem slot reference 2
        public byte InventoryGemSlotReference2 { get; set; }
        [MemoryOffset(0x2e)]  // 0x607f4 - Gem slot reference 3
        public byte InventoryGemSlotReference3 { get; set; }

        public InventoryBladeData(
            string name,
            byte bladeInventorySlot,
            byte bladeEquipStatus,
            BladeID bladeID,
            ushort bladeMaxDP,
            ushort bladeMaxPP,
            ushort bladeCurrentPP,
            ushort bladeCurrentDP,
            byte gemSlotQuantity,
            byte bladeStrStat,
            byte bladeIntStat,
            byte bladeAgiStat,
            byte bladeBluntDefStat,
            byte bladeEdgedDefStat,
            byte bladePiercingDefStat,
            byte bladeHumanStat,
            byte bladeBeastStat,
            byte bladeUndeadStat,
            byte bladePhantomStat,
            byte bladeDragonStat,
            byte bladeEvilStat,
            byte bladePhysicalStat,
            byte bladeAirStat,
            byte bladeFireStat,
            byte bladeEarthStat,
            byte bladeWaterStat,
            byte bladeLightStat,
            byte bladeDarkStat,
            ItemMaterials bladeMaterial,
            byte inventoryGemSlotReference1,
            byte inventoryGemSlotReference2,
            byte inventoryGemSlotReference3
        )
        {
            BladeName = name;
            BladeInventorySlot = bladeInventorySlot;
            BladeEquipStatus = bladeEquipStatus;
            BladeID = Convert.ToByte(bladeID);
            BladeGemSlotQuantity = gemSlotQuantity;
            BladeMaxDP = bladeMaxDP;
            BladeMaxPP = bladeMaxPP;
            BladeCurrentPP = bladeCurrentPP;
            BladeCurrentDP = bladeCurrentDP;
            BladeStrStat = bladeStrStat;
            BladeIntStat = bladeIntStat;
            BladeAgiStat = bladeAgiStat;
            BladeBluntDefStat = bladeBluntDefStat;
            BladeEdgedDefStat = bladeEdgedDefStat;
            BladePiercingDefStat = bladePiercingDefStat;
            BladeHumanStat = bladeHumanStat;
            BladeBeastStat = bladeBeastStat;
            BladeUndeadStat = bladeUndeadStat;
            BladePhantomStat = bladePhantomStat;
            BladeDragonStat = bladeDragonStat;
            BladeEvilStat = bladeEvilStat;
            BladePhysicalStat = bladePhysicalStat;
            BladeAirStat = bladeAirStat;
            BladeFireStat = bladeFireStat;
            BladeEarthStat = bladeEarthStat;
            BladeWaterStat = bladeWaterStat;
            BladeLightStat = bladeLightStat;
            BladeDarkStat = bladeDarkStat;
            BladeMaterial = (byte)bladeMaterial;
            InventoryGemSlotReference1 = inventoryGemSlotReference1;
            InventoryGemSlotReference2 = inventoryGemSlotReference2;
            InventoryGemSlotReference3 = inventoryGemSlotReference3;
        }
    }
}