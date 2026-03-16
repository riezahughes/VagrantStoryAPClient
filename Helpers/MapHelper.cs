using Archipelago.Core;
using Archipelago.Core.Util;
using Helpers;
using VagrantStoryArchipelago;
using VagrantStoryArchipelago.Data;
using VagrantStoryArchipelago.Helpers;
using VagrantStoryArchipelago.Models.MapData; // Assuming your Memory class is here

public class MapHelper
{
    /// <summary>
    /// Sets the bit corresponding to the mapId to 1 (Seen/Visited).
    /// </summary>
    /// 

    private static ushort _lastRoomValue = 0xFFFF; // Store last known map ID
    private static ushort _lastMapIdChest = 0xFFFF; // Store last known map ID
    private static uint _lastPointerValueBoss = 0xFFFFFFFF; // Store last known map ID
    private static bool _battleAbilitiesSet = false;


    public static void StartMapProgressionListener()
    {
        Memory.MonitorAddressForAction<ushort>(
            Addresses.CurrentMapandRoomID,
            () =>
            {
                ushort mapId = Memory.ReadUShort(Addresses.CurrentMapandRoomID);
                if (APHelpers.isInTheGame() && APHelpers.isProcessingItems() == false)
                {
                    Console.WriteLine("Progression State Updated");

                    SetBossProgression(mapId);
                }
                _lastRoomValue = mapId;
                Thread.Sleep(500);
                StartMapProgressionListener();
#if DEBUG
                Thread.Sleep(3000);
                CliHelpers.DebugInformation();
#endif
            },
            value => value != _lastRoomValue);
    }

    public static void StartMapBossListener(Dictionary<string, object> options)
    {
        Memory.MonitorAddressForAction<uint>(
            Addresses.MapBossDataPointer,
            () =>
            {
                ushort mapId = Memory.ReadUShort(Addresses.CurrentMapandRoomID);
                uint pointerValue = Memory.ReadUInt(Addresses.MapBossDataPointer);

                if (APHelpers.isInTheGame() && APHelpers.isProcessingItems() == false && MapsWithBosses.Contains(mapId))
                {
                    uint bossPointerLocation = Memory.ReadUInt(Addresses.MapBossDataPointer);
                    uint bossAddress = (bossPointerLocation & 0x0FFFFFFF);
                    Console.WriteLine($"Current Map ID: {mapId:X4} - Boss Drops Updating");
                    UpdateBossInMap(bossAddress, options);
                    _lastPointerValueBoss = pointerValue;
                }
                Thread.Sleep(500);
                StartMapBossListener(options);
            },
            value => value != _lastPointerValueBoss);
    }

    public static void UpdateBossInMap(uint currentPointerValue, Dictionary<string, object> options)
    {
        int dropChoice = Int32.Parse(options?.GetValueOrDefault("boss_item_choices", "0").ToString());
        var replacementBossItems = new MapBossData();
        var item1 = ItemDatabase.Items["Cure Root"];
        var item2 = ItemDatabase.Items["Vera Root"];
        var item3 = ItemDatabase.Items["Alchemist's Reagent"];

        if (dropChoice == DropItemChoice.HEALING_HEAVY)
        {
            replacementBossItems.Item1_Id = item1.ItemID;
            replacementBossItems.Item1_Qty = 0x01;
            replacementBossItems.Item2_Id = item2.ItemID;
            replacementBossItems.Item2_Qty = 0x01;
            replacementBossItems.Item3_Id = item3.ItemID;
            replacementBossItems.Item3_Qty = 0x01;
        }

        else if (dropChoice == DropItemChoice.RISK_HEAVY)
        {

            replacementBossItems.Item1_Id = item1.ItemID;
            replacementBossItems.Item1_Qty = 0x01;
            replacementBossItems.Item2_Id = item2.ItemID;
            replacementBossItems.Item2_Qty = 0x01;
            replacementBossItems.Item3_Id = item3.ItemID;
            replacementBossItems.Item3_Qty = 0x01;
        }

        Memory.WriteObject<MapBossData>(currentPointerValue, replacementBossItems);
    }

    public static void StartMapChestListener(Dictionary<string, object> options)
    {
        Memory.MonitorAddressForAction<ushort>(
            Addresses.CurrentMapandRoomID,
            () =>
            {
                ushort mapId = Memory.ReadUShort(Addresses.CurrentMapandRoomID);

                if (APHelpers.isInTheGame() && APHelpers.isProcessingItems() == false && MapsWithChests.Contains(mapId))
                {
                    Thread.Sleep(3000);
                    uint chestPointerLocation = Memory.ReadUInt(Addresses.MapChestDataPointer);
                    uint chestAddress = (chestPointerLocation & 0x0FFFFFFF) + 0x14;
                    Console.WriteLine($"Current Map ID: {mapId:X4} - Chest Drops Updating");

                    UpdateChestsInMap(chestAddress, options);
                    _lastMapIdChest = mapId;
                }
                Thread.Sleep(500);
                StartMapChestListener(options);
            },
            value => value != _lastMapIdChest);
    }

    public static void UpdateChestsInMap(uint currentPointerValue, Dictionary<string, object> options)
    {

        int dropChoice = Int32.Parse(options?.GetValueOrDefault("chest_item_choices", "0").ToString());

        var replacementChestItems = new MapChestData();
        var item1 = ItemDatabase.Items["Cure Root"];
        var item2 = ItemDatabase.Items["Vera Root"];
        var item3 = ItemDatabase.Items["Alchemist's Reagent"];



        if (dropChoice == DropItemChoice.HEALING_HEAVY)
        {
            replacementChestItems.Misc1_Exists = 0x03;
            replacementChestItems.Misc2_Exists = 0x03;
            replacementChestItems.Misc3_Exists = 0x03;
            replacementChestItems.Misc1_ID = item1.ItemID;
            replacementChestItems.Misc2_ID = item2.ItemID;
            replacementChestItems.Misc3_ID = item3.ItemID;
            replacementChestItems.Misc1_Qty = 0x05;
            replacementChestItems.Misc2_Qty = 0x03;
            replacementChestItems.Misc3_Qty = 0x01;
            replacementChestItems.Misc1_Confirm = 0x01;
            replacementChestItems.Misc2_Confirm = 0x01;
            replacementChestItems.Misc3_Confirm = 0x01;
        }

        else if (dropChoice == DropItemChoice.RISK_HEAVY)
        {
            replacementChestItems.Misc1_Exists = 0x03;
            replacementChestItems.Misc2_Exists = 0x03;
            replacementChestItems.Misc3_Exists = 0x03;
            replacementChestItems.Misc1_ID = item1.ItemID;
            replacementChestItems.Misc2_ID = item2.ItemID;
            replacementChestItems.Misc3_ID = item3.ItemID;
            replacementChestItems.Misc1_Qty = 0x03;
            replacementChestItems.Misc2_Qty = 0x05;
            replacementChestItems.Misc3_Qty = 0x01;
            replacementChestItems.Misc1_Confirm = 0x01;
            replacementChestItems.Misc2_Confirm = 0x01;
            replacementChestItems.Misc3_Confirm = 0x01;
        }

        Memory.WriteObject<MapChestData>(currentPointerValue, replacementChestItems);
    }

    public static List<ushort> MapsWithBosses = new List<ushort>
    {
        0x000B, // The Hero's Winehall - Dullahan
        0x000C, // The Gallows - Minotaur
        0x0010, // Hall of Sacrilege - Golem
        0x0011, // The Cleansing Chantry - Dragon
        0x0016, // Sanity and Madness - Iron Crab
        0x0018, // The Flayed Confessional - Djinn
        0x0119, // What Ails You, Kills You - Nightmare
        0x0135, // Dream of the Holy Land - Water Elemental
        0x0229, // Nature's Womb - Damascus Crab
        0x0231, // Bazaar of the Bizarre - Lich
        0x0233, // The Miner's End - Air Elemental
        0x0320, // Tircolas Flow - Father Duane, Sarjik and Bejart
        0x0330, // Underdark Fishmarket - Giant Crab
        0x0416, // Truth and Lies - Ifrit
        0x0418, // A Light in the Dark - Arch Dragon
        0x0531, // Gemsword Blackmarket - Nightstalker
        0x0632, // The Battle's Beginning - Wyvern
        0x0633, // Dining in Darkness - Sky Dragon
        0x0737, // Spanish Tickler - Wyvern Knight
        0x0B18, // The Hall of Broken Vows - Flame Dragon
        0x0C37, // Burial - Iron Golem
        0x0E33, // Tomb of the Reborn - Earth Elemental
        0x0F18, // Hopes of the Idealist - Dao
        0x0F30, // Fear of the Fall - Dark Elemental
        0x1132, // The Smeltry - Fire Elemental
        0x1628, // Return to the Land - Earth Dragon
        0x1632, // Traitor's Parting - Ogre
        0x1638, // The Iron Maiden - Asura
        0x1735, // Torture Without End - Ogre Lord
        0x1D35, // Hall of the Wage-Paying - Snow Dragon

        // mini boss drops
        //0x000e, // Lizardmen Fight // commented out till i can check it.
        // NG+
        0x0136, // Slaugher of the Innocent - Damascus Golem (Evil)
        0x0138, // Ordeal By Fire - Dark Dragon (Dragon)
        0x0229, // Nature's Womb - Damascus Crab (Beast) [Also regular boss]
        0x041D, // Urge the Boy On - Marid and Ifrit (Phantoms) [Time Trial]
        0x051D, // A Taste of the Spoils - Damascus Crab & Damascus Golem (Beast/Evil) [Time Trial]
        0x0538, // Pressing - Ravana (Human)
        0x061D, // Wiping Blood from Blades - Death, Ogre Zombie & Asura (Evil/Undead/Human) [Time Trial]
        0x0A38, // The Saw - Dragon Zombie (Undead)
        0x0E38, // The Shin-Vice - Ogre Zombie (Undead)
        0x1237, // Knotting - Wyvern Queen (Dragon)
        0x1638, // The Iron Maiden - Asura (Human) [Also regular final boss]
        0x1A30, // Bite the Master's Wounds - Death (Evil)
    };

    public static List<ushort> MapsWithChests = new List<ushort>
    {
           // Wine Cellar
        0x1009, // Worker's Breakroom
        0x0909, // The Reckoning Room
        0x1109, // Blackmarket of Wines
        0x000C, // The Gallows
        0x000B, // The Hero's Winehall
        
        // Catacombs
        0x050D, // Rodent-Ridden Chamber
        0x040D, // The Lamenting Mother
        0x090D, // Bandits' Hideout
        
        // Sanctum
        0x030F, // Alchemists' Laboratory
        
        // Abandoned Mines B1
        0x0132, // Miners' Resting Hall
        0x0A32, // Coal Mine Storage
        0x0E32, // Rust in Peace
        0x1032, // Mining Regrets
        
        // Abandoned Mines B2
        0x0533, // Delusions of Happiness
        0x0833, // Hidden Resources
        0x0B33, // Acolyte's Burial Vault
        0x1633, // Suicidal Desires
        
        // Limestone Quarry
        0x0535, // Bonds of Friendship
        0x1635, // Stone and Sulfurous Fire
        0x1935, // Excavated Hollow
        0x1435, // Drowned in Fleeting Joy
        0x0F35, // Companions in Arms
        
        // Temple of Kiltia
        0x031E, // The Chapel of Meschaunce
        
        // Great Cathedral L1
        0x0218, // Where Darkness Spreads
        0x0018, // The Flayed Confessional
        
        // Great Cathedral L2
        0x0019, // An Arrow into Darkness
        
        // Forgotten Pathway
        0x0236, // The Fallen Knight
        0x0436, // Awaiting Retribution
        
        // Escapeway
        0x0734, // Where Body and Soul Part
        0x0134, // Buried Alive
        
        // Iron Maiden B1
        0x1437, // The Wheel
        0x1537, // The Judas Cradle
        0x1637, // The Ducking Stool
        0x1337, // The Branks
        
        // Iron Maiden B2
        0x1138, // Lead Sprinkler
        0x0F38, // Squassation
        
        // Iron Maiden B3
        0x1738, // Saint Elmo's Belt
        0x1938, // Dunking the Witch
        
        // Undercity West
        0x1430, // The Children's Hideout
        0x0730, // Larder for a Lean Winter
        0x1530, // The Crumbling Market
        
        // Undercity East
        0x0831, // Weapons Not Allowed
        0x0731, // Sale of the Sword
        0x0C31, // Catspaw Blackmarket
        
        // The Keep
        0x001D, // The Warrior's Rest
        
        // Snowfly Forest
        0x1728, // Forest River
        0x1828, // Hewn from Nature
        
        // Snowfly Forest East
        0x0229, // Nature's Womb
        
        // Town Centre South
        0x0025, // The House Khazabas
        
        // Town Centre East
        0x0024, // Gharmes Walk
        0x0026, // The House Gilgitte
    };

    public static readonly Dictionary<int, string> HexToRoomDictionary = new Dictionary<int, string>
{
    { 0x0009, "Entrance to Darkness" },
    { 0x0109, "Room of Cheap Red Wine" },
    { 0x0209, "Room of Cheap White Wine" },
    { 0x0309, "Hall of Struggle" },
    { 0x0409, "Smokebarrel Stair" },
    { 0x0509, "Wine Guild Hall" },
    { 0x0609, "Wine Magnate's Chambers" },
    { 0x0709, "Fine Vintage Vault" },
    { 0x0809, "Chamber of Fear" },
    { 0x0909, "The Reckoning Room" },
    { 0x0A09, "A Laborer's Thirst" },
    { 0x0B09, "The Rich Drown in Wine" },
    { 0x0C09, "Room of Rotten Grapes" },
    { 0x0F09, "The Greedy One's Den" },
    { 0x1009, "Worker's Breakroom" },
    { 0x1109, "Blackmarket of Wines" },
    { 0x000B, "The Hero's Winehall" },
    { 0x000C, "The Gallows" },
    { 0x000D, "Hall of Sworn Revenge" },
    { 0x010D, "The Last Blessing" },
    { 0x020D, "The Weeping Corridor" },
    { 0x030D, "Persecution Hall" },
    { 0x040D, "The Lamenting Mother" },
    { 0x050D, "Rodent-Ridden Chamber" },
    { 0x060D, "Shrine to the Martyrs" },
    { 0x080D, "Hall of Dying Hope" },
    { 0x090D, "Bandits' Hideout" },
    { 0x0A0D, "The Bloody Hallway" },
    { 0x0B0D, "Faith Overcame Fear" },
    { 0x0C0D, "The Withered Spring" },
    { 0x0D0D, "Repent, O ye Sinners" },
    { 0x0E0D, "The Reaper's Victims" },
    { 0x0F0D, "The Last Stab of Hope" },
    { 0x100D, "Hallway of Heroes" },
    { 0x000E, "The Beast's Domain" },
    { 0x002A, "Workshop \"Work of Art\"" },
    { 0x000F, "Prisoners' Niche" },
    { 0x010F, "Corridor of the Clerics" },
    { 0x020F, "Priests' Confinement" },
    { 0x030F, "Alchemists' Laboratory" },
    { 0x040F, "Theology Classroom" },
    { 0x050F, "Shrine of the Martyrs" },
    { 0x060F, "Advent Ground" },
    { 0x070F, "Passage of the Refugees" },
    { 0x0A0F, "Stairway to the Light" },
    { 0x0B0F, "Hallowed Hope" },
    { 0x0C0F, "The Academia Corridor" },
    { 0x0010, "Hall of Sacrilege" },
    { 0x0011, "The Cleansing Chantry" },
    { 0x0032, "Dreamers' Entrance" },
    { 0x0132, "Miners' Resting Hall" },
    { 0x0232, "The Crossing" },
    { 0x0332, "Conflict and Accord" },
    { 0x0432, "The Suicide King" },
    { 0x0532, "The End of the Line" },
    { 0x0632, "The Battle's Beginning" },
    { 0x0732, "What Lies Ahead?" },
    { 0x0832, "The Fruits of Friendship" },
    { 0x0932, "The Earthquake's Mark" },
    { 0x0A32, "Coal Mine Storage" },
    { 0x0B32, "The Passion of Lovers" },
    { 0x0C32, "The Hall of Hope" },
    { 0x0D32, "The Dark Tunnel" },
    { 0x0E32, "Rust in Peace" },
    { 0x0F32, "Everwant Passage" },
    { 0x1032, "Mining Regrets" },
    { 0x1132, "The Smeltry" },
    { 0x1232, "Clash of Hyaenas" },
    { 0x1332, "Greed Knows No Bounds" },
    { 0x1432, "Live Long and Prosper" },
    { 0x1532, "Pray to the Mineral Gods" },
    { 0x1632, "Traitor's Parting" },
    { 0x1732, "Escapeway" },
    { 0x0033, "Gambler's Passage" },
    { 0x0133, "Treaty Room" },
    { 0x0233, "The Miner's End" },
    { 0x0333, "Work, Then Die" },
    { 0x0433, "Bandits' Hollow" },
    { 0x0533, "Delusions of Happiness" },
    { 0x0633, "Dining in Darkness" },
    { 0x0733, "Subtellurian Horrors" },
    { 0x0833, "Hidden Resources" },
    { 0x0933, "Way of Lost Children" },
    { 0x0A33, "Hall of the Empty Sconce" },
    { 0x0B33, "Acolyte's Burial Vault" },
    { 0x0C33, "Hall of Contemplation" },
    { 0x0D33, "The Abandoned Catspaw" },
    { 0x0E33, "Tomb of the Reborn" },
    { 0x0F33, "The Fallen Bricklayer" },
    { 0x1033, "Crossing of Blood" },
    { 0x1133, "Fool's Gold, Fool's Loss" },
    { 0x1233, "Cry of the Beast" },
    { 0x1333, "Senses Lost" },
    { 0x1433, "Desire's Passage" },
    { 0x1533, "Kilroy Was Here" },
    { 0x1633, "Suicidal Desires" },
    { 0x1733, "The Ore of Legend" },
    { 0x1833, "Lambs to the Slaughter" },
    { 0x1933, "A Wager of Noble Gold" },
    { 0x1A33, "The Lunatic Veins" },
    { 0x1B33, "Corridor of Shade" },
    { 0x1C33, "Revelation Shaft" },
    { 0x0035, "Dark Abhors Light" },
    { 0x0135, "Dream of the Holy Land" },
    { 0x0235, "The Ore Road" },
    { 0x0335, "Atone for Eternity" },
    { 0x0435, "The Air Stirs" },
    { 0x0535, "Bonds of Friendship" },
    { 0x0635, "Stair to Sanctuary" },
    { 0x0735, "The Fallen Hall" },
    { 0x0835, "The Rotten Core" },
    { 0x0935, "Bacchus is Cheap" },
    { 0x0A35, "Screams of the Wounded" },
    { 0x0B35, "The Ore-Bearers" },
    { 0x0C35, "The Dreamer's Climb" },
    { 0x0D35, "Sinner's Sustenence" },
    { 0x0E35, "The Timely Dew of Sleep" },
    { 0x0F35, "Companions in Arms" },
    { 0x1035, "The Auction Block" },
    { 0x1135, "Ascension" },
    { 0x1235, "Where the Serpent Hunts" },
    { 0x1335, "Ants Prepare for Winter" },
    { 0x1435, "Drowned in Fleeting Joy" },
    { 0x1535, "The Laborer's Bonfire" },
    { 0x1635, "Stone and Sulfurous Fire" },
    { 0x1735, "Torture Without End" },
    { 0x1835, "Way Down" },
    { 0x1935, "Excavated Hollow" },
    { 0x1A35, "Parting Regrets" },
    { 0x1B35, "Corridor of Tales" },
    { 0x1C35, "Dust Shall Eat the Days" },
    { 0x1D35, "Hall of the Wage-Paying" },
    { 0x1F35, "Tunnel of the Heartless" },
    { 0x001E, "The Dark Coast" },
    { 0x011E, "Hall of Prayer" },
    { 0x021E, "Those who Drink the Dark" },
    { 0x031E, "The Chapel of Meschaunce" },
    { 0x041E, "The Resentful Ones" },
    { 0x051E, "Those who Fear the Light" },
    { 0x001F, "Chamber of Reason" },
    { 0x011F, "Exit to City Center" },
    { 0x0016, "Sanity and Madness" },
    { 0x0416, "Truth and Lies" },
    { 0x0616, "Order and Chaos" },
    { 0x0716, "The Victor's Laurels" },
    { 0x0816, "Struggle for the Soul" },
    { 0x0916, "An Offering of Souls" },
    { 0x0018, "The Flayed Confessional" },
    { 0x0118, "Monk's Leap" },
    { 0x0218, "Where Darkness Spreads" },
    { 0x0318, "Hieratic Recollections" },
    { 0x0418, "A Light in the Dark" },
    { 0x0518, "The Poisoned Chapel" },
    { 0x0618, "Sin and Punishment" },
    { 0x0718, "Cracked Pleasures" },
    { 0x0818, "Into Holy Battle" },
    { 0x0117, "He Screams for Mercy" },
    { 0x0217, "Light and Dark Wage War" },
    { 0x0317, "Abasement from Above" },
    { 0x0918, "Maelstrom of Malice" },
    { 0x0A18, "The Acolyte's Weakness" },
    { 0x0B18, "The Hall of Broken Vows" },
    { 0x0C18, "The Melodics of Madness" },
    { 0x0D18, "Free from Base Desires" },
    { 0x0E18, "The Convent Room" },
    { 0x0019, "An Arrow into Darkness" },
    { 0x0119, "What Ails You, Kills You" },
    { 0x0417, "The Heretics' Story" },
    { 0x0517, "The Wine-Lecher's Fall" },
    { 0x0F18, "Hopes of the Idealist" },
    { 0x0219, "Where the Soul Rots" },
    { 0x0319, "Despair of the Fallen" },
    { 0x0419, "The Atrium" },
    { 0x0036, "Stair to the Sinners" },
    { 0x0136, "Slaugher of the Innocent" },
    { 0x0236, "The Fallen Knight" },
    { 0x0336, "The Oracle Sins No More" },
    { 0x0436, "Awaiting Retribution" },
    { 0x0034, "Shelter From the Quake" },
    { 0x0134, "Buried Alive" },
    { 0x0234, "Movement of Fear" },
    { 0x0334, "Facing Your Illusions" },
    { 0x0434, "The Darkness Drinks" },
    { 0x0534, "Fear and Loathing" },
    { 0x0634, "Blood and the Beast" },
    { 0x0734, "Where Body and Soul Part" },
    { 0x0037, "The Cage" },
    { 0x0137, "The Cauldron" },
    { 0x0237, "Wooden Horse" },
    { 0x0337, "Starvation" },
    { 0x0437, "The Breast Ripper" },
    { 0x0537, "The Pear" },
    { 0x0637, "The Whirligig" },
    { 0x0737, "Spanish Tickler" },
    { 0x0837, "Heretic's Fork" },
    { 0x0937, "The Chair of Spikes" },
    { 0x0A37, "Blooding" },
    { 0x0B37, "Bootikens" },
    { 0x0C37, "Burial" },
    { 0x0D37, "Burning" },
    { 0x0E37, "Cleansing the Soul" },
    { 0x0F37, "The Garotte" },
    { 0x1037, "Hanging" },
    { 0x1137, "Impalement" },
    { 0x1237, "Knotting" },
    { 0x1337, "The Branks" },
    { 0x1437, "The Wheel" },
    { 0x1537, "The Judas Cradle" },
    { 0x1637, "The Ducking Stool" },
    { 0x0038, "The Eunics' Lot" },
    { 0x0138, "Ordeal By Fire" },
    { 0x0238, "Tablillas" },
    { 0x0338, "The Oven at Neisse" },
    { 0x0438, "Strangulation" },
    { 0x0538, "Pressing" },
    { 0x0638, "The Strappado" },
    { 0x0738, "The Mind Burns" },
    { 0x0838, "Thumbscrews" },
    { 0x0938, "The Rack" },
    { 0x0A38, "The Saw" },
    { 0x0B38, "Ordeal By Water" },
    { 0x0C38, "The Cold's Bridle" },
    { 0x0D38, "Brank" },
    { 0x0E38, "The Shin-Vice" },
    { 0x0F38, "Squassation" },
    { 0x1038, "The Spider" },
    { 0x1138, "Lead Sprinkler" },
    { 0x1238, "Pendulum" },
    { 0x1338, "Dragging" },
    { 0x1438, "Tongue Slicer" },
    { 0x1538, "Tormentum Insomniae" },
    { 0x1638, "The Iron Maiden" },
    { 0x1738, "Saint Elmo's Belt" },
    { 0x1838, "Judgement" },
    { 0x1938, "Dunking the Witch" },
    { 0x002F, "Workshop \"Godhands\"" },
    { 0x0030, "The Bread Peddler's Way" },
    { 0x0130, "Way of the Mother Lode" },
    { 0x0230, "Sewer of Ravenous Rats" },
    { 0x0330, "Underdark Fishmarket" },
    { 0x0430, "The Sunless Way" },
    { 0x0530, "Remembering Days of Yore" },
    { 0x0630, "Where the Hunter Climbed" },
    { 0x0730, "Larder for a Lean Winter" },
    { 0x0830, "Hall of Poverty" },
    { 0x0930, "The Washing-Woman's Way" },
    { 0x0A30, "Beggars of the Mouthharp" },
    { 0x0B30, "Corner of the Wretched" },
    { 0x0C30, "Path to the Greengrocer" },
    { 0x0D30, "Crossroads of Rest" },
    { 0x0E30, "Path of the Children" },
    { 0x0F30, "Fear of the Fall" },
    { 0x1030, "Sinner's Corner" },
    { 0x1130, "Nameless Dark Oblivion" },
    { 0x1230, "Corner of Prayers" },
    { 0x1330, "Hope Obstructed" },
    { 0x1430, "The Children's Hideout" },
    { 0x1530, "The Crumbling Market" },
    { 0x1630, "Tears from Empty Sockets" },
    { 0x1730, "Where Flood Waters Ran" },
    { 0x1830, "The Body Fragile Yields" },
    { 0x1930, "Salvation for the Mother" },
    { 0x1A30, "Bite the Master's Wounds" },
    { 0x0031, "Hall to a New World" },
    { 0x0131, "Place of Free Words" },
    { 0x0231, "Bazaar of the Bizarre" },
    { 0x0331, "Noble Gold and Silk" },
    { 0x0431, "A Knight Sells his Sword" },
    { 0x0531, "Gemsword Blackmarket" },
    { 0x0631, "The Pirate's Son" },
    { 0x0731, "Sale of the Sword" },
    { 0x0831, "Weapons Not Allowed" },
    { 0x0931, "The Greengrocer's Stair" },
    { 0x0A31, "Where Black Waters Ran" },
    { 0x0B31, "Arms Against Invaders" },
    { 0x0C31, "Catspaw Blackmarket" },
    { 0x001D, "The Warrior's Rest" },
    { 0x021D, "The Soldier's Bedding" },
    { 0x031D, "A Storm of Arrows" },
    { 0x041D, "Urge the Boy On" },
    { 0x051D, "A Taste of the Spoils" },
    { 0x061D, "Wiping Blood from Blades" },
    { 0x002C, "Wkshop \"Keane's Crafts\"" },
    { 0x001C, "Students of Death" },
    { 0x011C, "The Gabled Hall" },
    { 0x021C, "Where the Master Fell" },
    { 0x031C, "The Weeping Boy" },
    { 0x041C, "Swords for the Land" },
    { 0x051C, "In Wait of the Foe" },
    { 0x061C, "Where Weary Riders Rest" },
    { 0x071C, "The Boy's Training Room" },
    { 0x081C, "Train and Grow Strong" },
    { 0x091C, "The Squire's Gathering" },
    { 0x0A1C, "The Invaders are Found" },
    { 0x0B1C, "The Dream-Weavers" },
    { 0x0C1C, "The Cornered Savage" },
    { 0x0D1C, "Traces of Invasion Past" },
    { 0x0E1C, "From Squire to Knight" },
    { 0x0F1C, "Be for Battle Prepared" },
    { 0x101C, "Destruction and Rebirth" },
    { 0x111C, "From Boy to Hero" },
    { 0x121C, "A Welcome Invasion" },
    { 0x0028, "The Hunt Begins" },
    { 0x0128, "Which Way Home" },
    { 0x0228, "The Giving Trees" },
    { 0x0328, "The Wounded Boar" },
    { 0x0428, "Golden Egg Way" },
    { 0x0528, "The Birds and the Bees" },
    { 0x0628, "The Woodcutter's Run" },
    { 0x0728, "The Wolves' Choice" },
    { 0x0828, "Howl of the Wolf King" },
    { 0x0928, "Fluttering Hope" },
    { 0x0A28, "Traces of the Beast" },
    { 0x0B28, "The Yellow Wood" },
    { 0x0C28, "They Also Feed" },
    { 0x0D28, "Where Soft Rains Fell" },
    { 0x0E28, "The Spirit Trees" },
    { 0x0F28, "The Silent Hedges" },
    { 0x1028, "Lamenting to the Moon" },
    { 0x1128, "The Hollow Hills" },
    { 0x1228, "Running with the Wolves" },
    { 0x1328, "You Are the Prey" },
    { 0x1428, "The Secret Path" },
    { 0x1528, "The Faerie Circle" },
    { 0x1628, "Return to the Land" },
    { 0x1728, "Forest River" },
    { 0x1828, "Hewn from Nature" },
    { 0x1928, "The Wood Gate" },
    { 0x0029, "Steady the Boar-Spears" },
    { 0x0129, "The Boar's Revenge" },
    { 0x0229, "Nature's Womb" },
    { 0x0020, "Rue Vermillion" },
    { 0x0120, "The Rene Coastroad" },
    { 0x0220, "Rue Mal Fallde" },
    { 0x0320, "Tircolas Flow" },
    { 0x0420, "Glacialdra Kirk Ruins" },
    { 0x0520, "Rue Bouquet" },
    { 0x0620, "Villeport Way" },
    { 0x0720, "Rue Sant D'alsa" },
    { 0x0022, "Dinas Walk" },
    { 0x002B, "Workshop \"Magic Hammer\"" },
    { 0x0820, "Valdiman Gates" },
    { 0x0920, "Rue Faltes" },
    { 0x0A20, "Forcas Rise" },
    { 0x0B20, "Rue Aliano" },
    { 0x0C20, "Rue Volnac" },
    { 0x0D20, "Rue Morgue" },
    { 0x0023, "Zebel's Walk" },
    { 0x0025, "The House Khazabas" },
    { 0x0F20, "Rue Lejour" },
    { 0x1020, "Kesch Bridge" },
    { 0x1120, "Rue Crimnade" },
    { 0x1220, "Rue Fisserano" },
    { 0x1320, "Shasras Hill Park" },
    { 0x0024, "Gharmes Walk" },
    { 0x0026, "The House Gilgitte" },
    { 0x0027, "Plateia Lumitar" },
    { 0x002D, "Workshop \"Metal Works\"" },
    { 0x002E, "Wkshop \"Junction Point\"" },
};

    public record struct RoomEntryProgression(ushort Prog1, byte? Prog2);

    public static Dictionary<ushort, RoomEntryProgression> BossProgressionSettings = new Dictionary<ushort, RoomEntryProgression>
    {
        { 0x000C, new(0x0008, 0x00) }, // minotaur
        { 0x000B, new(0x000c, 0x00) }, // dullahan
        { 0x0320, new(0x0020, null) }, // Duane
        { 0x1632, new(0x0022, null) }, // Ogre
        { 0x1828, new(0x002c, 0x00) }, // Father and Dark Crusader
        // Rozenrantz goes here
        { 0x0F30, new(0x0035, null) }, // Dark Elemental
        { 0x0737, new(0x0037, null) },
        // neesa and tieger go here
    };

    public static Dictionary<int, ushort> StartingLocationAddress = new Dictionary<int, ushort>
    {
        { 0, 0x002b },
        { 1, 0x0005 },
        { 2, 0x002d },
        { 3, 0x002f },
        { 4, 0x002c },
        { 5, 0x002a }
    };

    public static void SetBossProgression(ushort mapId)
    {
        if (BossProgressionSettings.TryGetValue(mapId, out var progression))
        {
            Memory.Write(Addresses.ProgressionState, progression.Prog1);
            if (progression.Prog2.HasValue)
            {
                Memory.Write(Addresses.ProgressionState2, progression.Prog2.Value);
            }
        }
        else
        {
            // No match found for this mapId — set a default/fallback state
            Memory.Write(Addresses.ProgressionState, 0x0051);
        }
    }

    public static void SetStartingLocation(CancellationTokenSource cts, ArchipelagoClient client)
    {
        if (cts.Token.IsCancellationRequested) return;

        Memory.MonitorAddressForAction<ushort>(
            Addresses.CurrentMapandRoomID,
            () =>
            {

                int startingLocation = Int32.Parse(client.Options?.GetValueOrDefault("open_world_option", "0").ToString());

                int count = 0;
                while (count < 10)
                {
                    var address = StartingLocationAddress[startingLocation];
                    Memory.Write(Addresses.CurrentMapandRoomID, address);
                    count++;
                }
            },
            value => value >= 1);
    }

    public static void MarkMapAsSeen(int mapId)
    {
        // Data Crystal Formula:
        // Address = 0x8005FFD8 + (MapID / 8)
        // Bit = MapID % 8

        uint byteOffset = (uint)(mapId / 8);
        int bitNumber = mapId % 8;
        ulong targetAddress = Addresses.MapStatusAddress01 + byteOffset;

        // Use the existing WriteBit utility
        // value: true sets the bit to 1
        Memory.WriteBit(targetAddress, bitNumber, true);

    }

    /// <summary>
    /// Flips the bits for a collection of map IDs to "silence" them.
    /// </summary>
    public static void SilenceCutsceneRange(IEnumerable<int> mapIds)
    {
        foreach (var id in mapIds)
        {
            MarkMapAsSeen(id);
        }
    }
}