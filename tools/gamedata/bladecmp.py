import struct,re,collections
S="C:/Users/Dan/AppData/Local/Temp/claude/3cad74f8b8ca03ce/054dc5ce-2eb7-4ce8-b589-d11b3dcb5b20/scratchpad/"
syd=open(S+"blade_syd.bin","rb").read(); slus=open(S+"slus.bin","rb").read()
info=struct.unpack_from("<I",syd,8)[0]
SYD={i:struct.unpack_from("<8B3b4BB",syd,info+i*16) for i in range(96)}
base=0x800+(0x8004EDDC-0x80010000)
MAT={}
for m in range(8):
    r=slus[base+m*30:base+m*30+30]
    MAT[m]=dict(cl=struct.unpack_from("<6b",r,0),at=struct.unpack_from("<7b",r,6),dp=struct.unpack_from("<h",r,22)[0],st=struct.unpack_from("<3h",r,24))
# enum BladeID names -> value
enum={}
txt=open(r"C:/Users/Dan/source/repos/VagrantStoryArchipelago/Enums/BladeID.cs",encoding="utf-8-sig").read()
for n,v in re.findall(r"(\w+) = (0x[0-9A-Fa-f]+)",txt): enum[n]=int(v,16)
bt={"DAGGER":1,"SWORD":2,"GREAT_SWORD":3,"AXE":4,"GREAT_AXE":5,"STAFF":6,"MACE":7,"POLEARM":8,"CROSSBOW":9}
dm={"BARE_HANDS":0,"BLUNT":1,"EDGED":2,"PIERCING":3}
mt={"NONE":0,"WOOD":1,"LEATHER":2,"BRONZE":3,"IRON":4,"HAGANE":5,"SILVER":6,"DAMASCUS":7}
src=open(r"C:/Users/Dan/source/repos/VagrantStoryArchipelago/Helpers/EntityLists/Blades.cs",encoding="utf-8-sig").read()
pat=re.compile(r'\["([^"]+)"\] = new InventoryBladeData\("[^"]+", DamageType\.(\w+), BladeType\.(\w+), BladeID\.(\w+), (0x[0-9A-F]+), (0x[0-9A-F]+), (0x[0-9A-F]+), (0x[0-9A-F]+), ((?:0x[0-9A-F]+, ){18})ItemMaterials\.(\w+), (0x[0-9A-F]+), (0x[0-9A-F]+)\)')
ents=[]
for m in pat.finditer(src):
    nums=[int(x,16) for x in re.findall(r"0x[0-9A-F]+",m.group(9))]
    s8=lambda v:v-256 if v>127 else v
    ents.append(dict(name=m.group(1),dmg=dm[m.group(2)],cat=bt[m.group(3)],id=enum[m.group(4)],mdp=int(m.group(5),16),mpp=int(m.group(6),16),cdp=int(m.group(7),16),cpp=int(m.group(8),16),
      risk=nums[0],st=s8(nums[1]),it=s8(nums[2]),ag=s8(nums[3]),rng=nums[4],cls=nums[5:11],aff=nums[11:19] if False else nums[11:18],mat=mt[m.group(10)]))
print(len(ents),"entries parsed; lines with 'new InventoryBladeData':",src.count("new InventoryBladeData("))
