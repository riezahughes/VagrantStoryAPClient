using Archipelago.Core;
using Archipelago.Core.Util;
using VagrantStoryArchipelago;
using VagrantStoryArchipelago.Helpers;
using VagrantStoryArchipelago.Options;
using static VagrantStoryArchipelago.Helpers.ItemHelpers;

namespace Helpers
{
    public class PlayerStateHelpers
    {

        public static T GetPlayerOption<T>(Dictionary<string, object> options, string optionKey, T defaultValue = default) where T : struct, Enum
        {
            string optionValue = options?.GetValueOrDefault(optionKey, "0").ToString();

            if (Enum.TryParse<T>(optionValue, out T result))
            {
                return result;
            }

            return defaultValue;
        }

        public static int GetPlayerOptionCounts(Dictionary<string, object> options, string optionKey, int defaultValue = 0)
        {
            string optionValue = options?.GetValueOrDefault(optionKey, "0")?.ToString() ?? "0";

            if (Int32.TryParse(optionValue, out int result))
            {
                return result;
            }

            return defaultValue;
        }

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
            BreakArtResetState(client);
            BreakArtSyncState(client);
        }

        public static void OnSaveMenuDetected(ArchipelagoClient client)
        {
            // Write the current ProcessedItemIndex to a specific memory address
            Memory.Write(Addresses.ItemIndexStorage, (ushort)App.ProcessedItemIndex);
#if DEBUG
            Console.WriteLine($"Saved item index: {App.ProcessedItemIndex}");
#endif
        }

        public static void OnGameLoaded(ArchipelagoClient client)
        {
            // Read the saved index from memory
            var index = Memory.ReadUShort(Addresses.ItemIndexStorage);
            App.ProcessedItemIndex = index;
#if DEBUG
            Console.WriteLine($"Loaded item index: {App.ProcessedItemIndex}");
#endif
            // Immediately try to process any pending items
            UpdatePlayerState(client);

        }

        public static void SetVanillaBattleSkills()
        {
            // set default battle chain abilities
            Memory.WriteByte(Addresses.AbilityHeavyShotUnlock, 0x80);
            Memory.WriteByte(Addresses.AbilityGainLifeUnlock, 0x80);
            Memory.WriteByte(Addresses.AbilityTemperUnlock, 0x80);

            // set default defence chain abilities
            Memory.WriteByte(Addresses.AbilityWardUnlock, 0x90);
            Memory.WriteByte(Addresses.AbilityReflectDamageUnlock, 0x90);
            Memory.WriteByte(Addresses.AbilityImpactGuardUnlock, 0x90);

            // set default starting progression value
            Memory.WriteByte(Addresses.ProgressionState, 0x0a);
        }

        public static void SetMenuOptionsAvailable()
        {
            Memory.Write(Addresses.MainMenuOptionsAddress, 0xffff);
        }

        public static void SetOpenWorldSettings(ArchipelagoClient client)
        {
            SetVanillaBattleSkills();
            return;
        }

        public static void EnableNewGamePlus(ArchipelagoClient client)
        {
            OptionToggle newgameplus_choice = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "include_new_game_plus");
            if (newgameplus_choice == OptionToggle.TRUE)
            {
                Memory.WriteByte(Addresses.RoodInverseActive, 0x01);
            }
        }



        public static void EnableTeleportOptions(ArchipelagoClient client)
        {
            OptionToggle teleport_choice = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "include_teleport");
            OptionToggle teleport_zero_mp_choice = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "zero_mp_teleport");
            OptionToggle teleport_open_locations = PlayerStateHelpers.GetPlayerOption<OptionToggle>(client.Options, "open_teleport_locations");

            if (teleport_choice == OptionToggle.TRUE)
            {
                Memory.WriteByte(Addresses.MagicMenuUnlock, 0x90);
                Memory.WriteByte(Addresses.TeleportToggle, 0x01);
            }

            if (teleport_zero_mp_choice == OptionToggle.TRUE)
            {
                Memory.Write(Addresses.TeleportNoMP, 0x00801023);
            }

            if (teleport_open_locations == OptionToggle.TRUE)
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

        public static void SetRoomProgression(ArchipelagoClient client)
        {
            ushort current_room = Memory.ReadByte(Addresses.CurrentMapandRoomID);
            MapHelper.SetBossProgression(current_room);
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

        // BREAK ART SETUPS

        public static void BreakArtThresholdSetup(ArchipelagoClient client)
        {
            SkillUnlockOptions breakArtChoice = PlayerStateHelpers.GetPlayerOption<SkillUnlockOptions>(client.Options, "break_art_unlock_option");

            if (breakArtChoice == SkillUnlockOptions.SET)
            {

                int breakArtValue = PlayerStateHelpers.GetPlayerOptionCounts(client.Options, "break_art_counter");

                foreach (var weapon in ItemHelpers.BreakArtUnlockReference)
                {
                    int level = 1;
                    foreach (var breakArt in weapon.Value)
                    {
                        ushort newThreshold = (ushort)(breakArtValue * level);
                        Memory.Write(breakArt.Value.ThresholdAddress, newThreshold);
                        level++;

                        if (level >= 5)
                        {
                            level = 1;
                        }
                    }
                }
            }
        }

        public static void BreakArtResetState(ArchipelagoClient client)
        {
            foreach (var weapon in ItemHelpers.BreakArtUnlockReference)
            {
                int level = 1;
                foreach (var breakArt in weapon.Value)
                {
                    Memory.WriteByte(breakArt.Value.Address, 0x40);
                }
            }
        }

        public static void BreakArtSyncState(ArchipelagoClient client)
        {
            var items = client.CurrentSession.Items.AllItemsReceived;

            foreach (var item in items)

                if (item.ItemName.Contains("Break Art", StringComparison.OrdinalIgnoreCase))
                {
                    if (ItemHelpers.BreakArtsFlattenedDictionary.TryGetValue(item.ItemName, out BreakArtInfo breakArtInfo))
                    {
                        Memory.WriteByte(breakArtInfo.Address, breakArtInfo.Value);
                    }
                }
        }

        public static void BreakArtListener(CancellationTokenSource cts, ArchipelagoClient client)
        {
            if (cts.Token.IsCancellationRequested) return;
#if DEBUG
            Console.WriteLine("Listening for Break Arts...");
#endif

            Memory.MonitorAddressForAction<byte>(
            Addresses.MenuUnlockState,
            () =>
            {

                byte currentValue = Memory.ReadByte(Addresses.MenuUnlockState);
                if (currentValue == 0x02)
                {
#if DEBUG
                    Console.WriteLine("I can see the change! Updating Break art State!");
#endif
                    BreakArtResetState(client);
                    BreakArtSyncState(client);
                }
                Thread.Sleep(300);
                BreakArtListener(cts, client);
            },
            value => value == 0x02);

        }


        // CHAIN ABILITY SETUPS


        public static void ChainAbilityThresholdSetup(ArchipelagoClient client)
        {

            SkillUnlockOptions chainAbilityChoice = PlayerStateHelpers.GetPlayerOption<SkillUnlockOptions>(client.Options, "chain_skill_unlock_option");

            if (chainAbilityChoice == SkillUnlockOptions.SET)
            {

                int chainAbilityValue = PlayerStateHelpers.GetPlayerOptionCounts(client.Options, "chain_skill_counter");
                int count = 1;
                foreach (var abilityThreshold in ItemHelpers.ChainAbilityThresholds.OrderBy(x => x.Key))
                {
                    ushort newThreshold = (ushort)(chainAbilityValue * count);
                    Memory.Write(abilityThreshold.Value, newThreshold);
                    count++;
                }
            }
        }

        public static void ChainAbilityResetState(ArchipelagoClient client)
        {
            var chainAbilitySkip = new HashSet<string>
            {
                "Heavy Shot Chain Ability",
                "Gain Life Chain Ability",
                "Temper Chain Ability"
            };

            var defenceAbilitySkip = new HashSet<string>
            {
                "Ward Defence Ability",
                "Reflect Damage Defence Ability",
                "Impact Guard Defence Ability"
            };

            foreach (var ability in ItemHelpers.ChainAbilityUnlockReference)
            {
                if (chainAbilitySkip.Contains(ability.Key))
                {
                    Memory.WriteByte(ability.Value, 0x80);
                }
                else
                {
                    Memory.WriteByte(ability.Value, 0x00);
                };
            }

            foreach (var ability in ItemHelpers.DefenceAbilityUnlockReference)
            {
                if (defenceAbilitySkip.Contains(ability.Key))
                {
                    Memory.WriteByte(ability.Value, 0x90);
                }
                else
                {
                    Memory.WriteByte(ability.Value, 0x00);
                };
            }
        }

        public static void ChainAbilitySyncState(ArchipelagoClient client)
        {
            var items = client.CurrentSession.Items.AllItemsReceived;

            foreach (var item in items)
            {
                if (item.ItemName.Contains("Chain Ability", StringComparison.OrdinalIgnoreCase))
                {
                    if (ItemHelpers.ChainAbilityUnlockReference.TryGetValue(item.ItemName, out uint chainUnlockReference))
                    {
                        Memory.WriteByte(chainUnlockReference, 0x80);
                    }
                }

                if (item.ItemName.Contains("Defence Ability", StringComparison.OrdinalIgnoreCase))
                {
                    if (ItemHelpers.DefenceAbilityUnlockReference.TryGetValue(item.ItemName, out uint defenceUnlockReference))
                    {
                        Memory.WriteByte(defenceUnlockReference, 0x90);
                    }
                }
            }
        }

        public static void ChainAbilityListener(CancellationTokenSource cts, ArchipelagoClient client)
        {
            if (cts.Token.IsCancellationRequested) return;
#if DEBUG
            Console.WriteLine("Listening for Chain Ability Updates...");
#endif
            Memory.MonitorAddressForAction<byte>(
            Addresses.MenuUnlockState,
            () =>
            {
                byte currentValue = Memory.ReadByte(Addresses.MenuUnlockState);
                if (currentValue == 0x04 || currentValue == 0x05)
                {
#if DEBUG
                    Console.WriteLine("I can see the change! Updating Chain Ability State!");
#endif
                    ChainAbilityResetState(client);
                    ChainAbilitySyncState(client);
                }
                Thread.Sleep(300);
                ChainAbilityListener(cts, client);
            },
            value => value == 0x05);

        }


    }
}