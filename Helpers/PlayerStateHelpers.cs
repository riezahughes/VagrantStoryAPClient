using Archipelago.Core.Util;
using Archipelago.MultiClient.Net.Models;
using VagrantStoryArchipelago;

namespace Helpers
{
    public class PlayerStateHelpers
    {
        public static void KillPlayer()
        {
            //TODO: Kill the player logic goes here
            Console.WriteLine("Ur ded kiddo");
            Memory.WriteByte(Addresses.AshleyHealth, 0x0000); // Set Ashley's health to 0
        }

        public static void UpdatePlayerState(System.Collections.ObjectModel.ReadOnlyCollection<ItemInfo> itemsCollected)
        {
            //TODO: Player update logic
            Console.WriteLine("Player Status updated");
        }
    }

}
