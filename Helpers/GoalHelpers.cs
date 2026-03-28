using Archipelago.Core;
using Archipelago.Core.Util;
using VagrantStoryArchipelago;

namespace Helpers
{
    public class GoalHelpers
    {
        internal static bool CheckFirstWinCondition(ArchipelagoClient client)
        {
            return true;
        }

        internal static bool CheckSecondWinCondition(ArchipelagoClient client)
        {
            return true;
        }

        public static bool CheckGoalCondition(ArchipelagoClient client)
        {

            // TODO Victory logic goes into each of these goal conditions

            PlayerVictoryConditions goalCondition = PlayerStateHelpers.GetPlayerOption<PlayerVictoryConditions>(client.Options, "goal");

            if (goalCondition == PlayerVictoryConditions.DEFEAT_DARK_ANGEL)
            {
                ushort mapId = Memory.ReadUShort(Addresses.CurrentMapandRoomID);

                if (mapId == 0x011b)
                {
                    ushort bossHealth = Memory.ReadUShort(Addresses.GE_Credits);

                    if (bossHealth == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}