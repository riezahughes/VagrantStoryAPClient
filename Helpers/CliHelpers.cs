using Archipelago.Core.Util;
using Helpers;
using Kokuban;
using Spectre.Console;

namespace VagrantStoryArchipelago.Helpers
{
    internal class CliHelpers
    {
        public static Layout CreateGridLayout()
        {

            var layout = new Layout("Root")
                .SplitColumns(
                    new Layout("Left").Ratio(1),
                    new Layout("Right").Ratio(1)
                );

            layout["Right"].SplitRows(
                new Layout("TopRight"),
                new Layout("BottomRight")
            );

            layout["Left"].Update(
                new Panel("Left Column (Full Height)")
                    .Expand()
                    .BorderColor(Color.Blue));

            layout["TopRight"].Update(
                new Panel("Right - Top Square")
                    .Expand()
                    .BorderColor(Color.Green));

            layout["BottomRight"].Update(
                new Panel("Right - Bottom Square")
                    .Expand()
                    .BorderColor(Color.Red));

            return layout;
        }
        public static void AddMessageToLeftPanel(Layout layout, List<Markup> currentMessages, string newMessage)
        {

            currentMessages.Add(new Markup($"\n[bold yellow]{newMessage}[/]"));
            layout["Left"].Update(new Panel(new Rows(currentMessages)).Expand());
            //AnsiConsole.Write(layout);
        }

        public static void DebugInformation()
        {
            uint actorPointer = Memory.ReadUInt(Addresses.MapMonsterDataPointer);
            uint actorPointerRemoved = (actorPointer & 0x0FFFFFFF);
            var enemyCount = ActorHelpers.CountActors(actorPointerRemoved);

            uint trapPointer = Memory.ReadUInt(Addresses.RoomTilesPointer);
            uint trapPointerRemoved = (trapPointer & 0x0FFFFFFF);
            var trapCount = trapPointer == 0x0 ? 0 : FloorTrapHelpers.CountTraps(trapPointerRemoved + 0x08);

            uint bossPointer = Memory.ReadUInt(Addresses.MapBossDataPointer);
            uint bossPointerRemoved = (bossPointer & 0x0FFFFFFF);

            ushort roomAndId = Memory.ReadUShort(Addresses.CurrentMapandRoomID);
            byte prog1 = Memory.ReadByte(Addresses.ProgressionState);
            byte prog2 = Memory.ReadByte(Addresses.ProgressionState2);

            Console.WriteLine($"--- DEBUG INFO ---");
            Console.WriteLine($"Current Thread States:");
            Console.WriteLine($"Main Thread: {App._cancellationTokenSource.Token.CanBeCanceled}");
            Console.WriteLine($"Map Listener: {App._cancellationTokenMapListener.Token.CanBeCanceled}");
            Console.WriteLine($"Break Art Listener: {App._cancellationTokenBreakArtListener.Token.CanBeCanceled}");
            Console.WriteLine($"Chain Ability Listener: {App._cancellationTokenChainAbilityListener.Token.CanBeCanceled}");
            Console.WriteLine($"Chest Listener: {App._cancellationTokenMapChestListener.Token.CanBeCanceled}");
            Console.WriteLine($"Boss Listener: {App._cancellationTokenMapBossListener.Token.CanBeCanceled}");
            Console.WriteLine("---");
            Console.WriteLine($"Current Room: 0x{roomAndId:X4}");
            Console.WriteLine($"Current Room Name: {MapHelper.HexToRoomDictionary[roomAndId]}");
            Console.WriteLine("---");
            Console.WriteLine($"Current Actor Pointer Value: 0x{actorPointer:X8}");
            Console.WriteLine($"Current Actor Pointer Value Cleaned: 0x{actorPointerRemoved:X8}");
            Console.WriteLine($"Current Boss Pointer: 0x{bossPointerRemoved:X8}");
            Console.WriteLine($"Current Enemies: {enemyCount}");
            var actors = ActorHelpers.GetAllActors(actorPointerRemoved);
            foreach (var actor in actors)
            {
                Console.WriteLine($"Actor NextPointer: 0x{actor.NextActorPointer:X8}");
                Console.WriteLine($"Actor HP: {actor.CurrentHP}/{actor.MaxHP}");
            }
            Console.WriteLine("---");
            Console.WriteLine($"Current Trap Pointer Value: 0x{trapPointer:X8}");
            Console.WriteLine($"Current Trap Pointer Value Cleaned: 0x{trapPointerRemoved:X8}");
            Console.WriteLine($"Current Traps in Rooom: {Chalk.BgBlue + (Chalk.White + trapCount.ToString())}");
            Console.WriteLine("---");
            Console.WriteLine($"Progression State 1: 0x{prog1:X2}");
            Console.WriteLine($"Progression  State 2: 0x{prog2:X2}");
            Console.WriteLine($"------------------");
        }
    }
}
