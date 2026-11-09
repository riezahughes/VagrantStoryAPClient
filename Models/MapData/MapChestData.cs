using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.MapData
{
    /// <summary>
    /// A room's loot record (vs_battle_loot, 0x220 bytes) as the game copies it to room section 13 + 0x14. Offsets from the rood-reverse headers,
    /// checked with offsetof() on the compiled structs.
    /// </summary>
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

        // --- SHIELD (+$0F0) ---
        [MemoryOffset(0xF0)]  // difficulty flags / present marker of the entry
        public uint ShieldExists { get; set; }
        [MemoryOffset(0xF4)]
        public byte Shield_NameIndex { get; set; }
        [MemoryOffset(0xF5)]
        public byte Shield_ItemIndex { get; set; }
        [MemoryOffset(0xF6)]
        public byte Shield_FileIndex { get; set; }
        [MemoryOffset(0xF7)]
        public byte Shield_Category { get; set; }
        [MemoryOffset(0xF8)]
        public ushort Shield_DPMax { get; set; }
        [MemoryOffset(0xFA)]
        public ushort Shield_PPMax { get; set; }
        [MemoryOffset(0xFC)]
        public ushort Shield_DPCurrent { get; set; }
        [MemoryOffset(0xFE)]
        public ushort Shield_PPCurrent { get; set; }
        [MemoryOffset(0x100)]
        public byte Shield_GemSlots { get; set; }
        [MemoryOffset(0x101)]
        public byte Shield_STR { get; set; }
        [MemoryOffset(0x102)]
        public byte Shield_INT { get; set; }
        [MemoryOffset(0x103)]
        public byte Shield_AGL { get; set; }
        [MemoryOffset(0x104)]
        public uint Shield_Types { get; set; }
        [MemoryOffset(0x108)]
        public ulong Shield_Classes { get; set; }
        [MemoryOffset(0x110)]
        public ulong Shield_Affinities { get; set; }
        [MemoryOffset(0x118)]
        public ushort Shield_Material { get; set; }
        [MemoryOffset(0x11A)]
        public byte Shield_Limb { get; set; }
        [MemoryOffset(0x11B)]
        public byte Shield_Index { get; set; }

        // --- SHIELD GEM 1 ---
        [MemoryOffset(0x11C)]
        public ushort ShieldGem1_NameIndex { get; set; }
        [MemoryOffset(0x11E)]
        public byte ShieldGem1_ItemIndex { get; set; }
        [MemoryOffset(0x120)]
        public byte ShieldGem1_SpecialEffect { get; set; }
        [MemoryOffset(0x121)]
        public byte ShieldGem1_STR { get; set; }
        [MemoryOffset(0x122)]
        public byte ShieldGem1_INT { get; set; }
        [MemoryOffset(0x123)]
        public byte ShieldGem1_AGL { get; set; }
        [MemoryOffset(0x124)]
        public ulong ShieldGem1_Classes { get; set; }
        [MemoryOffset(0x12C)]
        public ulong ShieldGem1_Affinities { get; set; }
        [MemoryOffset(0x134)]
        public ushort ShieldGem1_SetItemIndex { get; set; }
        [MemoryOffset(0x136)]
        public ushort ShieldGem1_Index { get; set; }

        // --- SHIELD GEM 2 ---
        [MemoryOffset(0x138)]
        public ushort ShieldGem2_NameIndex { get; set; }
        [MemoryOffset(0x13A)]
        public byte ShieldGem2_ItemIndex { get; set; }
        [MemoryOffset(0x13C)]
        public byte ShieldGem2_SpecialEffect { get; set; }
        [MemoryOffset(0x13D)]
        public byte ShieldGem2_STR { get; set; }
        [MemoryOffset(0x13E)]
        public byte ShieldGem2_INT { get; set; }
        [MemoryOffset(0x13F)]
        public byte ShieldGem2_AGL { get; set; }
        [MemoryOffset(0x140)]
        public ulong ShieldGem2_Classes { get; set; }
        [MemoryOffset(0x148)]
        public ulong ShieldGem2_Affinities { get; set; }
        [MemoryOffset(0x150)]
        public ushort ShieldGem2_SetItemIndex { get; set; }
        [MemoryOffset(0x152)]
        public ushort ShieldGem2_Index { get; set; }

        // --- SHIELD GEM 3 ---
        [MemoryOffset(0x154)]
        public ushort ShieldGem3_NameIndex { get; set; }
        [MemoryOffset(0x156)]
        public byte ShieldGem3_ItemIndex { get; set; }
        [MemoryOffset(0x158)]
        public byte ShieldGem3_SpecialEffect { get; set; }
        [MemoryOffset(0x159)]
        public byte ShieldGem3_STR { get; set; }
        [MemoryOffset(0x15A)]
        public byte ShieldGem3_INT { get; set; }
        [MemoryOffset(0x15B)]
        public byte ShieldGem3_AGL { get; set; }
        [MemoryOffset(0x15C)]
        public ulong ShieldGem3_Classes { get; set; }
        [MemoryOffset(0x164)]
        public ulong ShieldGem3_Affinities { get; set; }
        [MemoryOffset(0x16C)]
        public ushort ShieldGem3_SetItemIndex { get; set; }
        [MemoryOffset(0x16E)]
        public ushort ShieldGem3_Index { get; set; }

        // --- ARMOR 1 (+$170) ---
        [MemoryOffset(0x170)]  // difficulty flags / present marker of the entry
        public uint Armor1Exists { get; set; }
        [MemoryOffset(0x174)]
        public byte Armor1_NameIndex { get; set; }
        [MemoryOffset(0x175)]
        public byte Armor1_ItemIndex { get; set; }
        [MemoryOffset(0x176)]
        public byte Armor1_FileIndex { get; set; }
        [MemoryOffset(0x177)]
        public byte Armor1_Category { get; set; }
        [MemoryOffset(0x178)]
        public ushort Armor1_DPMax { get; set; }
        [MemoryOffset(0x17A)]
        public ushort Armor1_PPMax { get; set; }
        [MemoryOffset(0x17C)]
        public ushort Armor1_DPCurrent { get; set; }
        [MemoryOffset(0x17E)]
        public ushort Armor1_PPCurrent { get; set; }
        [MemoryOffset(0x180)]
        public byte Armor1_GemSlots { get; set; }
        [MemoryOffset(0x181)]
        public byte Armor1_STR { get; set; }
        [MemoryOffset(0x182)]
        public byte Armor1_INT { get; set; }
        [MemoryOffset(0x183)]
        public byte Armor1_AGL { get; set; }
        [MemoryOffset(0x184)]
        public uint Armor1_Types { get; set; }
        [MemoryOffset(0x188)]
        public ulong Armor1_Classes { get; set; }
        [MemoryOffset(0x190)]
        public ulong Armor1_Affinities { get; set; }
        [MemoryOffset(0x198)]
        public ushort Armor1_Material { get; set; }
        [MemoryOffset(0x19A)]
        public byte Armor1_Limb { get; set; }
        [MemoryOffset(0x19B)]
        public byte Armor1_Index { get; set; }

        // --- ARMOR 2 (+$19C) ---
        [MemoryOffset(0x19C)]  // difficulty flags / present marker of the entry
        public uint Armor2Exists { get; set; }
        [MemoryOffset(0x1A0)]
        public byte Armor2_NameIndex { get; set; }
        [MemoryOffset(0x1A1)]
        public byte Armor2_ItemIndex { get; set; }
        [MemoryOffset(0x1A2)]
        public byte Armor2_FileIndex { get; set; }
        [MemoryOffset(0x1A3)]
        public byte Armor2_Category { get; set; }
        [MemoryOffset(0x1A4)]
        public ushort Armor2_DPMax { get; set; }
        [MemoryOffset(0x1A6)]
        public ushort Armor2_PPMax { get; set; }
        [MemoryOffset(0x1A8)]
        public ushort Armor2_DPCurrent { get; set; }
        [MemoryOffset(0x1AA)]
        public ushort Armor2_PPCurrent { get; set; }
        [MemoryOffset(0x1AC)]
        public byte Armor2_GemSlots { get; set; }
        [MemoryOffset(0x1AD)]
        public byte Armor2_STR { get; set; }
        [MemoryOffset(0x1AE)]
        public byte Armor2_INT { get; set; }
        [MemoryOffset(0x1AF)]
        public byte Armor2_AGL { get; set; }
        [MemoryOffset(0x1B0)]
        public uint Armor2_Types { get; set; }
        [MemoryOffset(0x1B4)]
        public ulong Armor2_Classes { get; set; }
        [MemoryOffset(0x1BC)]
        public ulong Armor2_Affinities { get; set; }
        [MemoryOffset(0x1C4)]
        public ushort Armor2_Material { get; set; }
        [MemoryOffset(0x1C6)]
        public byte Armor2_Limb { get; set; }
        [MemoryOffset(0x1C7)]
        public byte Armor2_Index { get; set; }

        // --- ACCESSORY (+$1C8) ---
        [MemoryOffset(0x1C8)]  // difficulty flags / present marker of the entry
        public uint AccessoryExists { get; set; }
        [MemoryOffset(0x1CC)]
        public byte Accessory_NameIndex { get; set; }
        [MemoryOffset(0x1CD)]
        public byte Accessory_ItemIndex { get; set; }
        [MemoryOffset(0x1CE)]
        public byte Accessory_FileIndex { get; set; }
        [MemoryOffset(0x1CF)]
        public byte Accessory_Category { get; set; }
        [MemoryOffset(0x1D0)]
        public ushort Accessory_DPMax { get; set; }
        [MemoryOffset(0x1D2)]
        public ushort Accessory_PPMax { get; set; }
        [MemoryOffset(0x1D4)]
        public ushort Accessory_DPCurrent { get; set; }
        [MemoryOffset(0x1D6)]
        public ushort Accessory_PPCurrent { get; set; }
        [MemoryOffset(0x1D8)]
        public byte Accessory_GemSlots { get; set; }
        [MemoryOffset(0x1D9)]
        public byte Accessory_STR { get; set; }
        [MemoryOffset(0x1DA)]
        public byte Accessory_INT { get; set; }
        [MemoryOffset(0x1DB)]
        public byte Accessory_AGL { get; set; }
        [MemoryOffset(0x1DC)]
        public uint Accessory_Types { get; set; }
        [MemoryOffset(0x1E0)]
        public ulong Accessory_Classes { get; set; }
        [MemoryOffset(0x1E8)]
        public ulong Accessory_Affinities { get; set; }
        [MemoryOffset(0x1F0)]
        public ushort Accessory_Material { get; set; }
        [MemoryOffset(0x1F2)]
        public byte Accessory_Limb { get; set; }
        [MemoryOffset(0x1F3)]
        public byte Accessory_Index { get; set; }

        // --- STANDALONE GEM (+$1F4) ---
        [MemoryOffset(0x1F4)]  // difficulty flags / present marker of the entry
        public uint GemExists { get; set; }
        [MemoryOffset(0x1F8)]
        public ushort Gem_NameIndex { get; set; }
        [MemoryOffset(0x1FA)]
        public byte Gem_ItemIndex { get; set; }
        [MemoryOffset(0x1FC)]
        public byte Gem_SpecialEffect { get; set; }
        [MemoryOffset(0x1FD)]
        public byte Gem_STR { get; set; }
        [MemoryOffset(0x1FE)]
        public byte Gem_INT { get; set; }
        [MemoryOffset(0x1FF)]
        public byte Gem_AGL { get; set; }
        [MemoryOffset(0x200)]
        public ulong Gem_Classes { get; set; }
        [MemoryOffset(0x208)]
        public ulong Gem_Affinities { get; set; }
        [MemoryOffset(0x210)]
        public ushort Gem_SetItemIndex { get; set; }
        [MemoryOffset(0x212)]
        public ushort Gem_Index { get; set; }

        // --- MISC ITEMS (+$214), 3 entries of 4 bytes. The loot record ends at +$220. ---
        [MemoryOffset(0x214)]  // low byte of the u16 item id
        public byte Misc1_ID { get; set; }
        [MemoryOffset(0x215)]  // high byte of the u16 item id (1 for keys, sigils and other 0x1xx ids)
        public byte Misc1_Confirm { get; set; }
        [MemoryOffset(0x216)]  // difficulty flags, non-zero = present
        public byte Misc1_Exists { get; set; }
        [MemoryOffset(0x217)]
        public byte Misc1_Qty { get; set; }
        [MemoryOffset(0x218)]  // low byte of the u16 item id
        public byte Misc2_ID { get; set; }
        [MemoryOffset(0x219)]  // high byte of the u16 item id (1 for keys, sigils and other 0x1xx ids)
        public byte Misc2_Confirm { get; set; }
        [MemoryOffset(0x21A)]  // difficulty flags, non-zero = present
        public byte Misc2_Exists { get; set; }
        [MemoryOffset(0x21B)]
        public byte Misc2_Qty { get; set; }
        [MemoryOffset(0x21C)]  // low byte of the u16 item id
        public byte Misc3_ID { get; set; }
        [MemoryOffset(0x21D)]  // high byte of the u16 item id (1 for keys, sigils and other 0x1xx ids)
        public byte Misc3_Confirm { get; set; }
        [MemoryOffset(0x21E)]  // difficulty flags, non-zero = present
        public byte Misc3_Exists { get; set; }
        [MemoryOffset(0x21F)]
        public byte Misc3_Qty { get; set; }
    }
}
