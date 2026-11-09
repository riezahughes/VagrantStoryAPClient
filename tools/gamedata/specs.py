import re,subprocess,os
RR="C:/Users/Dan/AppData/Local/Temp/claude/3cad74f8b8ca03ce/054dc5ce-2eb7-4ce8-b589-d11b3dcb5b20/scratchpad/rr/src"
G="C:/Users/Dan/g++-mipsel-none-elf-13.1.0/bin/mipsel-none-elf-gcc.exe"
CLASSES=["Human","Beast","Undead","Phantom","Dragon","Evil"]
AFFIN=["Physical","Air","Fire","Earth","Water","Light","Dark"]
TYPES=["BareHands","Blunt","Edged","Piercing"]
class Spec:
    def __init__(s): s.items=[]   # (propname, ctype, struct, path, comment)
    def add(s,name,ct,struct,path,comment=""): s.items.append((name,ct,struct,path,comment))
def equip(sp,prefix,struct,base):
    """vs_battle_uiEquipment at <base> inside <struct> (actor stats based)"""
    b=lambda f: f"{base}.{f}" if base else f
    for n,t,f in [("Id","u16","id"),("SubId","u8","subId"),("WepId","u8","wepId"),("Category","u8","category"),("Str","u8","strength"),("Int","u8","intelligence"),("Agi","u8","agility"),
                  ("CurrentDP","u16","currentDp"),("MaxDP","u16","maxDp"),("CurrentPP","u16","currentPp"),("MaxPP","u16","maxPp"),
                  ("DamageType","u8","damageType"),("CostType","u8","costType"),("Cost","u8","cost"),("Material","u8","material"),("GemSlots","u8","gemSlots"),("GemEffects","u8","gemEffects"),("Index","u8","index"),("Range","u8","range.range")]:
        sp.add(f"{prefix}_{n}",t,struct,b(f))
    for i,n in enumerate(TYPES): sp.add(f"{prefix}_{n}","u8",struct,b(f"types[{i}]"))
    for i,n in enumerate(CLASSES): sp.add(f"{prefix}_{n}","u8",struct,b(f"classes[{i}]"))
    for i,n in enumerate(AFFIN): sp.add(f"{prefix}_{n}","u8",struct,b(f"affinities[{i}]"))
def compile_offsets(items,extra_include='#include "src/BATTLE/BATTLE.PRG/actor.h"\n#include "src/BATTLE/BATTLE.PRG/loot.h"\n'):
    c=extra_include+"#define offsetof(t,m) __builtin_offsetof(t,m)\n"
    for i,(name,ct,struct,path,_) in enumerate(items):
        c+=f"const int o{i} = 0x10000 + offsetof({struct}, {path});\n"
    open(RR+"/../gen_offs.c","w").write(c)
    r=subprocess.run([G,"-S","-O0","-I.","-Iinclude","-Isrc/include","-Isrc","-Iinclude/psx","-ffreestanding","-o","../gen_offs.s","../gen_offs.c"],cwd=RR,capture_output=True,text=True)
    if r.returncode: raise SystemExit(r.stderr[:3000])
    t=open(RR+"/../gen_offs.s").read()
    off={int(m.group(1)):int(m.group(2))-0x10000 for m in re.finditer(r"^o(\d+):\s*\n\s*\.word\s+(\d+)",t,re.M)}
    assert len(off)==len(items),(len(off),len(items))
    return [off[i] for i in range(len(items))]
CS={"u8":"byte","u16":"ushort","s16":"short","u32":"uint","u64":"ulong"}
