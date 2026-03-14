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
    }
}