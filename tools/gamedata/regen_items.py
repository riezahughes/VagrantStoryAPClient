import struct,os,collections,re,statistics
S="C:/Users/Dan/AppData/Local/Temp/claude/3cad74f8b8ca03ce/054dc5ce-2eb7-4ce8-b589-d11b3dcb5b20/scratchpad/"
exec(open(S+"armorcmp.py").read())
dsh=open(S+"shield_syd.bin","rb").read(); infos=struct.unpack_from("<I",dsh,8)[0]
SHD={i:struct.unpack_from("<4B3bB",dsh,infos+i*8) for i in range(17)}
# real per-sub data from chest loot (armor1/armor2/shield base)
os.chdir(r"D:/Roms/PSX/Vagrant Story (USA)/maps")
real={}   # sub -> dict(basedp,pp,types)
for k in range(512):
    dd=open(f"MAP{k:03d}.MPD","rb").read()
    off,ln=struct.unpack_from("<II",dd,0x28)
    if ln!=544: continue
    L=dd[off:off+544]
    for o in (0x174,0x1A0,0xF4):
        if not L[o-4]: continue
        b=L[o:o+0x28]; sub=b[1]; mi=struct.unpack_from("<H",b,36)[0]
        real[sub]=dict(dp=struct.unpack_from("<H",b,4)[0]-MAT[mi]['dp'],pp=struct.unpack_from("<H",b,6)[0],types=tuple(struct.unpack_from("<3b",b,17)))
os.chdir(r"C:/Users/Dan/source/repos/VagrantStoryArchipelago")
catmed=collections.defaultdict(list)
for sub,v in real.items():
    if sub in ARM and ARM[sub][2]!=1: catmed[ARM[sub][2]].append(v['dp'])
shdp=[v['dp'] for s,v in real.items() if s<=16]; shpp=[v['pp'] for s,v in real.items() if s<=16]
DPMED={c:int(statistics.median(v)) for c,v in catmed.items()}; SHDP=int(statistics.median(shdp)); SHPP=int(statistics.median(shpp))
print("known armour/shield subs",len(real),"| median base DP by category",DPMED,"| shield DP/PP",SHDP,SHPP)
h=lambda v:f"0x{v&0xFF:02X}"
h16=lambda v:f"0x{v:04X}"
stats=collections.Counter()
def regen_armor(file,enumfile,enumname):
    ev=enumvals(enumfile); p=EL+file
    raw=open(p,"rb").read(); t=raw.decode("utf-8-sig"); crlf="\r\n" in t
    pat=re.compile(r'(\["([^"]+)"\] = new InventoryArmorData\("[^"]+", (0x[0-9A-F]+), %s\.(\w+), ArmorType\.(\w+), )(0x[0-9A-F]+), (0x[0-9A-F]+), ((?:0x[0-9A-F]+, ){19})ItemMaterials\.(\w+), (0x[0-9A-F]+)\)'%enumname)
    def sub(m):
        i=ev[m.group(4)]; subid=i-126; r=ARM[subid]; mat=mt[m.group(9)]; md=MAT[mat]
        old=[int(x,16) for x in re.findall(r"0x[0-9A-F]+",m.group(8))]
        types=[s8(x) for x in old[3:6]]
        if subid in real: types=list(real[subid]['types']); stats['types real']+=1
        else: stats['types kept']+=1
        if subid in real: bdp=real[subid]['dp']; stats['dp real']+=1
        else: bdp=DPMED[r[2]]; stats['dp estimated']+=1
        mdp=bdp+md['dp']
        vals=[r[4]+md['st'][0],r[5]+md['st'][1],r[6]+md['st'][2]]+types+list(md['cl'])+list(md['df'])
        return m.group(1)+f"{h16(mdp)}, {h16(mdp)}, "+", ".join(h(v) for v in vals)+f", ItemMaterials.{m.group(9)}, {m.group(10)})"
    new,n=pat.subn(sub,t); assert n==t.count("new InventoryArmorData("),(file,n)
    open(p,"wb").write(b"\xef\xbb\xbf"+(new.replace("\n","\r\n") if crlf and "\r\n" not in new else new).encode("utf-8"))
    print(file,n,"entries")
for f,e,n in (("Helmets.cs","HelmetID.cs","HelmetID"),("Gloves.cs","GloveID.cs","GloveID"),("ChestPieces.cs","ChestPieceID.cs","ChestPieceID"),("Leggings.cs","LeggingID.cs","LeggingID")): regen_armor(f,e,n)
# shields
ev=enumvals("ShieldID.cs"); p=EL+"Shields.cs"
raw=open(p,"rb").read(); t=raw.decode("utf-8-sig"); crlf="\r\n" in t
pat=re.compile(r'(\["([^"]+)"\] = new InventoryShieldData\("[^"]+", (0x[0-9A-F]+), (0x[0-9A-F]+), ShieldID\.(\w+), )(0x[0-9A-F]+), (0x[0-9A-F]+), (0x[0-9A-F]+), (0x[0-9A-F]+), ((?:0x[0-9A-F]+, ){20})ItemMaterials\.(\w+), (0x[0-9A-F]+), (0x[0-9A-F]+), (0x[0-9A-F]+)\)')
def sub(m):
    i=ev[m.group(5)]; subid=i-126; r=SHD[subid]; mat=mt[m.group(11)]; md=MAT[mat]
    old=[int(x,16) for x in re.findall(r"0x[0-9A-F]+",m.group(10))]
    types=[s8(x) for x in old[4:7]]
    if subid in real: types=list(real[subid]['types']); bdp=real[subid]['dp']; pp=real[subid]['pp']; stats['shield real']+=1
    else: bdp=SHDP; pp=SHPP; stats['shield estimated']+=1
    mdp=bdp+md['dp']
    vals=[r[3],r[4]+md['st'][0],r[5]+md['st'][1],r[6]+md['st'][2]]+types+list(md['cl'])+list(md['df'])
    return m.group(1)+f"{h16(mdp)}, {h16(pp)}, 0x0000, {h16(mdp)}, "+", ".join(h(v) for v in vals)+f", ItemMaterials.{m.group(11)}, {m.group(12)}, {m.group(13)}, {m.group(14)}, 0x{r[1]:02X})"
new,n=pat.subn(sub,t); assert n==96
open(p,"wb").write(b"\xef\xbb\xbf"+(new.replace("\n","\r\n") if crlf and "\r\n" not in new else new).encode("utf-8"))
print("Shields.cs",n,"entries"); print(dict(stats))
