using Archipelago.MultiClient.Net.Models;

namespace Helpers
{
    public class PlayerStateHelpers
    {
        public static void KillPlayer()
        {
            //TODO: Kill the player logic goes here
            Console.WriteLine("Ur ded kiddo");
        }

        public static void UpdatePlayerState(System.Collections.ObjectModel.ReadOnlyCollection<ItemInfo> itemsCollected)
        {
            //TODO: Player update logic
            Console.WriteLine("Player Status updated");
        }
    }

}
