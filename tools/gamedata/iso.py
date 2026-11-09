import struct
BIN=r"D:/Roms/PSX/Vagrant Story (USA)/Vagrant Story (USA).bin"
f=open(BIN,"rb")
def sector(n):
    f.seek(n*2352+24); return f.read(2048)
def readfile(lba,size):
    out=b""
    n=(size+2047)//2048
    for i in range(n): out+=sector(lba+i)
    return out[:size]
def walk(lba,size,path=""):
    data=readfile(lba,size); p=0; res=[]
    while p<len(data):
        l=data[p]
        if l==0: p=(p//2048+1)*2048; continue
        elba,=struct.unpack_from("<I",data,p+2); esz,=struct.unpack_from("<I",data,p+10)
        fl=data[p+25]; nl=data[p+32]; name=data[p+33:p+33+nl].decode("latin1")
        p+=l
        if name in("\x00","\x01"): continue
        if fl&2: res+=walk(elba,esz,path+name+"/")
        else: res.append((path+name,elba,esz))
    return res
pvd=sector(16)
rl,rs=struct.unpack_from("<I",pvd,158)[0],struct.unpack_from("<I",pvd,166)[0]
files=walk(rl,rs)

def build_map_ids():
    bylba={}
    for n,l,s in files:
        if n.startswith("MAP/MAP") and ".MPD" in n: bylba[l]=int(n[7:10])
    ids={}  # mapId(mpd<<8|zone) -> file number
    for n,l,s in files:
        if n.startswith("MAP/ZONE") and ".ZND" in n:
            z=int(n[8:11]); d=readfile(l,s)
            off,ln=struct.unpack_from("<II",d,0)
            for i in range(ln//8):
                lba,sz=struct.unpack_from("<II",d,off+i*8)
                if lba in bylba: ids[(i<<8)|z]=bylba[lba]
    return ids
