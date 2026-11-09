import struct,re,collections,json,sys
CS=open(r"C:/Users/Dan/source/repos/VagrantStoryArchipelago/Helpers/MapHelper.cs",encoding="utf-8-sig",errors="replace").read()
blk=CS[CS.index("HexToRoomDictionary"):]
blk=blk[:blk.index("};")]
names={int(a,16):b for a,b in re.findall(r'\{\s*0x([0-9A-Fa-f]+),\s*"([^"]+)"',blk)}
zmax=collections.defaultdict(int)
for i in names: zmax[i&0xff]=max(zmax[i&0xff],(i>>8)+1)
def load(n):
    d=open(f"MAP{n:03d}.MPD","rb").read()
    base,=struct.unpack_from("<I",d,0)
    L=struct.unpack_from("<24I",d,base); off=base+0x60; offs=[]
    for l in L: offs.append(off); off+=l
    ws=[];ls=[]
    for j in range(L[3]//12):
        w=d[offs[3]+j*12:offs[3]+j*12+12]
        tt,v,f=struct.unpack_from("<HHH",w,2)
        ws.append(dict(zone=w[0],mpd=w[1],x=tt&31,z=(tt>>5)&31,s=(tt>>10)&7,flag=f&0x3ff,val=v&0xff))
    for j in range(L[9]//20):
        e=d[offs[9]+j*20:offs[9]+j*20+20]
        x,z,s,dr=struct.unpack_from("<4h",e,0)
        ls.append(dict(i=j,x=x,z=z,s=s,dir=dr,state=e[8],key=struct.unpack_from("<H",e,12)[0],unkE=struct.unpack_from("<H",e,14)[0],u12=e[18],foff=offs[9]+j*20))
    return ws,ls
data={n:load(n) for n in range(512)}
