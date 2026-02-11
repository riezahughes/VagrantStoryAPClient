using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.MapData
{
    public class MapChestData
    {
        // --- WEAPON BLADE (+$000) ---
        [MemoryOffset(0x00)]
        public uint WeaponExists { get; set; }
        [MemoryOffset(0x04)]
        public byte WeaponItemNameIndex { get; set; }
        [MemoryOffset(0x05)]
        public byte WeaponItemIndex { get; set; }
        [MemoryOffset(0x06)]
        public byte WeaponFileIndex { get; set; }
        [MemoryOffset(0x07)]
        public byte WeaponCategory { get; set; }
        [MemoryOffset(0x08)]
        public ushort WeaponDPMax { get; set; }
        [MemoryOffset(0x0A)]
        public ushort WeaponPPMax { get; set; }
        [MemoryOffset(0x0C)]
        public ushort WeaponDPCurrent { get; set; }
        [MemoryOffset(0x0E)]
        public ushort WeaponPPCurrent { get; set; }
        [MemoryOffset(0x10)]
        public byte WeaponSTR { get; set; }
        [MemoryOffset(0x11)]
        public byte WeaponINT { get; set; }
        [MemoryOffset(0x12)]
        public byte WeaponAGL { get; set; }
        [MemoryOffset(0x13)]
        public byte WeaponCost { get; set; }
        [MemoryOffset(0x14)]
        public byte WeaponDamageTypeStats { get; set; }
        [MemoryOffset(0x18)]
        public uint WeaponRange { get; set; }
        [MemoryOffset(0x1C)]
        public ulong WeaponClasses { get; set; }
        [MemoryOffset(0x24)]
        public ulong WeaponAffinities { get; set; }
        [MemoryOffset(0x2C)]
        public ushort WeaponMaterial { get; set; }

        // --- WEAPON GRIP (+$030) ---
        [MemoryOffset(0x30)]
        public ushort GripItemNameIndex { get; set; }
        [MemoryOffset(0x32)]
        public byte GripItemIndex { get; set; }
        [MemoryOffset(0x33)]
        public byte GripCategory { get; set; }
        [MemoryOffset(0x34)]
        public byte GripGemSlots { get; set; }
        [MemoryOffset(0x35)]
        public byte GripSTR { get; set; }
        [MemoryOffset(0x36)]
        public byte GripINT { get; set; }
        [MemoryOffset(0x37)]
        public byte GripAGL { get; set; }
        [MemoryOffset(0x38)]
        public uint GripTypes { get; set; }

        // --- WEAPON GEMS (+$040, +$05C, +$078) ---
        // Gem 1
        [MemoryOffset(0x40)]
        public ushort WGem1_NameIndex { get; set; }
        [MemoryOffset(0x42)]
        public byte WGem1_ItemIndex { get; set; }
        [MemoryOffset(0x44)]
        public byte WGem1_SpecialEffect { get; set; }
        [MemoryOffset(0x45)]
        public byte WGem1_STR { get; set; }
        [MemoryOffset(0x46)]
        public byte WGem1_INT { get; set; }
        [MemoryOffset(0x47)]
        public byte WGem1_AGL { get; set; }
        [MemoryOffset(0x48)]
        public ulong WGem1_Classes { get; set; }
        [MemoryOffset(0x50)]
        public ulong WGem1_Affinities { get; set; }

        // Gem 2
        [MemoryOffset(0x5C)]
        public ushort WGem2_NameIndex { get; set; }
        [MemoryOffset(0x5E)]
        public byte WGem2_ItemIndex { get; set; }
        [MemoryOffset(0x60)]
        public byte WGem2_SpecialEffect { get; set; }
        [MemoryOffset(0x61)]
        public byte WGem2_STR { get; set; }
        [MemoryOffset(0x62)]
        public byte WGem2_INT { get; set; }
        [MemoryOffset(0x63)]
        public byte WGem2_AGL { get; set; }
        [MemoryOffset(0x64)]
        public ulong WGem2_Classes { get; set; }
        [MemoryOffset(0x6C)]
        public ulong WGem2_Affinities { get; set; }

        // Gem 3
        [MemoryOffset(0x78)]
        public ushort WGem3_NameIndex { get; set; }
        [MemoryOffset(0x7A)]
        public byte WGem3_ItemIndex { get; set; }
        [MemoryOffset(0x7C)]
        public byte WGem3_SpecialEffect { get; set; }
        [MemoryOffset(0x7D)]
        public byte WGem3_STR { get; set; }
        [MemoryOffset(0x7E)]
        public byte WGem3_INT { get; set; }
        [MemoryOffset(0x7F)]
        public byte WGem3_AGL { get; set; }
        [MemoryOffset(0x80)]
        public ulong WGem3_Classes { get; set; }
        [MemoryOffset(0x88)]
        public ulong WGem3_Affinities { get; set; }

        // --- WEAPON NAME SKIPPED (causes alignment issues) ---
        // [MemoryOffset(0x94)]
        // public string WeaponName { get; set; } // Length $18

        // --- STANDALONE BLADE (+$0AC) ---
        [MemoryOffset(0xAC)]
        public uint BladeExists { get; set; }
        [MemoryOffset(0xB0)]
        public byte BladeItemNameIndex { get; set; }
        [MemoryOffset(0xB1)]
        public byte BladeItemIndex { get; set; }
        [MemoryOffset(0xB2)]
        public byte BladeFileIndex { get; set; }
        [MemoryOffset(0xB3)]
        public byte BladeCategory { get; set; }
        [MemoryOffset(0xB4)]
        public ushort BladeDPMax { get; set; }
        [MemoryOffset(0xB6)]
        public ushort BladePPMax { get; set; }
        [MemoryOffset(0xB8)]
        public ushort BladeDPCurrent { get; set; }
        [MemoryOffset(0xBA)]
        public ushort BladePPCurrent { get; set; }
        [MemoryOffset(0xBC)]
        public byte BladeSTR { get; set; }
        [MemoryOffset(0xBD)]
        public byte BladeINT { get; set; }
        [MemoryOffset(0xBE)]
        public byte BladeAGL { get; set; }
        [MemoryOffset(0xBF)]
        public byte BladeCost { get; set; }
        [MemoryOffset(0xC0)]
        public byte BladeDamageTypeStats { get; set; }
        [MemoryOffset(0xC4)]
        public uint BladeRange { get; set; }
        [MemoryOffset(0xC8)]
        public ulong BladeClasses { get; set; }
        [MemoryOffset(0xD0)]
        public ulong BladeAffinities { get; set; }
        [MemoryOffset(0xD8)]
        public ushort BladeMaterial { get; set; }

        // --- STANDALONE GRIP (+$0CC) ---
        [MemoryOffset(0xDC)]
        public uint GripStandaloneExists { get; set; }
        [MemoryOffset(0xE0)]
        public ushort GripStandaloneNameIndex { get; set; }
        [MemoryOffset(0xE2)]
        public byte GripStandaloneItemIndex { get; set; }
        [MemoryOffset(0xE3)]
        public byte GripStandaloneCategory { get; set; }
        [MemoryOffset(0xE4)]
        public byte GripStandaloneGemSlots { get; set; }
        [MemoryOffset(0xE5)]
        public byte GripStandaloneSTR { get; set; }
        [MemoryOffset(0xE6)]
        public byte GripStandaloneINT { get; set; }
        [MemoryOffset(0xE7)]
        public byte GripStandaloneAGL { get; set; }
        [MemoryOffset(0xE8)]
        public uint GripStandaloneTypes { get; set; }

        // --- SHIELD (+$0EC) ---
        [MemoryOffset(0xEC)]
        public uint ShieldExists { get; set; }
        [MemoryOffset(0xF0)]
        public byte ShieldItemNameIndex { get; set; }
        [MemoryOffset(0xF1)]
        public byte ShieldItemIndex { get; set; }
        [MemoryOffset(0xF2)]
        public byte ShieldFileIndex { get; set; }
        [MemoryOffset(0xF3)]
        public byte ShieldCategory { get; set; }
        [MemoryOffset(0xF4)]
        public ushort ShieldDPMax { get; set; }
        [MemoryOffset(0xF6)]
        public ushort ShieldPPMax { get; set; }
        [MemoryOffset(0xF8)]
        public ushort ShieldDPCurrent { get; set; }
        [MemoryOffset(0xFA)]
        public ushort ShieldPPCurrent { get; set; }
        [MemoryOffset(0xFC)]
        public byte ShieldGemSlots { get; set; }
        [MemoryOffset(0xFD)]
        public byte ShieldSTR { get; set; }
        [MemoryOffset(0xFE)]
        public byte ShieldINT { get; set; }
        [MemoryOffset(0xFF)]
        public byte ShieldAGL { get; set; }
        [MemoryOffset(0x104)]
        public uint ShieldTypes { get; set; }
        [MemoryOffset(0x108)]
        public ulong ShieldClasses { get; set; }
        [MemoryOffset(0x110)]
        public ulong ShieldAffinities { get; set; }
        [MemoryOffset(0x118)]
        public ushort ShieldMaterial { get; set; }

        // --- SHIELD GEMS ---
        [MemoryOffset(0x12C)]
        public ushort ShieldGem1_NameIndex { get; set; }
        [MemoryOffset(0x12E)]
        public byte ShieldGem1_ItemIndex { get; set; }
        [MemoryOffset(0x130)]
        public byte ShieldGem1_SpecialEffect { get; set; }
        [MemoryOffset(0x131)]
        public byte ShieldGem1_STR { get; set; }
        [MemoryOffset(0x132)]
        public byte ShieldGem1_INT { get; set; }
        [MemoryOffset(0x133)]
        public byte ShieldGem1_AGL { get; set; }
        [MemoryOffset(0x134)]
        public ulong ShieldGem1_Classes { get; set; }
        [MemoryOffset(0x13C)]
        public ulong ShieldGem1_Affinities { get; set; }

        [MemoryOffset(0x148)]
        public ushort ShieldGem2_NameIndex { get; set; }
        [MemoryOffset(0x14A)]
        public byte ShieldGem2_ItemIndex { get; set; }
        [MemoryOffset(0x14C)]
        public byte ShieldGem2_SpecialEffect { get; set; }
        [MemoryOffset(0x14D)]
        public byte ShieldGem2_STR { get; set; }
        [MemoryOffset(0x14E)]
        public byte ShieldGem2_INT { get; set; }
        [MemoryOffset(0x14F)]
        public byte ShieldGem2_AGL { get; set; }
        [MemoryOffset(0x150)]
        public ulong ShieldGem2_Classes { get; set; }
        [MemoryOffset(0x158)]
        public ulong ShieldGem2_Affinities { get; set; }

        [MemoryOffset(0x164)]
        public ushort ShieldGem3_NameIndex { get; set; }
        [MemoryOffset(0x166)]
        public byte ShieldGem3_ItemIndex { get; set; }
        [MemoryOffset(0x168)]
        public byte ShieldGem3_SpecialEffect { get; set; }
        [MemoryOffset(0x169)]
        public byte ShieldGem3_STR { get; set; }
        [MemoryOffset(0x16A)]
        public byte ShieldGem3_INT { get; set; }
        [MemoryOffset(0x16B)]
        public byte ShieldGem3_AGL { get; set; }
        [MemoryOffset(0x16C)]
        public ulong ShieldGem3_Classes { get; set; }
        [MemoryOffset(0x174)]
        public ulong ShieldGem3_Affinities { get; set; }

        // --- ARMOR 1 ---
        [MemoryOffset(0x180)]
        public uint Armor1Exists { get; set; }
        [MemoryOffset(0x184)]
        public byte Armor1_NameIndex { get; set; }
        [MemoryOffset(0x185)]
        public byte Armor1_ItemIndex { get; set; }
        [MemoryOffset(0x187)]
        public byte Armor1_Category { get; set; }
        [MemoryOffset(0x188)]
        public ushort Armor1_DPMax { get; set; }
        [MemoryOffset(0x18A)]
        public ushort Armor1_PPMax { get; set; }
        [MemoryOffset(0x18C)]
        public ushort Armor1_DPCurrent { get; set; }
        [MemoryOffset(0x18E)]
        public ushort Armor1_PPCurrent { get; set; }
        [MemoryOffset(0x191)]
        public byte Armor1_STR { get; set; }
        [MemoryOffset(0x192)]
        public byte Armor1_INT { get; set; }
        [MemoryOffset(0x193)]
        public byte Armor1_AGL { get; set; }
        [MemoryOffset(0x198)]
        public uint Armor1_Types { get; set; }
        [MemoryOffset(0x19C)]
        public ulong Armor1_Classes { get; set; }
        [MemoryOffset(0x1A4)]
        public ulong Armor1_Affinities { get; set; }
        [MemoryOffset(0x1AC)]
        public ushort Armor1_Material { get; set; }

        // --- ARMOR 2 ---
        [MemoryOffset(0x1B0)]
        public uint Armor2Exists { get; set; }
        [MemoryOffset(0x1B4)]
        public byte Armor2_NameIndex { get; set; }
        [MemoryOffset(0x1B5)]
        public byte Armor2_ItemIndex { get; set; }
        [MemoryOffset(0x1B7)]
        public byte Armor2_Category { get; set; }
        [MemoryOffset(0x1B8)]
        public ushort Armor2_DPMax { get; set; }
        [MemoryOffset(0x1BA)]
        public ushort Armor2_PPMax { get; set; }
        [MemoryOffset(0x1BC)]
        public ushort Armor2_DPCurrent { get; set; }
        [MemoryOffset(0x1BE)]
        public ushort Armor2_PPCurrent { get; set; }
        [MemoryOffset(0x1C1)]
        public byte Armor2_STR { get; set; }
        [MemoryOffset(0x1C2)]
        public byte Armor2_INT { get; set; }
        [MemoryOffset(0x1C3)]
        public byte Armor2_AGL { get; set; }
        [MemoryOffset(0x1C8)]
        public uint Armor2_Types { get; set; }
        [MemoryOffset(0x1CC)]
        public ulong Armor2_Classes { get; set; }
        [MemoryOffset(0x1D4)]
        public ulong Armor2_Affinities { get; set; }
        [MemoryOffset(0x1DC)]
        public ushort Armor2_Material { get; set; }

        // --- ACCESSORY ---
        [MemoryOffset(0x1E0)]
        public uint AccessoryExists { get; set; }
        [MemoryOffset(0x1E4)]
        public byte Accessory_NameIndex { get; set; }
        [MemoryOffset(0x1E5)]
        public byte Accessory_ItemIndex { get; set; }
        [MemoryOffset(0x1E7)]
        public byte Accessory_Category { get; set; }
        [MemoryOffset(0x1E8)]
        public ushort Accessory_DPMax { get; set; }
        [MemoryOffset(0x1EA)]
        public ushort Accessory_PPMax { get; set; }
        [MemoryOffset(0x1EC)]
        public ushort Accessory_DPCurrent { get; set; }
        [MemoryOffset(0x1EE)]
        public ushort Accessory_PPCurrent { get; set; }
        [MemoryOffset(0x1F1)]
        public byte Accessory_STR { get; set; }
        [MemoryOffset(0x1F2)]
        public byte Accessory_INT { get; set; }
        [MemoryOffset(0x1F3)]
        public byte Accessory_AGL { get; set; }
        [MemoryOffset(0x1F8)]
        public uint Accessory_Types { get; set; }
        [MemoryOffset(0x1FC)]
        public ulong Accessory_Classes { get; set; }
        [MemoryOffset(0x204)]
        public ulong Accessory_Affinities { get; set; }

        // --- STANDALONE GEM ---
        [MemoryOffset(0x210)]
        public uint GemExists { get; set; }
        [MemoryOffset(0x214)]
        public ushort Gem_NameIndex { get; set; }
        [MemoryOffset(0x216)]
        public byte Gem_ItemIndex { get; set; }
        [MemoryOffset(0x218)]
        public byte Gem_SpecialEffect { get; set; }
        [MemoryOffset(0x219)]
        public byte Gem_STR { get; set; }
        [MemoryOffset(0x21A)]
        public byte Gem_INT { get; set; }
        [MemoryOffset(0x21B)]
        public byte Gem_AGL { get; set; }
        [MemoryOffset(0x21C)]
        public ulong Gem_Classes { get; set; }
        [MemoryOffset(0x224)]
        public ulong Gem_Affinities { get; set; }

        // --- MISC ITEMS (+$214 from doc, but documentation says +$220) ---
        [MemoryOffset(0x214)]
        public ushort Misc1_ID { get; set; }
        [MemoryOffset(0x215)]
        public byte Misc1_Confirm { get; set; }

        [MemoryOffset(0x216)]
        public byte Misc1_Exists { get; set; }
        [MemoryOffset(0x217)]
        public byte Misc1_Qty { get; set; }

        [MemoryOffset(0x218)]
        public ushort Misc2_ID { get; set; }
        [MemoryOffset(0x219)]
        public byte Misc2_Confirm { get; set; }
        [MemoryOffset(0x21A)]
        public byte Misc2_Exists { get; set; }
        [MemoryOffset(0x21B)]
        public byte Misc2_Qty { get; set; }

        [MemoryOffset(0x21C)]
        public ushort Misc3_ID { get; set; }
        [MemoryOffset(0x21D)]
        public byte Misc3_Confirm { get; set; }

        [MemoryOffset(0x21E)]
        public byte Misc3_Exists { get; set; }
        [MemoryOffset(0x21F)]
        public byte Misc3_Qty { get; set; }

        [MemoryOffset(0x220)]
        public ushort Misc4_ID { get; set; }
        [MemoryOffset(0x221)]
        public byte Misc4_Confirm { get; set; }
        [MemoryOffset(0x222)]
        public byte Misc4_Exists { get; set; }
        [MemoryOffset(0x223)]
        public byte Misc4_Qty { get; set; }
    }
}