import sys,re; sys.path.insert(0,".")
from specs import *
L="vs_battle_loot"
# 1) verify the part of the old class that is being kept (weapon .. standalone grip)
old=open(r"C:/Users/Dan/source/repos/VagrantStoryArchipelago/Models/MapData/MapChestData.cs",encoding="utf-8-sig").read()
props=dict((n,int(o,16)) for o,n in re.findall(r"MemoryOffset\((0x[0-9A-Fa-f]+)\)\]\s*(?://[^\n]*)?\s*public \w+ (\w+)",old))
chk=[]
def inv_blade(prefix,base):
    for n,f in [("ItemNameIndex","id"),("ItemIndex","subId"),("FileIndex","wepId"),("Category","category"),("DPMax","maxDp"),("PPMax","maxPp"),("DPCurrent","currentDp"),("PPCurrent","currentPp"),("STR","strength"),("INT","intelligence"),("AGL","agility"),("Cost","cost"),("Range","range"),("Classes","classes"),("Affinities","affinities"),("Material","material")]:
        chk.append((prefix+n,f"{base}.{f}"))
inv_blade("Weapon","weapon.blade"); inv_blade("Blade","blade.blade")
chk.append(("WeaponExists","weapon.difficultyFlags")); chk.append(("BladeExists","blade.difficultyFlags")); chk.append(("GripStandaloneExists","grip.difficultyFlags"))
for p,b in (("Grip","weapon.grip"),("GripStandalone","grip.grip")):
    for n,f in [("ItemNameIndex","id"),("ItemIndex","subId"),("Category","category"),("GemSlots","gemSlots"),("STR","strength"),("INT","intelligence"),("AGL","agility"),("Types","types")]:
        chk.append((p+n,f"{b}.{f}"))
for g in (1,2,3):
    for n,f in [("NameIndex","id"),("ItemIndex","subId"),("SpecialEffect","gemEffects"),("STR","strength"),("INT","intelligence"),("AGL","agility"),("Classes","classes"),("Affinities","affinities")]:
        chk.append((f"WGem{g}_{n}",f"weapon.gems[{g-1}].{f}"))
items=[(n,"u8",L,p,"") for n,p in chk if n in props]
offs=compile_offsets(items)
bad=[(n,hex(props[n]),hex(o)) for (n,_,_,p,_),o in zip(items,offs) if props[n]!=o]
print("kept-section properties checked:",len(items),"mismatching:",bad)

# 2) generate shield .. misc from the compiler
secs=[]
def inv_armor(prefix,base,exists_path,hdr_name):
    its=[(hdr_name,"u32",L,exists_path,"difficulty flags / present marker of the entry")]
    for n,ct,f in [("NameIndex","u8","id"),("ItemIndex","u8","subId"),("FileIndex","u8","wepId"),("Category","u8","category"),("DPMax","u16","maxDp"),("PPMax","u16","maxPp"),("DPCurrent","u16","currentDp"),("PPCurrent","u16","currentPp"),
                   ("GemSlots","u8","gemSlots"),("STR","u8","strength"),("INT","u8","intelligence"),("AGL","u8","agility"),("Types","u32","types"),("Classes","u64","classes"),("Affinities","u64","affinities"),("Material","u16","material"),("Limb","u8","limb"),("Index","u8","index")]:
        its.append((f"{prefix}_{n}",ct,L,f"{base}.{f}",""))
    return its
def inv_gem(prefix,base):
    return [(f"{prefix}_{n}",ct,L,f"{base}.{f}","") for n,ct,f in [("NameIndex","u16","id"),("ItemIndex","u8","subId"),("SpecialEffect","u8","gemEffects"),("STR","u8","strength"),("INT","u8","intelligence"),("AGL","u8","agility"),("Classes","u64","classes"),("Affinities","u64","affinities"),("SetItemIndex","u16","setItemIndex"),("Index","u16","index")]]
secs.append(("SHIELD (+$0F0)",inv_armor("Shield","shield.shield","shield.difficultyFlags","ShieldExists")))
for g in (1,2,3): secs.append((f"SHIELD GEM {g}",inv_gem(f"ShieldGem{g}",f"shield.gems[{g-1}]")))
secs.append(("ARMOR 1 (+$170)",inv_armor("Armor1","armor[0].armor","armor[0].difficultyFlags","Armor1Exists")))
secs.append(("ARMOR 2 (+$19C)",inv_armor("Armor2","armor[1].armor","armor[1].difficultyFlags","Armor2Exists")))
secs.append(("ACCESSORY (+$1C8)",inv_armor("Accessory","accessory.accessory","accessory.difficultyFlags","AccessoryExists")))
g=[("GemExists","u32",L,"gem.difficultyFlags","difficulty flags / present marker of the entry")]+inv_gem("Gem","gem.gem")
secs.append(("STANDALONE GEM (+$1F4)",g))
m=[]
for i in range(3):
    m+=[(f"Misc{i+1}_ID","u8",L,f"misc[{i}].id","low byte of the u16 item id"),(f"Misc{i+1}_Confirm","u8",L,f"misc[{i}].id + 1","high byte of the u16 item id (1 for keys, sigils and other 0x1xx ids)"),
        (f"Misc{i+1}_Exists","u8",L,f"misc[{i}].difficultyFlags","difficulty flags, non-zero = present"),(f"Misc{i+1}_Qty","u8",L,f"misc[{i}].count","")]
secs.append(("MISC ITEMS (+$214), 3 entries of 4 bytes. The loot record ends at +$220.",m))
allit=[it for _,its in secs for it in its]
# the "+ 1" path trick for the id high byte isn't valid inside offsetof, so build it from the base offset
fixed=[]
for n,ct,s,p,c in allit:
    if p.endswith(" + 1"): fixed.append((n,ct,s,p[:-4],c,1))
    else: fixed.append((n,ct,s,p,c,0))
offs=compile_offsets([(n,ct,s,p,c) for n,ct,s,p,c,_ in fixed])
lines=[]; k=0
for title,its in secs:
    lines.append(f"        // --- {title} ---")
    for _ in its:
        n,ct,s,p,c,add=fixed[k]; o=offs[k]+add; k+=1
        lines.append(f"        [MemoryOffset(0x{o:X})]"+(f"  // {c}" if c else ""))
        lines.append(f"        public {CS[ct]} {n} {{ get; set; }}")
    lines.append("")
new_tail="\n".join(lines).rstrip("\n")+"\n"
src=old.replace("\r\n","\n")
i=src.index("        // --- SHIELD (+$0EC) ---")
head=src[:i]
out=head+new_tail+"    }\n}\n"
out=out.replace("    public class MapChestData\n","    /// <summary>\n    /// A room's loot record (vs_battle_loot, 0x220 bytes) as the game copies it to room section 13 + 0x14. Offsets from the rood-reverse headers,\n    /// checked with offsetof() on the compiled structs.\n    /// </summary>\n    public class MapChestData\n")
open("MapChestData.new.cs","w",encoding="utf-8").write(out.replace("\n","\r\n"))
d={n:o for (n,_,_,_,_,_),o in zip(fixed,offs)}
for n in ["ShieldExists","Shield_NameIndex","Shield_Material","ShieldGem1_NameIndex","Armor1Exists","Armor1_Material","Armor2Exists","AccessoryExists","Accessory_Material","GemExists","Gem_NameIndex","Misc1_ID","Misc3_Qty"]: print(n,hex(d[n]))
