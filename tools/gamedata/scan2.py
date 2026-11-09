import json
S="C:/Users/Dan/AppData/Local/Temp/claude/3cad74f8b8ca03ce/054dc5ce-2eb7-4ce8-b589-d11b3dcb5b20/scratchpad/"
exec(open(S+"iso.py").read())
import os; os.chdir(r"D:/Roms/PSX/Vagrant Story (USA)/maps")
exec(open(S+"scan.py").read())
ids=build_map_ids()
fid2map={v:k for k,v in ids.items()}
nm=lambda m: names.get(m, f"?{m:04X}")
def lock_at(ls,x,z,s):
    for l in ls:
        if (l['x'],l['z'],l['s'])==(x,z,s): return l
        d=l['dir']-4
        nx,nz=l['x'],l['z']
        if d==0: nz-=1
        elif d==1: nx+=1
        elif d==2: nz+=1
        elif d==3: nx-=1
        else: continue
        if (nx,nz,l['s'])==(x,z,s): return l
    return None
rooms={}
for mid,fn in ids.items():
    ws,ls=data[fn]; rooms[mid]=(fn,ws,ls)
res=[];alllocks=[]
for mid,(fn,ws,ls) in sorted(rooms.items()):
    for l in ls:
        if l['state'] in (1,3): alllocks.append((mid,fn,l))
    for w in ws:
        if not (9<=w['zone']<=60): continue
        tgt=(w['mpd']<<8)|w['zone']
        if tgt not in rooms: continue
        la=lock_at(ls,w['x'],w['z'],w['s'])
        # reverse warps in target going back to mid
        for w2 in rooms[tgt][1]:
            if ((w2['mpd']<<8)|w2['zone'])==mid:
                lb=lock_at(rooms[tgt][2],w2['x'],w2['z'],w2['s'])
                ka=(la['state'],la['key']) if la and la['state'] in(1,3) else None
                kb=(lb['state'],lb['key']) if lb and lb['state'] in(1,3) else None
                if ka!=kb and (ka or kb):
                    res.append((mid,tgt,w,la,w2,lb))
print("locks(state1/3):",len(alllocks))
for mid,fn,l in alllocks: print(f"  {mid:04X} {nm(mid)} (MAP{fn:03d}) lock#{l['i']} tile=({l['x']},{l['z']},{l['s']}) state={l['state']} key={l['key']:#x} unkE={l['unkE']} u12={l['u12']}")
print("one-sided door locks:")
for mid,tgt,w,la,w2,lb in res:
    print(f"  {mid:04X} {nm(mid)} -> {tgt:04X} {nm(tgt)}: here={(la['state'],hex(la['key'])) if la else None}(entry {la['i'] if la else '-'}) other={(lb['state'],hex(lb['key'])) if lb else None} (entry {lb['i'] if lb else '-'}) warpTile=({w['x']},{w['z']},{w['s']})")

print("\n=========== SYMMETRISED ===========")
want={}   # (mid,x,z,s) -> dict(key, entry, existing_key, to)
for mid,(fn,ws,ls) in sorted(rooms.items()):
    for w in ws:
        if not (9<=w['zone']<=60) or w['flag']: continue
        tgt=(w['mpd']<<8)|w['zone']
        if tgt not in rooms: continue
        la=lock_at(ls,w['x'],w['z'],w['s'])
        here=la['key'] if la and la['state'] in(1,3) else None
        there=set()
        for w2 in rooms[tgt][1]:
            if ((w2['mpd']<<8)|w2['zone'])==mid:
                lb=lock_at(rooms[tgt][2],w2['x'],w2['z'],w2['s'])
                if lb and lb['state'] in(1,3): there.add(lb['key'])
        keys={k for k in ([here] if here else [])+list(there)}
        if not keys: continue
        if len(keys)>1: print("CONFLICT",f"{mid:04X}",nm(mid),keys)
        k=sorted(keys)[0]
        want[(mid,w['x'],w['z'],w['s'])]=dict(key=k,entry=(la['i'] if la else None),fileoff=(la['foff'] if la else None),existing=here,to=tgt)
need=[(k,v) for k,v in want.items() if v['existing']!=v['key']]
noentry=[(k,v) for k,v in need if v['entry'] is None]
print("door sides total",len(want),"needing patch",len(need),"no lock slot",len(noentry))
for k,v in noentry: print("  NO SLOT",f"{k[0]:04X}",nm(k[0]),k[1:],f"key={v['key']:#x}",'->',nm(v['to']),"entries in room:",len(rooms[k[0]][2]))
json.dump([dict(map=k[0],name=nm(k[0]),x=k[1],z=k[2],s=k[3],key=v['key'],entry=v['entry'],existing=v['existing'],to=nm(v['to'])) for k,v in sorted(want.items())],open(S+"door_locks.json","w"),indent=1)
# world cross-check
import sys
sys.path.insert(0,r"D:/Archipelago/dev/Poptracker/VagrantStory/tools")
from worlddata import World
W=World(); er=W.entrance_rules()
def items(e,acc):
    if e[0]=="item": acc.add(e[1])
    elif e[0]=="and": [items(x,acc) for x in e[1]]
    return acc
def rule(mode,a,b):
    for n,fa,fb in W.entrances():
        if fa==a and fb==b:
            e=er[mode].get(n)
            return items(e,set()) if e else set()
    return None
KN={0x1ca:"Bronze Key",0x1cb:"Iron Key",0x1cc:"Silver Key",0x1cd:"Gold Key",0x1ce:"Platinum Key",0x1cf:"Steel Key",0x1d0:"Crimson Key",0x1d1:"Chest Key"}
for i,n in enumerate(["Chamomile","Lily","Tearose","Clematis","Hyacinth","Fern","Aster","Eulelia","Melissa","Calla","Laurel","Acacia","Palm","Kalmia","Colombine","Anemone","Verbena","Schirra","Marigold","Azalea","Tigertail","Stock","Cattleya","Mandrake"]): KN[0x1d2+i]=n+" Sigil"
print("\n=========== WORLD vs GAME (per door side) ===========")
seen=set();bad=0
for (mid,x,z,s),v in sorted(want.items()):
    a,b=nm(mid),nm(v['to']); kn=KN[v['key']]
    for mode in("vanilla","open"):
        r=rule(mode,a,b)
        if r is None: continue
        if kn not in r:
            key=(a,b,mode,kn)
            if key in seen: continue
            seen.add(key); bad+=1
            print(f"  [{mode}] {a} -> {b}: game needs {kn}, world rule has {sorted(r) or 'nothing'}")
print("world gaps:",bad)
