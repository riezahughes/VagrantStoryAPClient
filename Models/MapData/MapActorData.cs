using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.MapData
{
    /// <summary>
    /// A battle actor (vs_battle_actor, 0x50 bytes) followed by its stats block (vs_battle_actorStats at +0x50, 0x964 bytes).
    /// Every offset was produced by compiling the rood-reverse headers and taking offsetof(), so they match the game build.
    /// Equipment is stored in the game's vs_battle_uiEquipment layout (not the inventory layout). Bytes marked signed in the game
    /// (strength/intelligence/agility, types, classes, affinities) are read as byte, so values above 127 are negative.
    /// </summary>
    public class MapActorData
    {
        // ===========================================
        // ACTOR (+$000) - vs_battle_actor
        // ===========================================
        [MemoryOffset(0x0)]  // next actor in the list (0x8xxxxxxx pointer)
        public uint NextActorPointer { get; set; }
        [MemoryOffset(0x4)]
        public uint ActorId { get; set; }
        [MemoryOffset(0x1A)]
        public ushort SubType { get; set; }
        [MemoryOffset(0x25)]
        public byte EquippedWeaponCategory { get; set; }
        [MemoryOffset(0x28)]
        public byte Defeated { get; set; }
        [MemoryOffset(0x2C)]
        public byte Tile_X { get; set; }
        [MemoryOffset(0x2D)]
        public byte Tile_Surface { get; set; }
        [MemoryOffset(0x2E)]
        public byte Tile_Z { get; set; }
        [MemoryOffset(0x2F)]
        public byte Tile_Status { get; set; }
        [MemoryOffset(0x3C)]  // pointer to the stats block that follows the actor (+0x50)
        public uint StatsPointer { get; set; }

        // ===========================================
        // STATS (+$050) - vs_battle_actorStats; the 24 byte name is at +$050 and the weapon name at +$08C (not mapped)
        // ===========================================
        [MemoryOffset(0x68)]
        public short CurrentHP { get; set; }
        [MemoryOffset(0x6A)]
        public short MaxHP { get; set; }
        [MemoryOffset(0x6C)]
        public short CurrentMP { get; set; }
        [MemoryOffset(0x6E)]
        public short MaxMP { get; set; }
        [MemoryOffset(0x70)]
        public ushort RISK { get; set; }
        [MemoryOffset(0x72)]
        public ushort OriginalSTR { get; set; }
        [MemoryOffset(0x74)]
        public ushort EquippedSTR { get; set; }
        [MemoryOffset(0x76)]
        public ushort OriginalINT { get; set; }
        [MemoryOffset(0x78)]
        public ushort EquippedINT { get; set; }
        [MemoryOffset(0x7A)]
        public ushort OriginalAGL { get; set; }
        [MemoryOffset(0x7C)]
        public ushort EquippedAGL { get; set; }

        // ===========================================
        // BLADE (vs_battle_uiEquipment)
        // ===========================================
        [MemoryOffset(0xA4)]
        public ushort Blade_Id { get; set; }
        [MemoryOffset(0xA6)]
        public byte Blade_SubId { get; set; }
        [MemoryOffset(0xA7)]
        public byte Blade_WepId { get; set; }
        [MemoryOffset(0xA8)]
        public byte Blade_Category { get; set; }
        [MemoryOffset(0xA9)]
        public byte Blade_Str { get; set; }
        [MemoryOffset(0xAA)]
        public byte Blade_Int { get; set; }
        [MemoryOffset(0xAB)]
        public byte Blade_Agi { get; set; }
        [MemoryOffset(0xAC)]
        public ushort Blade_CurrentDP { get; set; }
        [MemoryOffset(0xAE)]
        public ushort Blade_MaxDP { get; set; }
        [MemoryOffset(0xB0)]
        public ushort Blade_CurrentPP { get; set; }
        [MemoryOffset(0xB2)]
        public ushort Blade_MaxPP { get; set; }
        [MemoryOffset(0xB4)]
        public byte Blade_DamageType { get; set; }
        [MemoryOffset(0xB5)]
        public byte Blade_CostType { get; set; }
        [MemoryOffset(0xB6)]
        public byte Blade_Cost { get; set; }
        [MemoryOffset(0xB7)]
        public byte Blade_Material { get; set; }
        [MemoryOffset(0xB9)]
        public byte Blade_GemSlots { get; set; }
        [MemoryOffset(0xBA)]
        public byte Blade_GemEffects { get; set; }
        [MemoryOffset(0xBB)]
        public byte Blade_Index { get; set; }
        [MemoryOffset(0xBC)]
        public byte Blade_Range { get; set; }
        [MemoryOffset(0xC0)]
        public byte Blade_BareHands { get; set; }
        [MemoryOffset(0xC1)]
        public byte Blade_Blunt { get; set; }
        [MemoryOffset(0xC2)]
        public byte Blade_Edged { get; set; }
        [MemoryOffset(0xC3)]
        public byte Blade_Piercing { get; set; }
        [MemoryOffset(0xC4)]
        public byte Blade_Human { get; set; }
        [MemoryOffset(0xC5)]
        public byte Blade_Beast { get; set; }
        [MemoryOffset(0xC6)]
        public byte Blade_Undead { get; set; }
        [MemoryOffset(0xC7)]
        public byte Blade_Phantom { get; set; }
        [MemoryOffset(0xC8)]
        public byte Blade_Dragon { get; set; }
        [MemoryOffset(0xC9)]
        public byte Blade_Evil { get; set; }
        [MemoryOffset(0xCC)]
        public byte Blade_Physical { get; set; }
        [MemoryOffset(0xCD)]
        public byte Blade_Air { get; set; }
        [MemoryOffset(0xCE)]
        public byte Blade_Fire { get; set; }
        [MemoryOffset(0xCF)]
        public byte Blade_Earth { get; set; }
        [MemoryOffset(0xD0)]
        public byte Blade_Water { get; set; }
        [MemoryOffset(0xD1)]
        public byte Blade_Light { get; set; }
        [MemoryOffset(0xD2)]
        public byte Blade_Dark { get; set; }

        // ===========================================
        // GRIP (vs_battle_uiEquipment)
        // ===========================================
        [MemoryOffset(0xD4)]
        public ushort Grip_Id { get; set; }
        [MemoryOffset(0xD6)]
        public byte Grip_SubId { get; set; }
        [MemoryOffset(0xD7)]
        public byte Grip_WepId { get; set; }
        [MemoryOffset(0xD8)]
        public byte Grip_Category { get; set; }
        [MemoryOffset(0xD9)]
        public byte Grip_Str { get; set; }
        [MemoryOffset(0xDA)]
        public byte Grip_Int { get; set; }
        [MemoryOffset(0xDB)]
        public byte Grip_Agi { get; set; }
        [MemoryOffset(0xDC)]
        public ushort Grip_CurrentDP { get; set; }
        [MemoryOffset(0xDE)]
        public ushort Grip_MaxDP { get; set; }
        [MemoryOffset(0xE0)]
        public ushort Grip_CurrentPP { get; set; }
        [MemoryOffset(0xE2)]
        public ushort Grip_MaxPP { get; set; }
        [MemoryOffset(0xE4)]
        public byte Grip_DamageType { get; set; }
        [MemoryOffset(0xE5)]
        public byte Grip_CostType { get; set; }
        [MemoryOffset(0xE6)]
        public byte Grip_Cost { get; set; }
        [MemoryOffset(0xE7)]
        public byte Grip_Material { get; set; }
        [MemoryOffset(0xE9)]
        public byte Grip_GemSlots { get; set; }
        [MemoryOffset(0xEA)]
        public byte Grip_GemEffects { get; set; }
        [MemoryOffset(0xEB)]
        public byte Grip_Index { get; set; }
        [MemoryOffset(0xEC)]
        public byte Grip_Range { get; set; }
        [MemoryOffset(0xF0)]
        public byte Grip_BareHands { get; set; }
        [MemoryOffset(0xF1)]
        public byte Grip_Blunt { get; set; }
        [MemoryOffset(0xF2)]
        public byte Grip_Edged { get; set; }
        [MemoryOffset(0xF3)]
        public byte Grip_Piercing { get; set; }
        [MemoryOffset(0xF4)]
        public byte Grip_Human { get; set; }
        [MemoryOffset(0xF5)]
        public byte Grip_Beast { get; set; }
        [MemoryOffset(0xF6)]
        public byte Grip_Undead { get; set; }
        [MemoryOffset(0xF7)]
        public byte Grip_Phantom { get; set; }
        [MemoryOffset(0xF8)]
        public byte Grip_Dragon { get; set; }
        [MemoryOffset(0xF9)]
        public byte Grip_Evil { get; set; }
        [MemoryOffset(0xFC)]
        public byte Grip_Physical { get; set; }
        [MemoryOffset(0xFD)]
        public byte Grip_Air { get; set; }
        [MemoryOffset(0xFE)]
        public byte Grip_Fire { get; set; }
        [MemoryOffset(0xFF)]
        public byte Grip_Earth { get; set; }
        [MemoryOffset(0x100)]
        public byte Grip_Water { get; set; }
        [MemoryOffset(0x101)]
        public byte Grip_Light { get; set; }
        [MemoryOffset(0x102)]
        public byte Grip_Dark { get; set; }

        // ===========================================
        // WEAPON GEM 1 (vs_battle_uiEquipment)
        // ===========================================
        [MemoryOffset(0x104)]
        public ushort WGem1_Id { get; set; }
        [MemoryOffset(0x106)]
        public byte WGem1_SubId { get; set; }
        [MemoryOffset(0x107)]
        public byte WGem1_WepId { get; set; }
        [MemoryOffset(0x108)]
        public byte WGem1_Category { get; set; }
        [MemoryOffset(0x109)]
        public byte WGem1_Str { get; set; }
        [MemoryOffset(0x10A)]
        public byte WGem1_Int { get; set; }
        [MemoryOffset(0x10B)]
        public byte WGem1_Agi { get; set; }
        [MemoryOffset(0x10C)]
        public ushort WGem1_CurrentDP { get; set; }
        [MemoryOffset(0x10E)]
        public ushort WGem1_MaxDP { get; set; }
        [MemoryOffset(0x110)]
        public ushort WGem1_CurrentPP { get; set; }
        [MemoryOffset(0x112)]
        public ushort WGem1_MaxPP { get; set; }
        [MemoryOffset(0x114)]
        public byte WGem1_DamageType { get; set; }
        [MemoryOffset(0x115)]
        public byte WGem1_CostType { get; set; }
        [MemoryOffset(0x116)]
        public byte WGem1_Cost { get; set; }
        [MemoryOffset(0x117)]
        public byte WGem1_Material { get; set; }
        [MemoryOffset(0x119)]
        public byte WGem1_GemSlots { get; set; }
        [MemoryOffset(0x11A)]
        public byte WGem1_GemEffects { get; set; }
        [MemoryOffset(0x11B)]
        public byte WGem1_Index { get; set; }
        [MemoryOffset(0x11C)]
        public byte WGem1_Range { get; set; }
        [MemoryOffset(0x120)]
        public byte WGem1_BareHands { get; set; }
        [MemoryOffset(0x121)]
        public byte WGem1_Blunt { get; set; }
        [MemoryOffset(0x122)]
        public byte WGem1_Edged { get; set; }
        [MemoryOffset(0x123)]
        public byte WGem1_Piercing { get; set; }
        [MemoryOffset(0x124)]
        public byte WGem1_Human { get; set; }
        [MemoryOffset(0x125)]
        public byte WGem1_Beast { get; set; }
        [MemoryOffset(0x126)]
        public byte WGem1_Undead { get; set; }
        [MemoryOffset(0x127)]
        public byte WGem1_Phantom { get; set; }
        [MemoryOffset(0x128)]
        public byte WGem1_Dragon { get; set; }
        [MemoryOffset(0x129)]
        public byte WGem1_Evil { get; set; }
        [MemoryOffset(0x12C)]
        public byte WGem1_Physical { get; set; }
        [MemoryOffset(0x12D)]
        public byte WGem1_Air { get; set; }
        [MemoryOffset(0x12E)]
        public byte WGem1_Fire { get; set; }
        [MemoryOffset(0x12F)]
        public byte WGem1_Earth { get; set; }
        [MemoryOffset(0x130)]
        public byte WGem1_Water { get; set; }
        [MemoryOffset(0x131)]
        public byte WGem1_Light { get; set; }
        [MemoryOffset(0x132)]
        public byte WGem1_Dark { get; set; }

        // ===========================================
        // WEAPON GEM 2 (vs_battle_uiEquipment)
        // ===========================================
        [MemoryOffset(0x134)]
        public ushort WGem2_Id { get; set; }
        [MemoryOffset(0x136)]
        public byte WGem2_SubId { get; set; }
        [MemoryOffset(0x137)]
        public byte WGem2_WepId { get; set; }
        [MemoryOffset(0x138)]
        public byte WGem2_Category { get; set; }
        [MemoryOffset(0x139)]
        public byte WGem2_Str { get; set; }
        [MemoryOffset(0x13A)]
        public byte WGem2_Int { get; set; }
        [MemoryOffset(0x13B)]
        public byte WGem2_Agi { get; set; }
        [MemoryOffset(0x13C)]
        public ushort WGem2_CurrentDP { get; set; }
        [MemoryOffset(0x13E)]
        public ushort WGem2_MaxDP { get; set; }
        [MemoryOffset(0x140)]
        public ushort WGem2_CurrentPP { get; set; }
        [MemoryOffset(0x142)]
        public ushort WGem2_MaxPP { get; set; }
        [MemoryOffset(0x144)]
        public byte WGem2_DamageType { get; set; }
        [MemoryOffset(0x145)]
        public byte WGem2_CostType { get; set; }
        [MemoryOffset(0x146)]
        public byte WGem2_Cost { get; set; }
        [MemoryOffset(0x147)]
        public byte WGem2_Material { get; set; }
        [MemoryOffset(0x149)]
        public byte WGem2_GemSlots { get; set; }
        [MemoryOffset(0x14A)]
        public byte WGem2_GemEffects { get; set; }
        [MemoryOffset(0x14B)]
        public byte WGem2_Index { get; set; }
        [MemoryOffset(0x14C)]
        public byte WGem2_Range { get; set; }
        [MemoryOffset(0x150)]
        public byte WGem2_BareHands { get; set; }
        [MemoryOffset(0x151)]
        public byte WGem2_Blunt { get; set; }
        [MemoryOffset(0x152)]
        public byte WGem2_Edged { get; set; }
        [MemoryOffset(0x153)]
        public byte WGem2_Piercing { get; set; }
        [MemoryOffset(0x154)]
        public byte WGem2_Human { get; set; }
        [MemoryOffset(0x155)]
        public byte WGem2_Beast { get; set; }
        [MemoryOffset(0x156)]
        public byte WGem2_Undead { get; set; }
        [MemoryOffset(0x157)]
        public byte WGem2_Phantom { get; set; }
        [MemoryOffset(0x158)]
        public byte WGem2_Dragon { get; set; }
        [MemoryOffset(0x159)]
        public byte WGem2_Evil { get; set; }
        [MemoryOffset(0x15C)]
        public byte WGem2_Physical { get; set; }
        [MemoryOffset(0x15D)]
        public byte WGem2_Air { get; set; }
        [MemoryOffset(0x15E)]
        public byte WGem2_Fire { get; set; }
        [MemoryOffset(0x15F)]
        public byte WGem2_Earth { get; set; }
        [MemoryOffset(0x160)]
        public byte WGem2_Water { get; set; }
        [MemoryOffset(0x161)]
        public byte WGem2_Light { get; set; }
        [MemoryOffset(0x162)]
        public byte WGem2_Dark { get; set; }

        // ===========================================
        // WEAPON GEM 3 (vs_battle_uiEquipment)
        // ===========================================
        [MemoryOffset(0x164)]
        public ushort WGem3_Id { get; set; }
        [MemoryOffset(0x166)]
        public byte WGem3_SubId { get; set; }
        [MemoryOffset(0x167)]
        public byte WGem3_WepId { get; set; }
        [MemoryOffset(0x168)]
        public byte WGem3_Category { get; set; }
        [MemoryOffset(0x169)]
        public byte WGem3_Str { get; set; }
        [MemoryOffset(0x16A)]
        public byte WGem3_Int { get; set; }
        [MemoryOffset(0x16B)]
        public byte WGem3_Agi { get; set; }
        [MemoryOffset(0x16C)]
        public ushort WGem3_CurrentDP { get; set; }
        [MemoryOffset(0x16E)]
        public ushort WGem3_MaxDP { get; set; }
        [MemoryOffset(0x170)]
        public ushort WGem3_CurrentPP { get; set; }
        [MemoryOffset(0x172)]
        public ushort WGem3_MaxPP { get; set; }
        [MemoryOffset(0x174)]
        public byte WGem3_DamageType { get; set; }
        [MemoryOffset(0x175)]
        public byte WGem3_CostType { get; set; }
        [MemoryOffset(0x176)]
        public byte WGem3_Cost { get; set; }
        [MemoryOffset(0x177)]
        public byte WGem3_Material { get; set; }
        [MemoryOffset(0x179)]
        public byte WGem3_GemSlots { get; set; }
        [MemoryOffset(0x17A)]
        public byte WGem3_GemEffects { get; set; }
        [MemoryOffset(0x17B)]
        public byte WGem3_Index { get; set; }
        [MemoryOffset(0x17C)]
        public byte WGem3_Range { get; set; }
        [MemoryOffset(0x180)]
        public byte WGem3_BareHands { get; set; }
        [MemoryOffset(0x181)]
        public byte WGem3_Blunt { get; set; }
        [MemoryOffset(0x182)]
        public byte WGem3_Edged { get; set; }
        [MemoryOffset(0x183)]
        public byte WGem3_Piercing { get; set; }
        [MemoryOffset(0x184)]
        public byte WGem3_Human { get; set; }
        [MemoryOffset(0x185)]
        public byte WGem3_Beast { get; set; }
        [MemoryOffset(0x186)]
        public byte WGem3_Undead { get; set; }
        [MemoryOffset(0x187)]
        public byte WGem3_Phantom { get; set; }
        [MemoryOffset(0x188)]
        public byte WGem3_Dragon { get; set; }
        [MemoryOffset(0x189)]
        public byte WGem3_Evil { get; set; }
        [MemoryOffset(0x18C)]
        public byte WGem3_Physical { get; set; }
        [MemoryOffset(0x18D)]
        public byte WGem3_Air { get; set; }
        [MemoryOffset(0x18E)]
        public byte WGem3_Fire { get; set; }
        [MemoryOffset(0x18F)]
        public byte WGem3_Earth { get; set; }
        [MemoryOffset(0x190)]
        public byte WGem3_Water { get; set; }
        [MemoryOffset(0x191)]
        public byte WGem3_Light { get; set; }
        [MemoryOffset(0x192)]
        public byte WGem3_Dark { get; set; }

        // ===========================================
        // WEAPON TOTALS (vs_battle_uiWeapon)
        // ===========================================
        [MemoryOffset(0x194)]
        public byte WeaponTotal_WepId { get; set; }
        [MemoryOffset(0x195)]
        public byte WeaponTotal_DamageTypeValue { get; set; }
        [MemoryOffset(0x196)]
        public byte WeaponTotal_Risk { get; set; }
        [MemoryOffset(0x198)]
        public byte WeaponTotal_DropRate { get; set; }
        [MemoryOffset(0x199)]
        public byte WeaponTotal_Index { get; set; }
        [MemoryOffset(0x19A)]
        public byte WeaponTotal_DamageType { get; set; }
        [MemoryOffset(0x19B)]
        public byte WeaponTotal_ActionType { get; set; }
        [MemoryOffset(0x19C)]
        public ushort WeaponTotal_CurrentPP { get; set; }
        [MemoryOffset(0x19E)]
        public ushort WeaponTotal_MaxPP { get; set; }
        [MemoryOffset(0x1A0)]
        public ushort WeaponTotal_CurrentDP { get; set; }
        [MemoryOffset(0x1A2)]
        public ushort WeaponTotal_MaxDP { get; set; }
        [MemoryOffset(0x1A4)]
        public short WeaponTotal_CurrentSTR { get; set; }
        [MemoryOffset(0x1A6)]
        public ushort WeaponTotal_BaseSTR { get; set; }
        [MemoryOffset(0x1A8)]
        public short WeaponTotal_CurrentINT { get; set; }
        [MemoryOffset(0x1AA)]
        public ushort WeaponTotal_BaseINT { get; set; }
        [MemoryOffset(0x1AC)]
        public short WeaponTotal_CurrentAGL { get; set; }
        [MemoryOffset(0x1AE)]
        public ushort WeaponTotal_BaseAGL { get; set; }
        [MemoryOffset(0x1B0)]
        public byte WeaponTotal_Range { get; set; }

        // ===========================================
        // SHIELD (vs_battle_uiEquipment)
        // ===========================================
        [MemoryOffset(0x23C)]
        public ushort Shield_Id { get; set; }
        [MemoryOffset(0x23E)]
        public byte Shield_SubId { get; set; }
        [MemoryOffset(0x23F)]
        public byte Shield_WepId { get; set; }
        [MemoryOffset(0x240)]
        public byte Shield_Category { get; set; }
        [MemoryOffset(0x241)]
        public byte Shield_Str { get; set; }
        [MemoryOffset(0x242)]
        public byte Shield_Int { get; set; }
        [MemoryOffset(0x243)]
        public byte Shield_Agi { get; set; }
        [MemoryOffset(0x244)]
        public ushort Shield_CurrentDP { get; set; }
        [MemoryOffset(0x246)]
        public ushort Shield_MaxDP { get; set; }
        [MemoryOffset(0x248)]
        public ushort Shield_CurrentPP { get; set; }
        [MemoryOffset(0x24A)]
        public ushort Shield_MaxPP { get; set; }
        [MemoryOffset(0x24C)]
        public byte Shield_DamageType { get; set; }
        [MemoryOffset(0x24D)]
        public byte Shield_CostType { get; set; }
        [MemoryOffset(0x24E)]
        public byte Shield_Cost { get; set; }
        [MemoryOffset(0x24F)]
        public byte Shield_Material { get; set; }
        [MemoryOffset(0x251)]
        public byte Shield_GemSlots { get; set; }
        [MemoryOffset(0x252)]
        public byte Shield_GemEffects { get; set; }
        [MemoryOffset(0x253)]
        public byte Shield_Index { get; set; }
        [MemoryOffset(0x254)]
        public byte Shield_Range { get; set; }
        [MemoryOffset(0x258)]
        public byte Shield_BareHands { get; set; }
        [MemoryOffset(0x259)]
        public byte Shield_Blunt { get; set; }
        [MemoryOffset(0x25A)]
        public byte Shield_Edged { get; set; }
        [MemoryOffset(0x25B)]
        public byte Shield_Piercing { get; set; }
        [MemoryOffset(0x25C)]
        public byte Shield_Human { get; set; }
        [MemoryOffset(0x25D)]
        public byte Shield_Beast { get; set; }
        [MemoryOffset(0x25E)]
        public byte Shield_Undead { get; set; }
        [MemoryOffset(0x25F)]
        public byte Shield_Phantom { get; set; }
        [MemoryOffset(0x260)]
        public byte Shield_Dragon { get; set; }
        [MemoryOffset(0x261)]
        public byte Shield_Evil { get; set; }
        [MemoryOffset(0x264)]
        public byte Shield_Physical { get; set; }
        [MemoryOffset(0x265)]
        public byte Shield_Air { get; set; }
        [MemoryOffset(0x266)]
        public byte Shield_Fire { get; set; }
        [MemoryOffset(0x267)]
        public byte Shield_Earth { get; set; }
        [MemoryOffset(0x268)]
        public byte Shield_Water { get; set; }
        [MemoryOffset(0x269)]
        public byte Shield_Light { get; set; }
        [MemoryOffset(0x26A)]
        public byte Shield_Dark { get; set; }

        // ===========================================
        // SHIELD GEM 1
        // ===========================================
        [MemoryOffset(0x26C)]
        public ushort SGem1_Id { get; set; }
        [MemoryOffset(0x26E)]
        public byte SGem1_SubId { get; set; }
        [MemoryOffset(0x26F)]
        public byte SGem1_WepId { get; set; }
        [MemoryOffset(0x270)]
        public byte SGem1_Category { get; set; }
        [MemoryOffset(0x271)]
        public byte SGem1_Str { get; set; }
        [MemoryOffset(0x272)]
        public byte SGem1_Int { get; set; }
        [MemoryOffset(0x273)]
        public byte SGem1_Agi { get; set; }
        [MemoryOffset(0x274)]
        public ushort SGem1_CurrentDP { get; set; }
        [MemoryOffset(0x276)]
        public ushort SGem1_MaxDP { get; set; }
        [MemoryOffset(0x278)]
        public ushort SGem1_CurrentPP { get; set; }
        [MemoryOffset(0x27A)]
        public ushort SGem1_MaxPP { get; set; }
        [MemoryOffset(0x27C)]
        public byte SGem1_DamageType { get; set; }
        [MemoryOffset(0x27D)]
        public byte SGem1_CostType { get; set; }
        [MemoryOffset(0x27E)]
        public byte SGem1_Cost { get; set; }
        [MemoryOffset(0x27F)]
        public byte SGem1_Material { get; set; }
        [MemoryOffset(0x281)]
        public byte SGem1_GemSlots { get; set; }
        [MemoryOffset(0x282)]
        public byte SGem1_GemEffects { get; set; }
        [MemoryOffset(0x283)]
        public byte SGem1_Index { get; set; }
        [MemoryOffset(0x284)]
        public byte SGem1_Range { get; set; }
        [MemoryOffset(0x288)]
        public byte SGem1_BareHands { get; set; }
        [MemoryOffset(0x289)]
        public byte SGem1_Blunt { get; set; }
        [MemoryOffset(0x28A)]
        public byte SGem1_Edged { get; set; }
        [MemoryOffset(0x28B)]
        public byte SGem1_Piercing { get; set; }
        [MemoryOffset(0x28C)]
        public byte SGem1_Human { get; set; }
        [MemoryOffset(0x28D)]
        public byte SGem1_Beast { get; set; }
        [MemoryOffset(0x28E)]
        public byte SGem1_Undead { get; set; }
        [MemoryOffset(0x28F)]
        public byte SGem1_Phantom { get; set; }
        [MemoryOffset(0x290)]
        public byte SGem1_Dragon { get; set; }
        [MemoryOffset(0x291)]
        public byte SGem1_Evil { get; set; }
        [MemoryOffset(0x294)]
        public byte SGem1_Physical { get; set; }
        [MemoryOffset(0x295)]
        public byte SGem1_Air { get; set; }
        [MemoryOffset(0x296)]
        public byte SGem1_Fire { get; set; }
        [MemoryOffset(0x297)]
        public byte SGem1_Earth { get; set; }
        [MemoryOffset(0x298)]
        public byte SGem1_Water { get; set; }
        [MemoryOffset(0x299)]
        public byte SGem1_Light { get; set; }
        [MemoryOffset(0x29A)]
        public byte SGem1_Dark { get; set; }

        // ===========================================
        // SHIELD GEM 2
        // ===========================================
        [MemoryOffset(0x29C)]
        public ushort SGem2_Id { get; set; }
        [MemoryOffset(0x29E)]
        public byte SGem2_SubId { get; set; }
        [MemoryOffset(0x29F)]
        public byte SGem2_WepId { get; set; }
        [MemoryOffset(0x2A0)]
        public byte SGem2_Category { get; set; }
        [MemoryOffset(0x2A1)]
        public byte SGem2_Str { get; set; }
        [MemoryOffset(0x2A2)]
        public byte SGem2_Int { get; set; }
        [MemoryOffset(0x2A3)]
        public byte SGem2_Agi { get; set; }
        [MemoryOffset(0x2A4)]
        public ushort SGem2_CurrentDP { get; set; }
        [MemoryOffset(0x2A6)]
        public ushort SGem2_MaxDP { get; set; }
        [MemoryOffset(0x2A8)]
        public ushort SGem2_CurrentPP { get; set; }
        [MemoryOffset(0x2AA)]
        public ushort SGem2_MaxPP { get; set; }
        [MemoryOffset(0x2AC)]
        public byte SGem2_DamageType { get; set; }
        [MemoryOffset(0x2AD)]
        public byte SGem2_CostType { get; set; }
        [MemoryOffset(0x2AE)]
        public byte SGem2_Cost { get; set; }
        [MemoryOffset(0x2AF)]
        public byte SGem2_Material { get; set; }
        [MemoryOffset(0x2B1)]
        public byte SGem2_GemSlots { get; set; }
        [MemoryOffset(0x2B2)]
        public byte SGem2_GemEffects { get; set; }
        [MemoryOffset(0x2B3)]
        public byte SGem2_Index { get; set; }
        [MemoryOffset(0x2B4)]
        public byte SGem2_Range { get; set; }
        [MemoryOffset(0x2B8)]
        public byte SGem2_BareHands { get; set; }
        [MemoryOffset(0x2B9)]
        public byte SGem2_Blunt { get; set; }
        [MemoryOffset(0x2BA)]
        public byte SGem2_Edged { get; set; }
        [MemoryOffset(0x2BB)]
        public byte SGem2_Piercing { get; set; }
        [MemoryOffset(0x2BC)]
        public byte SGem2_Human { get; set; }
        [MemoryOffset(0x2BD)]
        public byte SGem2_Beast { get; set; }
        [MemoryOffset(0x2BE)]
        public byte SGem2_Undead { get; set; }
        [MemoryOffset(0x2BF)]
        public byte SGem2_Phantom { get; set; }
        [MemoryOffset(0x2C0)]
        public byte SGem2_Dragon { get; set; }
        [MemoryOffset(0x2C1)]
        public byte SGem2_Evil { get; set; }
        [MemoryOffset(0x2C4)]
        public byte SGem2_Physical { get; set; }
        [MemoryOffset(0x2C5)]
        public byte SGem2_Air { get; set; }
        [MemoryOffset(0x2C6)]
        public byte SGem2_Fire { get; set; }
        [MemoryOffset(0x2C7)]
        public byte SGem2_Earth { get; set; }
        [MemoryOffset(0x2C8)]
        public byte SGem2_Water { get; set; }
        [MemoryOffset(0x2C9)]
        public byte SGem2_Light { get; set; }
        [MemoryOffset(0x2CA)]
        public byte SGem2_Dark { get; set; }

        // ===========================================
        // SHIELD GEM 3
        // ===========================================
        [MemoryOffset(0x2CC)]
        public ushort SGem3_Id { get; set; }
        [MemoryOffset(0x2CE)]
        public byte SGem3_SubId { get; set; }
        [MemoryOffset(0x2CF)]
        public byte SGem3_WepId { get; set; }
        [MemoryOffset(0x2D0)]
        public byte SGem3_Category { get; set; }
        [MemoryOffset(0x2D1)]
        public byte SGem3_Str { get; set; }
        [MemoryOffset(0x2D2)]
        public byte SGem3_Int { get; set; }
        [MemoryOffset(0x2D3)]
        public byte SGem3_Agi { get; set; }
        [MemoryOffset(0x2D4)]
        public ushort SGem3_CurrentDP { get; set; }
        [MemoryOffset(0x2D6)]
        public ushort SGem3_MaxDP { get; set; }
        [MemoryOffset(0x2D8)]
        public ushort SGem3_CurrentPP { get; set; }
        [MemoryOffset(0x2DA)]
        public ushort SGem3_MaxPP { get; set; }
        [MemoryOffset(0x2DC)]
        public byte SGem3_DamageType { get; set; }
        [MemoryOffset(0x2DD)]
        public byte SGem3_CostType { get; set; }
        [MemoryOffset(0x2DE)]
        public byte SGem3_Cost { get; set; }
        [MemoryOffset(0x2DF)]
        public byte SGem3_Material { get; set; }
        [MemoryOffset(0x2E1)]
        public byte SGem3_GemSlots { get; set; }
        [MemoryOffset(0x2E2)]
        public byte SGem3_GemEffects { get; set; }
        [MemoryOffset(0x2E3)]
        public byte SGem3_Index { get; set; }
        [MemoryOffset(0x2E4)]
        public byte SGem3_Range { get; set; }
        [MemoryOffset(0x2E8)]
        public byte SGem3_BareHands { get; set; }
        [MemoryOffset(0x2E9)]
        public byte SGem3_Blunt { get; set; }
        [MemoryOffset(0x2EA)]
        public byte SGem3_Edged { get; set; }
        [MemoryOffset(0x2EB)]
        public byte SGem3_Piercing { get; set; }
        [MemoryOffset(0x2EC)]
        public byte SGem3_Human { get; set; }
        [MemoryOffset(0x2ED)]
        public byte SGem3_Beast { get; set; }
        [MemoryOffset(0x2EE)]
        public byte SGem3_Undead { get; set; }
        [MemoryOffset(0x2EF)]
        public byte SGem3_Phantom { get; set; }
        [MemoryOffset(0x2F0)]
        public byte SGem3_Dragon { get; set; }
        [MemoryOffset(0x2F1)]
        public byte SGem3_Evil { get; set; }
        [MemoryOffset(0x2F4)]
        public byte SGem3_Physical { get; set; }
        [MemoryOffset(0x2F5)]
        public byte SGem3_Air { get; set; }
        [MemoryOffset(0x2F6)]
        public byte SGem3_Fire { get; set; }
        [MemoryOffset(0x2F7)]
        public byte SGem3_Earth { get; set; }
        [MemoryOffset(0x2F8)]
        public byte SGem3_Water { get; set; }
        [MemoryOffset(0x2F9)]
        public byte SGem3_Light { get; set; }
        [MemoryOffset(0x2FA)]
        public byte SGem3_Dark { get; set; }

        // ===========================================
        // SHIELD TOTALS (vs_battle_uiShield)
        // ===========================================
        [MemoryOffset(0x2FC)]
        public byte ShieldTotal_WepId { get; set; }
        [MemoryOffset(0x2FD)]
        public byte ShieldTotal_DropRate { get; set; }
        [MemoryOffset(0x2FE)]
        public byte ShieldTotal_Index { get; set; }
        [MemoryOffset(0x300)]
        public ushort ShieldTotal_CurrentPP { get; set; }
        [MemoryOffset(0x302)]
        public ushort ShieldTotal_MaxPP { get; set; }
        [MemoryOffset(0x304)]
        public ushort ShieldTotal_CurrentDP { get; set; }
        [MemoryOffset(0x306)]
        public ushort ShieldTotal_MaxDP { get; set; }
        [MemoryOffset(0x308)]
        public short ShieldTotal_CurrentSTR { get; set; }
        [MemoryOffset(0x30A)]
        public ushort ShieldTotal_BaseSTR { get; set; }
        [MemoryOffset(0x30C)]
        public short ShieldTotal_CurrentINT { get; set; }
        [MemoryOffset(0x30E)]
        public ushort ShieldTotal_BaseINT { get; set; }
        [MemoryOffset(0x310)]
        public short ShieldTotal_CurrentAGL { get; set; }
        [MemoryOffset(0x312)]
        public ushort ShieldTotal_BaseAGL { get; set; }

        // ===========================================
        // ACCESSORY (vs_battle_uiEquipment)
        // ===========================================
        [MemoryOffset(0x388)]
        public ushort Accessory_Id { get; set; }
        [MemoryOffset(0x38A)]
        public byte Accessory_SubId { get; set; }
        [MemoryOffset(0x38B)]
        public byte Accessory_WepId { get; set; }
        [MemoryOffset(0x38C)]
        public byte Accessory_Category { get; set; }
        [MemoryOffset(0x38D)]
        public byte Accessory_Str { get; set; }
        [MemoryOffset(0x38E)]
        public byte Accessory_Int { get; set; }
        [MemoryOffset(0x38F)]
        public byte Accessory_Agi { get; set; }
        [MemoryOffset(0x390)]
        public ushort Accessory_CurrentDP { get; set; }
        [MemoryOffset(0x392)]
        public ushort Accessory_MaxDP { get; set; }
        [MemoryOffset(0x394)]
        public ushort Accessory_CurrentPP { get; set; }
        [MemoryOffset(0x396)]
        public ushort Accessory_MaxPP { get; set; }
        [MemoryOffset(0x398)]
        public byte Accessory_DamageType { get; set; }
        [MemoryOffset(0x399)]
        public byte Accessory_CostType { get; set; }
        [MemoryOffset(0x39A)]
        public byte Accessory_Cost { get; set; }
        [MemoryOffset(0x39B)]
        public byte Accessory_Material { get; set; }
        [MemoryOffset(0x39D)]
        public byte Accessory_GemSlots { get; set; }
        [MemoryOffset(0x39E)]
        public byte Accessory_GemEffects { get; set; }
        [MemoryOffset(0x39F)]
        public byte Accessory_Index { get; set; }
        [MemoryOffset(0x3A0)]
        public byte Accessory_Range { get; set; }
        [MemoryOffset(0x3A4)]
        public byte Accessory_BareHands { get; set; }
        [MemoryOffset(0x3A5)]
        public byte Accessory_Blunt { get; set; }
        [MemoryOffset(0x3A6)]
        public byte Accessory_Edged { get; set; }
        [MemoryOffset(0x3A7)]
        public byte Accessory_Piercing { get; set; }
        [MemoryOffset(0x3A8)]
        public byte Accessory_Human { get; set; }
        [MemoryOffset(0x3A9)]
        public byte Accessory_Beast { get; set; }
        [MemoryOffset(0x3AA)]
        public byte Accessory_Undead { get; set; }
        [MemoryOffset(0x3AB)]
        public byte Accessory_Phantom { get; set; }
        [MemoryOffset(0x3AC)]
        public byte Accessory_Dragon { get; set; }
        [MemoryOffset(0x3AD)]
        public byte Accessory_Evil { get; set; }
        [MemoryOffset(0x3B0)]
        public byte Accessory_Physical { get; set; }
        [MemoryOffset(0x3B1)]
        public byte Accessory_Air { get; set; }
        [MemoryOffset(0x3B2)]
        public byte Accessory_Fire { get; set; }
        [MemoryOffset(0x3B3)]
        public byte Accessory_Earth { get; set; }
        [MemoryOffset(0x3B4)]
        public byte Accessory_Water { get; set; }
        [MemoryOffset(0x3B5)]
        public byte Accessory_Light { get; set; }
        [MemoryOffset(0x3B6)]
        public byte Accessory_Dark { get; set; }

        // ===========================================
        // ACCESSORY TOTALS (vs_battle_uiAccessory)
        // ===========================================
        [MemoryOffset(0x3B8)]
        public short AccessoryTotal_CurrentSTR { get; set; }
        [MemoryOffset(0x3BA)]
        public short AccessoryTotal_CurrentINT { get; set; }
        [MemoryOffset(0x3BC)]
        public short AccessoryTotal_CurrentAGL { get; set; }
        [MemoryOffset(0x3BE)]
        public byte AccessoryTotal_DropRate { get; set; }
        [MemoryOffset(0x3BF)]
        public byte AccessoryTotal_Index { get; set; }

        // ===========================================
        // LIMB 0 (vs_battle_uiEquipment_limb)
        // ===========================================
        [MemoryOffset(0x3E8)]
        public short Limb0_HP { get; set; }
        [MemoryOffset(0x3EA)]
        public short Limb0_MaxHP { get; set; }
        [MemoryOffset(0x3EC)]
        public byte Limb0_AgilityDefenseBonus { get; set; }
        [MemoryOffset(0x3EE)]
        public byte Limb0_NameIndex { get; set; }
        [MemoryOffset(0x3EF)]
        public byte Limb0_ChainEvasion { get; set; }
        [MemoryOffset(0x438)]
        public ushort Limb0_CurrentDP { get; set; }
        [MemoryOffset(0x43A)]
        public ushort Limb0_MaxDP { get; set; }
        [MemoryOffset(0x43C)]
        public short Limb0_CurrentSTR { get; set; }
        [MemoryOffset(0x43E)]
        public ushort Limb0_BaseSTR { get; set; }
        [MemoryOffset(0x440)]
        public short Limb0_CurrentINT { get; set; }
        [MemoryOffset(0x442)]
        public ushort Limb0_BaseINT { get; set; }
        [MemoryOffset(0x444)]
        public short Limb0_CurrentAGL { get; set; }
        [MemoryOffset(0x446)]
        public ushort Limb0_BaseAGL { get; set; }
        [MemoryOffset(0x4A0)]
        public byte Limb0_DropRate { get; set; }
        [MemoryOffset(0x4A2)]
        public byte Limb0_ArmorIndex { get; set; }
        [MemoryOffset(0x408)]
        public ushort Limb0_Armor_Id { get; set; }
        [MemoryOffset(0x40A)]
        public byte Limb0_Armor_SubId { get; set; }
        [MemoryOffset(0x40B)]
        public byte Limb0_Armor_WepId { get; set; }
        [MemoryOffset(0x40C)]
        public byte Limb0_Armor_Category { get; set; }
        [MemoryOffset(0x40D)]
        public byte Limb0_Armor_Str { get; set; }
        [MemoryOffset(0x40E)]
        public byte Limb0_Armor_Int { get; set; }
        [MemoryOffset(0x40F)]
        public byte Limb0_Armor_Agi { get; set; }
        [MemoryOffset(0x410)]
        public ushort Limb0_Armor_CurrentDP { get; set; }
        [MemoryOffset(0x412)]
        public ushort Limb0_Armor_MaxDP { get; set; }
        [MemoryOffset(0x414)]
        public ushort Limb0_Armor_CurrentPP { get; set; }
        [MemoryOffset(0x416)]
        public ushort Limb0_Armor_MaxPP { get; set; }
        [MemoryOffset(0x418)]
        public byte Limb0_Armor_DamageType { get; set; }
        [MemoryOffset(0x419)]
        public byte Limb0_Armor_CostType { get; set; }
        [MemoryOffset(0x41A)]
        public byte Limb0_Armor_Cost { get; set; }
        [MemoryOffset(0x41B)]
        public byte Limb0_Armor_Material { get; set; }
        [MemoryOffset(0x41D)]
        public byte Limb0_Armor_GemSlots { get; set; }
        [MemoryOffset(0x41E)]
        public byte Limb0_Armor_GemEffects { get; set; }
        [MemoryOffset(0x41F)]
        public byte Limb0_Armor_Index { get; set; }
        [MemoryOffset(0x420)]
        public byte Limb0_Armor_Range { get; set; }
        [MemoryOffset(0x424)]
        public byte Limb0_Armor_BareHands { get; set; }
        [MemoryOffset(0x425)]
        public byte Limb0_Armor_Blunt { get; set; }
        [MemoryOffset(0x426)]
        public byte Limb0_Armor_Edged { get; set; }
        [MemoryOffset(0x427)]
        public byte Limb0_Armor_Piercing { get; set; }
        [MemoryOffset(0x428)]
        public byte Limb0_Armor_Human { get; set; }
        [MemoryOffset(0x429)]
        public byte Limb0_Armor_Beast { get; set; }
        [MemoryOffset(0x42A)]
        public byte Limb0_Armor_Undead { get; set; }
        [MemoryOffset(0x42B)]
        public byte Limb0_Armor_Phantom { get; set; }
        [MemoryOffset(0x42C)]
        public byte Limb0_Armor_Dragon { get; set; }
        [MemoryOffset(0x42D)]
        public byte Limb0_Armor_Evil { get; set; }
        [MemoryOffset(0x430)]
        public byte Limb0_Armor_Physical { get; set; }
        [MemoryOffset(0x431)]
        public byte Limb0_Armor_Air { get; set; }
        [MemoryOffset(0x432)]
        public byte Limb0_Armor_Fire { get; set; }
        [MemoryOffset(0x433)]
        public byte Limb0_Armor_Earth { get; set; }
        [MemoryOffset(0x434)]
        public byte Limb0_Armor_Water { get; set; }
        [MemoryOffset(0x435)]
        public byte Limb0_Armor_Light { get; set; }
        [MemoryOffset(0x436)]
        public byte Limb0_Armor_Dark { get; set; }

        // ===========================================
        // LIMB 1 (vs_battle_uiEquipment_limb)
        // ===========================================
        [MemoryOffset(0x4C4)]
        public short Limb1_HP { get; set; }
        [MemoryOffset(0x4C6)]
        public short Limb1_MaxHP { get; set; }
        [MemoryOffset(0x4C8)]
        public byte Limb1_AgilityDefenseBonus { get; set; }
        [MemoryOffset(0x4CA)]
        public byte Limb1_NameIndex { get; set; }
        [MemoryOffset(0x4CB)]
        public byte Limb1_ChainEvasion { get; set; }
        [MemoryOffset(0x514)]
        public ushort Limb1_CurrentDP { get; set; }
        [MemoryOffset(0x516)]
        public ushort Limb1_MaxDP { get; set; }
        [MemoryOffset(0x518)]
        public short Limb1_CurrentSTR { get; set; }
        [MemoryOffset(0x51A)]
        public ushort Limb1_BaseSTR { get; set; }
        [MemoryOffset(0x51C)]
        public short Limb1_CurrentINT { get; set; }
        [MemoryOffset(0x51E)]
        public ushort Limb1_BaseINT { get; set; }
        [MemoryOffset(0x520)]
        public short Limb1_CurrentAGL { get; set; }
        [MemoryOffset(0x522)]
        public ushort Limb1_BaseAGL { get; set; }
        [MemoryOffset(0x57C)]
        public byte Limb1_DropRate { get; set; }
        [MemoryOffset(0x57E)]
        public byte Limb1_ArmorIndex { get; set; }
        [MemoryOffset(0x4E4)]
        public ushort Limb1_Armor_Id { get; set; }
        [MemoryOffset(0x4E6)]
        public byte Limb1_Armor_SubId { get; set; }
        [MemoryOffset(0x4E7)]
        public byte Limb1_Armor_WepId { get; set; }
        [MemoryOffset(0x4E8)]
        public byte Limb1_Armor_Category { get; set; }
        [MemoryOffset(0x4E9)]
        public byte Limb1_Armor_Str { get; set; }
        [MemoryOffset(0x4EA)]
        public byte Limb1_Armor_Int { get; set; }
        [MemoryOffset(0x4EB)]
        public byte Limb1_Armor_Agi { get; set; }
        [MemoryOffset(0x4EC)]
        public ushort Limb1_Armor_CurrentDP { get; set; }
        [MemoryOffset(0x4EE)]
        public ushort Limb1_Armor_MaxDP { get; set; }
        [MemoryOffset(0x4F0)]
        public ushort Limb1_Armor_CurrentPP { get; set; }
        [MemoryOffset(0x4F2)]
        public ushort Limb1_Armor_MaxPP { get; set; }
        [MemoryOffset(0x4F4)]
        public byte Limb1_Armor_DamageType { get; set; }
        [MemoryOffset(0x4F5)]
        public byte Limb1_Armor_CostType { get; set; }
        [MemoryOffset(0x4F6)]
        public byte Limb1_Armor_Cost { get; set; }
        [MemoryOffset(0x4F7)]
        public byte Limb1_Armor_Material { get; set; }
        [MemoryOffset(0x4F9)]
        public byte Limb1_Armor_GemSlots { get; set; }
        [MemoryOffset(0x4FA)]
        public byte Limb1_Armor_GemEffects { get; set; }
        [MemoryOffset(0x4FB)]
        public byte Limb1_Armor_Index { get; set; }
        [MemoryOffset(0x4FC)]
        public byte Limb1_Armor_Range { get; set; }
        [MemoryOffset(0x500)]
        public byte Limb1_Armor_BareHands { get; set; }
        [MemoryOffset(0x501)]
        public byte Limb1_Armor_Blunt { get; set; }
        [MemoryOffset(0x502)]
        public byte Limb1_Armor_Edged { get; set; }
        [MemoryOffset(0x503)]
        public byte Limb1_Armor_Piercing { get; set; }
        [MemoryOffset(0x504)]
        public byte Limb1_Armor_Human { get; set; }
        [MemoryOffset(0x505)]
        public byte Limb1_Armor_Beast { get; set; }
        [MemoryOffset(0x506)]
        public byte Limb1_Armor_Undead { get; set; }
        [MemoryOffset(0x507)]
        public byte Limb1_Armor_Phantom { get; set; }
        [MemoryOffset(0x508)]
        public byte Limb1_Armor_Dragon { get; set; }
        [MemoryOffset(0x509)]
        public byte Limb1_Armor_Evil { get; set; }
        [MemoryOffset(0x50C)]
        public byte Limb1_Armor_Physical { get; set; }
        [MemoryOffset(0x50D)]
        public byte Limb1_Armor_Air { get; set; }
        [MemoryOffset(0x50E)]
        public byte Limb1_Armor_Fire { get; set; }
        [MemoryOffset(0x50F)]
        public byte Limb1_Armor_Earth { get; set; }
        [MemoryOffset(0x510)]
        public byte Limb1_Armor_Water { get; set; }
        [MemoryOffset(0x511)]
        public byte Limb1_Armor_Light { get; set; }
        [MemoryOffset(0x512)]
        public byte Limb1_Armor_Dark { get; set; }

        // ===========================================
        // LIMB 2 (vs_battle_uiEquipment_limb)
        // ===========================================
        [MemoryOffset(0x5A0)]
        public short Limb2_HP { get; set; }
        [MemoryOffset(0x5A2)]
        public short Limb2_MaxHP { get; set; }
        [MemoryOffset(0x5A4)]
        public byte Limb2_AgilityDefenseBonus { get; set; }
        [MemoryOffset(0x5A6)]
        public byte Limb2_NameIndex { get; set; }
        [MemoryOffset(0x5A7)]
        public byte Limb2_ChainEvasion { get; set; }
        [MemoryOffset(0x5F0)]
        public ushort Limb2_CurrentDP { get; set; }
        [MemoryOffset(0x5F2)]
        public ushort Limb2_MaxDP { get; set; }
        [MemoryOffset(0x5F4)]
        public short Limb2_CurrentSTR { get; set; }
        [MemoryOffset(0x5F6)]
        public ushort Limb2_BaseSTR { get; set; }
        [MemoryOffset(0x5F8)]
        public short Limb2_CurrentINT { get; set; }
        [MemoryOffset(0x5FA)]
        public ushort Limb2_BaseINT { get; set; }
        [MemoryOffset(0x5FC)]
        public short Limb2_CurrentAGL { get; set; }
        [MemoryOffset(0x5FE)]
        public ushort Limb2_BaseAGL { get; set; }
        [MemoryOffset(0x658)]
        public byte Limb2_DropRate { get; set; }
        [MemoryOffset(0x65A)]
        public byte Limb2_ArmorIndex { get; set; }
        [MemoryOffset(0x5C0)]
        public ushort Limb2_Armor_Id { get; set; }
        [MemoryOffset(0x5C2)]
        public byte Limb2_Armor_SubId { get; set; }
        [MemoryOffset(0x5C3)]
        public byte Limb2_Armor_WepId { get; set; }
        [MemoryOffset(0x5C4)]
        public byte Limb2_Armor_Category { get; set; }
        [MemoryOffset(0x5C5)]
        public byte Limb2_Armor_Str { get; set; }
        [MemoryOffset(0x5C6)]
        public byte Limb2_Armor_Int { get; set; }
        [MemoryOffset(0x5C7)]
        public byte Limb2_Armor_Agi { get; set; }
        [MemoryOffset(0x5C8)]
        public ushort Limb2_Armor_CurrentDP { get; set; }
        [MemoryOffset(0x5CA)]
        public ushort Limb2_Armor_MaxDP { get; set; }
        [MemoryOffset(0x5CC)]
        public ushort Limb2_Armor_CurrentPP { get; set; }
        [MemoryOffset(0x5CE)]
        public ushort Limb2_Armor_MaxPP { get; set; }
        [MemoryOffset(0x5D0)]
        public byte Limb2_Armor_DamageType { get; set; }
        [MemoryOffset(0x5D1)]
        public byte Limb2_Armor_CostType { get; set; }
        [MemoryOffset(0x5D2)]
        public byte Limb2_Armor_Cost { get; set; }
        [MemoryOffset(0x5D3)]
        public byte Limb2_Armor_Material { get; set; }
        [MemoryOffset(0x5D5)]
        public byte Limb2_Armor_GemSlots { get; set; }
        [MemoryOffset(0x5D6)]
        public byte Limb2_Armor_GemEffects { get; set; }
        [MemoryOffset(0x5D7)]
        public byte Limb2_Armor_Index { get; set; }
        [MemoryOffset(0x5D8)]
        public byte Limb2_Armor_Range { get; set; }
        [MemoryOffset(0x5DC)]
        public byte Limb2_Armor_BareHands { get; set; }
        [MemoryOffset(0x5DD)]
        public byte Limb2_Armor_Blunt { get; set; }
        [MemoryOffset(0x5DE)]
        public byte Limb2_Armor_Edged { get; set; }
        [MemoryOffset(0x5DF)]
        public byte Limb2_Armor_Piercing { get; set; }
        [MemoryOffset(0x5E0)]
        public byte Limb2_Armor_Human { get; set; }
        [MemoryOffset(0x5E1)]
        public byte Limb2_Armor_Beast { get; set; }
        [MemoryOffset(0x5E2)]
        public byte Limb2_Armor_Undead { get; set; }
        [MemoryOffset(0x5E3)]
        public byte Limb2_Armor_Phantom { get; set; }
        [MemoryOffset(0x5E4)]
        public byte Limb2_Armor_Dragon { get; set; }
        [MemoryOffset(0x5E5)]
        public byte Limb2_Armor_Evil { get; set; }
        [MemoryOffset(0x5E8)]
        public byte Limb2_Armor_Physical { get; set; }
        [MemoryOffset(0x5E9)]
        public byte Limb2_Armor_Air { get; set; }
        [MemoryOffset(0x5EA)]
        public byte Limb2_Armor_Fire { get; set; }
        [MemoryOffset(0x5EB)]
        public byte Limb2_Armor_Earth { get; set; }
        [MemoryOffset(0x5EC)]
        public byte Limb2_Armor_Water { get; set; }
        [MemoryOffset(0x5ED)]
        public byte Limb2_Armor_Light { get; set; }
        [MemoryOffset(0x5EE)]
        public byte Limb2_Armor_Dark { get; set; }

        // ===========================================
        // LIMB 3 (vs_battle_uiEquipment_limb)
        // ===========================================
        [MemoryOffset(0x67C)]
        public short Limb3_HP { get; set; }
        [MemoryOffset(0x67E)]
        public short Limb3_MaxHP { get; set; }
        [MemoryOffset(0x680)]
        public byte Limb3_AgilityDefenseBonus { get; set; }
        [MemoryOffset(0x682)]
        public byte Limb3_NameIndex { get; set; }
        [MemoryOffset(0x683)]
        public byte Limb3_ChainEvasion { get; set; }
        [MemoryOffset(0x6CC)]
        public ushort Limb3_CurrentDP { get; set; }
        [MemoryOffset(0x6CE)]
        public ushort Limb3_MaxDP { get; set; }
        [MemoryOffset(0x6D0)]
        public short Limb3_CurrentSTR { get; set; }
        [MemoryOffset(0x6D2)]
        public ushort Limb3_BaseSTR { get; set; }
        [MemoryOffset(0x6D4)]
        public short Limb3_CurrentINT { get; set; }
        [MemoryOffset(0x6D6)]
        public ushort Limb3_BaseINT { get; set; }
        [MemoryOffset(0x6D8)]
        public short Limb3_CurrentAGL { get; set; }
        [MemoryOffset(0x6DA)]
        public ushort Limb3_BaseAGL { get; set; }
        [MemoryOffset(0x734)]
        public byte Limb3_DropRate { get; set; }
        [MemoryOffset(0x736)]
        public byte Limb3_ArmorIndex { get; set; }
        [MemoryOffset(0x69C)]
        public ushort Limb3_Armor_Id { get; set; }
        [MemoryOffset(0x69E)]
        public byte Limb3_Armor_SubId { get; set; }
        [MemoryOffset(0x69F)]
        public byte Limb3_Armor_WepId { get; set; }
        [MemoryOffset(0x6A0)]
        public byte Limb3_Armor_Category { get; set; }
        [MemoryOffset(0x6A1)]
        public byte Limb3_Armor_Str { get; set; }
        [MemoryOffset(0x6A2)]
        public byte Limb3_Armor_Int { get; set; }
        [MemoryOffset(0x6A3)]
        public byte Limb3_Armor_Agi { get; set; }
        [MemoryOffset(0x6A4)]
        public ushort Limb3_Armor_CurrentDP { get; set; }
        [MemoryOffset(0x6A6)]
        public ushort Limb3_Armor_MaxDP { get; set; }
        [MemoryOffset(0x6A8)]
        public ushort Limb3_Armor_CurrentPP { get; set; }
        [MemoryOffset(0x6AA)]
        public ushort Limb3_Armor_MaxPP { get; set; }
        [MemoryOffset(0x6AC)]
        public byte Limb3_Armor_DamageType { get; set; }
        [MemoryOffset(0x6AD)]
        public byte Limb3_Armor_CostType { get; set; }
        [MemoryOffset(0x6AE)]
        public byte Limb3_Armor_Cost { get; set; }
        [MemoryOffset(0x6AF)]
        public byte Limb3_Armor_Material { get; set; }
        [MemoryOffset(0x6B1)]
        public byte Limb3_Armor_GemSlots { get; set; }
        [MemoryOffset(0x6B2)]
        public byte Limb3_Armor_GemEffects { get; set; }
        [MemoryOffset(0x6B3)]
        public byte Limb3_Armor_Index { get; set; }
        [MemoryOffset(0x6B4)]
        public byte Limb3_Armor_Range { get; set; }
        [MemoryOffset(0x6B8)]
        public byte Limb3_Armor_BareHands { get; set; }
        [MemoryOffset(0x6B9)]
        public byte Limb3_Armor_Blunt { get; set; }
        [MemoryOffset(0x6BA)]
        public byte Limb3_Armor_Edged { get; set; }
        [MemoryOffset(0x6BB)]
        public byte Limb3_Armor_Piercing { get; set; }
        [MemoryOffset(0x6BC)]
        public byte Limb3_Armor_Human { get; set; }
        [MemoryOffset(0x6BD)]
        public byte Limb3_Armor_Beast { get; set; }
        [MemoryOffset(0x6BE)]
        public byte Limb3_Armor_Undead { get; set; }
        [MemoryOffset(0x6BF)]
        public byte Limb3_Armor_Phantom { get; set; }
        [MemoryOffset(0x6C0)]
        public byte Limb3_Armor_Dragon { get; set; }
        [MemoryOffset(0x6C1)]
        public byte Limb3_Armor_Evil { get; set; }
        [MemoryOffset(0x6C4)]
        public byte Limb3_Armor_Physical { get; set; }
        [MemoryOffset(0x6C5)]
        public byte Limb3_Armor_Air { get; set; }
        [MemoryOffset(0x6C6)]
        public byte Limb3_Armor_Fire { get; set; }
        [MemoryOffset(0x6C7)]
        public byte Limb3_Armor_Earth { get; set; }
        [MemoryOffset(0x6C8)]
        public byte Limb3_Armor_Water { get; set; }
        [MemoryOffset(0x6C9)]
        public byte Limb3_Armor_Light { get; set; }
        [MemoryOffset(0x6CA)]
        public byte Limb3_Armor_Dark { get; set; }

        // ===========================================
        // LIMB 4 (vs_battle_uiEquipment_limb)
        // ===========================================
        [MemoryOffset(0x758)]
        public short Limb4_HP { get; set; }
        [MemoryOffset(0x75A)]
        public short Limb4_MaxHP { get; set; }
        [MemoryOffset(0x75C)]
        public byte Limb4_AgilityDefenseBonus { get; set; }
        [MemoryOffset(0x75E)]
        public byte Limb4_NameIndex { get; set; }
        [MemoryOffset(0x75F)]
        public byte Limb4_ChainEvasion { get; set; }
        [MemoryOffset(0x7A8)]
        public ushort Limb4_CurrentDP { get; set; }
        [MemoryOffset(0x7AA)]
        public ushort Limb4_MaxDP { get; set; }
        [MemoryOffset(0x7AC)]
        public short Limb4_CurrentSTR { get; set; }
        [MemoryOffset(0x7AE)]
        public ushort Limb4_BaseSTR { get; set; }
        [MemoryOffset(0x7B0)]
        public short Limb4_CurrentINT { get; set; }
        [MemoryOffset(0x7B2)]
        public ushort Limb4_BaseINT { get; set; }
        [MemoryOffset(0x7B4)]
        public short Limb4_CurrentAGL { get; set; }
        [MemoryOffset(0x7B6)]
        public ushort Limb4_BaseAGL { get; set; }
        [MemoryOffset(0x810)]
        public byte Limb4_DropRate { get; set; }
        [MemoryOffset(0x812)]
        public byte Limb4_ArmorIndex { get; set; }
        [MemoryOffset(0x778)]
        public ushort Limb4_Armor_Id { get; set; }
        [MemoryOffset(0x77A)]
        public byte Limb4_Armor_SubId { get; set; }
        [MemoryOffset(0x77B)]
        public byte Limb4_Armor_WepId { get; set; }
        [MemoryOffset(0x77C)]
        public byte Limb4_Armor_Category { get; set; }
        [MemoryOffset(0x77D)]
        public byte Limb4_Armor_Str { get; set; }
        [MemoryOffset(0x77E)]
        public byte Limb4_Armor_Int { get; set; }
        [MemoryOffset(0x77F)]
        public byte Limb4_Armor_Agi { get; set; }
        [MemoryOffset(0x780)]
        public ushort Limb4_Armor_CurrentDP { get; set; }
        [MemoryOffset(0x782)]
        public ushort Limb4_Armor_MaxDP { get; set; }
        [MemoryOffset(0x784)]
        public ushort Limb4_Armor_CurrentPP { get; set; }
        [MemoryOffset(0x786)]
        public ushort Limb4_Armor_MaxPP { get; set; }
        [MemoryOffset(0x788)]
        public byte Limb4_Armor_DamageType { get; set; }
        [MemoryOffset(0x789)]
        public byte Limb4_Armor_CostType { get; set; }
        [MemoryOffset(0x78A)]
        public byte Limb4_Armor_Cost { get; set; }
        [MemoryOffset(0x78B)]
        public byte Limb4_Armor_Material { get; set; }
        [MemoryOffset(0x78D)]
        public byte Limb4_Armor_GemSlots { get; set; }
        [MemoryOffset(0x78E)]
        public byte Limb4_Armor_GemEffects { get; set; }
        [MemoryOffset(0x78F)]
        public byte Limb4_Armor_Index { get; set; }
        [MemoryOffset(0x790)]
        public byte Limb4_Armor_Range { get; set; }
        [MemoryOffset(0x794)]
        public byte Limb4_Armor_BareHands { get; set; }
        [MemoryOffset(0x795)]
        public byte Limb4_Armor_Blunt { get; set; }
        [MemoryOffset(0x796)]
        public byte Limb4_Armor_Edged { get; set; }
        [MemoryOffset(0x797)]
        public byte Limb4_Armor_Piercing { get; set; }
        [MemoryOffset(0x798)]
        public byte Limb4_Armor_Human { get; set; }
        [MemoryOffset(0x799)]
        public byte Limb4_Armor_Beast { get; set; }
        [MemoryOffset(0x79A)]
        public byte Limb4_Armor_Undead { get; set; }
        [MemoryOffset(0x79B)]
        public byte Limb4_Armor_Phantom { get; set; }
        [MemoryOffset(0x79C)]
        public byte Limb4_Armor_Dragon { get; set; }
        [MemoryOffset(0x79D)]
        public byte Limb4_Armor_Evil { get; set; }
        [MemoryOffset(0x7A0)]
        public byte Limb4_Armor_Physical { get; set; }
        [MemoryOffset(0x7A1)]
        public byte Limb4_Armor_Air { get; set; }
        [MemoryOffset(0x7A2)]
        public byte Limb4_Armor_Fire { get; set; }
        [MemoryOffset(0x7A3)]
        public byte Limb4_Armor_Earth { get; set; }
        [MemoryOffset(0x7A4)]
        public byte Limb4_Armor_Water { get; set; }
        [MemoryOffset(0x7A5)]
        public byte Limb4_Armor_Light { get; set; }
        [MemoryOffset(0x7A6)]
        public byte Limb4_Armor_Dark { get; set; }

        // ===========================================
        // LIMB 5 (vs_battle_uiEquipment_limb)
        // ===========================================
        [MemoryOffset(0x834)]
        public short Limb5_HP { get; set; }
        [MemoryOffset(0x836)]
        public short Limb5_MaxHP { get; set; }
        [MemoryOffset(0x838)]
        public byte Limb5_AgilityDefenseBonus { get; set; }
        [MemoryOffset(0x83A)]
        public byte Limb5_NameIndex { get; set; }
        [MemoryOffset(0x83B)]
        public byte Limb5_ChainEvasion { get; set; }
        [MemoryOffset(0x884)]
        public ushort Limb5_CurrentDP { get; set; }
        [MemoryOffset(0x886)]
        public ushort Limb5_MaxDP { get; set; }
        [MemoryOffset(0x888)]
        public short Limb5_CurrentSTR { get; set; }
        [MemoryOffset(0x88A)]
        public ushort Limb5_BaseSTR { get; set; }
        [MemoryOffset(0x88C)]
        public short Limb5_CurrentINT { get; set; }
        [MemoryOffset(0x88E)]
        public ushort Limb5_BaseINT { get; set; }
        [MemoryOffset(0x890)]
        public short Limb5_CurrentAGL { get; set; }
        [MemoryOffset(0x892)]
        public ushort Limb5_BaseAGL { get; set; }
        [MemoryOffset(0x8EC)]
        public byte Limb5_DropRate { get; set; }
        [MemoryOffset(0x8EE)]
        public byte Limb5_ArmorIndex { get; set; }
        [MemoryOffset(0x854)]
        public ushort Limb5_Armor_Id { get; set; }
        [MemoryOffset(0x856)]
        public byte Limb5_Armor_SubId { get; set; }
        [MemoryOffset(0x857)]
        public byte Limb5_Armor_WepId { get; set; }
        [MemoryOffset(0x858)]
        public byte Limb5_Armor_Category { get; set; }
        [MemoryOffset(0x859)]
        public byte Limb5_Armor_Str { get; set; }
        [MemoryOffset(0x85A)]
        public byte Limb5_Armor_Int { get; set; }
        [MemoryOffset(0x85B)]
        public byte Limb5_Armor_Agi { get; set; }
        [MemoryOffset(0x85C)]
        public ushort Limb5_Armor_CurrentDP { get; set; }
        [MemoryOffset(0x85E)]
        public ushort Limb5_Armor_MaxDP { get; set; }
        [MemoryOffset(0x860)]
        public ushort Limb5_Armor_CurrentPP { get; set; }
        [MemoryOffset(0x862)]
        public ushort Limb5_Armor_MaxPP { get; set; }
        [MemoryOffset(0x864)]
        public byte Limb5_Armor_DamageType { get; set; }
        [MemoryOffset(0x865)]
        public byte Limb5_Armor_CostType { get; set; }
        [MemoryOffset(0x866)]
        public byte Limb5_Armor_Cost { get; set; }
        [MemoryOffset(0x867)]
        public byte Limb5_Armor_Material { get; set; }
        [MemoryOffset(0x869)]
        public byte Limb5_Armor_GemSlots { get; set; }
        [MemoryOffset(0x86A)]
        public byte Limb5_Armor_GemEffects { get; set; }
        [MemoryOffset(0x86B)]
        public byte Limb5_Armor_Index { get; set; }
        [MemoryOffset(0x86C)]
        public byte Limb5_Armor_Range { get; set; }
        [MemoryOffset(0x870)]
        public byte Limb5_Armor_BareHands { get; set; }
        [MemoryOffset(0x871)]
        public byte Limb5_Armor_Blunt { get; set; }
        [MemoryOffset(0x872)]
        public byte Limb5_Armor_Edged { get; set; }
        [MemoryOffset(0x873)]
        public byte Limb5_Armor_Piercing { get; set; }
        [MemoryOffset(0x874)]
        public byte Limb5_Armor_Human { get; set; }
        [MemoryOffset(0x875)]
        public byte Limb5_Armor_Beast { get; set; }
        [MemoryOffset(0x876)]
        public byte Limb5_Armor_Undead { get; set; }
        [MemoryOffset(0x877)]
        public byte Limb5_Armor_Phantom { get; set; }
        [MemoryOffset(0x878)]
        public byte Limb5_Armor_Dragon { get; set; }
        [MemoryOffset(0x879)]
        public byte Limb5_Armor_Evil { get; set; }
        [MemoryOffset(0x87C)]
        public byte Limb5_Armor_Physical { get; set; }
        [MemoryOffset(0x87D)]
        public byte Limb5_Armor_Air { get; set; }
        [MemoryOffset(0x87E)]
        public byte Limb5_Armor_Fire { get; set; }
        [MemoryOffset(0x87F)]
        public byte Limb5_Armor_Earth { get; set; }
        [MemoryOffset(0x880)]
        public byte Limb5_Armor_Water { get; set; }
        [MemoryOffset(0x881)]
        public byte Limb5_Armor_Light { get; set; }
        [MemoryOffset(0x882)]
        public byte Limb5_Armor_Dark { get; set; }

        // ===========================================
        // STATUS
        // ===========================================
        [MemoryOffset(0x998)]  // vs_battle_statuses bit mask
        public uint StatusEffects { get; set; }
        [MemoryOffset(0x9A4)]
        public ushort ActionDelay { get; set; }

        // ===========================================
        // LOOT
        // ===========================================
        [MemoryOffset(0x9A8)]  // item id of the first drop
        public ushort GuaranteedLoot1_Name { get; set; }
        [MemoryOffset(0x9AA)]
        public byte GuaranteedLoot1_Quantity { get; set; }
        [MemoryOffset(0x9AC)]  // item id of the second drop
        public ushort GuaranteedLoot2_Name { get; set; }
        [MemoryOffset(0x9AE)]
        public byte GuaranteedLoot2_Quantity { get; set; }
        [MemoryOffset(0x9B0)]  // random drop
        public ushort MiscLootName { get; set; }
        [MemoryOffset(0x9B2)]  // range 0-255
        public byte MiscLootDropChance { get; set; }
    }
}
