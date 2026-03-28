using Archipelago.Core.Util;
using VagrantStoryArchipelago.Models.MapData;
namespace VagrantStoryArchipelago.Helpers
{
    public class ActorHelpers
    {
        public static List<MapActorData> GetAllActors(uint pointerAddress)
        {
            var actors = new List<MapActorData>();

            if (pointerAddress == 0x0)
                return actors;

            ulong currentAddress = pointerAddress; // already the actor's address, don't dereference

            while (true)
            {
                MapActorData actor = Memory.ReadObject<MapActorData>(currentAddress);
                actors.Add(actor);

                currentAddress = actor.NextActorPointer & 0x0FFFFFFF;

                if (currentAddress == 0x0)
                    break;
            }

            return actors;
        }

        public static int CountActors(uint pointerAddress) => GetAllActors(pointerAddress).Count;

        public static void CleanActorDrops(uint pointerAddress)
        {
            if (pointerAddress == 0x0)
                return;
            ulong currentAddress = pointerAddress; // already the actor's address, don't dereference
            while (true)
            {
                MapActorData actor = Memory.ReadObject<MapActorData>(currentAddress);
                actor.GuaranteedLoot1_Name = 0x00;
                actor.GuaranteedLoot2_Name = 0x00;
                Memory.WriteObject(currentAddress, actor);

                currentAddress = actor.NextActorPointer & 0x0FFFFFFF;
                if (currentAddress == 0x0)
                    break;
            }
        }

        //public static Dictionary<>
        //
        // Dark Crusader fight
        /*
        Actor NextPointer: 0x8018D340
        Actor HP: 302/302 guy
        Actor NextPointer: 0x801814C0
        Actor HP: 379/379 crusader
        Actor NextPointer: 0x00000000
        Actor HP: 282/282 sydney
        */
    }
}