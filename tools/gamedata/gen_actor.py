import sys; sys.path.insert(0,".")
from specs import *
A="vs_battle_actor_dat2"
st=lambda p:f"unk0.unk50.{p}"       # path of a stats field inside vs_battle_actor_dat2
ac=lambda p:f"unk0.unk0.{p}"        # actor field
sections=[]   # (title, [Spec items])
def sec(title,items): sections.append((title,items))
def S(): return Spec()
# --- actor header
s=S()
s.add("NextActorPointer","u32",A,ac("next"),"next actor in the list (0x8xxxxxxx pointer)")
s.add("ActorId","u32",A,ac("id"))
s.add("SubType","u16",A,ac("subType"))
s.add("EquippedWeaponCategory","u8",A,ac("equippedWeaponCategory"))
s.add("Defeated","u8",A,ac("defeated"))
s.add("Tile_X","u8",A,ac("currentTile.x"))
s.add("Tile_Surface","u8",A,ac("currentTile.surface"))
s.add("Tile_Z","u8",A,ac("currentTile.z"))
s.add("Tile_Status","u8",A,ac("currentTile.status"))
s.add("StatsPointer","u32",A,ac("stats"),"pointer to the stats block that follows the actor (+0x50)")
sec("ACTOR (+$000) - vs_battle_actor",s.items)
s=S()
for n,t,f in [("CurrentHP","s16","currentHP"),("MaxHP","s16","maxHP"),("CurrentMP","s16","currentMP"),("MaxMP","s16","maxMP"),("RISK","u16","risk"),
              ("OriginalSTR","u16","strength"),("EquippedSTR","u16","totalStrength"),("OriginalINT","u16","intelligence"),("EquippedINT","u16","totalIntelligence"),
              ("OriginalAGL","u16","agility"),("EquippedAGL","u16","totalAgility")]:
    s.add(n,t,A,st(f))
sec("STATS (+$050) - vs_battle_actorStats; the 24 byte name is at +$050 and the weapon name at +$08C (not mapped)",s.items)
# --- weapon
W=st("weapon")
for name,base,title in [("Blade","blade","BLADE"),("Grip","grip","GRIP"),("WGem1","gems[0]","WEAPON GEM 1"),("WGem2","gems[1]","WEAPON GEM 2"),("WGem3","gems[2]","WEAPON GEM 3")]:
    s=S(); equip(s,name,A,f"{W}.{base}"); sec(f"{title} (vs_battle_uiEquipment)",s.items)
s=S()
for n,t,f in [("WepId","u8","wepId"),("DamageTypeValue","u8","damageTypeValue"),("Risk","u8","risk"),("DropRate","u8","dropRate"),("Index","u8","index"),("DamageType","u8","damageType"),("ActionType","u8","actionType"),
              ("CurrentPP","u16","currentPp"),("MaxPP","u16","maxPp"),("CurrentDP","u16","currentDp"),("MaxDP","u16","maxDp"),
              ("CurrentSTR","s16","currentStr"),("BaseSTR","u16","baseStr"),("CurrentINT","s16","currentInt"),("BaseINT","u16","baseInt"),("CurrentAGL","s16","currentAgility"),("BaseAGL","u16","baseAgility"),("Range","u8","range.range")]:
    s.add(f"WeaponTotal_{n}",t,A,f"{W}.{f}")
sec("WEAPON TOTALS (vs_battle_uiWeapon)",s.items)
# --- shield
SH=st("shield")
s=S(); equip(s,"Shield",A,f"{SH}.base"); sec("SHIELD (vs_battle_uiEquipment)",s.items)
for i in range(3):
    s=S(); equip(s,f"SGem{i+1}",A,f"{SH}.gems[{i}]"); sec(f"SHIELD GEM {i+1}",s.items)
s=S()
for n,t,f in [("WepId","u8","wepId"),("DropRate","u8","dropRate"),("Index","u8","index"),("CurrentPP","u16","currentPp"),("MaxPP","u16","maxPp"),("CurrentDP","u16","currentDp"),("MaxDP","u16","maxDp"),
              ("CurrentSTR","s16","currentStr"),("BaseSTR","u16","baseStr"),("CurrentINT","s16","currentInt"),("BaseINT","u16","baseInt"),("CurrentAGL","s16","currentAgility"),("BaseAGL","u16","baseAgility")]:
    s.add(f"ShieldTotal_{n}",t,A,f"{SH}.{f}")
sec("SHIELD TOTALS (vs_battle_uiShield)",s.items)
# --- accessory
AC=st("accessory")
s=S(); equip(s,"Accessory",A,f"{AC}.accessory"); sec("ACCESSORY (vs_battle_uiEquipment)",s.items)
s=S()
for n,t,f in [("CurrentSTR","s16","currentStr"),("CurrentINT","s16","currentInt"),("CurrentAGL","s16","currentAgility"),("DropRate","u8","dropRate"),("Index","u8","index")]:
    s.add(f"AccessoryTotal_{n}",t,A,f"{AC}.{f}")
sec("ACCESSORY TOTALS (vs_battle_uiAccessory)",s.items)
# --- limbs
for i in range(6):
    L=st(f"limbs[{i}]")
    s=S()
    for n,t,f in [("HP","s16","hp"),("MaxHP","s16","maxHp"),("AgilityDefenseBonus","u8","agilityDefenseBonus"),("NameIndex","u8","nameIndex"),("ChainEvasion","u8","chainEvasion")]:
        s.add(f"Limb{i}_{n}",t,A,f"{L}.{f}")
    for n,t,f in [("CurrentDP","u16","currentDp"),("MaxDP","u16","maxDp"),("CurrentSTR","s16","currentStr"),("BaseSTR","u16","baseStr"),("CurrentINT","s16","currentInt"),("BaseINT","u16","baseInt"),("CurrentAGL","s16","currentAgility"),("BaseAGL","u16","baseAgility"),("DropRate","u8","dropRate"),("ArmorIndex","u8","index")]:
        s.add(f"Limb{i}_{n}",t,A,f"{L}.armor.{f}")
    equip(s,f"Limb{i}_Armor",A,f"{L}.armor.armor")
    sec(f"LIMB {i} (vs_battle_uiEquipment_limb)",s.items)
# --- status + loot
s=S()
s.add("StatusEffects","u32",A,st("statuses"),"vs_battle_statuses bit mask")
s.add("ActionDelay","u16",A,st("actionDelay"))
sec("STATUS",s.items)
s=S()
s.add("GuaranteedLoot1_Name","u16",A,st("miscItem.id"),"item id of the first drop")
s.add("GuaranteedLoot1_Quantity","u8",A,st("miscItem.count"))
s.add("GuaranteedLoot2_Name","u16",A,st("unk95C.id"),"item id of the second drop")
s.add("GuaranteedLoot2_Quantity","u8",A,st("unk95C.count"))
s.add("MiscLootName","u16",A,st("unk960.id"),"random drop")
s.add("MiscLootDropChance","u8",A,st("unk960.dropRate"),"range 0-255")
sec("LOOT",s.items)
allitems=[it for _,its in sections for it in its]
offs=compile_offsets(allitems)
names=[it[0] for it in allitems]; assert len(names)==len(set(names)),[n for n in names if names.count(n)>1][:5]
out=["using Archipelago.Core.Util;","","namespace VagrantStoryArchipelago.Models.MapData","{",
"    /// <summary>",
"    /// A battle actor (vs_battle_actor, 0x50 bytes) followed by its stats block (vs_battle_actorStats at +0x50, 0x964 bytes).",
"    /// Every offset was produced by compiling the rood-reverse headers and taking offsetof(), so they match the game build.",
"    /// Equipment is stored in the game's vs_battle_uiEquipment layout (not the inventory layout). Bytes marked signed in the game",
"    /// (strength/intelligence/agility, types, classes, affinities) are read as byte, so values above 127 are negative.",
"    /// </summary>","    public class MapActorData","    {"]
k=0
for title,its in sections:
    out.append("        // ===========================================")
    out.append(f"        // {title}")
    out.append("        // ===========================================")
    for name,ct,struct,path,cm in its:
        o=offs[k]; k+=1
        out.append(f"        [MemoryOffset(0x{o:X})]"+(f"  // {cm}" if cm else ""))
        out.append(f"        public {CS[ct]} {name} {{ get; set; }}")
    out.append("")
out[-1:]=["    }","}"]
open("MapActorData.new.cs","w",encoding="utf-8").write("\r\n".join(out)+"\r\n")
print(len(allitems),"properties")
# sanity anchors
import collections
d={n:o for n,o in zip(names,offs)}
for n in ["NextActorPointer","StatsPointer","CurrentHP","RISK","EquippedAGL","Blade_Id","Grip_Id","WGem1_Id","WGem3_Id","Shield_Id","SGem1_Id","Accessory_Id","Limb0_Armor_Id","Limb4_Armor_Id","StatusEffects","GuaranteedLoot1_Name","GuaranteedLoot2_Name","MiscLootName","Tile_X"]: print(n,hex(d[n]))
