using Archipelago.Core.Util;
using VagrantStoryArchipelago.Models.MapData;
namespace Helpers
{
    public class FloorTrapHelpers
    {
        public static List<MapFloorTrapData> GetAllTraps(uint pointerAddress)
        {
            var traps = new List<MapFloorTrapData>();

            ulong currentAddress = pointerAddress; // already the actor's address, don't dereference

            while (true)
            {
                MapFloorTrapData trap = Memory.ReadObject<MapFloorTrapData>(currentAddress);

                if (trap.TypeOfEntity == 0xff)
                {
                    break;
                }

                traps.Add(trap);

                currentAddress += 0x0c;

                if (trap.NextTileAvailable == 0x0)
                    break;
            }

            return traps;
        }

        public static int CountTraps(uint pointerAddress) => GetAllTraps(pointerAddress).Count;
    }
}