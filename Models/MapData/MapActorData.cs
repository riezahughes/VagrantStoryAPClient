using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.MapData
{
    public class MapActorData
    {
        // --- LINKED LIST POINTER (+$000) ---
        [MemoryOffset(0x00)]
        public uint NextActorPointer { get; set; }

        // _padding0: $04–$2B (40 bytes) skipped

        // --- POSITION (+$02C) ---
        [MemoryOffset(0x2C)]
        public ushort XCoordinate { get; set; }
        [MemoryOffset(0x2E)]
        public ushort YCoordinate { get; set; }

        // padding: $30–$3B (12 bytes) skipped

        // --- NAME POINTER (+$03C) ---
        [MemoryOffset(0x3C)]
        public uint ActorNamePointer { get; set; }

        // padding: $40–$4F (16 bytes) skipped

        // --- ACTOR NAME (+$050) --- (24 bytes, skipped to avoid alignment issues)
        // [MemoryOffset(0x50)]
        // public string ActorName { get; set; } // Length $18

        // --- STATS (+$068) ---
        [MemoryOffset(0x68)]
        public ushort CurrentHP { get; set; }
        [MemoryOffset(0x6A)]
        public ushort MaxHP { get; set; }
        [MemoryOffset(0x6C)]
        public ushort CurrentMP { get; set; }
        [MemoryOffset(0x6E)]
        public ushort MaxMP { get; set; }
        [MemoryOffset(0x70)]
        public ushort RISK { get; set; }

        // Signed shorts (2s)
        [MemoryOffset(0x72)]
        public short OriginalSTR { get; set; }
        [MemoryOffset(0x74)]
        public short EquippedSTR { get; set; }
        [MemoryOffset(0x76)]
        public short OriginalINT { get; set; }
        [MemoryOffset(0x78)]
        public short EquippedINT { get; set; }
        [MemoryOffset(0x7A)]
        public short OriginalAGL { get; set; }
        [MemoryOffset(0x7C)]
        public short EquippedAGL { get; set; }

        // padding: $7E–$8B (14 bytes) skipped

        // --- WEAPON NAME (+$08C) --- (24 bytes, skipped to avoid alignment issues)
        // [MemoryOffset(0x8C)]
        // public string WeaponName { get; set; } // Length $18

        // ===========================================
        // BLADE EQUIP DATA (+$0A4) — ref: InventoryBladeData
        // ===========================================
        [MemoryOffset(0xA4)]
        public uint BladeID { get; set; }
        [MemoryOffset(0xA7)]
        public byte BladeType { get; set; }
        [MemoryOffset(0xA8)]
        public ushort BladeMaxDP { get; set; }
        [MemoryOffset(0xAA)]
        public ushort BladeMaxPP { get; set; }
        [MemoryOffset(0xAC)]
        public ushort BladeCurrentPP { get; set; }
        [MemoryOffset(0xAE)]
        public ushort BladeCurrentDP { get; set; }
        [MemoryOffset(0xB0)]
        public byte BladeStrStat { get; set; }
        [MemoryOffset(0xB1)]
        public byte BladeIntStat { get; set; }
        [MemoryOffset(0xB2)]
        public byte BladeAgiStat { get; set; }
        [MemoryOffset(0xB3)]
        public ushort BladeRiskStat { get; set; }
        [MemoryOffset(0xB8)]
        public byte BladeRangeStat { get; set; }
        [MemoryOffset(0xBC)]
        public byte BladeHumanStat { get; set; }
        [MemoryOffset(0xBD)]
        public byte BladeBeastStat { get; set; }
        [MemoryOffset(0xBE)]
        public byte BladeUndeadStat { get; set; }
        [MemoryOffset(0xBF)]
        public byte BladePhantomStat { get; set; }
        [MemoryOffset(0xC0)]
        public byte BladeDragonStat { get; set; }
        [MemoryOffset(0xC1)]
        public byte BladeEvilStat { get; set; }
        [MemoryOffset(0xC4)]
        public byte BladePhysicalStat { get; set; }
        [MemoryOffset(0xC5)]
        public byte BladeAirStat { get; set; }
        [MemoryOffset(0xC6)]
        public byte BladeFireStat { get; set; }
        [MemoryOffset(0xC7)]
        public byte BladeEarthStat { get; set; }
        [MemoryOffset(0xC8)]
        public byte BladeWaterStat { get; set; }
        [MemoryOffset(0xC9)]
        public byte BladeLightStat { get; set; }
        [MemoryOffset(0xCA)]
        public byte BladeDarkStat { get; set; }
        [MemoryOffset(0xCC)]
        public byte BladeMaterial { get; set; }
        [MemoryOffset(0xCE)]
        public byte BladeEquipStatus { get; set; }
        [MemoryOffset(0xCF)]
        public byte BladeInventorySlot { get; set; }

        // ===========================================
        // GRIP EQUIP DATA (+$0D4) — ref: InventoryGripData
        // ===========================================
        [MemoryOffset(0xD4)]
        public uint GripID { get; set; }
        [MemoryOffset(0xD6)]
        public byte GripInventorySlot { get; set; }
        [MemoryOffset(0xD7)]
        public byte GripType { get; set; }
        [MemoryOffset(0xD8)]
        public byte GripGemSlotQuantity { get; set; }
        [MemoryOffset(0xD9)]
        public byte GripStrStat { get; set; }
        [MemoryOffset(0xDA)]
        public byte GripIntStat { get; set; }
        [MemoryOffset(0xDB)]
        public byte GripAgiStat { get; set; }
        [MemoryOffset(0xDD)]
        public byte GripBluntStat { get; set; }
        [MemoryOffset(0xDE)]
        public byte GripEdgedStat { get; set; }
        [MemoryOffset(0xDF)]
        public byte GripPierceStat { get; set; }
        [MemoryOffset(0xE0)]
        public byte GripEquipStatus { get; set; }
        [MemoryOffset(0xE1)]
        public byte GripSetStatus { get; set; }

        // ===========================================
        // WEAPON GEM 1 EQUIP DATA (+$104) — ref: InventoryGemData
        // ===========================================
        [MemoryOffset(0x106)]
        public byte WGem1_InventorySlot { get; set; }
        [MemoryOffset(0x108)]
        public byte WGem1_ID { get; set; }
        [MemoryOffset(0x109)]
        public byte WGem1_TextCategory { get; set; }
        [MemoryOffset(0x10D)]
        public byte WGem1_StrStat { get; set; }
        [MemoryOffset(0x10E)]
        public byte WGem1_IntStat { get; set; }
        [MemoryOffset(0x10F)]
        public byte WGem1_AgiStat { get; set; }
        [MemoryOffset(0x110)]
        public byte WGem1_HumanStat { get; set; }
        [MemoryOffset(0x111)]
        public byte WGem1_BeastStat { get; set; }
        [MemoryOffset(0x112)]
        public byte WGem1_UndeadStat { get; set; }
        [MemoryOffset(0x113)]
        public byte WGem1_PhantomStat { get; set; }
        [MemoryOffset(0x114)]
        public byte WGem1_DragonStat { get; set; }
        [MemoryOffset(0x115)]
        public byte WGem1_EvilStat { get; set; }
        [MemoryOffset(0x118)]
        public byte WGem1_PhysicalStat { get; set; }
        [MemoryOffset(0x119)]
        public byte WGem1_AirStat { get; set; }
        [MemoryOffset(0x11A)]
        public byte WGem1_FireStat { get; set; }
        [MemoryOffset(0x11B)]
        public byte WGem1_EarthStat { get; set; }
        [MemoryOffset(0x11C)]
        public byte WGem1_WaterStat { get; set; }
        [MemoryOffset(0x11D)]
        public byte WGem1_LightStat { get; set; }
        [MemoryOffset(0x11E)]
        public byte WGem1_DarkStat { get; set; }

        // ===========================================
        // WEAPON GEM 2 EQUIP DATA (+$134) — ref: InventoryGemData
        // ===========================================
        [MemoryOffset(0x136)]
        public byte WGem2_InventorySlot { get; set; }
        [MemoryOffset(0x138)]
        public byte WGem2_ID { get; set; }
        [MemoryOffset(0x139)]
        public byte WGem2_TextCategory { get; set; }
        [MemoryOffset(0x13D)]
        public byte WGem2_StrStat { get; set; }
        [MemoryOffset(0x13E)]
        public byte WGem2_IntStat { get; set; }
        [MemoryOffset(0x13F)]
        public byte WGem2_AgiStat { get; set; }
        [MemoryOffset(0x140)]
        public byte WGem2_HumanStat { get; set; }
        [MemoryOffset(0x141)]
        public byte WGem2_BeastStat { get; set; }
        [MemoryOffset(0x142)]
        public byte WGem2_UndeadStat { get; set; }
        [MemoryOffset(0x143)]
        public byte WGem2_PhantomStat { get; set; }
        [MemoryOffset(0x144)]
        public byte WGem2_DragonStat { get; set; }
        [MemoryOffset(0x145)]
        public byte WGem2_EvilStat { get; set; }
        [MemoryOffset(0x148)]
        public byte WGem2_PhysicalStat { get; set; }
        [MemoryOffset(0x149)]
        public byte WGem2_AirStat { get; set; }
        [MemoryOffset(0x14A)]
        public byte WGem2_FireStat { get; set; }
        [MemoryOffset(0x14B)]
        public byte WGem2_EarthStat { get; set; }
        [MemoryOffset(0x14C)]
        public byte WGem2_WaterStat { get; set; }
        [MemoryOffset(0x14D)]
        public byte WGem2_LightStat { get; set; }
        [MemoryOffset(0x14E)]
        public byte WGem2_DarkStat { get; set; }

        // ===========================================
        // WEAPON GEM 3 EQUIP DATA (+$164) — ref: InventoryGemData
        // ===========================================
        [MemoryOffset(0x166)]
        public byte WGem3_InventorySlot { get; set; }
        [MemoryOffset(0x168)]
        public byte WGem3_ID { get; set; }
        [MemoryOffset(0x169)]
        public byte WGem3_TextCategory { get; set; }
        [MemoryOffset(0x16D)]
        public byte WGem3_StrStat { get; set; }
        [MemoryOffset(0x16E)]
        public byte WGem3_IntStat { get; set; }
        [MemoryOffset(0x16F)]
        public byte WGem3_AgiStat { get; set; }
        [MemoryOffset(0x170)]
        public byte WGem3_HumanStat { get; set; }
        [MemoryOffset(0x171)]
        public byte WGem3_BeastStat { get; set; }
        [MemoryOffset(0x172)]
        public byte WGem3_UndeadStat { get; set; }
        [MemoryOffset(0x173)]
        public byte WGem3_PhantomStat { get; set; }
        [MemoryOffset(0x174)]
        public byte WGem3_DragonStat { get; set; }
        [MemoryOffset(0x175)]
        public byte WGem3_EvilStat { get; set; }
        [MemoryOffset(0x178)]
        public byte WGem3_PhysicalStat { get; set; }
        [MemoryOffset(0x179)]
        public byte WGem3_AirStat { get; set; }
        [MemoryOffset(0x17A)]
        public byte WGem3_FireStat { get; set; }
        [MemoryOffset(0x17B)]
        public byte WGem3_EarthStat { get; set; }
        [MemoryOffset(0x17C)]
        public byte WGem3_WaterStat { get; set; }
        [MemoryOffset(0x17D)]
        public byte WGem3_LightStat { get; set; }
        [MemoryOffset(0x17E)]
        public byte WGem3_DarkStat { get; set; }

        // padding: $194–$23B (168 bytes) skipped

        // ===========================================
        // SHIELD EQUIP DATA (+$23C) — ref: InventoryShieldData
        // ===========================================
        [MemoryOffset(0x23C)]
        public byte ShieldInventorySlot { get; set; }
        [MemoryOffset(0x23D)]
        public byte ShieldEquipStatus { get; set; }
        [MemoryOffset(0x240)]
        public uint ShieldID { get; set; }
        [MemoryOffset(0x243)]
        public ushort ShieldMaxDP { get; set; }
        [MemoryOffset(0x245)]
        public ushort ShieldMaxPP { get; set; }
        [MemoryOffset(0x247)]
        public ushort ShieldCurrentPP { get; set; }
        [MemoryOffset(0x249)]
        public ushort ShieldCurrentDP { get; set; }
        [MemoryOffset(0x24C)]
        public byte ShieldGemSlotQuantity { get; set; }
        [MemoryOffset(0x24D)]
        public byte ShieldStrStat { get; set; }
        [MemoryOffset(0x24E)]
        public byte ShieldIntStat { get; set; }
        [MemoryOffset(0x24F)]
        public byte ShieldAgiStat { get; set; }
        [MemoryOffset(0x250)]
        public byte ShieldBluntDefStat { get; set; }
        [MemoryOffset(0x251)]
        public byte ShieldEdgedDefStat { get; set; }
        [MemoryOffset(0x252)]
        public byte ShieldPiercingDefStat { get; set; }
        [MemoryOffset(0x254)]
        public byte ShieldHumanStat { get; set; }
        [MemoryOffset(0x255)]
        public byte ShieldBeastStat { get; set; }
        [MemoryOffset(0x256)]
        public byte ShieldUndeadStat { get; set; }
        [MemoryOffset(0x257)]
        public byte ShieldPhantomStat { get; set; }
        [MemoryOffset(0x258)]
        public byte ShieldDragonStat { get; set; }
        [MemoryOffset(0x259)]
        public byte ShieldEvilStat { get; set; }
        [MemoryOffset(0x25C)]
        public byte ShieldPhysicalStat { get; set; }
        [MemoryOffset(0x25D)]
        public byte ShieldAirStat { get; set; }
        [MemoryOffset(0x25E)]
        public byte ShieldFireStat { get; set; }
        [MemoryOffset(0x25F)]
        public byte ShieldEarthStat { get; set; }
        [MemoryOffset(0x260)]
        public byte ShieldWaterStat { get; set; }
        [MemoryOffset(0x261)]
        public byte ShieldLightStat { get; set; }
        [MemoryOffset(0x262)]
        public byte ShieldDarkStat { get; set; }
        [MemoryOffset(0x264)]
        public byte ShieldMaterial { get; set; }
        [MemoryOffset(0x268)]
        public byte ShieldGemSlotReference1 { get; set; }
        [MemoryOffset(0x269)]
        public byte ShieldGemSlotReference2 { get; set; }
        [MemoryOffset(0x26A)]
        public byte ShieldGemSlotReference3 { get; set; }

        // ===========================================
        // SHIELD GEM 1 EQUIP DATA (+$26C) — ref: InventoryGemData
        // ===========================================
        [MemoryOffset(0x26E)]
        public byte ShieldGem1_InventorySlot { get; set; }
        [MemoryOffset(0x270)]
        public byte ShieldGem1_ID { get; set; }
        [MemoryOffset(0x271)]
        public byte ShieldGem1_TextCategory { get; set; }
        [MemoryOffset(0x275)]
        public byte ShieldGem1_StrStat { get; set; }
        [MemoryOffset(0x276)]
        public byte ShieldGem1_IntStat { get; set; }
        [MemoryOffset(0x277)]
        public byte ShieldGem1_AgiStat { get; set; }
        [MemoryOffset(0x278)]
        public byte ShieldGem1_HumanStat { get; set; }
        [MemoryOffset(0x279)]
        public byte ShieldGem1_BeastStat { get; set; }
        [MemoryOffset(0x27A)]
        public byte ShieldGem1_UndeadStat { get; set; }
        [MemoryOffset(0x27B)]
        public byte ShieldGem1_PhantomStat { get; set; }
        [MemoryOffset(0x27C)]
        public byte ShieldGem1_DragonStat { get; set; }
        [MemoryOffset(0x27D)]
        public byte ShieldGem1_EvilStat { get; set; }
        [MemoryOffset(0x280)]
        public byte ShieldGem1_PhysicalStat { get; set; }
        [MemoryOffset(0x281)]
        public byte ShieldGem1_AirStat { get; set; }
        [MemoryOffset(0x282)]
        public byte ShieldGem1_FireStat { get; set; }
        [MemoryOffset(0x283)]
        public byte ShieldGem1_EarthStat { get; set; }
        [MemoryOffset(0x284)]
        public byte ShieldGem1_WaterStat { get; set; }
        [MemoryOffset(0x285)]
        public byte ShieldGem1_LightStat { get; set; }
        [MemoryOffset(0x286)]
        public byte ShieldGem1_DarkStat { get; set; }

        // ===========================================
        // SHIELD GEM 2 EQUIP DATA (+$29C) — ref: InventoryGemData
        // ===========================================
        [MemoryOffset(0x29E)]
        public byte ShieldGem2_InventorySlot { get; set; }
        [MemoryOffset(0x2A0)]
        public byte ShieldGem2_ID { get; set; }
        [MemoryOffset(0x2A1)]
        public byte ShieldGem2_TextCategory { get; set; }
        [MemoryOffset(0x2A5)]
        public byte ShieldGem2_StrStat { get; set; }
        [MemoryOffset(0x2A6)]
        public byte ShieldGem2_IntStat { get; set; }
        [MemoryOffset(0x2A7)]
        public byte ShieldGem2_AgiStat { get; set; }
        [MemoryOffset(0x2A8)]
        public byte ShieldGem2_HumanStat { get; set; }
        [MemoryOffset(0x2A9)]
        public byte ShieldGem2_BeastStat { get; set; }
        [MemoryOffset(0x2AA)]
        public byte ShieldGem2_UndeadStat { get; set; }
        [MemoryOffset(0x2AB)]
        public byte ShieldGem2_PhantomStat { get; set; }
        [MemoryOffset(0x2AC)]
        public byte ShieldGem2_DragonStat { get; set; }
        [MemoryOffset(0x2AD)]
        public byte ShieldGem2_EvilStat { get; set; }
        [MemoryOffset(0x2B0)]
        public byte ShieldGem2_PhysicalStat { get; set; }
        [MemoryOffset(0x2B1)]
        public byte ShieldGem2_AirStat { get; set; }
        [MemoryOffset(0x2B2)]
        public byte ShieldGem2_FireStat { get; set; }
        [MemoryOffset(0x2B3)]
        public byte ShieldGem2_EarthStat { get; set; }
        [MemoryOffset(0x2B4)]
        public byte ShieldGem2_WaterStat { get; set; }
        [MemoryOffset(0x2B5)]
        public byte ShieldGem2_LightStat { get; set; }
        [MemoryOffset(0x2B6)]
        public byte ShieldGem2_DarkStat { get; set; }

        // ===========================================
        // SHIELD GEM 3 EQUIP DATA (+$2CC) — ref: InventoryGemData
        // ===========================================
        [MemoryOffset(0x2CE)]
        public byte ShieldGem3_InventorySlot { get; set; }
        [MemoryOffset(0x2D0)]
        public byte ShieldGem3_ID { get; set; }
        [MemoryOffset(0x2D1)]
        public byte ShieldGem3_TextCategory { get; set; }
        [MemoryOffset(0x2D5)]
        public byte ShieldGem3_StrStat { get; set; }
        [MemoryOffset(0x2D6)]
        public byte ShieldGem3_IntStat { get; set; }
        [MemoryOffset(0x2D7)]
        public byte ShieldGem3_AgiStat { get; set; }
        [MemoryOffset(0x2D8)]
        public byte ShieldGem3_HumanStat { get; set; }
        [MemoryOffset(0x2D9)]
        public byte ShieldGem3_BeastStat { get; set; }
        [MemoryOffset(0x2DA)]
        public byte ShieldGem3_UndeadStat { get; set; }
        [MemoryOffset(0x2DB)]
        public byte ShieldGem3_PhantomStat { get; set; }
        [MemoryOffset(0x2DC)]
        public byte ShieldGem3_DragonStat { get; set; }
        [MemoryOffset(0x2DD)]
        public byte ShieldGem3_EvilStat { get; set; }
        [MemoryOffset(0x2E0)]
        public byte ShieldGem3_PhysicalStat { get; set; }
        [MemoryOffset(0x2E1)]
        public byte ShieldGem3_AirStat { get; set; }
        [MemoryOffset(0x2E2)]
        public byte ShieldGem3_FireStat { get; set; }
        [MemoryOffset(0x2E3)]
        public byte ShieldGem3_EarthStat { get; set; }
        [MemoryOffset(0x2E4)]
        public byte ShieldGem3_WaterStat { get; set; }
        [MemoryOffset(0x2E5)]
        public byte ShieldGem3_LightStat { get; set; }
        [MemoryOffset(0x2E6)]
        public byte ShieldGem3_DarkStat { get; set; }

        // padding: $2FC–$387 (140 bytes) skipped

        // ===========================================
        // ACCESSORY EQUIP DATA (+$388) — ref: InventoryArmorData
        // ===========================================
        [MemoryOffset(0x388)]
        public byte AccessoryInventorySlot { get; set; }
        [MemoryOffset(0x389)]
        public uint AccessoryID { get; set; }
        [MemoryOffset(0x38C)]
        public byte AccessoryType { get; set; }
        [MemoryOffset(0x38D)]
        public ushort AccessoryMaxDP { get; set; }
        [MemoryOffset(0x391)]
        public byte AccessoryCurrentDP { get; set; }
        [MemoryOffset(0x396)]
        public byte AccessoryStrStat { get; set; }
        [MemoryOffset(0x397)]
        public byte AccessoryIntStat { get; set; }
        [MemoryOffset(0x398)]
        public byte AccessoryAgiStat { get; set; }
        [MemoryOffset(0x39A)]
        public byte AccessoryBluntDefStat { get; set; }
        [MemoryOffset(0x39B)]
        public byte AccessoryEdgedDefStat { get; set; }
        [MemoryOffset(0x39C)]
        public byte AccessoryPiercingDefStat { get; set; }
        [MemoryOffset(0x39D)]
        public byte AccessoryHumanStat { get; set; }
        [MemoryOffset(0x39E)]
        public byte AccessoryBeastStat { get; set; }
        [MemoryOffset(0x39F)]
        public byte AccessoryUndeadStat { get; set; }
        [MemoryOffset(0x3A0)]
        public byte AccessoryPhantomStat { get; set; }
        [MemoryOffset(0x3A1)]
        public byte AccessoryDragonStat { get; set; }
        [MemoryOffset(0x3A2)]
        public byte AccessoryEvilStat { get; set; }
        [MemoryOffset(0x3A5)]
        public byte AccessoryPhysicalStat { get; set; }
        [MemoryOffset(0x3A6)]
        public byte AccessoryAirStat { get; set; }
        [MemoryOffset(0x3A7)]
        public byte AccessoryFireStat { get; set; }
        [MemoryOffset(0x3A8)]
        public byte AccessoryEarthStat { get; set; }
        [MemoryOffset(0x3A9)]
        public byte AccessoryWaterStat { get; set; }
        [MemoryOffset(0x3AA)]
        public byte AccessoryLightStat { get; set; }
        [MemoryOffset(0x3AB)]
        public byte AccessoryDarkStat { get; set; }
        [MemoryOffset(0x3AD)]
        public byte AccessoryMaterial { get; set; }
        [MemoryOffset(0x3AF)]
        public byte AccessoryEquipStatus { get; set; }

        // padding: $3B8–$407 (80 bytes) skipped

        // ===========================================
        // RIGHT ARM EQUIP DATA (+$408) — ref: InventoryArmorData
        // ===========================================
        [MemoryOffset(0x408)]
        public byte RightArmInventorySlot { get; set; }
        [MemoryOffset(0x409)]
        public uint RightArmID { get; set; }
        [MemoryOffset(0x40C)]
        public byte RightArmType { get; set; }
        [MemoryOffset(0x40D)]
        public ushort RightArmMaxDP { get; set; }
        [MemoryOffset(0x411)]
        public byte RightArmCurrentDP { get; set; }
        [MemoryOffset(0x416)]
        public byte RightArmStrStat { get; set; }
        [MemoryOffset(0x417)]
        public byte RightArmIntStat { get; set; }
        [MemoryOffset(0x418)]
        public byte RightArmAgiStat { get; set; }
        [MemoryOffset(0x41A)]
        public byte RightArmBluntDefStat { get; set; }
        [MemoryOffset(0x41B)]
        public byte RightArmEdgedDefStat { get; set; }
        [MemoryOffset(0x41C)]
        public byte RightArmPiercingDefStat { get; set; }
        [MemoryOffset(0x41D)]
        public byte RightArmHumanStat { get; set; }
        [MemoryOffset(0x41E)]
        public byte RightArmBeastStat { get; set; }
        [MemoryOffset(0x41F)]
        public byte RightArmUndeadStat { get; set; }
        [MemoryOffset(0x420)]
        public byte RightArmPhantomStat { get; set; }
        [MemoryOffset(0x421)]
        public byte RightArmDragonStat { get; set; }
        [MemoryOffset(0x422)]
        public byte RightArmEvilStat { get; set; }
        [MemoryOffset(0x425)]
        public byte RightArmPhysicalStat { get; set; }
        [MemoryOffset(0x426)]
        public byte RightArmAirStat { get; set; }
        [MemoryOffset(0x427)]
        public byte RightArmFireStat { get; set; }
        [MemoryOffset(0x428)]
        public byte RightArmEarthStat { get; set; }
        [MemoryOffset(0x429)]
        public byte RightArmWaterStat { get; set; }
        [MemoryOffset(0x42A)]
        public byte RightArmLightStat { get; set; }
        [MemoryOffset(0x42B)]
        public byte RightArmDarkStat { get; set; }
        [MemoryOffset(0x42D)]
        public byte RightArmMaterial { get; set; }
        [MemoryOffset(0x42F)]
        public byte RightArmEquipStatus { get; set; }

        // padding: $438–$4E3 (172 bytes) skipped

        // ===========================================
        // LEFT ARM EQUIP DATA (+$4E4) — ref: InventoryArmorData
        // ===========================================
        [MemoryOffset(0x4E4)]
        public byte LeftArmInventorySlot { get; set; }
        [MemoryOffset(0x4E5)]
        public uint LeftArmID { get; set; }
        [MemoryOffset(0x4E8)]
        public byte LeftArmType { get; set; }
        [MemoryOffset(0x4E9)]
        public ushort LeftArmMaxDP { get; set; }
        [MemoryOffset(0x4ED)]
        public byte LeftArmCurrentDP { get; set; }
        [MemoryOffset(0x4F2)]
        public byte LeftArmStrStat { get; set; }
        [MemoryOffset(0x4F3)]
        public byte LeftArmIntStat { get; set; }
        [MemoryOffset(0x4F4)]
        public byte LeftArmAgiStat { get; set; }
        [MemoryOffset(0x4F6)]
        public byte LeftArmBluntDefStat { get; set; }
        [MemoryOffset(0x4F7)]
        public byte LeftArmEdgedDefStat { get; set; }
        [MemoryOffset(0x4F8)]
        public byte LeftArmPiercingDefStat { get; set; }
        [MemoryOffset(0x4F9)]
        public byte LeftArmHumanStat { get; set; }
        [MemoryOffset(0x4FA)]
        public byte LeftArmBeastStat { get; set; }
        [MemoryOffset(0x4FB)]
        public byte LeftArmUndeadStat { get; set; }
        [MemoryOffset(0x4FC)]
        public byte LeftArmPhantomStat { get; set; }
        [MemoryOffset(0x4FD)]
        public byte LeftArmDragonStat { get; set; }
        [MemoryOffset(0x4FE)]
        public byte LeftArmEvilStat { get; set; }
        [MemoryOffset(0x501)]
        public byte LeftArmPhysicalStat { get; set; }
        [MemoryOffset(0x502)]
        public byte LeftArmAirStat { get; set; }
        [MemoryOffset(0x503)]
        public byte LeftArmFireStat { get; set; }
        [MemoryOffset(0x504)]
        public byte LeftArmEarthStat { get; set; }
        [MemoryOffset(0x505)]
        public byte LeftArmWaterStat { get; set; }
        [MemoryOffset(0x506)]
        public byte LeftArmLightStat { get; set; }
        [MemoryOffset(0x507)]
        public byte LeftArmDarkStat { get; set; }
        [MemoryOffset(0x509)]
        public byte LeftArmMaterial { get; set; }
        [MemoryOffset(0x50B)]
        public byte LeftArmEquipStatus { get; set; }

        // padding: $514–$5BF (172 bytes) skipped

        // ===========================================
        // HELM EQUIP DATA (+$5C0) — ref: InventoryArmorData
        // ===========================================
        [MemoryOffset(0x5C0)]
        public byte HelmInventorySlot { get; set; }
        [MemoryOffset(0x5C1)]
        public uint HelmID { get; set; }
        [MemoryOffset(0x5C4)]
        public byte HelmType { get; set; }
        [MemoryOffset(0x5C5)]
        public ushort HelmMaxDP { get; set; }
        [MemoryOffset(0x5C9)]
        public byte HelmCurrentDP { get; set; }
        [MemoryOffset(0x5CE)]
        public byte HelmStrStat { get; set; }
        [MemoryOffset(0x5CF)]
        public byte HelmIntStat { get; set; }
        [MemoryOffset(0x5D0)]
        public byte HelmAgiStat { get; set; }
        [MemoryOffset(0x5D2)]
        public byte HelmBluntDefStat { get; set; }
        [MemoryOffset(0x5D3)]
        public byte HelmEdgedDefStat { get; set; }
        [MemoryOffset(0x5D4)]
        public byte HelmPiercingDefStat { get; set; }
        [MemoryOffset(0x5D5)]
        public byte HelmHumanStat { get; set; }
        [MemoryOffset(0x5D6)]
        public byte HelmBeastStat { get; set; }
        [MemoryOffset(0x5D7)]
        public byte HelmUndeadStat { get; set; }
        [MemoryOffset(0x5D8)]
        public byte HelmPhantomStat { get; set; }
        [MemoryOffset(0x5D9)]
        public byte HelmDragonStat { get; set; }
        [MemoryOffset(0x5DA)]
        public byte HelmEvilStat { get; set; }
        [MemoryOffset(0x5DD)]
        public byte HelmPhysicalStat { get; set; }
        [MemoryOffset(0x5DE)]
        public byte HelmAirStat { get; set; }
        [MemoryOffset(0x5DF)]
        public byte HelmFireStat { get; set; }
        [MemoryOffset(0x5E0)]
        public byte HelmEarthStat { get; set; }
        [MemoryOffset(0x5E1)]
        public byte HelmWaterStat { get; set; }
        [MemoryOffset(0x5E2)]
        public byte HelmLightStat { get; set; }
        [MemoryOffset(0x5E3)]
        public byte HelmDarkStat { get; set; }
        [MemoryOffset(0x5E5)]
        public byte HelmMaterial { get; set; }
        [MemoryOffset(0x5E7)]
        public byte HelmEquipStatus { get; set; }

        // padding: $5F0–$69B (172 bytes) skipped

        // ===========================================
        // BREASTPLATE EQUIP DATA (+$69C) — ref: InventoryArmorData
        // ===========================================
        [MemoryOffset(0x69C)]
        public byte BreastplateInventorySlot { get; set; }
        [MemoryOffset(0x69D)]
        public uint BreastplateID { get; set; }
        [MemoryOffset(0x6A0)]
        public byte BreastplateType { get; set; }
        [MemoryOffset(0x6A1)]
        public ushort BreastplateMaxDP { get; set; }
        [MemoryOffset(0x6A5)]
        public byte BreastplateCurrentDP { get; set; }
        [MemoryOffset(0x6AA)]
        public byte BreastplateStrStat { get; set; }
        [MemoryOffset(0x6AB)]
        public byte BreastplateIntStat { get; set; }
        [MemoryOffset(0x6AC)]
        public byte BreastplateAgiStat { get; set; }
        [MemoryOffset(0x6AE)]
        public byte BreastplateBluntDefStat { get; set; }
        [MemoryOffset(0x6AF)]
        public byte BreastplateEdgedDefStat { get; set; }
        [MemoryOffset(0x6B0)]
        public byte BreastplatePiercingDefStat { get; set; }
        [MemoryOffset(0x6B1)]
        public byte BreastplateHumanStat { get; set; }
        [MemoryOffset(0x6B2)]
        public byte BreastplateBeastStat { get; set; }
        [MemoryOffset(0x6B3)]
        public byte BreastplateUndeadStat { get; set; }
        [MemoryOffset(0x6B4)]
        public byte BreastplatePhantomStat { get; set; }
        [MemoryOffset(0x6B5)]
        public byte BreastplateDragonStat { get; set; }
        [MemoryOffset(0x6B6)]
        public byte BreastplateEvilStat { get; set; }
        [MemoryOffset(0x6B9)]
        public byte BreastplatePhysicalStat { get; set; }
        [MemoryOffset(0x6BA)]
        public byte BreastplateAirStat { get; set; }
        [MemoryOffset(0x6BB)]
        public byte BreastplateFireStat { get; set; }
        [MemoryOffset(0x6BC)]
        public byte BreastplateEarthStat { get; set; }
        [MemoryOffset(0x6BD)]
        public byte BreastplateWaterStat { get; set; }
        [MemoryOffset(0x6BE)]
        public byte BreastplateLightStat { get; set; }
        [MemoryOffset(0x6BF)]
        public byte BreastplateDarkStat { get; set; }
        [MemoryOffset(0x6C1)]
        public byte BreastplateMaterial { get; set; }
        [MemoryOffset(0x6C3)]
        public byte BreastplateEquipStatus { get; set; }

        // padding: $6CC–$777 (172 bytes) skipped

        // ===========================================
        // LEGGINGS EQUIP DATA (+$778) — ref: InventoryArmorData
        // ===========================================
        [MemoryOffset(0x778)]
        public byte LeggingsInventorySlot { get; set; }
        [MemoryOffset(0x779)]
        public uint LeggingsID { get; set; }
        [MemoryOffset(0x77C)]
        public byte LeggingsType { get; set; }
        [MemoryOffset(0x77D)]
        public ushort LeggingsMaxDP { get; set; }
        [MemoryOffset(0x781)]
        public byte LeggingsCurrentDP { get; set; }
        [MemoryOffset(0x786)]
        public byte LeggingsStrStat { get; set; }
        [MemoryOffset(0x787)]
        public byte LeggingsIntStat { get; set; }
        [MemoryOffset(0x788)]
        public byte LeggingsAgiStat { get; set; }
        [MemoryOffset(0x78A)]
        public byte LeggingsBluntDefStat { get; set; }
        [MemoryOffset(0x78B)]
        public byte LeggingsEdgedDefStat { get; set; }
        [MemoryOffset(0x78C)]
        public byte LeggingsPiercingDefStat { get; set; }
        [MemoryOffset(0x78D)]
        public byte LeggingsHumanStat { get; set; }
        [MemoryOffset(0x78E)]
        public byte LeggingsBeastStat { get; set; }
        [MemoryOffset(0x78F)]
        public byte LeggingsUndeadStat { get; set; }
        [MemoryOffset(0x790)]
        public byte LeggingsPhantomStat { get; set; }
        [MemoryOffset(0x791)]
        public byte LeggingsDragonStat { get; set; }
        [MemoryOffset(0x792)]
        public byte LeggingsEvilStat { get; set; }
        [MemoryOffset(0x795)]
        public byte LeggingsPhysicalStat { get; set; }
        [MemoryOffset(0x796)]
        public byte LeggingsAirStat { get; set; }
        [MemoryOffset(0x797)]
        public byte LeggingsFireStat { get; set; }
        [MemoryOffset(0x798)]
        public byte LeggingsEarthStat { get; set; }
        [MemoryOffset(0x799)]
        public byte LeggingsWaterStat { get; set; }
        [MemoryOffset(0x79A)]
        public byte LeggingsLightStat { get; set; }
        [MemoryOffset(0x79B)]
        public byte LeggingsDarkStat { get; set; }
        [MemoryOffset(0x79D)]
        public byte LeggingsMaterial { get; set; }
        [MemoryOffset(0x79F)]
        public byte LeggingsEquipStatus { get; set; }

        // padding: $7A8–$997 (496 bytes) skipped

        // ===========================================
        // STATUS EFFECTS (+$998) — 16 bytes
        // ===========================================
        [MemoryOffset(0x998)]
        public ulong StatusEffects1 { get; set; }
        [MemoryOffset(0x9A0)]
        public ulong StatusEffects2 { get; set; }

        // ===========================================
        // LOOT (+$9A8) — ref: InventoryItemData layout
        // ===========================================
        [MemoryOffset(0x9A8)]
        public ushort GuaranteedLoot1_Name { get; set; }
        [MemoryOffset(0x9AA)]
        public byte GuaranteedLoot1_Quantity { get; set; }
        // $9AB padding

        [MemoryOffset(0x9AC)]
        public ushort GuaranteedLoot2_Name { get; set; }
        [MemoryOffset(0x9AE)]
        public byte GuaranteedLoot2_Quantity { get; set; }
        // $9AF padding

        [MemoryOffset(0x9B0)]
        public ushort MiscLootName { get; set; }
        [MemoryOffset(0x9B2)]
        public byte MiscLootDropChance { get; set; } // range 0–255, represents 0.0–1.0
    }
}