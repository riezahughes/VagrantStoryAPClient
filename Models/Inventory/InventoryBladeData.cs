using Archipelago.Core.Util;
using VagrantStoryArchipelago.Enums;
using VagrantStoryArchipelago.Helpers.EntityLists;
namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryBladeData
    {

        // IMPORTANT NOTE - THESE WON'T UPDATE IF YOU HAVE THE ITEM EQUIPPED. THEY ARE THEN STORED IN DIFFERENT SLOTS TO THIS AND THIS IS JUST A DUPLICATE
        public string BladeName { get; set; }

        // Record layout = vs_main_inventoryBlade in rood-reverse (0x2C bytes); checked against blades in the maps' chest loot.
        [MemoryOffset(0x00)]  // Item ID in the low byte, sub id in the high byte. The game always stores the same value in both.
        public ushort BladeID { get; set; }

        [MemoryOffset(0x02)]  // wepId: model of the blade. 0 means no model is loaded for the assembled weapon.
        public byte BladeWepId { get; set; }

        [MemoryOffset(0x03)]  // Blade Type
        public byte BladeType { get; set; }

        [MemoryOffset(0x04)]  // Max DP (16-bit)
        public ushort BladeMaxDP { get; set; }

        [MemoryOffset(0x06)]  // Max PP (16-bit)
        public ushort BladeMaxPP { get; set; }

        [MemoryOffset(0x08)]  // Current DP
        public ushort BladeCurrentDP { get; set; }

        [MemoryOffset(0x0a)]  // Current PP
        public ushort BladeCurrentPP { get; set; }

        [MemoryOffset(0x0c)]  // STR
        public byte BladeStrStat { get; set; }

        [MemoryOffset(0x0d)]  // INT
        public byte BladeIntStat { get; set; }

        [MemoryOffset(0x0e)]  // AGI
        public byte BladeAgiStat { get; set; }

        [MemoryOffset(0x0f)]  // Risk (a single byte; this used to be a ushort that overlapped the damage type byte)
        public byte BladeRiskStat { get; set; }

        [MemoryOffset(0x10)]  // bits 0-1 damage type (1 blunt, 2 edged, 3 piercing), bits 2-4 cost type (2 on every blade)
        public byte BladeDamageType { get; set; }

        [MemoryOffset(0x14)]  // range struct: range, two more range bytes, then the attack shape/angle bitfield
        public byte BladeRangeStat { get; set; }

        [MemoryOffset(0x15)]
        public byte BladeRangeUnk1 { get; set; }

        [MemoryOffset(0x16)]
        public byte BladeRangeUnk2 { get; set; }

        [MemoryOffset(0x17)]
        public byte BladeAttackShape { get; set; }

        [MemoryOffset(0x18)]  // Human
        public byte BladeHumanStat { get; set; }

        [MemoryOffset(0x19)]  // Beast
        public byte BladeBeastStat { get; set; }

        [MemoryOffset(0x1a)]  // Undead
        public byte BladeUndeadStat { get; set; }

        [MemoryOffset(0x1b)]  // Phantom
        public byte BladePhantomStat { get; set; }

        [MemoryOffset(0x1c)]  // Dragon
        public byte BladeDragonStat { get; set; }

        [MemoryOffset(0x1d)]  // Evil
        public byte BladeEvilStat { get; set; }

        [MemoryOffset(0x20)]  // Physical
        public byte BladePhysicalStat { get; set; }

        [MemoryOffset(0x21)]  // Air
        public byte BladeAirStat { get; set; }

        [MemoryOffset(0x22)]  // Fire
        public byte BladeFireStat { get; set; }

        [MemoryOffset(0x23)]  // Earth
        public byte BladeEarthStat { get; set; }

        [MemoryOffset(0x24)]  // Water
        public byte BladeWaterStat { get; set; }

        [MemoryOffset(0x25)]  // Light
        public byte BladeLightStat { get; set; }

        [MemoryOffset(0x26)]  // Dark
        public byte BladeDarkStat { get; set; }

        [MemoryOffset(0x28)]  // Material (u16 in the game, always < 8)
        public byte BladeMaterial { get; set; }

        [MemoryOffset(0x2a)]  // assembledWeaponIndex: which assembled weapon uses this blade, 0 for none
        public byte BladeEquipStatus { get; set; }

        [MemoryOffset(0x2b)]  // index: 1-based position in the blade inventory
        public byte BladeInventorySlot { get; set; }

        public InventoryBladeData(
            string name,
            DamageType damageType,
            BladeType bladeType,
            BladeID bladeID,
            ushort bladeMaxDP,
            ushort bladeMaxPP,
            ushort bladeCurrentDP,
            ushort bladeCurrentPP,
            byte bladeRiskStat,
            byte bladeStrStat,
            byte bladeIntStat,
            byte bladeAgiStat,
            byte bladeRangeStat,
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
            byte bladeEquipStatus,
            byte bladeInventorySlot
        )
        {
            BladeName = name;
            BladeDamageType = (byte)((byte)damageType | (2 << 2)); // damage type + cost type 2
            BladeType = Convert.ToByte(bladeType);
            byte id = Convert.ToByte(bladeID);
            BladeID = (ushort)(id | (id << 8));
            if (BladeBaseStats.ById.TryGetValue(bladeID, out var baseData))
            {
                BladeWepId = baseData.WepId;
                BladeRangeUnk1 = baseData.RangeUnk1;
                BladeRangeUnk2 = baseData.RangeUnk2;
                BladeAttackShape = baseData.AttackShape;
            }
            BladeMaxDP = bladeMaxDP;
            BladeMaxPP = bladeMaxPP;
            BladeCurrentDP = bladeCurrentDP;
            BladeCurrentPP = 0x0000;
            BladeRiskStat = bladeRiskStat;
            BladeStrStat = bladeStrStat;
            BladeIntStat = bladeIntStat;
            BladeAgiStat = bladeAgiStat;
            BladeRangeStat = bladeRangeStat;
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
            BladeEquipStatus = bladeEquipStatus;
            BladeInventorySlot = bladeInventorySlot;
        }
    }
}
