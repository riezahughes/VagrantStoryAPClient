import struct,os,collections,re
S="C:/Users/Dan/AppData/Local/Temp/claude/3cad74f8b8ca03ce/054dc5ce-2eb7-4ce8-b589-d11b3dcb5b20/scratchpad/"
exec(open(S+"bladecmp.py").read().split("# enum BladeID")[0])
base=0x800+(0x8004EDDC-0x80010000)
for m in range(8):
    r=slus[base+m*30:base+m*30+30]; MAT[m]['df']=struct.unpack_from("<7b",r,14)
d=open(S+"armor_syd.bin","rb").read(); info=struct.unpack_from("<I",d,8)[0]
ARM={i:struct.unpack_from("<4B3bB",d,info+i*8) for i in range(81)}
s8=lambda v:v-256 if v>127 else v
mt={"NONE":0,"WOOD":1,"LEATHER":2,"BRONZE":3,"IRON":4,"HAGANE":5,"SILVER":6,"DAMASCUS":7}
EL=r"C:/Users/Dan/source/repos/VagrantStoryArchipelago/Helpers/EntityLists/"
ENUMS=r"C:/Users/Dan/source/repos/VagrantStoryArchipelago/Enums/"
def enumvals(f):
    t=open(ENUMS+f,encoding="utf-8-sig").read(); return {n:int(v,16) for n,v in re.findall(r"(\w+) = (0x[0-9A-Fa-f]+)",t)}
def parse_armor(file,enumfile,enumname):
    ev=enumvals(enumfile)
    t=open(EL+file,encoding="utf-8-sig").read()
    pat=re.compile(r'\["([^"]+)"\] = new InventoryArmorData\("[^"]+", (0x[0-9A-F]+), %s\.(\w+), ArmorType\.(\w+), (0x[0-9A-F]+), (0x[0-9A-F]+), ((?:0x[0-9A-F]+, ){19})ItemMaterials\.(\w+), (0x[0-9A-F]+)\)'%enumname)
    out=[]
    for m in pat.finditer(t):
        nums=[int(x,16) for x in re.findall(r"0x[0-9A-F]+",m.group(7))]
        out.append(dict(name=m.group(1),id=ev[m.group(3)],type=m.group(4),mdp=int(m.group(5),16),cdp=int(m.group(6),16),st=s8(nums[0]),it=s8(nums[1]),ag=s8(nums[2]),types=[s8(x) for x in nums[3:6]],cls=[s8(x) for x in nums[6:12]],aff=[s8(x) for x in nums[12:19]],mat=mt[m.group(8)],file=file,count=t.count("new InventoryArmorData")))
    return out,t.count("new InventoryArmorData")
