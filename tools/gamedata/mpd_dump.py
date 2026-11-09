import struct,sys
def parse(mid):
    d=open(f"MAP{mid}.MPD","rb").read()
    base,rlen=struct.unpack_from("<IH",d,0)
    L=struct.unpack_from("<24I",d,base)
    off=base+0x60;offs=[]
    for l in L: offs.append(off); off+=l
    print(f"== MAP{mid}: room section file+{base:#x}, door(3) len {L[3]} @file+{offs[3]:#x}, sectionA len {L[9]} @file+{offs[9]:#x}")
    for i in range(L[3]//12):
        p=offs[3]+i*12;e=d[p:p+12]
        tt,v,f=struct.unpack_from("<HHH",e,2)
        print(f" warp[{i}] file+{p:#x}: zone={e[0]} mpd={e[1]:#05x} tgtTile=({tt&31},{(tt>>5)&31},surf{(tt>>10)&7},arr{(tt>>13)&7}) unlockFlag={f&0x3ff:#x} unlockValue={v&0xff} doorId={e[8]}")
    for i in range(L[9]//20):
        p=offs[9]+i*20;e=d[p:p+20]
        x,z,sf,dr=struct.unpack_from("<4h",e,0)
        key=struct.unpack_from("<h",e,12)[0]
        print(f" lock[{i}] file+{p:#x}: tile=({x},{z},{sf}) dir={dr} state={e[8]} unkA={e[10]} keyOrSigil={key:#x} raw={e.hex()}")
for m in sys.argv[1:]: parse(m)
