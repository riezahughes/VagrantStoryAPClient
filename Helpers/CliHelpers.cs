using System.Collections.ObjectModel;
using Archipelago.Core;
using Archipelago.Core.Util;
using Archipelago.MultiClient.Net.Models;
using Helpers;
using Kokuban;
using Spectre.Console;
using VagrantStoryArchipelago.Options;

namespace VagrantStoryArchipelago.Helpers
{
    internal class CliHelpers
    {

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

            Console.WriteLine("---");
            Console.WriteLine($"Current Room: 0x{roomAndId:X4}");
            Console.WriteLine($"Current Room Name: {MapHelper.HexToRoomDictionary[roomAndId]}");
            Console.WriteLine("---");
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
            Console.WriteLine($"Current Traps in Rooom: {Chalk.BgBlue + (Chalk.White + trapCount.ToString())}");
            Console.WriteLine("---");
            Console.WriteLine($"Progression State 1: 0x{prog1:X2}");
            Console.WriteLine($"Progression  State 2: 0x{prog2:X2}");
            Console.WriteLine($"------------------");
        }

        public static void RunOptions(ArchipelagoClient client)
        {
            PlayerVictoryConditions currentGoal = PlayerStateHelpers.GetPlayerOption<PlayerVictoryConditions>(client.Options, "goal");
            ProgressionOptions progressionOption = PlayerStateHelpers.GetPlayerOption<ProgressionOptions>(client.Options, "progression_option");
            PlayerStartingPosition openWorldStart = PlayerStateHelpers.GetPlayerOption<PlayerStartingPosition>(client.Options, "open_world_option");
            ItemPoolDropOptions itemDropOption = PlayerStateHelpers.GetPlayerOption<ItemPoolDropOptions>(client.Options, "item_drop");
            DropItemChoice chestItemChoices = PlayerStateHelpers.GetPlayerOption<DropItemChoice>(client.Options, "chest_item_choices");
            DropItemChoice bossItemChoices = PlayerStateHelpers.GetPlayerOption<DropItemChoice>(client.Options, "boss_item_choices");
            SkillUnlockOptions chainSkillSetting = PlayerStateHelpers.GetPlayerOption<SkillUnlockOptions>(client.Options, "chain_skill_unlock_option");
            SkillUnlockOptions breakArtSetting = PlayerStateHelpers.GetPlayerOption<SkillUnlockOptions>(client.Options, "break_art_unlock_option");
            PoolItemOptions newGamePlus = PlayerStateHelpers.GetPlayerOption<PoolItemOptions>(client.Options, "include_new_game_plus");
            PoolItemOptions includeTeleport = PlayerStateHelpers.GetPlayerOption<PoolItemOptions>(client.Options, "include_teleport");
            OptionToggle zeroMpTeleport = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "zero_mp_teleport");
            OptionToggle openTeleport = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "open_teleport");
            OptionToggle roomSanity = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "roomsanity");
            OptionToggle panelSanity = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "panelsanity");
            OptionToggle deathlink = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "deathlink");

            int breakArtCounter = PlayerStateHelpers.GetPlayerOptionCounts(client.Options, "break_art_counter");
            int chainSkillCounter = PlayerStateHelpers.GetPlayerOptionCounts(client.Options, "chain_skill_counter");
            int heavyDropLimit = PlayerStateHelpers.GetPlayerOptionCounts(client.Options, "heavy_drop_limit");
            int guaranteedItems = PlayerStateHelpers.GetPlayerOptionCounts(client.Options, "guaranteed_items");

            string progwrite = progressionOption == ProgressionOptions.OPEN ? openWorldStart.ToString() : "N/A";

            Console.WriteLine($"--- RUN OPTIONS ---");
            Console.WriteLine($"Goal: {currentGoal}");
            Console.WriteLine($"Progression: {progressionOption}");
            Console.WriteLine($"Open World Start: {progwrite}");
            Console.WriteLine($"Item Drop Option: {itemDropOption}");
            Console.WriteLine($"Chest Item Choices: {chestItemChoices}");
            Console.WriteLine($"Boss Item Choices: {bossItemChoices}");
            Console.WriteLine($"Chain Skill Setting: {chainSkillSetting}");
            Console.WriteLine($"Chain Skill Counter: {chainSkillCounter}");
            Console.WriteLine($"Break Art Setting: {breakArtSetting}");
            Console.WriteLine($"Break Art Counter: {breakArtCounter}");
            Console.WriteLine($"New Game Plus: {newGamePlus}");
            Console.WriteLine($"Include Teleport: {includeTeleport}");
            Console.WriteLine($"Zero MP Teleport: {zeroMpTeleport}");
            Console.WriteLine($"Open Teleport: {openTeleport}");
            Console.WriteLine($"Room Sanity: {roomSanity}");
            Console.WriteLine($"Panel Sanity: {panelSanity}");
            Console.WriteLine($"Deathlink: {deathlink}");
            Console.WriteLine($"Heavy Drop Limit: {heavyDropLimit}");
            Console.WriteLine($"Guaranteed Items: {guaranteedItems}");
            Console.WriteLine($"------------------");
        }

        public static void RunStatus(ArchipelagoClient client)
        {

            ReadOnlyCollection<ItemInfo> items = client.CurrentSession.Items.AllItemsReceived;
            int index = App.ProcessedItemIndex - 1;

            Console.WriteLine($"--- RUN STATUS ---");
            Console.WriteLine($"Current Items Collected: {index}");
            Console.WriteLine($"Last Item: {items[index]}");
            Console.WriteLine($"--- KEY ITEM CHECK ---");
            Console.WriteLine($"Bronze Key: {items.Any(i => i.ItemName == "Bronze Key") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Bronze Key").index <= index}");
            Console.WriteLine($"Iron Key: {items.Any(i => i.ItemName == "Iron Key") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Iron Key").index <= index}");
            Console.WriteLine($"Silver Key: {items.Any(i => i.ItemName == "Silver Key") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Silver Key").index <= index}");
            Console.WriteLine($"Gold Key: {items.Any(i => i.ItemName == "Gold Key") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Gold Key").index <= index}");
            Console.WriteLine($"Platinum Key: {items.Any(i => i.ItemName == "Platinum Key") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Platinum Key").index <= index}");
            Console.WriteLine($"Steel Key: {items.Any(i => i.ItemName == "Steel Key") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Steel Key").index <= index}");
            Console.WriteLine($"Crimson Key: {items.Any(i => i.ItemName == "Crimson Key") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Crimson Key").index <= index}");
            Console.WriteLine($"Chest Key: {items.Any(i => i.ItemName == "Chest Key") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Chest Key").index <= index}");
            Console.WriteLine($"Chamomile Sigil: {items.Any(i => i.ItemName == "Chamomile Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Chamomile Sigil").index <= index}");
            Console.WriteLine($"Lily Sigil: {items.Any(i => i.ItemName == "Lily Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Lily Sigil").index <= index}");
            Console.WriteLine($"Tearose Sigil: {items.Any(i => i.ItemName == "Tearose Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Tearose Sigil").index <= index}");
            Console.WriteLine($"Clematis Sigil: {items.Any(i => i.ItemName == "Clematis Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Clematis Sigil").index <= index}");
            Console.WriteLine($"Hyacinth Sigil: {items.Any(i => i.ItemName == "Hyacinth Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Hyacinth Sigil").index <= index}");
            Console.WriteLine($"Fern Sigil: {items.Any(i => i.ItemName == "Fern Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Fern Sigil").index <= index}");
            Console.WriteLine($"Aster Sigil: {items.Any(i => i.ItemName == "Aster Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Aster Sigil").index <= index}");
            Console.WriteLine($"Eulelia Sigil: {items.Any(i => i.ItemName == "Eulelia Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Eulelia Sigil").index <= index}");
            Console.WriteLine($"Melissa Sigil: {items.Any(i => i.ItemName == "Melissa Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Melissa Sigil").index <= index}");
            Console.WriteLine($"Calla Sigil: {items.Any(i => i.ItemName == "Calla Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Calla Sigil").index <= index}");
            Console.WriteLine($"Laurel Sigil: {items.Any(i => i.ItemName == "Laurel Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Laurel Sigil").index <= index}");
            Console.WriteLine($"Acacia Sigil: {items.Any(i => i.ItemName == "Acacia Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Acacia Sigil").index <= index}");
            Console.WriteLine($"Palm Sigil: {items.Any(i => i.ItemName == "Palm Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Palm Sigil").index <= index}");
            Console.WriteLine($"Kalmia Sigil: {items.Any(i => i.ItemName == "Kalmia Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Kalmia Sigil").index <= index}");
            Console.WriteLine($"Colombine Sigil: {items.Any(i => i.ItemName == "Colombine Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Colombine Sigil").index <= index}");
            Console.WriteLine($"Anemone Sigil: {items.Any(i => i.ItemName == "Anemone Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Anemone Sigil").index <= index}");
            Console.WriteLine($"Verbena Sigil: {items.Any(i => i.ItemName == "Verbena Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Verbena Sigil").index <= index}");
            Console.WriteLine($"Schirra Sigil: {items.Any(i => i.ItemName == "Schirra Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Schirra Sigil").index <= index}");
            Console.WriteLine($"Marigold Sigil: {items.Any(i => i.ItemName == "Marigold Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Marigold Sigil").index <= index}");
            Console.WriteLine($"Azalea Sigil: {items.Any(i => i.ItemName == "Azalea Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Azalea Sigil").index <= index}");
            Console.WriteLine($"Tigertail Sigil: {items.Any(i => i.ItemName == "Tigertail Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Tigertail Sigil").index <= index}");
            Console.WriteLine($"Stock Sigil: {items.Any(i => i.ItemName == "Stock Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Stock Sigil").index <= index}");
            Console.WriteLine($"Cattleya Sigil: {items.Any(i => i.ItemName == "Cattleya Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Cattleya Sigil").index <= index}");
            Console.WriteLine($"Mandrake Sigil: {items.Any(i => i.ItemName == "Mandrake Sigil") && items.Select((item, index) => new { item, index }).First(x => x.item.ItemName == "Mandrake Sigil").index <= index}");
            Console.WriteLine($"------------------");
        }

    }
}
