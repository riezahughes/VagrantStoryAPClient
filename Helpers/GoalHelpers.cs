using Archipelago.Core;

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

            int goalCondition = Int32.Parse(client.Options?.GetValueOrDefault("goal", "0").ToString());

            if (goalCondition == PlayerVictoryConditions.DEFEAT_DARK_ANGEL)
            {
                return true;
            }
            //else if (goalCondition == PlayerVictoryConditions.VICTORY_2)
            //{
            //    Console.WriteLine("Cleared 2");
            //    return true;
            //}
            //else if (goalCondition == PlayerVictoryConditions.VICTORY_3)
            //{
            //    Console.WriteLine("Cleared 1 and 2");
            //    return true;
            //}
            return false;
        }

    }
}