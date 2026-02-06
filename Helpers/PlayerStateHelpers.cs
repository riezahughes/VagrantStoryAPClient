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
            // Read the saved index from memory
            var index = Memory.ReadUShort(Addresses.ItemIndexStorage);
            App.ProcessedItemIndex = index;
            Console.WriteLine($"Loaded item index: {App.ProcessedItemIndex}");
            // Immediately try to process any pending items
            UpdatePlayerState(client);

        }

        public static void EnableTeleportOptions(ArchipelagoClient client)
        {

            int teleport_choice = Int32.Parse(client.Options?.GetValueOrDefault("include_teleport", "0").ToString());
            int teleport_zero_mp_choice = Int32.Parse(client.Options?.GetValueOrDefault("zero_mp_teleport", "0").ToString());
            int teleport_open_locations = Int32.Parse(client.Options?.GetValueOrDefault("open_teleport_locations", "0").ToString());

            if (teleport_choice == 1)
            {
                Memory.WriteByte(Addresses.MagicMenuUnlock, 0x90);
                Memory.WriteByte(Addresses.TeleportToggle, 0x01);
            }

            if (teleport_zero_mp_choice == 1)
            {
                Memory.Write(Addresses.TeleportNoMP, 0x00801023);
            }

            if (teleport_open_locations == 1)
            {
                Memory.Write(Addresses.TeleportWorkerBreakroom, 0x0001);
                Memory.Write(Addresses.TeleportWineGuildHall, 0x0001);
                Memory.Write(Addresses.TeleportBlackMarket, 0x0001);
                Memory.Write(Addresses.TeleportHallOfRevenge, 0x0001);
                Memory.Write(Addresses.TeleportWitheredSpring, 0x0001);
                Memory.Write(Addresses.TeleportWorkOfArtWorkshop, 0x0001);
                Memory.Write(Addresses.TeleportAdventGround, 0x0001);
                Memory.Write(Addresses.TeleportRueVermillion, 0x0001);
                Memory.Write(Addresses.TeleportMagicHammerWorkshop, 0x0001);
                Memory.Write(Addresses.TeleportTheCrossing, 0x0001);
                Memory.Write(Addresses.TeleportTheDarkTunnel, 0x0001);
                Memory.Write(Addresses.TeleportRueBouquet, 0x0001);
                Memory.Write(Addresses.TeleportTheSunlessWay, 0x0001);
                Memory.Write(Addresses.TeleportTheFaerieCircle, 0x0001);
                Memory.Write(Addresses.TeleportForestRiver, 0x0001);
                Memory.Write(Addresses.TeleportTheWoodGate, 0x0001);
                Memory.Write(Addresses.TeleportValdimanGates, 0x0001);
                Memory.Write(Addresses.TeleportTheWarriorsRest, 0x0001);
                Memory.Write(Addresses.TeleportKeanesWorkshop, 0x0001);
                Memory.Write(Addresses.TeleportSinnersCorner, 0x0001);
                Memory.Write(Addresses.TeleportCrumblingMarket, 0x0001);
                Memory.Write(Addresses.TeleportTreatyRoom, 0x0001);
                Memory.Write(Addresses.TeleportBanditsHollow, 0x0001);
                Memory.Write(Addresses.TeleportTheOreRoad, 0x0001);
                Memory.Write(Addresses.TeleportTheAuctionBlock, 0x0001);
                Memory.Write(Addresses.TeleportWayDown, 0x0001);
                Memory.Write(Addresses.TeleportRueLejour, 0x0001);
                Memory.Write(Addresses.TeleportKeschBridge, 0x0001);
                Memory.Write(Addresses.TeleportMetalWorksWorkshop, 0x0001);
                Memory.Write(Addresses.TeleportJunctionPointWorkshop, 0x0001);
                Memory.Write(Addresses.TeleportTheDarkCoast, 0x0001);
                Memory.Write(Addresses.TeleportPlateiaLumitar, 0x0001);
                Memory.Write(Addresses.TeleportSinAndPunishment, 0x0001);
                Memory.Write(Addresses.TeleportTheAtrium, 0x0001);
                Memory.Write(Addresses.TeleportGodsHandsWorkshop, 0x0001);
            }
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