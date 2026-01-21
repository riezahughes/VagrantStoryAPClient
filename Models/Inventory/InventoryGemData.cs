
using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryGemData
    {
        public string GemName { get; set; }
        [MemoryOffset(0x02)]
        public byte GemInventorySlot { get; set; }
        [MemoryOffset(0x04)]
        public byte GemID { get; set; }
        [MemoryOffset(0x05)]
        public byte GemTextCategory { get; set; }
        [MemoryOffset(0x10)]
        public byte GemStrStat { get; set; }
        [MemoryOffset(0x09)]
        public byte GemIntStat { get; set; }
        [MemoryOffset(0x0a)]
        public byte GemAgiStat { get; set; }
        [MemoryOffset(0x0b)]
        public byte GemHumanStat { get; set; }
        [MemoryOffset(0x0c)]
        public byte GemBeastStat { get; set; }
        [MemoryOffset(0x0d)]
        public byte GemUndeadStat { get; set; }
        [MemoryOffset(0x0e)]
        public byte GemPhantomStat { get; set; }
        [MemoryOffset(0x0f)]
        public byte GemDragonStat { get; set; }
        [MemoryOffset(0x10)]
        public byte GemEvilStat { get; set; }
        [MemoryOffset(0x11)]
        public byte GemPhysicalStat { get; set; }
        [MemoryOffset(0x15)]
        public byte GemAirStat { get; set; }
        [MemoryOffset(0x16)]
        public byte GemFireStat { get; set; } // this is correct
        [MemoryOffset(0x17)]
        public byte GemEarthStat { get; set; }
        [MemoryOffset(0x18)]
        public byte GemWaterStat { get; set; }
        [MemoryOffset(0x19)]
        public byte GemLightStat { get; set; }
        [MemoryOffset(0x1a)]
        public byte GemDarkStat { get; set; }

        public InventoryGemData(
            string name, byte inventorySlot, byte gemID, byte strStat, byte intStat, byte agiStat, byte humanStat, byte beastStat, byte undeadStat, byte phantomStat, byte dragonStat, byte evilStat, byte physicalStat, byte airStat, byte fireStat, byte earthStat, byte waterStat, byte lightStat, byte darkStat
        )
        {


            GemName = name;
            GemInventorySlot = inventorySlot;
            GemID = gemID;
            GemTextCategory = 0x01;
            GemStrStat = strStat;
            GemIntStat = intStat;
            GemAgiStat = agiStat;
            GemHumanStat = humanStat;
            GemBeastStat = beastStat;
            GemUndeadStat = undeadStat;
            GemPhantomStat = phantomStat;
            GemDragonStat = dragonStat;
            GemEvilStat = evilStat;
            GemPhysicalStat = physicalStat;
            GemAirStat = airStat;
            GemFireStat = fireStat;
            GemEarthStat = earthStat;
            GemWaterStat = waterStat;
            GemLightStat = lightStat;
            GemDarkStat = darkStat;
        }

    }
}
