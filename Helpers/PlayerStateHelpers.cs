using Archipelago.Core;
using Archipelago.Core.Util;
using VagrantStoryArchipelago;
using VagrantStoryArchipelago.Helpers;

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

        public static void UpdatePlayerState(ArchipelagoClient client)
        {
            //TODO: Player update logic
            ItemHelpers.ProcessPendingItems(client);
        }

        public static void OnSaveMenuDetected(ArchipelagoClient client)
        {
            // Write the current ProcessedItemIndex to a specific memory address
            Memory.Write(Addresses.ItemIndexStorage, (ushort)App.ProcessedItemIndex);
            Console.WriteLine($"Saved item index: {App.ProcessedItemIndex}");
        }

        public static void OnGameLoaded(ArchipelagoClient client)
        {
            // Read the saved index from memory
            var index = Memory.ReadUShort(Addresses.ItemIndexStorage);
            App.ProcessedItemIndex = index == 0 ? 1 : index;
            Console.WriteLine($"Loaded item index: {App.ProcessedItemIndex}");

            // Immediately try to process any pending items
            UpdatePlayerState(client);

        }

        public static void SetUpMapListener(CancellationTokenSource cts, ArchipelagoClient client)
        {
            if (cts.Token.IsCancellationRequested) return;

            Memory.MonitorAddressForAction<ushort>(
                Addresses.CurrentMapandRoomID,
                () =>
                {
                    while (APHelpers.isInTheGame() == false)
                    {
                        Console.WriteLine("Waiting to return to game...");
                        Thread.Sleep(2000);
                    }
                    OnGameLoaded(client);
                    UpdatePlayerState(client);
                    SetUpMapListener(cts, client);
                },
                value => value == 0);
        }
    }

}