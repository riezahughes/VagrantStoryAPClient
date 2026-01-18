using Archipelago.Core.Models;
using VagrantStoryArchipelago;
using VagrantStoryArchipelago.Models;

namespace Helpers
{
    public class LocationHelpers
    {
        // buildLocationsList returns a list of all the valid locations that you need to read from the game
        // while also taking into account what the addresses have to match in order to send out a location.
        // the ID's here must match the ID's in your ap world.

        // It helps to split them out somewhere that you can import and loop over instead of doing them one at a time like this. If you have regions in your ap world
        // then that's a great way to split them up. Just a reminder, the important thing is THAT THE ID'S MATCH THE APWORLD.
        public static List<ILocation> BuildLocationList(Dictionary<string, object> options)
        {



            int base_id = 99350000;
            int region_offset = 1000;

            //int gargoyleSanity = int.Parse(options?.GetValueOrDefault("gargoylesanity", "0").ToString());
            //int bookSanity = int.Parse(options?.GetValueOrDefault("booksanity", "0").ToString());

            List<string> table_order = [
                "Ashley",
                "Prologue",
                "Entrance to Darkness",
                "Worker's Breakroom",
                "Hall of Struggle",
                "Smokebarrel Stair",
                "Wine Guild Hall",
                "Wine Magnate's Chambers",
                "Fine Vintage Vault",
                "Chamber of Fear",
                "The Reckoning Room",
                "A Laborer's Thirst",
                "The Rich Drown in Wine",
                "Room of Rotten Grapes",
                "Blackmarket of Wines",
                "The Gallows",
                "Room of Cheap Red Wine",
                "Room of Cheap White Wine",
                "The Greedy One's Den",
                "The Hero's Winehall",
                "The Bread Peddler's Way",
                "Way of the Mother Lode",
                "Sewer of Ravenous Rats",
                "Underdark Fishmarket",
                "The Sunless Way",
                "Remembering Days of Yore",
                "Larder for a Lean Winter",
                "Where the Hunter Climbed",
                "Hall of Poverty",
                "The Washing-Woman's Way",
                "Nameless Dark Oblivion",
                "Sinner's Corner",
                "Fear of the Fall",
                "The Children's Hideout",
                "Corner of Prayers",
                "Hope Obstructed",
                "Beggars of the Mouthharp",
                "Corner of the Wretched",
                "Crossroads of Rest",
                "Path to the Greengrocer",
                "Path of the Children",
                "Salvation for the Mother",
                "The Body Fragile Yields",
                "Bite the Master's Wounds",
                "Workshop 'Godhands'",
                "The Crumbling Market (South)",
                "The Crumbling Market (North)",
                "Where Flood Waters Ran",
                "Tears from Empty Sockets",
                "Hall to a New World",
                "Place of Free Words",
                "Bazaar of the Bizarre",
                "Noble Gold and Silk",
                "Weapons Not Allowed",
                "A Knight Sells his Sword",
                "Gemsword Blackmarket",
                "The Pirate's Son",
                "Sale of the Sword",
                "The Greengrocer's Stair",
                "Where Black Waters Ran",
                "Arms Against Invaders",
                "Catspaw Blackmarket",
                "Forcas Rise",
                "Valdiman Gates",
                "Rue Aliano",
                "The House Khazabas",
                "Zebel's Walk",
                "Rue Volnac",
                "Rue Faltes",
                "Rue Morgue",
                "Rue Lejour",
                "Kesch Bridge",
                "Rue Crimnade",
                "Workshop 'Junction Point'",
                "Rue Fisserano",
                "Workshop 'Metal Works'",
                "Shasras Hill Park",
                "The House Gilgitte",
                "Gharmes Walk",
                "Plateia Lumitar",
                "Rue Vermillion",
                "The Rene Coastroad",
                "Workshop 'Magic Hammer'",
                "Rue Mal Fallde",
                "Tircolas Flow (North)",
                "Tircolas Flow (South)",
                "Rue Bouquet",
                "Glacialdra Kirk Ruins",
                "Rue Sant D'alsa",
                "Dinas Walk",
                "Villeport Way",
                "The Soldier's Bedding",
                "A Storm of Arrows",
                "Time Trial (Minotaur)",
                "Time Trial (Dragon)",
                "Urge the Boy On",
                "Time Trial (Earth Dragon)",
                "Time Trial (Snow Dragon)",
                "A Taste of the Spoils",
                "Time Trial (Damascus Golem)",
                "Time Trial (Damascus Crab)",
                "Wiping Blood from Blades",
                "Time Trial (Death + Ogre Zombie)",
                "Time Trial (Asura)",
                "The Warrior's Rest",
                "Workshop 'Keane's Crafts'",
                "The Dark Coast",
                "Hall of Prayer",
                "Those who Drink the Dark",
                "The Chapel of Meschaunce",
                "The Resentful Ones",
                "Those who Fear the Light",
                "Chamber of Reason",
                "Exit to City Center",
                "The Faerie Circle",
                "The Hunt Begins",
                "Which Way Home",
                "The Giving Trees",
                "The Birds and the Bees",
                "The Wounded Boar",
                "Golden Egg Way",
                "Traces of the Beast",
                "Fluttering Hope",
                "Return to the Land",
                "The Yellow Wood",
                "They Also Feed",
                "The Spirit Trees",
                "Where Soft Rains Fell",
                "Forest River",
                "Lamenting to the Moon",
                "Running with the Wolves",
                "You Are the Prey",
                "The Secret Path",
                "Hewn from Nature",
                "The Wood Gate",
                "The Wolves' Choice",
                "The Woodcutter's Run",
                "The Hollow Hills",
                "Howl of the Wolf King",
                "The Silent Hedges",
                "Steady the Boar-Spears",
                "The Boar's Revenge",
                "Nature's Womb",
                "Prisoners' Niche",
                "Corridor of the Clerics",
                "Priests' Confinement",
                "Alchemists' Laboratory",
                "The Academia Corridor",
                "Theology Classroom",
                "Shrine of the Martyrs",
                "Hallowed Hope",
                "Hall of Sacrilege",
                "Advent Ground (South)",
                "Passage of the Refugees (South)",
                "Passage of the Refugees (North)",
                "Advent Ground (North)",
                "The Cleansing Chantry",
                "Stairway to the Light",
                "Dark Abhors Light",
                "Dream of the Holy Land",
                "The Ore Road",
                "The Air Stirs",
                "Bonds of Friendship",
                "Atone for Eternity",
                "Stair to Sanctuary",
                "The Fallen Hall",
                "The Rotten Core",
                "The Dreamer's Climb",
                "The Ore-Bearers",
                "Screams of the Wounded",
                "Bacchus is Cheap",
                "Sinner's Sustenence",
                "The Timely Dew of Sleep",
                "Companions in Arms",
                "The Auction Block",
                "Ascension",
                "Where the Serpent Hunts",
                "Drowned in Fleeting Joy",
                "Ants Prepare for Winter",
                "The Laborer's Bonfire",
                "Stone and Sulfurous Fire",
                "Torture Without End",
                "Way Down",
                "Excavated Hollow",
                "Parting Regrets",
                "Corridor of Tales",
                "Dust Shall Eat the Days",
                "Hall of the Wage-Paying",
                "Tunnel of the Heartless",
                "The Cage",
                "The Cauldron",
                "Wooden Horse",
                "Starvation",
                "The Breast Ripper",
                "The Wheel",
                "The Branks",
                "The Pear",
                "The Judas Cradle",
                "The Whirlygig",
                "Spanish Tickler",
                "Heretic's Fork",
                "The Chair of Spikes",
                "Blooding",
                "Bootikens",
                "Burial",
                "Burning",
                "Cleansing the Soul",
                "The Ducking Stool",
                "The Garotte",
                "Hanging",
                "Impalement",
                "Knotting",
                "The Eunics' Lot",
                "Ordeal By Fire",
                "The Oven at Neisse",
                "Pressing",
                "The Mind Burns",
                "The Rack",
                "The Saw",
                "The Cold's Bridle",
                "The Shin-Vice",
                "The Spider",
                "Lead Sprinkler",
                "Squassation",
                "The Strappado",
                "Thumbscrews",
                "Pendulum",
                "Dragging",
                "Strangulation",
                "Tablillas",
                "Tongue Slicer",
                "Ordeal by Water",
                "Brank",
                "Tormentum Insomniae",
                "The Iron Maiden",
                "Judgement",
                "Saint Elmo's Belt",
                "Dunking the Witch",
                "Into Holy Battle",
                "The Poisoned Chapel",
                "Sin and Punishment",
                "A Light in the Dark",
                "Monk's Leap",
                "Hieratic Recollections",
                "The Flayed Confessional",
                "Cracked Pleasures",
                "Where Darkness Spreads",
                "Struggle for the Soul",
                "Order and Chaos",
                "An Offering of Souls",
                "Truth and Lies",
                "Sanity and Madness",
                "The Victor's Laurels",
                "Free from Base Desires",
                "Abasement from Above",
                "The Convent Room",
                "The Hall of Broken Vows",
                "Light and Dark Wage War",
                "An Arrow into Darkness",
                "He Screams for Mercy",
                "The Acolyte's Weakness",
                "Maelstrom of Malice",
                "The Melodics of Madness",
                "What Ails You, Kills You",
                "The Wine-Lecher's Fall",
                "The Heretics' Story (Lower)",
                "The Heretics' Story (Upper)",
                "Despair of the Fallen",
                "Hopes of the Idealist",
                "Where the Soul Rots",
                "The Atrium",
                "Dome",
                "Paling",
                "Stair to the Sinners",
                "Slaughter of the Innocent",
                "The Oracle Sins No More",
                "The Fallen Knight",
                "Awaiting Retribution",
                "Shelter From the Quake",
                "Buried Alive",
                "Movement of Fear",
                "Facing Your Illusions",
                "The Darkness Drinks",
                "Fear and Loathing",
                "Blood and The Beast",
                "Where Body and Soul Part",
                "Students of Death",
                "The Gabled Hall",
                "Where the Master Fell",
                "In Wait of the Foe",
                "Swords for the Land",
                "The Weeping Boy",
                "Where Weary Riders Rest",
                "The Boy's Training Room",
                "From Squire to Knight",
                "Traces of Invasion Past",
                "Be for Battle Prepared",
                "Destruction and Rebirth",
                "From Boy to Hero",
                "A Welcome Invasion",
                "Train and Grow Strong",
                "The Squire's Gathering",
                "The Invaders are Found",
                "The Dream Weavers",
                "The Cornered Savage",
                "Hall of Sworn Revenge",
                "The Last Blessing",
                "The Weeping Corridor",
                "Persecution Hall",
                "Rodent-Ridden Chamber",
                "Shrine to the Martyrs",
                "The Lamenting Mother (West)",
                "The Lamenting Mother (East)",
                "Hall of Dying Hope",
                "Bandits' Hideout",
                "The Bloody Hallway",
                "Faith Overcame Fear",
                "The Withered Spring",
                "Workshop 'Work of Art'",
                "Repent, O ye Sinners",
                "The Reaper's Victims",
                "The Last Stab of Hope",
                "Hallway of Heroes",
                "The Beast's Domain",
                "Dreamers' Entrance",
                "The Crossing",
                "Miners' Resting Hall",
                "Conflict and Accord",
                "The End of the Line",
                "The Earthquake's Mark",
                "Coal Mine Storage",
                "The Suicide King",
                "The Battle's Beginning",
                "What Lies Ahead?",
                "The Fruits of Friendship",
                "The Passion of Lovers",
                "The Hall of Hope",
                "The Dark Tunnel",
                "Everwant Passage",
                "Mining Regrets",
                "Rust in Peace",
                "The Smeltry",
                "Clash of Hyaenas",
                "Greed Knows No Bounds",
                "Live Long and Prosper",
                "Pray to the Mineral Gods",
                "Traitor's Parting",
                "Escapeway",
                "Subtellurian Horrors",
                "Dining in Darkness",
                "Bandit's Hollow",
                "Delusions of Happiness",
                "Work, Then Die",
                "Rock Bottom",
                "Senses Lost",
                "The Lunatic Veins",
                "Tomb of the Reborn",
                "Fool's Gold, Fool's Loss",
                "Kilroy Was Here",
                "A Wager of Noble Gold",
                "Lambs to the Slaughter",
                "The Ore of Legend",
                "Suicidal Desires",
                "Cry of the Beast",
                "The Fallen Bricklayer",
                "Hall of Contemplation",
                "Hall of the Empty Sconce",
                "Acolyte's Burial Vault",
                "The Abandoned Catspaw",
                "Crossing of Blood",
                "Desire's Passage",
                "Way of Lost Children",
                "Hidden Resources",
                "Treaty Room",
                "The Miner's End",
                "Gambler's Passage",
                "Revelation Shaft",
                "Corridor of Shade",
                "Credits"
            ];

            List<ILocation> locations = new List<ILocation>();

            Dictionary<string, List<GenericLocationData>> allLevelLocations = new Dictionary<string, List<GenericLocationData>>();

            // Level Locations
            allLevelLocations.Add("Ashley", GetAshleyData());
            allLevelLocations.Add("Prologue", GetPrologueData());
            allLevelLocations.Add("Entrance to Darkness", GetEntranceToDarknessData());
            allLevelLocations.Add("Worker's Breakroom", GetWorkersBreakroomData());
            allLevelLocations.Add("Hall of Struggle", GetHallOfStruggleData());
            allLevelLocations.Add("Smokebarrel Stair", GetSmokebarrelStairData());
            allLevelLocations.Add("Wine Guild Hall", GetWineGuildHallData());
            allLevelLocations.Add("Wine Magnate's Chambers", GetWineMagnatesChambersData());
            allLevelLocations.Add("Fine Vintage Vault", GetFineVintageVaultData());
            allLevelLocations.Add("Chamber of Fear", GetChamberOfFearData());
            allLevelLocations.Add("The Reckoning Room", GetTheReckoningRoomData());
            allLevelLocations.Add("A Laborer's Thirst", GetALaborersThirstData());
            allLevelLocations.Add("The Rich Drown in Wine", GetTheRichDrownInWineData());
            allLevelLocations.Add("Room of Rotten Grapes", GetRoomOfRottenGrapesData());
            allLevelLocations.Add("Blackmarket of Wines", GetBlackmarketOfWinesData());
            allLevelLocations.Add("The Gallows", GetTheGallowsData());
            allLevelLocations.Add("Room of Cheap Red Wine", GetRoomOfCheapRedWineData());
            allLevelLocations.Add("Room of Cheap White Wine", GetRoomOfCheapWhiteWineData());
            allLevelLocations.Add("The Greedy One's Den", GetTheGreedyOnesDenData());
            allLevelLocations.Add("The Hero's Winehall", GetTheHerosWinehallData());
            allLevelLocations.Add("The Bread Peddler's Way", GetTheBreadPeddlersWayData());
            allLevelLocations.Add("Way of the Mother Lode", GetWayOfTheMotherLodeData());
            allLevelLocations.Add("Sewer of Ravenous Rats", GetSewerOfRavenousRatsData());
            allLevelLocations.Add("Underdark Fishmarket", GetUnderdarkFishmarketData());
            allLevelLocations.Add("The Sunless Way", GetTheSunlessWayData());
            allLevelLocations.Add("Remembering Days of Yore", GetRememberingDaysOfYoreData());
            allLevelLocations.Add("Larder for a Lean Winter", GetLarderForALeanWinterData());
            allLevelLocations.Add("Where the Hunter Climbed", GetWhereTheHunterClimbedData());
            allLevelLocations.Add("Hall of Poverty", GetHallOfPovertyData());
            allLevelLocations.Add("The Washing-Woman's Way", GetTheWashingWomansWayData());
            allLevelLocations.Add("Nameless Dark Oblivion", GetNamelessDarkOblivionData());
            allLevelLocations.Add("Sinner's Corner", GetSinnersCornerData());
            allLevelLocations.Add("Fear of the Fall", GetFearOfTheFallData());
            allLevelLocations.Add("The Children's Hideout", GetTheChildrensHideoutData());
            allLevelLocations.Add("Corner of Prayers", GetCornerOfPrayersData());
            allLevelLocations.Add("Hope Obstructed", GetHopeObstructedData());
            allLevelLocations.Add("Beggars of the Mouthharp", GetBeggarsOfTheMouthharpData());
            allLevelLocations.Add("Corner of the Wretched", GetCornerOfTheWretchedData());
            allLevelLocations.Add("Crossroads of Rest", GetCrossroadsOfRestData());
            allLevelLocations.Add("Path to the Greengrocer", GetPathToTheGreengrocerData());
            allLevelLocations.Add("Path of the Children", GetPathOfTheChildrenData());
            allLevelLocations.Add("Salvation for the Mother", GetSalvationForTheMotherData());
            allLevelLocations.Add("The Body Fragile Yields", GetTheBodyFragileYieldsData());
            allLevelLocations.Add("Bite the Master's Wounds", GetBiteTheMastersWoundsData());
            allLevelLocations.Add("Workshop 'Godhands'", GetWorkshopGodhandsData());
            allLevelLocations.Add("The Crumbling Market (South)", GetTheCrumblingMarketSouthData());
            allLevelLocations.Add("The Crumbling Market (North)", GetTheCrumblingMarketNorthData());
            allLevelLocations.Add("Where Flood Waters Ran", GetWhereFloodWatersRanData());
            allLevelLocations.Add("Tears from Empty Sockets", GetTearsFromEmptySocketsData());
            allLevelLocations.Add("Hall to a New World", GetHallToANewWorldData());
            allLevelLocations.Add("Place of Free Words", GetPlaceOfFreeWordsData());
            allLevelLocations.Add("Bazaar of the Bizarre", GetBazaarOfTheBizarreData());
            allLevelLocations.Add("Noble Gold and Silk", GetNobleGoldAndSilkData());
            allLevelLocations.Add("Weapons Not Allowed", GetWeaponsNotAllowedData());
            allLevelLocations.Add("A Knight Sells his Sword", GetAKnightSellsHisSwordData());
            allLevelLocations.Add("Gemsword Blackmarket", GetGemswordBlackmarketData());
            allLevelLocations.Add("The Pirate's Son", GetThePiratesSonData());
            allLevelLocations.Add("Sale of the Sword", GetSaleOfTheSwordData());
            allLevelLocations.Add("The Greengrocer's Stair", GetTheGreengrocersStairData());
            allLevelLocations.Add("Where Black Waters Ran", GetWhereBlackWatersRanData());
            allLevelLocations.Add("Arms Against Invaders", GetArmsAgainstInvadersData());
            allLevelLocations.Add("Catspaw Blackmarket", GetCatspawBlackmarketData());
            allLevelLocations.Add("Forcas Rise", GetForcasRiseData());
            allLevelLocations.Add("Valdiman Gates", GetValdimanGatesData());
            allLevelLocations.Add("Rue Aliano", GetRueAlianoData());
            allLevelLocations.Add("The House Khazabas", GetTheHouseKhazabasData());
            allLevelLocations.Add("Zebel's Walk", GetZebelsWalkData());
            allLevelLocations.Add("Rue Volnac", GetRueVolnacData());
            allLevelLocations.Add("Rue Faltes", GetRueFaltesData());
            allLevelLocations.Add("Rue Morgue", GetRueMorgueData());
            allLevelLocations.Add("Rue Lejour", GetRueLejourData());
            allLevelLocations.Add("Kesch Bridge", GetKeschBridgeData());
            allLevelLocations.Add("Rue Crimnade", GetRueCrimnadeData());
            allLevelLocations.Add("Workshop 'Junction Point'", GetWorkshopJunctionPointData());
            allLevelLocations.Add("Rue Fisserano", GetRueFisseranoData());
            allLevelLocations.Add("Workshop 'Metal Works'", GetWorkshopMetalWorksData());
            allLevelLocations.Add("Shasras Hill Park", GetShasrasHillParkData());
            allLevelLocations.Add("The House Gilgitte", GetTheHouseGilgitteData());
            allLevelLocations.Add("Gharmes Walk", GetGharmesWalkData());
            allLevelLocations.Add("Plateia Lumitar", GetPlateiaLumitarData());
            allLevelLocations.Add("Rue Vermillion", GetRueVermillionData());
            allLevelLocations.Add("The Rene Coastroad", GetTheReneCoastroadData());
            allLevelLocations.Add("Workshop 'Magic Hammer'", GetWorkshopMagicHammerData());
            allLevelLocations.Add("Rue Mal Fallde", GetRueMalFalldeData());
            allLevelLocations.Add("Tircolas Flow (North)", GetTircolasFlowNorthData());
            allLevelLocations.Add("Tircolas Flow (South)", GetTircolasFlowSouthData());
            allLevelLocations.Add("Rue Bouquet", GetRueBouquetData());
            allLevelLocations.Add("Glacialdra Kirk Ruins", GetGlacialdraKirkRuinsData());
            allLevelLocations.Add("Rue Sant D'alsa", GetRueSantDalsaData());
            allLevelLocations.Add("Dinas Walk", GetDinasWalkData());
            allLevelLocations.Add("Villeport Way", GetVilleportWayData());
            allLevelLocations.Add("The Soldier's Bedding", GetTheSoldiersBeddingData());
            allLevelLocations.Add("A Storm of Arrows", GetAStormOfArrowsData());
            allLevelLocations.Add("Time Trial (Minotaur)", GetTimeTrialMinotaurData());
            allLevelLocations.Add("Time Trial (Dragon)", GetTimeTrialDragonData());
            allLevelLocations.Add("Urge the Boy On", GetUrgeTheBoyOnData());
            allLevelLocations.Add("Time Trial (Earth Dragon)", GetTimeTrialEarthDragonData());
            allLevelLocations.Add("Time Trial (Snow Dragon)", GetTimeTrialSnowDragonData());
            allLevelLocations.Add("A Taste of the Spoils", GetATasteOfTheSpoilsData());
            allLevelLocations.Add("Time Trial (Damascus Golem)", GetTimeTrialDamascusGolemData());
            allLevelLocations.Add("Time Trial (Damascus Crab)", GetTimeTrialDamascusCrabData());
            allLevelLocations.Add("Wiping Blood from Blades", GetWipingBloodFromBladesData());
            allLevelLocations.Add("Time Trial (Death + Ogre Zombie)", GetTimeTrialDeathOgreZombieData());
            allLevelLocations.Add("Time Trial (Asura)", GetTimeTrialAsuraData());
            allLevelLocations.Add("The Warrior's Rest", GetTheWarriorsRestData());
            allLevelLocations.Add("Workshop 'Keane's Crafts'", GetWorkshopKeanesCraftsData());
            allLevelLocations.Add("The Dark Coast", GetTheDarkCoastData());
            allLevelLocations.Add("Hall of Prayer", GetHallOfPrayerData());
            allLevelLocations.Add("Those who Drink the Dark", GetThoseWhoDrinkTheDarkData());
            allLevelLocations.Add("The Chapel of Meschaunce", GetTheChapelOfMeschaunceData());
            allLevelLocations.Add("The Resentful Ones", GetTheResentfulOnesData());
            allLevelLocations.Add("Those who Fear the Light", GetThoseWhoFearTheLightData());
            allLevelLocations.Add("Chamber of Reason", GetChamberOfReasonData());
            allLevelLocations.Add("Exit to City Center", GetExitToCityCenterData());
            allLevelLocations.Add("The Faerie Circle", GetTheFaerieCircleData());
            allLevelLocations.Add("The Hunt Begins", GetTheHuntBeginsData());
            allLevelLocations.Add("Which Way Home", GetWhichWayHomeData());
            allLevelLocations.Add("The Giving Trees", GetTheGivingTreesData());
            allLevelLocations.Add("The Birds and the Bees", GetTheBirdsAndTheBeesData());
            allLevelLocations.Add("The Wounded Boar", GetTheWoundedBoarData());
            allLevelLocations.Add("Golden Egg Way", GetGoldenEggWayData());
            allLevelLocations.Add("Traces of the Beast", GetTracesOfTheBeastData());
            allLevelLocations.Add("Fluttering Hope", GetFlutteringHopeData());
            allLevelLocations.Add("Return to the Land", GetReturnToTheLandData());
            allLevelLocations.Add("The Yellow Wood", GetTheYellowWoodData());
            allLevelLocations.Add("They Also Feed", GetTheyAlsoFeedData());
            allLevelLocations.Add("The Spirit Trees", GetTheSpiritTreesData());
            allLevelLocations.Add("Where Soft Rains Fell", GetWhereSoftRainsFellData());
            allLevelLocations.Add("Forest River", GetForestRiverData());
            allLevelLocations.Add("Lamenting to the Moon", GetLamentingToTheMoonData());
            allLevelLocations.Add("Running with the Wolves", GetRunningWithTheWolvesData());
            allLevelLocations.Add("You Are the Prey", GetYouAreThePreyData());
            allLevelLocations.Add("The Secret Path", GetTheSecretPathData());
            allLevelLocations.Add("Hewn from Nature", GetHewnFromNatureData());
            allLevelLocations.Add("The Wood Gate", GetTheWoodGateData());
            allLevelLocations.Add("The Wolves' Choice", GetTheWolvesChoiceData());
            allLevelLocations.Add("The Woodcutter's Run", GetTheWoodcuttersRunData());
            allLevelLocations.Add("The Hollow Hills", GetTheHollowHillsData());
            allLevelLocations.Add("Howl of the Wolf King", GetHowlOfTheWolfKingData());
            allLevelLocations.Add("The Silent Hedges", GetTheSilentHedgesData());
            allLevelLocations.Add("Steady the Boar-Spears", GetSteadyTheBoarSpearsData());
            allLevelLocations.Add("The Boar's Revenge", GetTheBoarsRevengeData());
            allLevelLocations.Add("Nature's Womb", GetNaturesWombData());
            allLevelLocations.Add("Prisoners' Niche", GetPrisonersNicheData());
            allLevelLocations.Add("Corridor of the Clerics", GetCorridorOfTheClericsData());
            allLevelLocations.Add("Priests' Confinement", GetPriestsConfinementData());
            allLevelLocations.Add("Alchemists' Laboratory", GetAlchemistsLaboratoryData());
            allLevelLocations.Add("The Academia Corridor", GetTheAcademiaCorridorData());
            allLevelLocations.Add("Theology Classroom", GetTheologyClassroomData());
            allLevelLocations.Add("Shrine of the Martyrs", GetShrineOfTheMartyrsData());
            allLevelLocations.Add("Hallowed Hope", GetHallowedHopeData());
            allLevelLocations.Add("Hall of Sacrilege", GetHallOfSacrilegeData());
            allLevelLocations.Add("Advent Ground (South)", GetAdventGroundSouthData());
            allLevelLocations.Add("Passage of the Refugees (South)", GetPassageOfTheRefugeesSouthData());
            allLevelLocations.Add("Passage of the Refugees (North)", GetPassageOfTheRefugeesNorthData());
            allLevelLocations.Add("Advent Ground (North)", GetAdventGroundNorthData());
            allLevelLocations.Add("The Cleansing Chantry", GetTheCleansingChantryData());
            allLevelLocations.Add("Stairway to the Light", GetStairwayToTheLightData());
            allLevelLocations.Add("Dark Abhors Light", GetDarkAbhorsLightData());
            allLevelLocations.Add("Dream of the Holy Land", GetDreamOfTheHolyLandData());
            allLevelLocations.Add("The Ore Road", GetTheOreRoadData());
            allLevelLocations.Add("The Air Stirs", GetTheAirStirsData());
            allLevelLocations.Add("Bonds of Friendship", GetBondsOfFriendshipData());
            allLevelLocations.Add("Atone for Eternity", GetAtoneForEternityData());
            allLevelLocations.Add("Stair to Sanctuary", GetStairToSanctuaryData());
            allLevelLocations.Add("The Fallen Hall", GetTheFallenHallData());
            allLevelLocations.Add("The Rotten Core", GetTheRottenCoreData());
            allLevelLocations.Add("The Dreamer's Climb", GetTheDreamersClimbData());
            allLevelLocations.Add("The Ore-Bearers", GetTheOreBearersData());
            allLevelLocations.Add("Screams of the Wounded", GetScreamsOfTheWoundedData());
            allLevelLocations.Add("Bacchus is Cheap", GetBacchusIsCheapData());
            allLevelLocations.Add("Sinner's Sustenence", GetSinnersSustenenceData());
            allLevelLocations.Add("The Timely Dew of Sleep", GetTheTimelyDewOfSleepData());
            allLevelLocations.Add("Companions in Arms", GetCompanionsInArmsData());
            allLevelLocations.Add("The Auction Block", GetTheAuctionBlockData());
            allLevelLocations.Add("Ascension", GetAscensionData());
            allLevelLocations.Add("Where the Serpent Hunts", GetWhereTheSerpentHuntsData());
            allLevelLocations.Add("Drowned in Fleeting Joy", GetDrownedInFleetingJoyData());
            allLevelLocations.Add("Ants Prepare for Winter", GetAntsPrepareForWinterData());
            allLevelLocations.Add("The Laborer's Bonfire", GetTheLaborersBonfireData());
            allLevelLocations.Add("Stone and Sulfurous Fire", GetStoneAndSulfurousFireData());
            allLevelLocations.Add("Torture Without End", GetTortureWithoutEndData());
            allLevelLocations.Add("Way Down", GetWayDownData());
            allLevelLocations.Add("Excavated Hollow", GetExcavatedHollowData());
            allLevelLocations.Add("Parting Regrets", GetPartingRegretsData());
            allLevelLocations.Add("Corridor of Tales", GetCorridorOfTalesData());
            allLevelLocations.Add("Dust Shall Eat the Days", GetDustShallEatTheDaysData());
            allLevelLocations.Add("Hall of the Wage-Paying", GetHallOfTheWagePayingData());
            allLevelLocations.Add("Tunnel of the Heartless", GetTunnelOfTheHeartlessData());
            allLevelLocations.Add("The Cage", GetTheCageData());
            allLevelLocations.Add("The Cauldron", GetTheCauldronData());
            allLevelLocations.Add("Wooden Horse", GetWoodenHorseData());
            allLevelLocations.Add("Starvation", GetStarvationData());
            allLevelLocations.Add("The Breast Ripper", GetTheBreastRipperData());
            allLevelLocations.Add("The Wheel", GetTheWheelData());
            allLevelLocations.Add("The Branks", GetTheBranksData());
            allLevelLocations.Add("The Pear", GetThePearData());
            allLevelLocations.Add("The Judas Cradle", GetTheJudasCradleData());
            allLevelLocations.Add("The Whirlygig", GetTheWhirlygigData());
            allLevelLocations.Add("Spanish Tickler", GetSpanishTicklerData());
            allLevelLocations.Add("Heretic's Fork", GetHereticsForkData());
            allLevelLocations.Add("The Chair of Spikes", GetTheChairOfSpikesData());
            allLevelLocations.Add("Blooding", GetBloodingData());
            allLevelLocations.Add("Bootikens", GetBootikensData());
            allLevelLocations.Add("Burial", GetBurialData());
            allLevelLocations.Add("Burning", GetBurningData());
            allLevelLocations.Add("Cleansing the Soul", GetCleansingTheSoulData());
            allLevelLocations.Add("The Ducking Stool", GetTheDuckingStoolData());
            allLevelLocations.Add("The Garotte", GetTheGarotteData());
            allLevelLocations.Add("Hanging", GetHangingData());
            allLevelLocations.Add("Impalement", GetImpalementData());
            allLevelLocations.Add("Knotting", GetKnottingData());
            allLevelLocations.Add("The Eunics' Lot", GetTheEunicsLotData());
            allLevelLocations.Add("Ordeal By Fire", GetOrdealByFireData());
            allLevelLocations.Add("The Oven at Neisse", GetTheOvenAtNeisseData());
            allLevelLocations.Add("Pressing", GetPressingData());
            allLevelLocations.Add("The Mind Burns", GetTheMindBurnsData());
            allLevelLocations.Add("The Rack", GetTheRackData());
            allLevelLocations.Add("The Saw", GetTheSawData());
            allLevelLocations.Add("The Cold's Bridle", GetTheColdsBridleData());
            allLevelLocations.Add("The Shin-Vice", GetTheShinViceData());
            allLevelLocations.Add("The Spider", GetTheSpiderData());
            allLevelLocations.Add("Lead Sprinkler", GetLeadSprinklerData());
            allLevelLocations.Add("Squassation", GetSquassationData());
            allLevelLocations.Add("The Strappado", GetTheStrappadoData());
            allLevelLocations.Add("Thumbscrews", GetThumbscrewsData());
            allLevelLocations.Add("Pendulum", GetPendulumData());
            allLevelLocations.Add("Dragging", GetDraggingData());
            allLevelLocations.Add("Strangulation", GetStrangulationData());
            allLevelLocations.Add("Tablillas", GetTablillasData());
            allLevelLocations.Add("Tongue Slicer", GetTongueSlicerData());
            allLevelLocations.Add("Ordeal by Water", GetOrdealByWaterData());
            allLevelLocations.Add("Brank", GetBrankData());
            allLevelLocations.Add("Tormentum Insomniae", GetTormentumInsomniaeData());
            allLevelLocations.Add("The Iron Maiden", GetTheIronMaidenData());
            allLevelLocations.Add("Judgement", GetJudgementData());
            allLevelLocations.Add("Saint Elmo's Belt", GetSaintElmosBeltData());
            allLevelLocations.Add("Dunking the Witch", GetDunkingTheWitchData());
            allLevelLocations.Add("Into Holy Battle", GetIntoHolyBattleData());
            allLevelLocations.Add("The Poisoned Chapel", GetThePoisonedChapelData());
            allLevelLocations.Add("Sin and Punishment", GetSinAndPunishmentData());
            allLevelLocations.Add("A Light in the Dark", GetALightInTheDarkData());
            allLevelLocations.Add("Monk's Leap", GetMonksLeapData());
            allLevelLocations.Add("Hieratic Recollections", GetHieraticRecollectionsData());
            allLevelLocations.Add("The Flayed Confessional", GetTheFlayedConfessionalData());
            allLevelLocations.Add("Cracked Pleasures", GetCrackedPleasuresData());
            allLevelLocations.Add("Where Darkness Spreads", GetWhereDarknessSpreadsData());
            allLevelLocations.Add("Struggle for the Soul", GetStruggleForTheSoulData());
            allLevelLocations.Add("Order and Chaos", GetOrderAndChaosData());
            allLevelLocations.Add("An Offering of Souls", GetAnOfferingOfSoulsData());
            allLevelLocations.Add("Truth and Lies", GetTruthAndLiesData());
            allLevelLocations.Add("Sanity and Madness", GetSanityAndMadnessData());
            allLevelLocations.Add("The Victor's Laurels", GetTheVictorsLaurelsData());
            allLevelLocations.Add("Free from Base Desires", GetFreeFromBaseDesiresData());
            allLevelLocations.Add("Abasement from Above", GetAbasementFromAboveData());
            allLevelLocations.Add("The Convent Room", GetTheConventRoomData());
            allLevelLocations.Add("The Hall of Broken Vows", GetTheHallOfBrokenVowsData());
            allLevelLocations.Add("Light and Dark Wage War", GetLightAndDarkWageWarData());
            allLevelLocations.Add("An Arrow into Darkness", GetAnArrowIntoDarknessData());
            allLevelLocations.Add("He Screams for Mercy", GetHeScreamsForMercyData());
            allLevelLocations.Add("The Acolyte's Weakness", GetTheAcolytesWeaknessData());
            allLevelLocations.Add("Maelstrom of Malice", GetMaelstromOfMaliceData());
            allLevelLocations.Add("The Melodics of Madness", GetTheMelodicsOfMadnessData());
            allLevelLocations.Add("What Ails You, Kills You", GetWhatAilsYouKillsYouData());
            allLevelLocations.Add("The Wine-Lecher's Fall", GetTheWineLechersFallData());
            allLevelLocations.Add("The Heretics' Story (Lower)", GetTheHereticsStoryLowerData());
            allLevelLocations.Add("The Heretics' Story (Upper)", GetTheHereticsStoryUpperData());
            allLevelLocations.Add("Despair of the Fallen", GetDespairOfTheFallenData());
            allLevelLocations.Add("Hopes of the Idealist", GetHopesOfTheIdealistData());
            allLevelLocations.Add("Where the Soul Rots", GetWhereTheSoulRotsData());
            allLevelLocations.Add("The Atrium", GetTheAtriumData());
            allLevelLocations.Add("Dome", GetDomeData());
            allLevelLocations.Add("Paling", GetPalingData());
            allLevelLocations.Add("Stair to the Sinners", GetStairToTheSinnersData());
            allLevelLocations.Add("Slaughter of the Innocent", GetSlaughterOfTheInnocentData());
            allLevelLocations.Add("The Oracle Sins No More", GetTheOracleSinsNoMoreData());
            allLevelLocations.Add("The Fallen Knight", GetTheFallenKnightData());
            allLevelLocations.Add("Awaiting Retribution", GetAwaitingRetributionData());
            allLevelLocations.Add("Shelter From the Quake", GetShelterFromTheQuakeData());
            allLevelLocations.Add("Buried Alive", GetBuriedAliveData());
            allLevelLocations.Add("Movement of Fear", GetMovementOfFearData());
            allLevelLocations.Add("Facing Your Illusions", GetFacingYourIllusionsData());
            allLevelLocations.Add("The Darkness Drinks", GetTheDarknessDrinksData());
            allLevelLocations.Add("Fear and Loathing", GetFearAndLoathingData());
            allLevelLocations.Add("Blood and The Beast", GetBloodAndTheBeastData());
            allLevelLocations.Add("Where Body and Soul Part", GetWhereBodyAndSoulPartData());
            allLevelLocations.Add("Students of Death", GetStudentsOfDeathData());
            allLevelLocations.Add("The Gabled Hall", GetTheGabledHallData());
            allLevelLocations.Add("Where the Master Fell", GetWhereTheMasterFellData());
            allLevelLocations.Add("In Wait of the Foe", GetInWaitOfTheFoeData());
            allLevelLocations.Add("Swords for the Land", GetSwordsForTheLandData());
            allLevelLocations.Add("The Weeping Boy", GetTheWeepingBoyData());
            allLevelLocations.Add("Where Weary Riders Rest", GetWhereWearyRidersRestData());
            allLevelLocations.Add("The Boy's Training Room", GetTheBoysTrainingRoomData());
            allLevelLocations.Add("From Squire to Knight", GetFromSquireToKnightData());
            allLevelLocations.Add("Traces of Invasion Past", GetTracesOfInvasionPastData());
            allLevelLocations.Add("Be for Battle Prepared", GetBeForBattlePreparedData());
            allLevelLocations.Add("Destruction and Rebirth", GetDestructionAndRebirthData());
            allLevelLocations.Add("From Boy to Hero", GetFromBoyToHeroData());
            allLevelLocations.Add("A Welcome Invasion", GetAWelcomeInvasionData());
            allLevelLocations.Add("Train and Grow Strong", GetTrainAndGrowStrongData());
            allLevelLocations.Add("The Squire's Gathering", GetTheSquiresGatheringData());
            allLevelLocations.Add("The Invaders are Found", GetTheInvadersAreFoundData());
            allLevelLocations.Add("The Dream Weavers", GetTheDreamWeaversData());
            allLevelLocations.Add("The Cornered Savage", GetTheCorneredSavageData());
            allLevelLocations.Add("Hall of Sworn Revenge", GetHallOfSwornRevengeData());
            allLevelLocations.Add("The Last Blessing", GetTheLastBlessingData());
            allLevelLocations.Add("The Weeping Corridor", GetTheWeepingCorridorData());
            allLevelLocations.Add("Persecution Hall", GetPersecutionHallData());
            allLevelLocations.Add("Rodent-Ridden Chamber", GetRodentRiddenChamberData());
            allLevelLocations.Add("Shrine to the Martyrs", GetShrineToTheMartyrsData());
            allLevelLocations.Add("The Lamenting Mother (West)", GetTheLamentingMotherWestData());
            allLevelLocations.Add("The Lamenting Mother (East)", GetTheLamentingMotherEastData());
            allLevelLocations.Add("Hall of Dying Hope", GetHallOfDyingHopeData());
            allLevelLocations.Add("Bandits' Hideout", GetBanditsHideoutData());
            allLevelLocations.Add("The Bloody Hallway", GetTheBloodyHallwayData());
            allLevelLocations.Add("Faith Overcame Fear", GetFaithOvercameFearData());
            allLevelLocations.Add("The Withered Spring", GetTheWitheredSpringData());
            allLevelLocations.Add("Workshop 'Work of Art'", GetWorkshopWorkOfArtData());
            allLevelLocations.Add("Repent, O ye Sinners", GetRepentOYeSinnersData());
            allLevelLocations.Add("The Reaper's Victims", GetTheReapersVictimsData());
            allLevelLocations.Add("The Last Stab of Hope", GetTheLastStabOfHopeData());
            allLevelLocations.Add("Hallway of Heroes", GetHallwayOfHeroesData());
            allLevelLocations.Add("The Beast's Domain", GetTheBeastsDomainData());
            allLevelLocations.Add("Dreamers' Entrance", GetDreamersEntranceData());
            allLevelLocations.Add("The Crossing", GetTheCrossingData());
            allLevelLocations.Add("Miners' Resting Hall", GetMinersRestingHallData());
            allLevelLocations.Add("Conflict and Accord", GetConflictAndAccordData());
            allLevelLocations.Add("The End of the Line", GetTheEndOfTheLineData());
            allLevelLocations.Add("The Earthquake's Mark", GetTheEarthquakesMarkData());
            allLevelLocations.Add("Coal Mine Storage", GetCoalMineStorageData());
            allLevelLocations.Add("The Suicide King", GetTheSuicideKingData());
            allLevelLocations.Add("The Battle's Beginning", GetTheBattlesBeginningData());
            allLevelLocations.Add("What Lies Ahead?", GetWhatLiesAheadData());
            allLevelLocations.Add("The Fruits of Friendship", GetTheFruitsOfFriendshipData());
            allLevelLocations.Add("The Passion of Lovers", GetThePassionOfLoversData());
            allLevelLocations.Add("The Hall of Hope", GetTheHallOfHopeData());
            allLevelLocations.Add("The Dark Tunnel", GetTheDarkTunnelData());
            allLevelLocations.Add("Everwant Passage", GetEverwantPassageData());
            allLevelLocations.Add("Mining Regrets", GetMiningRegretsData());
            allLevelLocations.Add("Rust in Peace", GetRustInPeaceData());
            allLevelLocations.Add("The Smeltry", GetTheSmeltryData());
            allLevelLocations.Add("Clash of Hyaenas", GetClashOfHyaenasData());
            allLevelLocations.Add("Greed Knows No Bounds", GetGreedKnowsNoBoundsData());
            allLevelLocations.Add("Live Long and Prosper", GetLiveLongAndProsperData());
            allLevelLocations.Add("Pray to the Mineral Gods", GetPrayToTheMineralGodsData());
            allLevelLocations.Add("Traitor's Parting", GetTraitorsPartingData());
            allLevelLocations.Add("Escapeway", GetEscapewayData());
            allLevelLocations.Add("Subtellurian Horrors", GetSubtellurianHorrorsData());
            allLevelLocations.Add("Dining in Darkness", GetDiningInDarknessData());
            allLevelLocations.Add("Bandit's Hollow", GetBanditsHollowData());
            allLevelLocations.Add("Delusions of Happiness", GetDelusionsOfHappinessData());
            allLevelLocations.Add("Work, Then Die", GetWorkThenDieData());
            allLevelLocations.Add("Rock Bottom", GetRockBottomData());
            allLevelLocations.Add("Senses Lost", GetSensesLostData());
            allLevelLocations.Add("The Lunatic Veins", GetTheLunaticVeinsData());
            allLevelLocations.Add("Tomb of the Reborn", GetTombOfTheRebornData());
            allLevelLocations.Add("Fool's Gold, Fool's Loss", GetFoolsGoldFoolsLossData());
            allLevelLocations.Add("Kilroy Was Here", GetKilroyWasHereData());
            allLevelLocations.Add("A Wager of Noble Gold", GetAWagerOfNobleGoldData());
            allLevelLocations.Add("Lambs to the Slaughter", GetLambsToTheSlaughterData());
            allLevelLocations.Add("The Ore of Legend", GetTheOreOfLegendData());
            allLevelLocations.Add("Suicidal Desires", GetSuicidalDesiresData());
            allLevelLocations.Add("Cry of the Beast", GetCryOfTheBeastData());
            allLevelLocations.Add("The Fallen Bricklayer", GetTheFallenBricklayerData());
            allLevelLocations.Add("Hall of Contemplation", GetHallOfContemplationData());
            allLevelLocations.Add("Hall of the Empty Sconce", GetHallOfTheEmptySconceData());
            allLevelLocations.Add("Acolyte's Burial Vault", GetAcolytesBurialVaultData());
            allLevelLocations.Add("The Abandoned Catspaw", GetTheAbandonedCatspawData());
            allLevelLocations.Add("Crossing of Blood", GetCrossingOfBloodData());
            allLevelLocations.Add("Desire's Passage", GetDesiresPassageData());
            allLevelLocations.Add("Way of Lost Children", GetWayOfLostChildrenData());
            allLevelLocations.Add("Hidden Resources", GetHiddenResourcesData());
            allLevelLocations.Add("Treaty Room", GetTreatyRoomData());
            allLevelLocations.Add("The Miner's End", GetTheMinersEndData());
            allLevelLocations.Add("Gambler's Passage", GetGamblersPassageData());
            allLevelLocations.Add("Revelation Shaft", GetRevelationShaftData());
            allLevelLocations.Add("Corridor of Shade", GetCorridorOfShadeData());
            allLevelLocations.Add("Credits", GetCreditsData());

            var regional_index = 0;

            foreach (var region_name in table_order.ToList())
            {

                long currentRegionBaseId = base_id + regional_index * region_offset;

                if (allLevelLocations.ContainsKey(region_name))
                {
                    // Retrieve the list of locations for the current region
                    List<GenericLocationData> regionLocations = allLevelLocations[region_name];

                    var location_index = 0;

                    foreach (var loc in regionLocations)

                    {
                        int locationId = (int)currentRegionBaseId + location_index;

                        locations.Add(new Location()
                        {
                            Id = locationId,
                            Name = loc.Name,
                            Address = loc.Address,
                            CheckType = loc.CheckType,
                            CompareType = LocationCheckCompareType.Match,
                            CheckValue = loc.Check

                        });

                        location_index++;
                    }
                }
            }
#if DEBUG
            foreach (var loc in locations)
            {
                Console.WriteLine($"{loc.Name}, {loc.Id}");
            }
#endif
            return locations;
        }

        private static List<GenericLocationData> GetAshleyData()
        {
            List<GenericLocationData> ashleyLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("Ability: Heavy Shot", Addresses.AbilityHeavyShotUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Gain Life", Addresses.AbilityGainLifeUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Mind Assault", Addresses.AbilityMindAssaultUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Gain Magic", Addresses.AbilityGainMagicUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Raging Ache", Addresses.AbilityRagingAcheUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Mind Ache", Addresses.AbilityMindAcheUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Temper", Addresses.AbilityTemperUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Crimson Pain", Addresses.AbilityCrimsonPainUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Instill", Addresses.AbilityInstillUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Phantom Pain", Addresses.AbilityPhantomPainUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Paralysis Pulse", Addresses.AbilityParalysisPulseUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Numbing Claw", Addresses.AbilityNumbingClawUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Dulling Impact", Addresses.AbilityDullingImpactUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Snake Venom", Addresses.AbilitySnakeVenomUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Ability: Ward", Addresses.AbilityWardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Siphon Soul", Addresses .AbilitySiphonSoulUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Reflect Magic", Addresses.AbilityReflectMagicUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Reflect Damage", Addresses.AbilityReflectDamageUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Absorb Magic", Addresses.AbilityAbsorbMagicUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Absorb Damage", Addresses.AbilityAbsorbDamageUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Impact Guard", Addresses.AbilityImpactGuardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Wind Break", Addresses.AbilityWindBreakUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Fire Proof", Addresses.AbilityFireProofUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Terra Ward", Addresses.AbilityTerraWardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Aqua Ward", Addresses.AbilityAquaWardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Shadow Guard", Addresses.AbilityShadowGuardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Demonscale", Addresses.AbilityDemonscaleUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Ability: Phantom Shield", Addresses.AbilityPhantomShieldUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Degenerate", Addresses.GrimoireDegenerateUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Psychodrain", Addresses.GrimoirePsychodrainUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Leadbones", Addresses.GrimoireLeadbonesUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Tarnish", Addresses.GrimoireTarnishUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Analyze", Addresses.GrimoireAnalyzeUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Herakles", Addresses.GrimoireHeraklesUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Enlighten", Addresses.GrimoireEnlightenUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Invigorate", Addresses.GrimoireInvigorateUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Prostasia", Addresses.GrimoireProstasiaUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Luft Fusion", Addresses.GrimoireLuftFusionUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Spark Fusion", Addresses.GrimoireSparkFusionUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Soil Fusion", Addresses.GrimoireSoilFusionUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Frost Fusion", Addresses.GrimoireFrostFusionUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Aero Guard", Addresses.GrimoireAeroGuardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Pyro Guard", Addresses.GrimoirePyroGuardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Terra Guard", Addresses.GrimoireTerraGuardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Silence", Addresses.GrimoireSilenceUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Magic Ward", Addresses.GrimoireMagicWardUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Surging Balm", Addresses.GrimoireSurgingBalmUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Fixate", Addresses.GrimoireFixateUnlock, "0", "176", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Dispel", Addresses.GrimoireDispelUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Stun Cloud", Addresses.GrimoireStunCloudUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Poison Mist", Addresses.GrimoirePoisonMistUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Curse", Addresses.GrimoireCurseUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Restoration", Addresses.GrimoireRestorationUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Antidote", Addresses.GrimoireAntidoteUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Blessing", Addresses.GrimoireBlessingUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Clearance", Addresses.GrimoireClearanceUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Unlock", Addresses.GrimoireUnlockUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Eureka", Addresses.GrimoireEurekaUnlock, "0", "176", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Drain Heart", Addresses.GrimoireDrainHeartUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Drain Mind", Addresses.GrimoireDrainMindUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Heal", Addresses.GrimoireHealUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Solid Shock", Addresses.GrimoireSolidShockUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Lightning Bolt", Addresses.GrimoireLightningBoltUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Fireball", Addresses.GrimoireFireballUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Vulcan Lance", Addresses.GrimoireVulcanLanceUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Aqua Blast", Addresses.GrimoireAquaBlastUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Spirit Surge", Addresses.GrimoireSpiritSurgeUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Dark Chant", Addresses.GrimoireDarkChantUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Exorcism", Addresses.GrimoireExorcismUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Banish", Addresses.GrimoireBanishUnlock, "0", "144", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Explosion Max Level", Addresses.GrimoireExplosionMaxLevel, "0", "704", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Thunderburst Max Level", Addresses.GrimoireThunderburstMaxLevel, "0", "704", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Flame Sphere Max Level", Addresses.GrimoireFlameSphereMaxLevel, "0", "704", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Gaea Strike Max Level", Addresses.GrimoireGaeaStrikeMaxLevel, "0", "704", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Avalanche Max Level", Addresses.GrimoireAvalancheMaxLevel, "0", "704", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Radial Surge Max Level", Addresses.GrimoireRadialSurgeMaxLevel, "0", "704", LocationCheckType.Byte),
                new GenericLocationData("Grimoire: Meteor Max Level", Addresses.GrimoireMeteorMaxLevel, "0", "704", LocationCheckType.Byte),
                new GenericLocationData("Break: Whistle Sting", Addresses.BreakWhistleStingUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Shadoweave", Addresses.BreakShadoweaveUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Double Fang", Addresses.BreakDoubleFangUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Wyrm Scorn", Addresses.BreakWyrmScornUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("Break: Rending Gale", Addresses.BreakRendingGaleUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Vile Scar", Addresses.BreakVileScarUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Cherry Ronde", Addresses.BreakCherryRondeUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Papillon Reel", Addresses.BreakPapillonReelUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("Break: Sunder", Addresses.BreakSunderUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Thunderwave", Addresses.BreakThunderwaveUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Swallow Slash", Addresses.BreakSwallowSlashUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Advent Sign", Addresses.BreakAdventSignUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("Break: Mistral Edge", Addresses.BreakMistralEdgeUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Glacial Gale", Addresses.BreakGlacialGaleUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Killer Mantis", Addresses.BreakKillerMantisUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Black Nebula", Addresses.BreakBlackNebulaUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("Break: Bear Claw", Addresses.BreakBearClawUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Accursed Umbra", Addresses.BreakAccursedUmbraUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Iron Ripper", Addresses.BreakIronRipperUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Emetic Bomb", Addresses.BreakEmeticBombUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("Break: Sirocco", Addresses.BreakSiroccoUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Riskbreak", Addresses.BreakRiskbreakUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Gravis Aether", Addresses.BreakGravisAetherUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Trinity Pulse", Addresses.BreakTrinityPulseUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("Break: Bonecrusher", Addresses.BreakBonecrusherUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Quickshock", Addresses.BreakQuickshockUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Ignis Wheel", Addresses.BreakIgnisWheelUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Hex Flux", Addresses.BreakHexFluxUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("Break: Ruination Polearm", Addresses.BreakRuinationPolearmUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Scythe Wind", Addresses.BreakScytheWindUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Giga Tempest", Addresses.BreakGigaTempestUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Spiral Scourge", Addresses.BreakSpiralScourgeUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("Break: Brimstone Hail", Addresses.BreakBrimstoneHailUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Heaven's Scorn", Addresses.BreakHeavensScornUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Death Wail", Addresses.BreakDeathWailUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Sanctus Flare", Addresses.BreakSanctusFlareUnlock, "0", "224", LocationCheckType.Byte),
                new GenericLocationData("Break: Lotus Palm", Addresses.BreakLotusPalmUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Vertigo", Addresses.BreakVertigoUnlock, "0", "192", LocationCheckType.Byte),
                new GenericLocationData("Break: Vermillion Aura", Addresses.BreakVermillionAuraUnlock, "0", "128", LocationCheckType.Byte),
                new GenericLocationData("Break: Retribution", Addresses.BreakRetributionUnlock, "0", "160", LocationCheckType.Byte)
            };

            return ashleyLocations;
        }



        private static List<GenericLocationData> GetPrologueData()
        {
            List<GenericLocationData> prologueLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("PR - Prologue - Injured Wyvern Boss", Addresses.PR_PrologueInjuredWyvernBossDefeat, "0", "160", LocationCheckType.Byte)
    };
            return prologueLocations;
        }

        private static List<GenericLocationData> GetEntranceToDarknessData()
        {
            List<GenericLocationData> entranceToDarknessLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Entrance to Darkness Entered", Addresses.WC_EntranceToDarknessEntered, "0", "160", LocationCheckType.Byte)
    };
            return entranceToDarknessLocations;
        }

        private static List<GenericLocationData> GetWorkersBreakroomData()
        {
            List<GenericLocationData> workersBreakroomLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Worker's Breakroom - Chest", Addresses.WC_WorkersBreakroomChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Worker's Breakroom Entered", Addresses.WC_WorkersBreakroomEntered, "0", "160", LocationCheckType.Byte)
    };
            return workersBreakroomLocations;
        }

        private static List<GenericLocationData> GetHallOfStruggleData()
        {
            List<GenericLocationData> hallOfStruggleLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Hall of Struggle Entered", Addresses.WC_HallOfStruggleEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallOfStruggleLocations;
        }

        private static List<GenericLocationData> GetSmokebarrelStairData()
        {
            List<GenericLocationData> smokebarrelStairLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Smokebarrel Stair - Heal Panel Floor Trap", Addresses.WC_SmokebarrelStairHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Smokebarrel Stair - Chamomile Sigil Unlock", Addresses.WC_SmokebarrelStairChamomileSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Smokebarrel Stair Entered", Addresses.WC_SmokebarrelStairEntered, "0", "160", LocationCheckType.Byte)
    };
            return smokebarrelStairLocations;
        }

        private static List<GenericLocationData> GetWineGuildHallData()
        {
            List<GenericLocationData> wineGuildHallLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Wine Guild Hall Entered", Addresses.WC_WineGuildHallEntered, "0", "160", LocationCheckType.Byte)
    };
            return wineGuildHallLocations;
        }

        private static List<GenericLocationData> GetWineMagnatesChambersData()
        {
            List<GenericLocationData> wineMagnatesChambersLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Wine Magnate's Chambers - Gust Floor Trap", Addresses.WC_WineMagnatesChambersGustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Wine Magnate's Chambers Entered", Addresses.WC_WineMagnatesChambersEntered, "0", "160", LocationCheckType.Byte)
    };
            return wineMagnatesChambersLocations;
        }

        private static List<GenericLocationData> GetFineVintageVaultData()
        {
            List<GenericLocationData> fineVintageVaultLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Fine Vintage Vault Entered", Addresses.WC_FineVintageVaultEntered, "0", "160", LocationCheckType.Byte)
    };
            return fineVintageVaultLocations;
        }

        private static List<GenericLocationData> GetChamberOfFearData()
        {
            List<GenericLocationData> chamberOfFearLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Chamber of Fear Entered", Addresses.WC_ChamberOfFearEntered, "0", "160", LocationCheckType.Byte)
    };
            return chamberOfFearLocations;
        }

        private static List<GenericLocationData> GetTheReckoningRoomData()
        {
            List<GenericLocationData> theReckoningRoomLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - The Reckoning Room - Chest", Addresses.WC_TheReckoningRoomChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - The Reckoning Room", Addresses.WC_TheReckoningRoom, "0", "160", LocationCheckType.Byte)
    };
            return theReckoningRoomLocations;
        }

        private static List<GenericLocationData> GetALaborersThirstData()
        {
            List<GenericLocationData> aLaborersThirstLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - A Laborer's Thirst Entered", Addresses.WC_ALaborersThirstEntered, "0", "160", LocationCheckType.Byte)
    };
            return aLaborersThirstLocations;
        }

        private static List<GenericLocationData> GetTheRichDrownInWineData()
        {
            List<GenericLocationData> theRichDrownInWineLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - The Rich Drown in Wine Entered", Addresses.WC_TheRichDrownInWineEntered, "0", "160", LocationCheckType.Byte)
    };
            return theRichDrownInWineLocations;
        }

        private static List<GenericLocationData> GetRoomOfRottenGrapesData()
        {
            List<GenericLocationData> roomOfRottenGrapesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Room of Rotten Grapes - Heal Panel Floor Trap", Addresses.WC_RoomOfRottenGrapesHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Room of Rotten Grapes - Curse Panel Floor Trap", Addresses.WC_RoomOfRottenGrapesCursePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Room of Rotten Grapes Entered", Addresses.WC_RoomOfRottenGrapesEntered, "0", "160", LocationCheckType.Byte)
    };
            return roomOfRottenGrapesLocations;
        }

        private static List<GenericLocationData> GetBlackmarketOfWinesData()
        {
            List<GenericLocationData> blackmarketOfWinesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Blackmarket of Wines - Chest", Addresses.WC_BlackmarketOfWinesChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Blackmarket of Wines - Stock Sigil Unlock", Addresses.WC_BlackmarketOfWinesStockSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Blackmarket of Wines Entered", Addresses.WC_BlackmarketOfWinesEntered, "0", "160", LocationCheckType.Byte)
    };
            return blackmarketOfWinesLocations;
        }

        private static List<GenericLocationData> GetTheGallowsData()
        {
            List<GenericLocationData> theGallowsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - The Gallows - Minotaur Boss", Addresses.WC_TheGallowsMinotaurBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - The Gallows (Again) - Minotaur Zombie Boss", Addresses.WC_TheGallowsAgainMinotaurZombieBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - The Gallows (Again) - Chest", Addresses.WC_TheGallowsAgainChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - The Gallows - Chest", Addresses.WC_TheGallowsChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - The Gallows Entered", Addresses.WC_TheGallowsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theGallowsLocations;
        }

        private static List<GenericLocationData> GetRoomOfCheapRedWineData()
        {
            List<GenericLocationData> roomOfCheapRedWineLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Room of Cheap Red Wine - Mandel Boss", Addresses.WC_RoomOfCheapRedWineMandelBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Room of Cheap Red Wine - Heal Panel Floor Trap", Addresses.WC_RoomOfCheapRedWineHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Room of Cheap Red Wine Entered", Addresses.WC_RoomOfCheapRedWineEntered, "0", "160", LocationCheckType.Byte)
    };
            return roomOfCheapRedWineLocations;
        }

        private static List<GenericLocationData> GetRoomOfCheapWhiteWineData()
        {
            List<GenericLocationData> roomOfCheapWhiteWineLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - Room of Cheap White Wine - Zombie Fighter Boss", Addresses.WC_RoomOfCheapWhiteWineZombieFighterBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Room of Cheap White Wine - Zombie Boss", Addresses.WC_RoomOfCheapWhiteWineZombieBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Room of Cheap White Wine - Ghoul Boss", Addresses.WC_RoomOfCheapWhiteWineGhoulBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - Room of Cheap White Wine Entered", Addresses.WC_RoomOfCheapWhiteWineEntered, "0", "160", LocationCheckType.Byte)
    };
            return roomOfCheapWhiteWineLocations;
        }

        private static List<GenericLocationData> GetTheGreedyOnesDenData()
        {
            List<GenericLocationData> theGreedyOnesDenLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - The Greedy One's Den Entered", Addresses.WC_TheGreedyOnesDenEntered, "0", "160", LocationCheckType.Byte)
    };
            return theGreedyOnesDenLocations;
        }

        private static List<GenericLocationData> GetTheHerosWinehallData()
        {
            List<GenericLocationData> theHerosWinehallLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("WC - The Hero's Winehall - Dullahan Boss", Addresses.WC_TheHerosWinehallDullahanBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - The Hero's Winehall - Chest", Addresses.WC_TheHerosWinehallChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("WC - The Hero's Winehall Entered", Addresses.WC_TheHerosWinehallEntered, "0", "160", LocationCheckType.Byte)
    };
            return theHerosWinehallLocations;
        }

        private static List<GenericLocationData> GetTheBreadPeddlersWayData()
        {
            List<GenericLocationData> theBreadPeddlersWayLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - The Bread Peddler's Way Entered", Addresses.UW_TheBreadPeddlersWayEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBreadPeddlersWayLocations;
        }

        private static List<GenericLocationData> GetWayOfTheMotherLodeData()
        {
            List<GenericLocationData> wayOfTheMotherLodeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Way of the Mother Lode Entered", Addresses.UW_WayOfTheMotherLodeEntered, "0", "160", LocationCheckType.Byte)
    };
            return wayOfTheMotherLodeLocations;
        }

        private static List<GenericLocationData> GetSewerOfRavenousRatsData()
        {
            List<GenericLocationData> sewerOfRavenousRatsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Sewer of Ravenous Rats - Silver Key Unlock", Addresses.UW_SewerOfRavenousRatsSilverKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Sewer of Ravenous Rats Entered", Addresses.UW_SewerOfRavenousRatsEntered, "0", "160", LocationCheckType.Byte)
    };
            return sewerOfRavenousRatsLocations;
        }

        private static List<GenericLocationData> GetUnderdarkFishmarketData()
        {
            List<GenericLocationData> underdarkFishmarketLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Underdark Fishmarket - Giant Crab Boss", Addresses.UW_UnderdarkFishmarketGiantCrabBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Underdark Fishmarket Entered", Addresses.UW_UnderdarkFishmarketEntered, "0", "160", LocationCheckType.Byte)
    };
            return underdarkFishmarketLocations;
        }

        private static List<GenericLocationData> GetTheSunlessWayData()
        {
            List<GenericLocationData> theSunlessWayLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - The Sunless Way - Iron Key Unlock", Addresses.UW_TheSunlessWayIronKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Sunless Way Entered", Addresses.UW_TheSunlessWayEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSunlessWayLocations;
        }
        private static List<GenericLocationData> GetRememberingDaysOfYoreData()
        {
            List<GenericLocationData> rememberingDaysOfYoreLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Remembering Days of Yore - Iron Key Unlock", Addresses.UW_RememberingDaysOfYoreIronKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Remembering Days of Yore Entered", Addresses.UW_RememberingDaysOfYoreEntered, "0", "160", LocationCheckType.Byte)
    };
            return rememberingDaysOfYoreLocations;
        }

        private static List<GenericLocationData> GetLarderForALeanWinterData()
        {
            List<GenericLocationData> larderForALeanWinterLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Larder for a Lean Winter - Chest", Addresses.UW_LarderForALeanWinterChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Larder for a Lean Winter Entered", Addresses.UW_LarderForALeanWinterEntered, "0", "160", LocationCheckType.Byte)
    };
            return larderForALeanWinterLocations;
        }

        private static List<GenericLocationData> GetWhereTheHunterClimbedData()
        {
            List<GenericLocationData> whereTheHunterClimbedLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Where the Hunter Climbed Entered", Addresses.UW_WhereTheHunterClimbedEntered, "0", "160", LocationCheckType.Byte)
    };
            return whereTheHunterClimbedLocations;
        }

        private static List<GenericLocationData> GetHallOfPovertyData()
        {
            List<GenericLocationData> hallOfPovertyLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Hall of Poverty Entered", Addresses.UW_HallOfPovertyEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallOfPovertyLocations;
        }

        private static List<GenericLocationData> GetTheWashingWomansWayData()
        {
            List<GenericLocationData> theWashingWomansWayLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - The Washing-Woman's Way - Silver Key Unlock", Addresses.UW_TheWashingWomansWaySilverKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Washing-Woman's Way - Heal Panel Floor Trap", Addresses.UW_TheWashingWomansWayHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Washing-Woman's Way - Cure Panel Floor Trap", Addresses.UW_TheWashingWomansWayCurePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Washing-Woman's Way Entered", Addresses.UW_TheWashingWomansWayEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWashingWomansWayLocations;
        }

        private static List<GenericLocationData> GetNamelessDarkOblivionData()
        {
            List<GenericLocationData> namelessDarkOblivionLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Nameless Dark Oblivion - Silver Key Unlock", Addresses.UW_NamelessDarkOblivionSilverKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Nameless Dark Oblivion Entered", Addresses.UW_NamelessDarkOblivionEntered, "0", "160", LocationCheckType.Byte)
    };
            return namelessDarkOblivionLocations;
        }

        private static List<GenericLocationData> GetSinnersCornerData()
        {
            List<GenericLocationData> sinnersCornerLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Sinner's Corner Entered", Addresses.UW_SinnersCornerEntered, "0", "160", LocationCheckType.Byte)
    };
            return sinnersCornerLocations;
        }

        private static List<GenericLocationData> GetFearOfTheFallData()
        {
            List<GenericLocationData> fearOfTheFallLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Fear of the Fall - Dark Elemental Boss", Addresses.UW_FearOfTheFallDarkElementalBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Fear of the Fall Entered", Addresses.UW_FearOfTheFallEntered, "0", "160", LocationCheckType.Byte)
    };
            return fearOfTheFallLocations;
        }

        private static List<GenericLocationData> GetTheChildrensHideoutData()
        {
            List<GenericLocationData> theChildrensHideoutLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - The Children's Hideout - Chest", Addresses.UW_TheChildrensHideoutChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Children's Hideout Entered", Addresses.UW_TheChildrensHideoutEntered, "0", "160", LocationCheckType.Byte)
    };
            return theChildrensHideoutLocations;
        }

        private static List<GenericLocationData> GetCornerOfPrayersData()
        {
            List<GenericLocationData> cornerOfPrayersLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Corner of Prayers - Gold Key Unlock", Addresses.UW_CornerOfPrayersGoldKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Corner of Prayers Entered", Addresses.UW_CornerOfPrayersEntered, "0", "160", LocationCheckType.Byte)
    };
            return cornerOfPrayersLocations;
        }

        private static List<GenericLocationData> GetHopeObstructedData()
        {
            List<GenericLocationData> hopeObstructedLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Hope Obstructed Entered", Addresses.UW_HopeObstructedEntered, "0", "160", LocationCheckType.Byte)
    };
            return hopeObstructedLocations;
        }

        private static List<GenericLocationData> GetBeggarsOfTheMouthharpData()
        {
            List<GenericLocationData> beggarsOfTheMouthharpLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Beggars of the Mouthharp - Silver Key Unlock", Addresses.UW_BeggarsOfTheMouthharpSilverKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Beggars of the Mouthharp Entered", Addresses.UW_BeggarsOfTheMouthharpEntered, "0", "160", LocationCheckType.Byte)
    };
            return beggarsOfTheMouthharpLocations;
        }

        private static List<GenericLocationData> GetCornerOfTheWretchedData()
        {
            List<GenericLocationData> cornerOfTheWretchedLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Corner of the Wretched Entered", Addresses.UW_CornerOfTheWretchedEntered, "0", "160", LocationCheckType.Byte)
    };
            return cornerOfTheWretchedLocations;
        }

        private static List<GenericLocationData> GetCrossroadsOfRestData()
        {
            List<GenericLocationData> crossroadsOfRestLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Crossroads of Rest - Gust Floor Trap", Addresses.UW_CrossroadsOfRestGustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Crossroads of Rest Entered", Addresses.UW_CrossroadsOfRestEntered, "0", "160", LocationCheckType.Byte)
    };
            return crossroadsOfRestLocations;
        }

        private static List<GenericLocationData> GetPathToTheGreengrocerData()
        {
            List<GenericLocationData> pathToTheGreengrocerLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Path to the Greengrocer Entered", Addresses.UW_PathToTheGreengrocerEntered, "0", "160", LocationCheckType.Byte)
    };
            return pathToTheGreengrocerLocations;
        }

        private static List<GenericLocationData> GetPathOfTheChildrenData()
        {
            List<GenericLocationData> pathOfTheChildrenLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Path of the Children Entered", Addresses.UW_PathOfTheChildrenEntered, "0", "160", LocationCheckType.Byte)
    };
            return pathOfTheChildrenLocations;
        }

        private static List<GenericLocationData> GetSalvationForTheMotherData()
        {
            List<GenericLocationData> salvationForTheMotherLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Salvation for the Mother - Gold Key Unlock", Addresses.UW_SalvationForTheMotherGoldKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Salvation for the Mother - Diabolos Floor Trap", Addresses.UW_SalvationForTheMotherDiabolosFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Salvation for the Mother - Poison Panel Floor Trap", Addresses.UW_SalvationForTheMotherPoisonPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - Salvation for the Mother Entered", Addresses.UW_SalvationForTheMotherEntered, "0", "160", LocationCheckType.Byte)
    };
            return salvationForTheMotherLocations;
        }
        private static List<GenericLocationData> GetTheBodyFragileYieldsData()
        {
            List<GenericLocationData> theBodyFragileYieldsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - The Body Fragile Yields - Gold Key Unlock", Addresses.UW_TheBodyFragileYieldsGoldKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Body Fragile Yields Entered", Addresses.UW_TheBodyFragileYieldsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBodyFragileYieldsLocations;
        }

        private static List<GenericLocationData> GetBiteTheMastersWoundsData()
        {
            List<GenericLocationData> biteTheMastersWoundsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Bite the Master's Wounds Entered", Addresses.UW_BiteTheMastersWoundsEntered, "0", "160", LocationCheckType.Byte)
    };
            return biteTheMastersWoundsLocations;
        }

        private static List<GenericLocationData> GetWorkshopGodhandsData()
        {
            List<GenericLocationData> workshopGodhandsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Workshop 'Godhands' Entered", Addresses.UW_WorkshopGodhandsEntered, "0", "160", LocationCheckType.Byte)
    };
            return workshopGodhandsLocations;
        }

        private static List<GenericLocationData> GetTheCrumblingMarketSouthData()
        {
            List<GenericLocationData> theCrumblingMarketSouthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - The Crumbling Market (South) Entered", Addresses.UW_TheCrumblingMarketSouthEntered, "0", "160", LocationCheckType.Byte)
    };
            return theCrumblingMarketSouthLocations;
        }

        private static List<GenericLocationData> GetTheCrumblingMarketNorthData()
        {
            List<GenericLocationData> theCrumblingMarketNorthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - The Crumbling Market (North) - Chest", Addresses.UW_TheCrumblingMarketNorthChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Crumbling Market (North) - Eruption Floor Trap", Addresses.UW_TheCrumblingMarketNorthEruptionFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Crumbling Market (North) - Freeze Floor Trap", Addresses.UW_TheCrumblingMarketNorthFreezeFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Crumbling Market (North) - Gust Floor Trap", Addresses.UW_TheCrumblingMarketNorthGustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Crumbling Market (North) - Terra Thrust Floor Trap", Addresses.UW_TheCrumblingMarketNorthTerraThrustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Crumbling Market (North) - Holy Light Floor Trap", Addresses.UW_TheCrumblingMarketNorthHolyLightFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UW - The Crumbling Market (North) Entered", Addresses.UW_TheCrumblingMarketNorthEntered, "0", "160", LocationCheckType.Byte)
    };
            return theCrumblingMarketNorthLocations;
        }

        private static List<GenericLocationData> GetWhereFloodWatersRanData()
        {
            List<GenericLocationData> whereFloodWatersRanLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Where Flood Waters Ran Entered", Addresses.UW_WhereFloodWatersRanEntered, "0", "160", LocationCheckType.Byte)
    };
            return whereFloodWatersRanLocations;
        }

        private static List<GenericLocationData> GetTearsFromEmptySocketsData()
        {
            List<GenericLocationData> tearsFromEmptySocketsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UW - Tears from Empty Sockets Entered", Addresses.UW_TearsFromEmptySocketsEntered, "0", "160", LocationCheckType.Byte)
    };
            return tearsFromEmptySocketsLocations;
        }

        private static List<GenericLocationData> GetHallToANewWorldData()
        {
            List<GenericLocationData> hallToANewWorldLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - Hall to a New World Entered", Addresses.UE_HallToANewWorldEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallToANewWorldLocations;
        }

        private static List<GenericLocationData> GetPlaceOfFreeWordsData()
        {
            List<GenericLocationData> placeOfFreeWordsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - Place of Free Words - Harpy Boss", Addresses.UE_PlaceOfFreeWordsHarpyBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UE - Place of Free Words Entered", Addresses.UE_PlaceOfFreeWordsEntered, "0", "160", LocationCheckType.Byte)
    };
            return placeOfFreeWordsLocations;
        }

        private static List<GenericLocationData> GetBazaarOfTheBizarreData()
        {
            List<GenericLocationData> bazaarOfTheBizarreLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - Bazaar of the Bizarre - Lich Boss", Addresses.UE_BazaarOfTheBizarreLichBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UE - Bazaar of the Bizarre Entered", Addresses.UE_BazaarOfTheBizarreEntered, "0", "160", LocationCheckType.Byte)
    };
            return bazaarOfTheBizarreLocations;
        }

        private static List<GenericLocationData> GetNobleGoldAndSilkData()
        {
            List<GenericLocationData> nobleGoldAndSilkLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - Noble Gold and Silk - Iron Key Unlock", Addresses.UE_NobleGoldAndSilkIronKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UE - Noble Gold and Silk Entered", Addresses.UE_NobleGoldAndSilkEntered, "0", "160", LocationCheckType.Byte)
    };
            return nobleGoldAndSilkLocations;
        }

        private static List<GenericLocationData> GetWeaponsNotAllowedData()
        {
            List<GenericLocationData> weaponsNotAllowedLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - Weapons Not Allowed - Chest", Addresses.UE_WeaponsNotAllowedChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UE - Weapons Not Allowed Entered", Addresses.UE_WeaponsNotAllowedEntered, "0", "160", LocationCheckType.Byte)
    };
            return weaponsNotAllowedLocations;
        }

        private static List<GenericLocationData> GetAKnightSellsHisSwordData()
        {
            List<GenericLocationData> aKnightSellsHisSwordLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - A Knight Sells his Sword Entered", Addresses.UE_AKnightSellsHisSwordEntered, "0", "160", LocationCheckType.Byte)
    };
            return aKnightSellsHisSwordLocations;
        }

        private static List<GenericLocationData> GetGemswordBlackmarketData()
        {
            List<GenericLocationData> gemswordBlackmarketLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - Gemsword Blackmarket - Nightstalker Boss", Addresses.UE_GemswordBlackmarketNightstalkerBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UE - Gemsword Blackmarket Entered", Addresses.UE_GemswordBlackmarketEntered, "0", "160", LocationCheckType.Byte)
    };
            return gemswordBlackmarketLocations;
        }

        private static List<GenericLocationData> GetThePiratesSonData()
        {
            List<GenericLocationData> thePiratesSonLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - The Pirate's Son Entered", Addresses.UE_ThePiratesSonEntered, "0", "160", LocationCheckType.Byte)
    };
            return thePiratesSonLocations;
        }

        private static List<GenericLocationData> GetSaleOfTheSwordData()
        {
            List<GenericLocationData> saleOfTheSwordLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UE - Sale of the Sword - Chest", Addresses.UE_SaleOfTheSwordChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UE - Sale of the Sword Entered", Addresses.UE_SaleOfTheSwordEntered, "0", "160", LocationCheckType.Byte)
    };
            return saleOfTheSwordLocations;
        }

        private static List<GenericLocationData> GetTheGreengrocersStairData()
        {
            List<GenericLocationData> theGreengrocersStairLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UEN - The Greengrocer's Stair - Neesa Boss", Addresses.UEN_TheGreengrocersStairNeesaBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UEN - The Greengrocer's Stair - Tieger Boss", Addresses.UEN_TheGreengrocersStairTiegerBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UEN - The Greengrocer's Stair Entered", Addresses.UEN_TheGreengrocersStairEntered, "0", "160", LocationCheckType.Byte)
    };
            return theGreengrocersStairLocations;
        }

        private static List<GenericLocationData> GetWhereBlackWatersRanData()
        {
            List<GenericLocationData> whereBlackWatersRanLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UEN - Where Black Waters Ran Entered", Addresses.UEN_WhereBlackWatersRanEntered, "0", "160", LocationCheckType.Byte)
    };
            return whereBlackWatersRanLocations;
        }

        private static List<GenericLocationData> GetArmsAgainstInvadersData()
        {
            List<GenericLocationData> armsAgainstInvadersLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UEN - Arms Against Invaders Entered", Addresses.UEN_ArmsAgainstInvadersEntered, "0", "160", LocationCheckType.Byte)
    };
            return armsAgainstInvadersLocations;
        }

        private static List<GenericLocationData> GetCatspawBlackmarketData()
        {
            List<GenericLocationData> catspawBlackmarketLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("UEN - Catspaw Blackmarket - Diabolos Floor Trap", Addresses.UEN_CatspawBlackmarketDiabolosFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UEN - Catspaw Blackmarket - Trap Clear Floor Trap", Addresses.UEN_CatspawBlackmarketTrapClearFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UEN - Catspaw Blackmarket - Chest", Addresses.UEN_CatspawBlackmarketChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("UEN - Catspaw Blackmarket Entered", Addresses.UEN_CatspawBlackmarketEntered, "0", "160", LocationCheckType.Byte)
    };
            return catspawBlackmarketLocations;
        }

        private static List<GenericLocationData> GetForcasRiseData()
        {
            List<GenericLocationData> forcasRiseLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCS - Forcas Rise Entered", Addresses.TCS_ForcasRiseEntered, "0", "160", LocationCheckType.Byte)
    };
            return forcasRiseLocations;
        }

        private static List<GenericLocationData> GetValdimanGatesData()
        {
            List<GenericLocationData> valdimanGatesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCS - Valdiman Gates Entered", Addresses.TCS_ValdimanGatesEntered, "0", "160", LocationCheckType.Byte)
    };
            return valdimanGatesLocations;
        }

        private static List<GenericLocationData> GetRueAlianoData()
        {
            List<GenericLocationData> rueAlianoLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCS - Rue Aliano - Mandrake Sigil Unlock", Addresses.TCS_RueAlianoMandrakeSigilUnlock, "0", "160", LocationCheckType.Byte)
    };
            return rueAlianoLocations;
        }

        private static List<GenericLocationData> GetTheHouseKhazabasData()
        {
            List<GenericLocationData> theHouseKhazabasLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCS - The House Khazabas - Chest", Addresses.TCS_TheHouseKhazabasChest, "0", "160", LocationCheckType.Byte)
    };
            return theHouseKhazabasLocations;
        }

        private static List<GenericLocationData> GetZebelsWalkData()
        {
            List<GenericLocationData> zebelsWalkLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCS - Zebel's Walk Entered", Addresses.TCS_ZebelsWalkEntered, "0", "160", LocationCheckType.Byte)
    };
            return zebelsWalkLocations;
        }

        private static List<GenericLocationData> GetRueVolnacData()
        {
            List<GenericLocationData> rueVolnacLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCS - Rue Volnac Entered", Addresses.TCS_RueVolnacEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueVolnacLocations;
        }

        private static List<GenericLocationData> GetRueFaltesData()
        {
            List<GenericLocationData> rueFaltesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCS - Rue Faltes Entered", Addresses.TCS_RueFaltesEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueFaltesLocations;
        }

        private static List<GenericLocationData> GetRueMorgueData()
        {
            List<GenericLocationData> rueMorgueLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCS - Rue Morgue Entered", Addresses.TCS_RueMorgueEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueMorgueLocations;
        }

        private static List<GenericLocationData> GetRueLejourData()
        {
            List<GenericLocationData> rueLejourLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Rue Lejour Entered", Addresses.TCE_RueLejourEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueLejourLocations;
        }

        private static List<GenericLocationData> GetKeschBridgeData()
        {
            List<GenericLocationData> keschBridgeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Kesch Bridge Entered", Addresses.TCE_KeschBridgeEntered, "0", "160", LocationCheckType.Byte)
    };
            return keschBridgeLocations;
        }

        private static List<GenericLocationData> GetRueCrimnadeData()
        {
            List<GenericLocationData> rueCrimnadeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Rue Crimnade - Cattleya Sigil Unlock", Addresses.TCE_RueCrimnadeCattleyaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCE - Rue Crimnade Entered", Addresses.TCE_RueCrimnadeEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueCrimnadeLocations;
        }

        private static List<GenericLocationData> GetWorkshopJunctionPointData()
        {
            List<GenericLocationData> workshopJunctionPointLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Workshop 'Junction Point' Entered", Addresses.TCE_WorkshopJunctionPointEntered, "0", "160", LocationCheckType.Byte)
    };
            return workshopJunctionPointLocations;
        }

        private static List<GenericLocationData> GetRueFisseranoData()
        {
            List<GenericLocationData> rueFisseranoLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Rue Fisserano - Heal Panel Floor Trap", Addresses.TCE_RueFisseranoHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCE - Rue Fisserano Entered", Addresses.TCE_RueFisseranoEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueFisseranoLocations;
        }

        private static List<GenericLocationData> GetWorkshopMetalWorksData()
        {
            List<GenericLocationData> workshopMetalWorksLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Workshop 'Metal Works' Entered", Addresses.TCE_WorkshopMetalWorksEntered, "0", "160", LocationCheckType.Byte)
    };
            return workshopMetalWorksLocations;
        }

        private static List<GenericLocationData> GetShasrasHillParkData()
        {
            List<GenericLocationData> shasrasHillParkLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Shasras Hill Park - Bronze Key Unlock", Addresses.TCE_ShasrasHillParkBronzeKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCE - Shasras Hill Park Entered", Addresses.TCE_ShasrasHillParkEntered, "0", "160", LocationCheckType.Byte)
    };
            return shasrasHillParkLocations;
        }

        private static List<GenericLocationData> GetTheHouseGilgitteData()
        {
            List<GenericLocationData> theHouseGilgitteLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - The House Gilgitte - Chest", Addresses.TCE_TheHouseGilgitteChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCE - The House Gilgitte Entered", Addresses.TCE_TheHouseGilgitteEntered, "0", "160", LocationCheckType.Byte)
    };
            return theHouseGilgitteLocations;
        }

        private static List<GenericLocationData> GetGharmesWalkData()
        {
            List<GenericLocationData> gharmesWalkLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Gharmes Walk - Chest", Addresses.TCE_GharmesWalkChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCE - Gharmes Walk Entered", Addresses.TCE_GharmesWalkEntered, "0", "160", LocationCheckType.Byte)
    };
            return gharmesWalkLocations;
        }

        private static List<GenericLocationData> GetPlateiaLumitarData()
        {
            List<GenericLocationData> plateiaLumitarLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCE - Plateia Lumitar - Cure Panel Floor Trap", Addresses.TCE_PlateiaLumitarCurePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCE - Plateia Lumitar Entered", Addresses.TCE_PlateiaLumitarEntered, "0", "160", LocationCheckType.Byte)
    };
            return plateiaLumitarLocations;
        }

        private static List<GenericLocationData> GetRueVermillionData()
        {
            List<GenericLocationData> rueVermillionLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Rue Vermillion - Crimson Key Unlock", Addresses.TCW_RueVermillionCrimsonKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCW - Rue Vermillion Entered", Addresses.TCW_RueVermillionEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueVermillionLocations;
        }

        private static List<GenericLocationData> GetTheReneCoastroadData()
        {
            List<GenericLocationData> theReneCoastroadLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - The Rene Coastroad - Heal Panel Floor Trap", Addresses.TCW_TheReneCoastroadHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCW - The Rene Coastroad Entered", Addresses.TCW_TheReneCoastroadEntered, "0", "160", LocationCheckType.Byte)
    };
            return theReneCoastroadLocations;
        }

        private static List<GenericLocationData> GetWorkshopMagicHammerData()
        {
            List<GenericLocationData> workshopMagicHammerLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Workshop 'Magic Hammer' Entered", Addresses.TCW_WorkshopMagicHammerEntered, "0", "160", LocationCheckType.Byte)
    };
            return workshopMagicHammerLocations;
        }

        private static List<GenericLocationData> GetRueMalFalldeData()
        {
            List<GenericLocationData> rueMalFalldeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Rue Mal Fallde Entered", Addresses.TCW_RueMalFalldeEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueMalFalldeLocations;
        }

        private static List<GenericLocationData> GetTircolasFlowNorthData()
        {
            List<GenericLocationData> tircolasFlowNorthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Tircolas Flow (North) - Duane Boss", Addresses.TCW_TircolasFlowNorthDuaneBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCW - Tircolas Flow (North) Entered", Addresses.TCW_TircolasFlowNorthEntered, "0", "160", LocationCheckType.Byte)
    };
            return tircolasFlowNorthLocations;
        }

        private static List<GenericLocationData> GetTircolasFlowSouthData()
        {
            List<GenericLocationData> tircolasFlowSouthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Tircolas Flow (South) Entered", Addresses.TCW_TircolasFlowSouthEntered, "0", "160", LocationCheckType.Byte)
    };
            return tircolasFlowSouthLocations;
        }

        private static List<GenericLocationData> GetRueBouquetData()
        {
            List<GenericLocationData> rueBouquetLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Rue Bouquet Entered", Addresses.TCW_RueBouquetEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueBouquetLocations;
        }

        private static List<GenericLocationData> GetGlacialdraKirkRuinsData()
        {
            List<GenericLocationData> glacialdraKirkRuinsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Glacialdra Kirk Ruins - Rood Inverse Unlock", Addresses.TCW_GlacialdraKirkRuinsRoodInverseUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TCW - Glacialdra Kirk Ruins Entered", Addresses.TCW_GlacialdraKirkRuinsEntered, "0", "160", LocationCheckType.Byte)
    };
            return glacialdraKirkRuinsLocations;
        }

        private static List<GenericLocationData> GetRueSantDalsaData()
        {
            List<GenericLocationData> rueSantDalsaLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Rue Sant D'alsa Entered", Addresses.TCW_RueSantDalsaEntered, "0", "160", LocationCheckType.Byte)
    };
            return rueSantDalsaLocations;
        }

        private static List<GenericLocationData> GetDinasWalkData()
        {
            List<GenericLocationData> dinasWalkLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Dinas Walk Entered", Addresses.TCW_DinasWalkEntered, "0", "160", LocationCheckType.Byte)
    };
            return dinasWalkLocations;
        }

        private static List<GenericLocationData> GetVilleportWayData()
        {
            List<GenericLocationData> villeportWayLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TCW - Villeport Way Entered", Addresses.TCW_VilleportWayEntered, "0", "160", LocationCheckType.Byte)
    };
            return villeportWayLocations;
        }
        private static List<GenericLocationData> GetTheSoldiersBeddingData()
        {
            List<GenericLocationData> theSoldiersBeddingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - The Soldier's Bedding - Gold Key Unlock", Addresses.KEP_TheSoldiersBeddingGoldKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - The Soldier's Bedding Entered", Addresses.KEP_TheSoldiersBeddingEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSoldiersBeddingLocations;
        }

        private static List<GenericLocationData> GetAStormOfArrowsData()
        {
            List<GenericLocationData> aStormOfArrowsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - A Storm of Arrows - Kalmia Sigil Unlock", Addresses.KEP_AStormOfArrowsKalmiaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - A Storm of Arrows - Columbine Sigil Unlock", Addresses.KEP_AStormOfArrowsColumbineSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - A Storm of Arrows Entered", Addresses.KEP_AStormOfArrowsEntered, "0", "160", LocationCheckType.Byte)
    };
            return aStormOfArrowsLocations;
        }

        private static List<GenericLocationData> GetTimeTrialMinotaurData()
        {
            List<GenericLocationData> timeTrialMinotaurLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Time Trial (Minotaur) - Minotaur Boss", Addresses.KEP_TimeTrialMinotaurMinotaurBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Minotaur) Entered", Addresses.KEP_TimeTrialMinotaurEntered, "0", "160", LocationCheckType.Byte)
    };
            return timeTrialMinotaurLocations;
        }

        private static List<GenericLocationData> GetTimeTrialDragonData()
        {
            List<GenericLocationData> timeTrialDragonLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Time Trial (Dragon) - Dragon Boss", Addresses.KEP_TimeTrialDragonDragonBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Dragon) Entered", Addresses.KEP_TimeTrialDragonEntered, "0", "160", LocationCheckType.Byte)
    };
            return timeTrialDragonLocations;
        }

        private static List<GenericLocationData> GetUrgeTheBoyOnData()
        {
            List<GenericLocationData> urgeTheBoyOnLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Urge the Boy On - Anemone Sigil Unlock", Addresses.KEP_UrgeTheBoyOnAnemoneSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Urge the Boy On - Verbena Sigil Unlock", Addresses.KEP_UrgeTheBoyOnVerbenaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Urge the Boy On Entered", Addresses.KEP_UrgeTheBoyOnEntered, "0", "160", LocationCheckType.Byte)
    };
            return urgeTheBoyOnLocations;
        }

        private static List<GenericLocationData> GetTimeTrialEarthDragonData()
        {
            List<GenericLocationData> timeTrialEarthDragonLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Time Trial (Earth Dragon) - Earth Dragon Boss", Addresses.KEP_TimeTrialEarthDragonEarthDragonBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Earth Dragon) Entered", Addresses.KEP_TimeTrialEarthDragonEntered, "0", "160", LocationCheckType.Byte)
    };
            return timeTrialEarthDragonLocations;
        }

        private static List<GenericLocationData> GetTimeTrialSnowDragonData()
        {
            List<GenericLocationData> timeTrialSnowDragonLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Time Trial (Snow Dragon) - Snow Dragon Boss", Addresses.KEP_TimeTrialSnowDragonSnowDragonBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Snow Dragon) Entered", Addresses.KEP_TimeTrialSnowDragonEntered, "0", "160", LocationCheckType.Byte)
    };
            return timeTrialSnowDragonLocations;
        }

        private static List<GenericLocationData> GetATasteOfTheSpoilsData()
        {
            List<GenericLocationData> aTasteOfTheSpoilsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - A Taste of the Spoils - Schirra Sigil Unlock", Addresses.KEP_ATasteOfTheSpoilsSchirraSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - A Taste of the Spoils - Marigold Sigil Unlock", Addresses.KEP_ATasteOfTheSpoilsMarigoldSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - A Taste of the Spoils Entered", Addresses.KEP_ATasteOfTheSpoilsEntered, "0", "160", LocationCheckType.Byte)
    };
            return aTasteOfTheSpoilsLocations;
        }

        private static List<GenericLocationData> GetTimeTrialDamascusGolemData()
        {
            List<GenericLocationData> timeTrialDamascusGolemLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Time Trial (Damascus Golem) - Damascus Golem Boss", Addresses.KEP_TimeTrialDamascusGolemDamascusGolemBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Damascus Golem) Entered", Addresses.KEP_TimeTrialDamascusGolemEntered, "0", "160", LocationCheckType.Byte)
    };
            return timeTrialDamascusGolemLocations;
        }

        private static List<GenericLocationData> GetTimeTrialDamascusCrabData()
        {
            List<GenericLocationData> timeTrialDamascusCrabLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Time Trial (Damascus Crab) - Damascus Crab Boss", Addresses.KEP_TimeTrialDamascusCrabDamascusCrabBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Damascus Crab) Entered", Addresses.KEP_TimeTrialDamascusCrabEntered, "0", "160", LocationCheckType.Byte)
    };
            return timeTrialDamascusCrabLocations;
        }

        private static List<GenericLocationData> GetWipingBloodFromBladesData()
        {
            List<GenericLocationData> wipingBloodFromBladesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Wiping Blood from Blades - Azalea Sigil Unlock", Addresses.KEP_WipingBloodFromBladesAzaleaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Wiping Blood from Blades - Tigertail Sigil Unlock", Addresses.KEP_WipingBloodFromBladesTigertailSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Wiping Blood from Blades Entered", Addresses.KEP_WipingBloodFromBladesEntered, "0", "160", LocationCheckType.Byte)
    };
            return wipingBloodFromBladesLocations;
        }

        private static List<GenericLocationData> GetTimeTrialDeathOgreZombieData()
        {
            List<GenericLocationData> timeTrialDeathOgreZombieLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Time Trial (Death + Ogre Zombie) - Death Boss", Addresses.KEP_TimeTrialDeathOgreZombieDeathBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Death + Ogre Zombie) - Ogre Zombie Boss", Addresses.KEP_TimeTrialDeathOgreZombieOgreZombieBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Death + Ogre Zombie) Entered", Addresses.KEP_TimeTrialDeathOgreZombieEntered, "0", "160", LocationCheckType.Byte)
    };
            return timeTrialDeathOgreZombieLocations;
        }

        private static List<GenericLocationData> GetTimeTrialAsuraData()
        {
            List<GenericLocationData> timeTrialAsuraLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Time Trial (Asura) - Asura Boss", Addresses.KEP_TimeTrialAsuraAsuraBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - Time Trial (Asura) Entered", Addresses.KEP_TimeTrialAsuraEntered, "0", "160", LocationCheckType.Byte)
    };
            return timeTrialAsuraLocations;
        }

        private static List<GenericLocationData> GetTheWarriorsRestData()
        {
            List<GenericLocationData> theWarriorsRestLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - The Warrior's Rest - Rosencrantz Boss", Addresses.KEP_TheWarriorsRestRosencrantzBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - The Warrior's Rest - Chest", Addresses.KEP_TheWarriorsRestChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("KEP - The Warrior's Rest Entered", Addresses.KEP_TheWarriorsRestEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWarriorsRestLocations;
        }

        private static List<GenericLocationData> GetWorkshopKeanesCraftsData()
        {
            List<GenericLocationData> workshopKeanesCraftsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("KEP - Workshop 'Keane's Crafts' Entered", Addresses.KEP_WorkshopKeanesCraftsEntered, "0", "160", LocationCheckType.Byte)
    };
            return workshopKeanesCraftsLocations;
        }

        private static List<GenericLocationData> GetTheDarkCoastData()
        {
            List<GenericLocationData> theDarkCoastLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TOK - The Dark Coast - Trap Clear Floor Trap", Addresses.TOK_TheDarkCoastTrapClearFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TOK - The Dark Coast - Heal Panel Floor Trap", Addresses.TOK_TheDarkCoastHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TOK - The Dark Coast Entered", Addresses.TOK_TheDarkCoastEntered, "0", "160", LocationCheckType.Byte)
    };
            return theDarkCoastLocations;
        }

        private static List<GenericLocationData> GetHallOfPrayerData()
        {
            List<GenericLocationData> hallOfPrayerLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TOK - Hall of Prayer - Last Crusader Boss", Addresses.TOK_HallOfPrayerLastCrusaderBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TOK - Hall of Prayer Entered", Addresses.TOK_HallOfPrayerEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallOfPrayerLocations;
        }

        private static List<GenericLocationData> GetThoseWhoDrinkTheDarkData()
        {
            List<GenericLocationData> thoseWhoDrinkTheDarkLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TOK - Those who Drink the Dark - Silver Key Unlock", Addresses.TOK_ThoseWhoDrinkTheDarkSilverKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TOK - Those who Drink the Dark Entered", Addresses.TOK_ThoseWhoDrinkTheDarkEntered, "0", "160", LocationCheckType.Byte)
    };
            return thoseWhoDrinkTheDarkLocations;
        }

        private static List<GenericLocationData> GetTheChapelOfMeschaunceData()
        {
            List<GenericLocationData> theChapelOfMeschaunceLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TOK - The Chapel of Meschaunce - Minotaur Lord Boss", Addresses.TOK_TheChapelOfMeschaunceMinotaurLordBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TOK - The Chapel of Meschaunce Entered", Addresses.TOK_TheChapelOfMeschaunceEntered, "0", "160", LocationCheckType.Byte)
    };
            return theChapelOfMeschaunceLocations;
        }

        private static List<GenericLocationData> GetTheResentfulOnesData()
        {
            List<GenericLocationData> theResentfulOnesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TOK - The Resentful Ones - Silver Key Unlock", Addresses.TOK_TheResentfulOnesSilverKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TOK - The Resentful Ones Entered", Addresses.TOK_TheResentfulOnesEntered, "0", "160", LocationCheckType.Byte)
    };
            return theResentfulOnesLocations;
        }

        private static List<GenericLocationData> GetThoseWhoFearTheLightData()
        {
            List<GenericLocationData> thoseWhoFearTheLightLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TOK - Those who Fear the Light Entered", Addresses.TOK_ThoseWhoFearTheLightEntered, "0", "160", LocationCheckType.Byte)
    };
            return thoseWhoFearTheLightLocations;
        }

        private static List<GenericLocationData> GetChamberOfReasonData()
        {
            List<GenericLocationData> chamberOfReasonLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TOK - Chamber of Reason - Kali Boss", Addresses.TOK_ChamberOfReasonKaliBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("TOK - Chamber of Reason Entered", Addresses.TOK_ChamberOfReasonEntered, "0", "160", LocationCheckType.Byte)
    };
            return chamberOfReasonLocations;
        }

        private static List<GenericLocationData> GetExitToCityCenterData()
        {
            List<GenericLocationData> exitToCityCenterLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("TOK - Exit to City Center Entered", Addresses.TOK_ExitToCityCenterEntered, "0", "160", LocationCheckType.Byte)
    };
            return exitToCityCenterLocations;
        }
        private static List<GenericLocationData> GetTheFaerieCircleData()
        {
            List<GenericLocationData> theFaerieCircleLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Faerie Circle Entered", Addresses.SFF_TheFaerieCircleEntered, "0", "160", LocationCheckType.Byte)
    };
            return theFaerieCircleLocations;
        }

        private static List<GenericLocationData> GetTheHuntBeginsData()
        {
            List<GenericLocationData> theHuntBeginsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Hunt Begins Entered", Addresses.SFF_TheHuntBeginsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theHuntBeginsLocations;
        }

        private static List<GenericLocationData> GetWhichWayHomeData()
        {
            List<GenericLocationData> whichWayHomeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Which Way Home Entered", Addresses.SFF_WhichWayHomeEntered, "0", "160", LocationCheckType.Byte)
    };
            return whichWayHomeLocations;
        }

        private static List<GenericLocationData> GetTheGivingTreesData()
        {
            List<GenericLocationData> theGivingTreesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Giving Trees Entered", Addresses.SFF_TheGivingTreesEntered, "0", "160", LocationCheckType.Byte)
    };
            return theGivingTreesLocations;
        }

        private static List<GenericLocationData> GetTheBirdsAndTheBeesData()
        {
            List<GenericLocationData> theBirdsAndTheBeesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Birds and the Bees Entered", Addresses.SFF_TheBirdsAndTheBeesEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBirdsAndTheBeesLocations;
        }

        private static List<GenericLocationData> GetTheWoundedBoarData()
        {
            List<GenericLocationData> theWoundedBoarLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Wounded Boar Entered", Addresses.SFF_TheWoundedBoarEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWoundedBoarLocations;
        }

        private static List<GenericLocationData> GetGoldenEggWayData()
        {
            List<GenericLocationData> goldenEggWayLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Golden Egg Way Entered", Addresses.SFF_GoldenEggWayEntered, "0", "160", LocationCheckType.Byte)
    };
            return goldenEggWayLocations;
        }

        private static List<GenericLocationData> GetTracesOfTheBeastData()
        {
            List<GenericLocationData> tracesOfTheBeastLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Traces of the Beast Entered", Addresses.SFF_TracesOfTheBeastEntered, "0", "160", LocationCheckType.Byte)
    };
            return tracesOfTheBeastLocations;
        }

        private static List<GenericLocationData> GetFlutteringHopeData()
        {
            List<GenericLocationData> flutteringHopeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Fluttering Hope Entered", Addresses.SFF_FlutteringHopeEntered, "0", "160", LocationCheckType.Byte)
    };
            return flutteringHopeLocations;
        }

        private static List<GenericLocationData> GetReturnToTheLandData()
        {
            List<GenericLocationData> returnToTheLandLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Return to the Land Entered", Addresses.SFF_ReturnToTheLandEntered, "0", "160", LocationCheckType.Byte)
    };
            return returnToTheLandLocations;
        }

        private static List<GenericLocationData> GetTheYellowWoodData()
        {
            List<GenericLocationData> theYellowWoodLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Yellow Wood Entered", Addresses.SFF_TheYellowWoodEntered, "0", "160", LocationCheckType.Byte)
    };
            return theYellowWoodLocations;
        }

        private static List<GenericLocationData> GetTheyAlsoFeedData()
        {
            List<GenericLocationData> theyAlsoFeedLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - They Also Feed Entered", Addresses.SFF_TheyAlsoFeedEntered, "0", "160", LocationCheckType.Byte)
    };
            return theyAlsoFeedLocations;
        }

        private static List<GenericLocationData> GetTheSpiritTreesData()
        {
            List<GenericLocationData> theSpiritTreesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Spirit Trees Entered", Addresses.SFF_TheSpiritTreesEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSpiritTreesLocations;
        }

        private static List<GenericLocationData> GetWhereSoftRainsFellData()
        {
            List<GenericLocationData> whereSoftRainsFellLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Where Soft Rains Fell Entered", Addresses.SFF_WhereSoftRainsFellEntered, "0", "160", LocationCheckType.Byte)
    };
            return whereSoftRainsFellLocations;
        }

        private static List<GenericLocationData> GetForestRiverData()
        {
            List<GenericLocationData> forestRiverLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Forest River - Cure Panel Floor Trap", Addresses.SFF_ForestRiverCurePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SFF - Forest River - Chest", Addresses.SFF_ForestRiverChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SFF - Forest River Entered", Addresses.SFF_ForestRiverEntered, "0", "160", LocationCheckType.Byte)
    };
            return forestRiverLocations;
        }

        private static List<GenericLocationData> GetLamentingToTheMoonData()
        {
            List<GenericLocationData> lamentingToTheMoonLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Lamenting to the Moon Entered", Addresses.SFF_LamentingToTheMoonEntered, "0", "160", LocationCheckType.Byte)
    };
            return lamentingToTheMoonLocations;
        }

        private static List<GenericLocationData> GetRunningWithTheWolvesData()
        {
            List<GenericLocationData> runningWithTheWolvesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Running with the Wolves Entered", Addresses.SFF_RunningWithTheWolvesEntered, "0", "160", LocationCheckType.Byte)
    };
            return runningWithTheWolvesLocations;
        }

        private static List<GenericLocationData> GetYouAreThePreyData()
        {
            List<GenericLocationData> youAreThePreyLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - You Are the Prey Entered", Addresses.SFF_YouAreThePreyEntered, "0", "160", LocationCheckType.Byte)
    };
            return youAreThePreyLocations;
        }

        private static List<GenericLocationData> GetTheSecretPathData()
        {
            List<GenericLocationData> theSecretPathLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Secret Path Entered", Addresses.SFF_TheSecretPathEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSecretPathLocations;
        }

        private static List<GenericLocationData> GetHewnFromNatureData()
        {
            List<GenericLocationData> hewnFromNatureLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Hewn from Nature - Grissom Boss", Addresses.SFF_HewnFromNatureGrissomBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SFF - Hewn from Nature - Dark Crusader Boss", Addresses.SFF_HewnFromNatureDarkCrusaderBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SFF - Hewn from Nature - Chest", Addresses.SFF_HewnFromNatureChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SFF - Hewn from Nature Entered", Addresses.SFF_HewnFromNatureEntered, "0", "160", LocationCheckType.Byte)
    };
            return hewnFromNatureLocations;
        }

        private static List<GenericLocationData> GetTheWoodGateData()
        {
            List<GenericLocationData> theWoodGateLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Wood Gate Entered", Addresses.SFF_TheWoodGateEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWoodGateLocations;
        }

        private static List<GenericLocationData> GetTheWolvesChoiceData()
        {
            List<GenericLocationData> theWolvesChoiceLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Wolves' Choice Entered", Addresses.SFF_TheWolvesChoiceEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWolvesChoiceLocations;
        }

        private static List<GenericLocationData> GetTheWoodcuttersRunData()
        {
            List<GenericLocationData> theWoodcuttersRunLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Woodcutter's Run Entered", Addresses.SFF_TheWoodcuttersRunEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWoodcuttersRunLocations;
        }

        private static List<GenericLocationData> GetTheHollowHillsData()
        {
            List<GenericLocationData> theHollowHillsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Hollow Hills Entered", Addresses.SFF_TheHollowHillsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theHollowHillsLocations;
        }

        private static List<GenericLocationData> GetHowlOfTheWolfKingData()
        {
            List<GenericLocationData> howlOfTheWolfKingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - Howl of the Wolf King Entered", Addresses.SFF_HowlOfTheWolfKingEntered, "0", "160", LocationCheckType.Byte)
    };
            return howlOfTheWolfKingLocations;
        }

        private static List<GenericLocationData> GetTheSilentHedgesData()
        {
            List<GenericLocationData> theSilentHedgesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFF - The Silent Hedges Entered", Addresses.SFF_TheSilentHedgesEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSilentHedgesLocations;
        }

        private static List<GenericLocationData> GetSteadyTheBoarSpearsData()
        {
            List<GenericLocationData> steadyTheBoarSpearsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFE - Steady the Boar-Spears - Rood Inverse Unlock", Addresses.SFE_SteadyTheBoarSpearsRoodInverseUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SFE - Steady the Boar-Spears Entered", Addresses.SFE_SteadyTheBoarSpearsEntered, "0", "160", LocationCheckType.Byte)
    };
            return steadyTheBoarSpearsLocations;
        }

        private static List<GenericLocationData> GetTheBoarsRevengeData()
        {
            List<GenericLocationData> theBoarsRevengeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFE - The Boar's Revenge Entered", Addresses.SFE_TheBoarsRevengeEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBoarsRevengeLocations;
        }
        private static List<GenericLocationData> GetNaturesWombData()
        {
            List<GenericLocationData> naturesWombLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SFE - Nature's Womb - Damascus Crab Boss", Addresses.SFE_NaturesWombDamascusCrabBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SFE - Nature's Womb Entered", Addresses.SFE_NaturesWombEntered, "0", "160", LocationCheckType.Byte)
    };
            return naturesWombLocations;
        }

        private static List<GenericLocationData> GetPrisonersNicheData()
        {
            List<GenericLocationData> prisonersNicheLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Prisoners' Niche Entered", Addresses.SNC_PrisonersNicheEntered, "0", "160", LocationCheckType.Byte)
    };
            return prisonersNicheLocations;
        }

        private static List<GenericLocationData> GetCorridorOfTheClericsData()
        {
            List<GenericLocationData> corridorOfTheClericsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Corridor of the Clerics Entered", Addresses.SNC_CorridorOfTheClericsEntered, "0", "160", LocationCheckType.Byte)
    };
            return corridorOfTheClericsLocations;
        }

        private static List<GenericLocationData> GetPriestsConfinementData()
        {
            List<GenericLocationData> priestsConfinementLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Priests' Confinement Entered", Addresses.SNC_PriestsConfinementEntered, "0", "160", LocationCheckType.Byte)
    };
            return priestsConfinementLocations;
        }

        private static List<GenericLocationData> GetAlchemistsLaboratoryData()
        {
            List<GenericLocationData> alchemistsLaboratoryLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Alchemists' Laboratory - Chest", Addresses.SNC_AlchemistsLaboratoryChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SNC - Alchemists' Laboratory Entered", Addresses.SNC_AlchemistsLaboratoryEntered, "0", "160", LocationCheckType.Byte)
    };
            return alchemistsLaboratoryLocations;
        }

        private static List<GenericLocationData> GetTheAcademiaCorridorData()
        {
            List<GenericLocationData> theAcademiaCorridorLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - The Academia Corridor Entered", Addresses.SNC_TheAcademiaCorridorEntered, "0", "160", LocationCheckType.Byte)
    };
            return theAcademiaCorridorLocations;
        }

        private static List<GenericLocationData> GetTheologyClassroomData()
        {
            List<GenericLocationData> theologyClassroomLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Theology Classroom Entered", Addresses.SNC_TheologyClassroomEntered, "0", "160", LocationCheckType.Byte)
    };
            return theologyClassroomLocations;
        }

        private static List<GenericLocationData> GetShrineOfTheMartyrsData()
        {
            List<GenericLocationData> shrineOfTheMartyrsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Shrine of the Martyrs Entered", Addresses.SNC_ShrineOfTheMartyrsEntered, "0", "160", LocationCheckType.Byte)
    };
            return shrineOfTheMartyrsLocations;
        }

        private static List<GenericLocationData> GetHallowedHopeData()
        {
            List<GenericLocationData> hallowedHopeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Hallowed Hope Entered", Addresses.SNC_HallowedHopeEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallowedHopeLocations;
        }

        private static List<GenericLocationData> GetHallOfSacrilegeData()
        {
            List<GenericLocationData> hallOfSacrilegeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Hall of Sacrilege - Golem Boss", Addresses.SNC_HallOfSacrilegeGolemBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SNC - Hall of Sacrilege Entered", Addresses.SNC_HallOfSacrilegeEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallOfSacrilegeLocations;
        }

        private static List<GenericLocationData> GetAdventGroundSouthData()
        {
            List<GenericLocationData> adventGroundSouthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Advent Ground (South) Entered", Addresses.SNC_AdventGroundSouthEntered, "0", "160", LocationCheckType.Byte)
    };
            return adventGroundSouthLocations;
        }

        private static List<GenericLocationData> GetPassageOfTheRefugeesSouthData()
        {
            List<GenericLocationData> passageOfTheRefugeesSouthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Passage of the Refugees (South) - Hall of Sacrilege Unlock", Addresses.SNC_PassageOfTheRefugeesSouthHallOfSacrilegeUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SNC - Passage of the Refugees (South) Entered", Addresses.SNC_PassageOfTheRefugeesSouthEntered, "0", "160", LocationCheckType.Byte)
    };
            return passageOfTheRefugeesSouthLocations;
        }

        private static List<GenericLocationData> GetPassageOfTheRefugeesNorthData()
        {
            List<GenericLocationData> passageOfTheRefugeesNorthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Passage of the Refugees (North) Entered", Addresses.SNC_PassageOfTheRefugeesNorthEntered, "0", "160", LocationCheckType.Byte)
    };
            return passageOfTheRefugeesNorthLocations;
        }

        private static List<GenericLocationData> GetAdventGroundNorthData()
        {
            List<GenericLocationData> adventGroundNorthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Advent Ground (North) Entered", Addresses.SNC_AdventGroundNorthEntered, "0", "160", LocationCheckType.Byte)
    };
            return adventGroundNorthLocations;
        }

        private static List<GenericLocationData> GetTheCleansingChantryData()
        {
            List<GenericLocationData> theCleansingChantryLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - The Cleansing Chantry - Dragon Boss", Addresses.SNC_TheCleansingChantryDragonBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("SNC - The Cleansing Chantry Entered", Addresses.SNC_TheCleansingChantryEntered, "0", "160", LocationCheckType.Byte)
    };
            return theCleansingChantryLocations;
        }

        private static List<GenericLocationData> GetStairwayToTheLightData()
        {
            List<GenericLocationData> stairwayToTheLightLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("SNC - Stairway to the Light Entered", Addresses.SNC_StairwayToTheLightEntered, "0", "160", LocationCheckType.Byte)
    };
            return stairwayToTheLightLocations;
        }

        private static List<GenericLocationData> GetDarkAbhorsLightData()
        {
            List<GenericLocationData> darkAbhorsLightLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Dark Abhors Light Entered", Addresses.LQ_DarkAbhorsLightEntered, "0", "160", LocationCheckType.Byte)
    };
            return darkAbhorsLightLocations;
        }

        private static List<GenericLocationData> GetDreamOfTheHolyLandData()
        {
            List<GenericLocationData> dreamOfTheHolyLandLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Dream of the Holy Land - Water Elemental Boss", Addresses.LQ_DreamOfTheHolyLandWaterElementalBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Dream of the Holy Land - Aster Sigil Unlock", Addresses.LQ_DreamOfTheHolyLandAsterSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Dream of the Holy Land Entered", Addresses.LQ_DreamOfTheHolyLandEntered, "0", "160", LocationCheckType.Byte)
    };
            return dreamOfTheHolyLandLocations;
        }

        private static List<GenericLocationData> GetTheOreRoadData()
        {
            List<GenericLocationData> theOreRoadLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Ore Road Entered", Addresses.LQ_TheOreRoadEntered, "0", "160", LocationCheckType.Byte)
    };
            return theOreRoadLocations;
        }

        private static List<GenericLocationData> GetTheAirStirsData()
        {
            List<GenericLocationData> theAirStirsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Air Stirs - Eulelia Sigil Unlock", Addresses.LQ_TheAirStirsEuleliaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - The Air Stirs Entered", Addresses.LQ_TheAirStirsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theAirStirsLocations;
        }

        private static List<GenericLocationData> GetBondsOfFriendshipData()
        {
            List<GenericLocationData> bondsOfFriendshipLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Bonds of Friendship - Chest", Addresses.LQ_BondsOfFriendshipChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Bonds of Friendship Entered", Addresses.LQ_BondsOfFriendshipEntered, "0", "160", LocationCheckType.Byte)
    };
            return bondsOfFriendshipLocations;
        }

        private static List<GenericLocationData> GetAtoneForEternityData()
        {
            List<GenericLocationData> atoneForEternityLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Atone for Eternity - Death Vapor Floor Trap", Addresses.LQ_AtoneForEternityDeathVaporFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Atone for Eternity Entered", Addresses.LQ_AtoneForEternityEntered, "0", "160", LocationCheckType.Byte)
    };
            return atoneForEternityLocations;
        }

        private static List<GenericLocationData> GetStairToSanctuaryData()
        {
            List<GenericLocationData> stairToSanctuaryLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Stair to Sanctuary Entered", Addresses.LQ_StairToSanctuaryEntered, "0", "160", LocationCheckType.Byte)
    };
            return stairToSanctuaryLocations;
        }

        private static List<GenericLocationData> GetTheFallenHallData()
        {
            List<GenericLocationData> theFallenHallLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Fallen Hall Entered", Addresses.LQ_TheFallenHallEntered, "0", "160", LocationCheckType.Byte)
    };
            return theFallenHallLocations;
        }

        private static List<GenericLocationData> GetTheRottenCoreData()
        {
            List<GenericLocationData> theRottenCoreLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Rotten Core Entered", Addresses.LQ_TheRottenCoreEntered, "0", "160", LocationCheckType.Byte)
    };
            return theRottenCoreLocations;
        }

        private static List<GenericLocationData> GetTheDreamersClimbData()
        {
            List<GenericLocationData> theDreamersClimbLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Dreamer's Climb - Eulelia Sigil Unlock", Addresses.LQ_TheDreamersClimbEuleliaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - The Dreamer's Climb - Heal Panel Floor Trap", Addresses.LQ_TheDreamersClimbHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - The Dreamer's Climb Entered", Addresses.LQ_TheDreamersClimbEntered, "0", "160", LocationCheckType.Byte)
    };
            return theDreamersClimbLocations;
        }

        private static List<GenericLocationData> GetTheOreBearersData()
        {
            List<GenericLocationData> theOreBearersLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Ore-Bearers - Poison Panel Floor Trap", Addresses.LQ_TheOreBearersPoisonPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - The Ore-Bearers Entered", Addresses.LQ_TheOreBearersEntered, "0", "160", LocationCheckType.Byte)
    };
            return theOreBearersLocations;
        }

        private static List<GenericLocationData> GetScreamsOfTheWoundedData()
        {
            List<GenericLocationData> screamsOfTheWoundedLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Screams of the Wounded Entered", Addresses.LQ_ScreamsOfTheWoundedEntered, "0", "160", LocationCheckType.Byte)
    };
            return screamsOfTheWoundedLocations;
        }

        private static List<GenericLocationData> GetBacchusIsCheapData()
        {
            List<GenericLocationData> bacchusIsCheapLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Bacchus is Cheap Entered", Addresses.LQ_BacchusIsCheapEntered, "0", "160", LocationCheckType.Byte)
    };
            return bacchusIsCheapLocations;
        }

        private static List<GenericLocationData> GetSinnersSustenenceData()
        {
            List<GenericLocationData> sinnersSustenenceLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Sinner's Sustenence Entered", Addresses.LQ_SinnersSustenenceEntered, "0", "160", LocationCheckType.Byte)
    };
            return sinnersSustenenceLocations;
        }

        private static List<GenericLocationData> GetTheTimelyDewOfSleepData()
        {
            List<GenericLocationData> theTimelyDewOfSleepLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Air Stirs - Gold Key Unlock", Addresses.LQ_TheAirStirsGoldKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - The Timely Dew of Sleep Entered", Addresses.LQ_TheTimelyDewOfSleepEntered, "0", "160", LocationCheckType.Byte)
    };
            return theTimelyDewOfSleepLocations;
        }

        private static List<GenericLocationData> GetCompanionsInArmsData()
        {
            List<GenericLocationData> companionsInArmsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Companions in Arms - Chest", Addresses.LQ_CompanionsInArmsChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Companions in Arms Entered", Addresses.LQ_CompanionsInArmsEntered, "0", "160", LocationCheckType.Byte)
    };
            return companionsInArmsLocations;
        }

        private static List<GenericLocationData> GetTheAuctionBlockData()
        {
            List<GenericLocationData> theAuctionBlockLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Auction Block - Silver Key Unlock", Addresses.LQ_TheAuctionBlockSilverKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - The Auction Block Entered", Addresses.LQ_TheAuctionBlockEntered, "0", "160", LocationCheckType.Byte)
    };
            return theAuctionBlockLocations;
        }

        private static List<GenericLocationData> GetAscensionData()
        {
            List<GenericLocationData> ascensionLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Ascension Entered", Addresses.LQ_AscensionEntered, "0", "160", LocationCheckType.Byte)
    };
            return ascensionLocations;
        }

        private static List<GenericLocationData> GetWhereTheSerpentHuntsData()
        {
            List<GenericLocationData> whereTheSerpentHuntsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Where the Serpent Hunts Entered", Addresses.LQ_WhereTheSerpentHuntsEntered, "0", "160", LocationCheckType.Byte)
    };
            return whereTheSerpentHuntsLocations;
        }

        private static List<GenericLocationData> GetDrownedInFleetingJoyData()
        {
            List<GenericLocationData> drownedInFleetingJoyLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Drowned in Fleeting Joy - Chest", Addresses.LQ_DrownedInFleetingJoyChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Drowned in Fleeting Joy Entered", Addresses.LQ_DrownedInFleetingJoyEntered, "0", "160", LocationCheckType.Byte)
    };
            return drownedInFleetingJoyLocations;
        }

        private static List<GenericLocationData> GetAntsPrepareForWinterData()
        {
            List<GenericLocationData> antsPrepareForWinterLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Ants Prepare for Winter Entered", Addresses.LQ_AntsPrepareForWinterEntered, "0", "160", LocationCheckType.Byte)
    };
            return antsPrepareForWinterLocations;
        }

        private static List<GenericLocationData> GetTheLaborersBonfireData()
        {
            List<GenericLocationData> theLaborersBonfireLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - The Laborer's Bonfire - Melissa Sigil Unlock", Addresses.LQ_TheLaborersBonfireMelissaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - The Laborer's Bonfire - Paralysis Panel Floor Trap", Addresses.LQ_TheLaborersBonfireParalysisPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - The Laborer's Bonfire Entered", Addresses.LQ_TheLaborersBonfireEntered, "0", "160", LocationCheckType.Byte)
    };
            return theLaborersBonfireLocations;
        }

        private static List<GenericLocationData> GetStoneAndSulfurousFireData()
        {
            List<GenericLocationData> stoneAndSulfurousFireLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Stone and Sulfurous Fire - Chest", Addresses.LQ_StoneAndSulfurousFireChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Stone and Sulfurous Fire Entered", Addresses.LQ_StoneAndSulfurousFireEntered, "0", "160", LocationCheckType.Byte)
    };
            return stoneAndSulfurousFireLocations;
        }
        private static List<GenericLocationData> GetTortureWithoutEndData()
        {
            List<GenericLocationData> tortureWithoutEndLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Torture Without End - Ogre Lord Boss", Addresses.LQ_TortureWithoutEndOgreLordBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Torture Without End Entered", Addresses.LQ_TortureWithoutEndEntered, "0", "160", LocationCheckType.Byte)
    };
            return tortureWithoutEndLocations;
        }

        private static List<GenericLocationData> GetWayDownData()
        {
            List<GenericLocationData> wayDownLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Way Down Entered", Addresses.LQ_WayDownEntered, "0", "160", LocationCheckType.Byte)
    };
            return wayDownLocations;
        }

        private static List<GenericLocationData> GetExcavatedHollowData()
        {
            List<GenericLocationData> excavatedHollowLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Excavated Hollow - Chest", Addresses.LQ_ExcavatedHollowChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Excavated Hollow Entered", Addresses.LQ_ExcavatedHollowEntered, "0", "160", LocationCheckType.Byte)
    };
            return excavatedHollowLocations;
        }

        private static List<GenericLocationData> GetPartingRegretsData()
        {
            List<GenericLocationData> partingRegretsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Parting Regrets Entered", Addresses.LQ_PartingRegretsEntered, "0", "160", LocationCheckType.Byte)
    };
            return partingRegretsLocations;
        }

        private static List<GenericLocationData> GetCorridorOfTalesData()
        {
            List<GenericLocationData> corridorOfTalesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Corridor of Tales Entered", Addresses.LQ_CorridorOfTalesEntered, "0", "160", LocationCheckType.Byte)
    };
            return corridorOfTalesLocations;
        }

        private static List<GenericLocationData> GetDustShallEatTheDaysData()
        {
            List<GenericLocationData> dustShallEatTheDaysLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Dust Shall Eat the Days Entered", Addresses.LQ_DustShallEatTheDaysEntered, "0", "160", LocationCheckType.Byte)
    };
            return dustShallEatTheDaysLocations;
        }

        private static List<GenericLocationData> GetHallOfTheWagePayingData()
        {
            List<GenericLocationData> hallOfTheWagePayingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Hall of the Wage-Paying - Snow Dragon Boss", Addresses.LQ_HallOfTheWagePayingSnowDragonBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("LQ - Hall of the Wage-Paying Entered", Addresses.LQ_HallOfTheWagePayingEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallOfTheWagePayingLocations;
        }

        private static List<GenericLocationData> GetTunnelOfTheHeartlessData()
        {
            List<GenericLocationData> tunnelOfTheHeartlessLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("LQ - Tunnel of the Heartless Entered", Addresses.LQ_TunnelOfTheHeartlessEntered, "0", "160", LocationCheckType.Byte)
    };
            return tunnelOfTheHeartlessLocations;
        }

        private static List<GenericLocationData> GetTheCageData()
        {
            List<GenericLocationData> theCageLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Cage Entered", Addresses.IM1_TheCageEntered, "0", "160", LocationCheckType.Byte)
    };
            return theCageLocations;
        }

        private static List<GenericLocationData> GetTheCauldronData()
        {
            List<GenericLocationData> theCauldronLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Cauldron - Gargoyle Boss", Addresses.IM1_TheCauldronGargoyleBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - The Cauldron - Wraith Boss", Addresses.IM1_TheCauldronWraithBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - The Cauldron - Tearose Sigil Unlock", Addresses.IM1_TheCauldronTearoseSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - The Cauldron Entered", Addresses.IM1_TheCauldronEntered, "0", "160", LocationCheckType.Byte)
    };
            return theCauldronLocations;
        }

        private static List<GenericLocationData> GetWoodenHorseData()
        {
            List<GenericLocationData> woodenHorseLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Wooden Horse Entered", Addresses.IM1_WoodenHorseEntered, "0", "160", LocationCheckType.Byte)
    };
            return woodenHorseLocations;
        }

        private static List<GenericLocationData> GetStarvationData()
        {
            List<GenericLocationData> starvationLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Starvation - Wraith Boss", Addresses.IM1_StarvationWraithBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Starvation - Mummy Boss", Addresses.IM1_StarvationMummyBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Starvation Entered", Addresses.IM1_StarvationEntered, "0", "160", LocationCheckType.Byte)
    };
            return starvationLocations;
        }

        private static List<GenericLocationData> GetTheBreastRipperData()
        {
            List<GenericLocationData> theBreastRipperLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Breast Ripper Entered", Addresses.IM1_TheBreastRipperEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBreastRipperLocations;
        }

        private static List<GenericLocationData> GetTheWheelData()
        {
            List<GenericLocationData> theWheelLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Wheel - Chest", Addresses.IM1_TheWheelChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - The Wheel Entered", Addresses.IM1_TheWheelEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWheelLocations;
        }

        private static List<GenericLocationData> GetTheBranksData()
        {
            List<GenericLocationData> theBranksLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Branks - Chest", Addresses.IM1_TheBranksChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - The Branks Entered", Addresses.IM1_TheBranksEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBranksLocations;
        }

        private static List<GenericLocationData> GetThePearData()
        {
            List<GenericLocationData> thePearLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Pear Entered", Addresses.IM1_ThePearEntered, "0", "160", LocationCheckType.Byte)
    };
            return thePearLocations;
        }

        private static List<GenericLocationData> GetTheJudasCradleData()
        {
            List<GenericLocationData> theJudasCradleLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Judas Cradle - Chest", Addresses.IM1_TheJudasCradleChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - The Judas Cradle Entered", Addresses.IM1_TheJudasCradleEntered, "0", "160", LocationCheckType.Byte)
    };
            return theJudasCradleLocations;
        }

        private static List<GenericLocationData> GetTheWhirlygigData()
        {
            List<GenericLocationData> theWhirlygigLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Whirlygig Entered", Addresses.IM1_TheWhirlygigEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWhirlygigLocations;
        }

        private static List<GenericLocationData> GetSpanishTicklerData()
        {
            List<GenericLocationData> spanishTicklerLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Spanish Tickler - Wyvern Knight Boss", Addresses.IM1_SpanishTicklerWyvernKnightBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Spanish Tickler Entered", Addresses.IM1_SpanishTicklerEntered, "0", "160", LocationCheckType.Byte)
    };
            return spanishTicklerLocations;
        }

        private static List<GenericLocationData> GetHereticsForkData()
        {
            List<GenericLocationData> hereticsForkLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Heretic's Fork - Freeze Floor Trap", Addresses.IM1_HereticsForkFreezeFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Heretic's Fork - Gust Floor Trap", Addresses.IM1_HereticsForkGustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Heretic's Fork Entered", Addresses.IM1_HereticsForkEntered, "0", "160", LocationCheckType.Byte)
    };
            return hereticsForkLocations;
        }

        private static List<GenericLocationData> GetTheChairOfSpikesData()
        {
            List<GenericLocationData> theChairOfSpikesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Chair of Spikes Entered", Addresses.IM1_TheChairOfSpikesEntered, "0", "160", LocationCheckType.Byte)
    };
            return theChairOfSpikesLocations;
        }

        private static List<GenericLocationData> GetBloodingData()
        {
            List<GenericLocationData> bloodingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Blooding - Death Vapor Floor Trap", Addresses.IM1_BloodingDeathVaporFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Blooding - Eruption Floor Trap", Addresses.IM1_BloodingEruptionFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Blooding Entered", Addresses.IM1_BloodingEntered, "0", "160", LocationCheckType.Byte)
    };
            return bloodingLocations;
        }

        private static List<GenericLocationData> GetBootikensData()
        {
            List<GenericLocationData> bootikensLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Bootikens Entered", Addresses.IM1_BootikensEntered, "0", "160", LocationCheckType.Byte)
    };
            return bootikensLocations;
        }

        private static List<GenericLocationData> GetBurialData()
        {
            List<GenericLocationData> burialLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Burial - Iron Golem Boss", Addresses.IM1_BurialIronGolemBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Burial Entered", Addresses.IM1_BurialEntered, "0", "160", LocationCheckType.Byte)
    };
            return burialLocations;
        }

        private static List<GenericLocationData> GetBurningData()
        {
            List<GenericLocationData> burningLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Burning - Terra Thrust Floor Trap", Addresses.IM1_BurningTerraThrustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Burning - Holy Light Floor Trap", Addresses.IM1_BurningHolyLightFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Burning Entered", Addresses.IM1_BurningEntered, "0", "160", LocationCheckType.Byte)
    };
            return burningLocations;
        }

        private static List<GenericLocationData> GetCleansingTheSoulData()
        {
            List<GenericLocationData> cleansingTheSoulLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Cleansing the Soul Entered", Addresses.IM1_CleansingTheSoulEntered, "0", "160", LocationCheckType.Byte)
    };
            return cleansingTheSoulLocations;
        }

        private static List<GenericLocationData> GetTheDuckingStoolData()
        {
            List<GenericLocationData> theDuckingStoolLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Ducking Stool - Chest", Addresses.IM1_TheDuckingStoolChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - The Ducking Stool Entered", Addresses.IM1_TheDuckingStoolEntered, "0", "160", LocationCheckType.Byte)
    };
            return theDuckingStoolLocations;
        }

        private static List<GenericLocationData> GetTheGarotteData()
        {
            List<GenericLocationData> theGarotteLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - The Garotte Entered", Addresses.IM1_TheGarotteEntered, "0", "160", LocationCheckType.Byte)
    };
            return theGarotteLocations;
        }

        private static List<GenericLocationData> GetHangingData()
        {
            List<GenericLocationData> hangingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Hanging - Steel Key Unlock", Addresses.IM1_HangingSteelKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Hanging Entered", Addresses.IM1_HangingEntered, "0", "160", LocationCheckType.Byte)
    };
            return hangingLocations;
        }

        private static List<GenericLocationData> GetImpalementData()
        {
            List<GenericLocationData> impalementLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Impalement - Platinum Key Unlock", Addresses.IM1_ImpalementPlatinumKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Impalement Entered", Addresses.IM1_ImpalementEntered, "0", "160", LocationCheckType.Byte)
    };
            return impalementLocations;
        }

        private static List<GenericLocationData> GetKnottingData()
        {
            List<GenericLocationData> knottingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM1 - Knotting - Wyvern Queen Boss", Addresses.IM1_KnottingWyvernQueenBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM1 - Knotting Entered", Addresses.IM1_KnottingEntered, "0", "160", LocationCheckType.Byte)
    };
            return knottingLocations;
        }

        private static List<GenericLocationData> GetTheEunicsLotData()
        {
            List<GenericLocationData> theEunicsLotLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - The Eunics' Lot Entered", Addresses.IM2_TheEunicsLotEntered, "0", "160", LocationCheckType.Byte)
    };
            return theEunicsLotLocations;
        }

        private static List<GenericLocationData> GetOrdealByFireData()
        {
            List<GenericLocationData> ordealByFireLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - Ordeal By Fire - Dark Dragon Boss", Addresses.IM2_OrdealByFireDarkDragonBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - Ordeal By Fire Entered", Addresses.IM2_OrdealByFireEntered, "0", "160", LocationCheckType.Byte)
    };
            return ordealByFireLocations;
        }

        private static List<GenericLocationData> GetTheOvenAtNeisseData()
        {
            List<GenericLocationData> theOvenAtNeisseLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - The Oven at Neisse Entered", Addresses.IM2_TheOvenAtNeisseEntered, "0", "160", LocationCheckType.Byte)
    };
            return theOvenAtNeisseLocations;
        }

        private static List<GenericLocationData> GetPressingData()
        {
            List<GenericLocationData> pressingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - Pressing - Ravana Boss", Addresses.IM2_PressingRavanaBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - Pressing Entered", Addresses.IM2_PressingEntered, "0", "160", LocationCheckType.Byte)
    };
            return pressingLocations;
        }

        private static List<GenericLocationData> GetTheMindBurnsData()
        {
            List<GenericLocationData> theMindBurnsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - The Mind Burns - Freeze Floor Trap", Addresses.IM2_TheMindBurnsFreezeFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - The Mind Burns - Gust Floor Trap", Addresses.IM2_TheMindBurnsGustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - The Mind Burns Entered", Addresses.IM2_TheMindBurnsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theMindBurnsLocations;
        }

        private static List<GenericLocationData> GetTheRackData()
        {
            List<GenericLocationData> theRackLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - The Rack Entered", Addresses.IM2_TheRackEntered, "0", "160", LocationCheckType.Byte)
    };
            return theRackLocations;
        }

        private static List<GenericLocationData> GetTheSawData()
        {
            List<GenericLocationData> theSawLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - The Saw - Dragon Zombie Boss", Addresses.IM2_TheSawDragonZombieBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - The Saw Entered", Addresses.IM2_TheSawEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSawLocations;
        }

        private static List<GenericLocationData> GetTheColdsBridleData()
        {
            List<GenericLocationData> theColdsBridleLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - The Cold's Bridle - Curse Panel Floor Trap", Addresses.IM2_TheColdsBridleCursePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - The Cold's Bridle - Death Vapor Floor Trap", Addresses.IM2_TheColdsBridleDeathVaporFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - The Cold's Bridle - Poison Panel Floor Trap", Addresses.IM2_TheColdsBridlePoisonPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - The Cold's Bridle Entered", Addresses.IM2_TheColdsBridleEntered, "0", "160", LocationCheckType.Byte)
    };
            return theColdsBridleLocations;
        }

        private static List<GenericLocationData> GetTheShinViceData()
        {
            List<GenericLocationData> theShinViceLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - The Shin-Vice - Ogre Zombie Boss", Addresses.IM2_TheShinViceOgreZombieBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - The Shin-Vice - Death Boss", Addresses.IM2_TheShinViceDeathBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - The Shin-Vice Entered", Addresses.IM2_TheShinViceEntered, "0", "160", LocationCheckType.Byte)
    };
            return theShinViceLocations;
        }

        private static List<GenericLocationData> GetTheSpiderData()
        {
            List<GenericLocationData> theSpiderLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - The Spider Entered", Addresses.IM2_TheSpiderEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSpiderLocations;
        }

        private static List<GenericLocationData> GetLeadSprinklerData()
        {
            List<GenericLocationData> leadSprinklerLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - Lead Sprinkler - Chest", Addresses.IM2_LeadSprinklerChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - Lead Sprinkler - Paralysis Panel Floor Trap", Addresses.IM2_LeadSprinklerParalysisPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - Lead Sprinkler Entered", Addresses.IM2_LeadSprinklerEntered, "0", "160", LocationCheckType.Byte)
    };
            return leadSprinklerLocations;
        }

        private static List<GenericLocationData> GetSquassationData()
        {
            List<GenericLocationData> squassationLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("IM2 - Squassation - Chest", Addresses.IM2_SquassationChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - Squassation - Poison Panel Floor Trap", Addresses.IM2_SquassationPoisonPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - Squassation - Terra Thrust Floor Trap", Addresses.IM2_SquassationTerraThrustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("IM2 - Squassation Entered", Addresses.IM2_SquassationEntered, "0", "160", LocationCheckType.Byte)
    };
            return squassationLocations;
        }

        private static List<GenericLocationData> GetTheStrappadoData()
        {
            List<GenericLocationData> strappedLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - The Strappado Entered", Addresses.IM2_TheStrappadoEntered, "0", "160", LocationCheckType.Byte)
            };

            return strappedLocations;
        }
        private static List<GenericLocationData> GetThumbscrewsData()
        {
            List<GenericLocationData> thumbscrewsLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Thumbscrews Entered", Addresses.IM2_ThumbscrewsEntered, "0", "160", LocationCheckType.Byte)
            };

            return thumbscrewsLocations;
        }

        private static List<GenericLocationData> GetPendulumData()
        {
            List<GenericLocationData> pendulumLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Pendulum - Curse Panel Floor Trap", Addresses.IM2_PendulumCursePanelFloorTrap, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("IM2 - Pendulum Entered", Addresses.IM2_PendulumEntered, "0", "160", LocationCheckType.Byte)
            };

            return pendulumLocations;
        }

        private static List<GenericLocationData> GetDraggingData()
        {
            List<GenericLocationData> draggingLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Dragging - Curse Panel Floor Trap", Addresses.IM2_DraggingCursePanelFloorTrap, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("IM2 - Dragging Entered", Addresses.IM2_DraggingEntered, "0", "160", LocationCheckType.Byte)
            };

            return draggingLocations;
        }
        private static List<GenericLocationData> GetStrangulationData()
        {
            List<GenericLocationData> strangulationLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Strangulation Entered", Addresses.IM2_StrangulationEntered, "0", "160", LocationCheckType.Byte)
            };

            return strangulationLocations;
        }
        private static List<GenericLocationData> GetTablillasData()
        {
            List<GenericLocationData> tablillasLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Tablillas Entered", Addresses.IM2_TablillasEntered, "0", "160", LocationCheckType.Byte)
            };

            return tablillasLocations;
        }
        private static List<GenericLocationData> GetTongueSlicerData()
        {
            List<GenericLocationData> tongueSlicerLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Tongue Slicer Entered", Addresses.IM2_TongueSlicerEntered, "0", "160", LocationCheckType.Byte)
            };

            return tongueSlicerLocations;
        }

        private static List<GenericLocationData> GetOrdealByWaterData()
        {
            List<GenericLocationData> ordealByWaterLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Ordeal By Water Entered", Addresses.IM2_OrdealByWaterEntered, "0", "160", LocationCheckType.Byte)
            };

            return ordealByWaterLocations;
        }

        private static List<GenericLocationData> GetBrankData()
        {
            List<GenericLocationData> BrankLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Brank Entered", Addresses.IM2_BrankEntered, "0", "160", LocationCheckType.Byte)
            };

            return BrankLocations;
        }

        private static List<GenericLocationData> GetTormentumInsomniaeData()
        {
            List<GenericLocationData> tormentumInsomniaeLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM2 - Tormentum Insomniae Entered", Addresses.IM2_TormentumInsomniaeEntered, "0", "160", LocationCheckType.Byte)
            };

            return tormentumInsomniaeLocations;
        }

        private static List<GenericLocationData> GetTheIronMaidenData()
        {
            List<GenericLocationData> theIronMaidenLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM3 - The Iron Maiden - Asura Boss", Addresses.IM3_TheIronMaidenAsuraBossDefeat, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("IM3 - The Iron Maiden Entered", Addresses.IM3_TheIronMaidenEntered, "0", "160", LocationCheckType.Byte)
            };

            return theIronMaidenLocations;
        }

        private static List<GenericLocationData> GetJudgementData()
        {
            List<GenericLocationData> judgementLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM3 - Judgement Entered", Addresses.IM3_JudgementEntered, "0", "160", LocationCheckType.Byte)
            };

            return judgementLocations;
        }

        private static List<GenericLocationData> GetSaintElmosBeltData()
        {
            List<GenericLocationData> saintElmosBeltLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM3 - Saint Elmo's Belt - Chest", Addresses.IM3_SaintElmosBeltChest, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("IM3 - Saint Elmo's Belt Entered", Addresses.IM3_SaintElmosBeltEntered, "0", "160", LocationCheckType.Byte)
            };

            return saintElmosBeltLocations;
        }

        private static List<GenericLocationData> GetDunkingTheWitchData()
        {
            List<GenericLocationData> dunkingTheWitchLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("IM3 - Dunking The Witch - Chest", Addresses.IM3_DunkingTheWitchChest, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("IM3 - Dunking The Witch Entered", Addresses.IM3_DunkingTheWitchEntered, "0", "160", LocationCheckType.Byte)
            };

            return dunkingTheWitchLocations;
        }

        private static List<GenericLocationData> GetIntoHolyBattleData()
        {
            List<GenericLocationData> intoHolyBattleLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("GC1 - Into Holy Battle Entered", Addresses.GC1_IntoHolyBattleEntered, "0", "160", LocationCheckType.Byte)
            };

            return intoHolyBattleLocations;
        }

        private static List<GenericLocationData> GetThePoisonedChapelData()
        {
            List<GenericLocationData> thePoisonedChapelLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("GC1 - The Poisoned Chapel - Laurel Sigil Unlock", Addresses.GC1_ThePoisonedChapelLaurelSigilUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("GC1 - The Poisoned Chapel Entered", Addresses.GC1_ThePoisonedChapelEntered, "0", "160", LocationCheckType.Byte)
            };

            return thePoisonedChapelLocations;
        }

        private static List<GenericLocationData> GetSinAndPunishmentData()
        {
            List<GenericLocationData> sinAndPunishmentLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("GC1 - Sin and Punishment - Curse Panel Floor Trap", Addresses.GC1_SinAndPunishmentCursePanelFloorTrap, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("GC1 - Sin and Punishment - Eruption Panel Floor Trap", Addresses.GC1_SinAndPunishmentEruptionPanelFloorTrap, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("GC1 - Sin and Punishment Entered", Addresses.GC1_SinAndPunishmentEntered, "0", "160", LocationCheckType.Byte)
            };

            return sinAndPunishmentLocations;
        }

        private static List<GenericLocationData> GetALightInTheDarkData()
        {
            List<GenericLocationData> aLightInTheDarkLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("GC1 - A Light in the Dark - Arch Dragon Boss", Addresses.GC1_ALightInTheDarkArchDragonBossDefeat, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("GC1 - A Light in the Dark Entered", Addresses.GC1_ALightInTheDarkEntered, "0", "160", LocationCheckType.Byte)
            };

            return aLightInTheDarkLocations;
        }

        private static List<GenericLocationData> GetMonksLeapData()
        {
            List<GenericLocationData> monksLeapLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("GC1 - Monk's Leap - Lich Boss", Addresses.GC1_MonksLeapLichBossDefeat, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("GC1 - Monk's Leap Entered", Addresses.GC1_MonksLeapEntered, "0", "160", LocationCheckType.Byte)
            };

            return monksLeapLocations;
        }

        private static List<GenericLocationData> GetHieraticRecollectionsData()
        {
            List<GenericLocationData> hieraticRecollectionsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC1 - Hieratic Recollections Entered", Addresses.GC1_HieraticRecollectionsEntered, "0", "160", LocationCheckType.Byte)
    };
            return hieraticRecollectionsLocations;
        }

        private static List<GenericLocationData> GetTheFlayedConfessionalData()
        {
            List<GenericLocationData> theFlayedConfessionalLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC1 - The Flayed Confessional - Djinn Boss", Addresses.GC1_TheFlayedConfessionalDjinnBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC1 - The Flayed Confessional - Chest", Addresses.GC1_TheFlayedConfessionalChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC1 - The Flayed Confessional Entered", Addresses.GC1_TheFlayedConfessionalEntered, "0", "160", LocationCheckType.Byte)
    };
            return theFlayedConfessionalLocations;
        }

        private static List<GenericLocationData> GetCrackedPleasuresData()
        {
            List<GenericLocationData> crackedPleasuresLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC1 - Cracked Pleasures Entered", Addresses.GC1_CrackedPleasuresEntered, "0", "160", LocationCheckType.Byte)
    };
            return crackedPleasuresLocations;
        }

        private static List<GenericLocationData> GetWhereDarknessSpreadsData()
        {
            List<GenericLocationData> whereDarknessSpreadsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC1 - Where Darkness Spreads - Chest", Addresses.GC1_WhereDarknessSpreadsChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC1 - Where Darkness Spreads Entered", Addresses.GC1_WhereDarknessSpreadsEntered, "0", "160", LocationCheckType.Byte)
    };
            return whereDarknessSpreadsLocations;
        }

        private static List<GenericLocationData> GetStruggleForTheSoulData()
        {
            List<GenericLocationData> struggleForTheSoulLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GCB - Struggle for the Soul - Heal Panel Floor Trap", Addresses.GCB_StruggleForTheSoulHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GCB - Struggle for the Soul Entered", Addresses.GCB_StruggleForTheSoulEntered, "0", "160", LocationCheckType.Byte)
    };
            return struggleForTheSoulLocations;
        }

        private static List<GenericLocationData> GetOrderAndChaosData()
        {
            List<GenericLocationData> orderAndChaosLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GCB - Order and Chaos - Marid Boss", Addresses.GCB_OrderAndChaosMaridBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GCB - Order and Chaos Entered", Addresses.GCB_OrderAndChaosEntered, "0", "160", LocationCheckType.Byte)
    };
            return orderAndChaosLocations;
        }

        private static List<GenericLocationData> GetAnOfferingOfSoulsData()
        {
            List<GenericLocationData> anOfferingOfSoulsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GCB - An Offering of Souls Entered", Addresses.GCB_AnOfferingOfSoulsEntered, "0", "160", LocationCheckType.Byte)
    };
            return anOfferingOfSoulsLocations;
        }

        private static List<GenericLocationData> GetTruthAndLiesData()
        {
            List<GenericLocationData> truthAndLiesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GCB - Truth and Lies - Ifrit Boss", Addresses.GCB_TruthAndLiesIfritBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GCB - Truth and Lies Entered", Addresses.GCB_TruthAndLiesEntered, "0", "160", LocationCheckType.Byte)
    };
            return truthAndLiesLocations;
        }

        // Sanity and Madness
        private static List<GenericLocationData> GetSanityAndMadnessData()
        {
            List<GenericLocationData> sanityandMadnessLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GCB - Sanity and Madness - Iron Crab Boss", Addresses.GCB_SanityandMadnessIronCrabBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GCB - Sanity and Madness Entered", Addresses.GCB_SanityandMadnessEntered, "0", "160", LocationCheckType.Byte)
    };
            return sanityandMadnessLocations;
        }

        // The Victor's Laurels
        private static List<GenericLocationData> GetTheVictorsLaurelsData()
        {
            List<GenericLocationData> theVictorsLaurelsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GCB - The Victor's Laurels Entered", Addresses.GCB_TheVictorsLaurelsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theVictorsLaurelsLocations;
        }

        // Free from Base Desires
        private static List<GenericLocationData> GetFreeFromBaseDesiresData()
        {
            List<GenericLocationData> freefromBaseDesiresLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - Free from Base Desires Entered", Addresses.GC2_FreefromBaseDesiresEntered, "0", "160", LocationCheckType.Byte)
    };
            return freefromBaseDesiresLocations;
        }

        // Abasement from Above
        private static List<GenericLocationData> GetAbasementFromAboveData()
        {
            List<GenericLocationData> abasementfromAboveLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - Abasement from Above - Poison Panel Floor Trap", Addresses.GC2_AbasementfromAbovePoisonPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - Abasement from Above - Paralysis Panel Floor Trap", Addresses.GC2_AbasementfromAboveParalysisPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - Abasement from Above - Curse Panel Floor Trap", Addresses.GC2_AbasementfromAboveCursePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - Abasement from Above Entered", Addresses.GC2_AbasementfromAboveEntered, "0", "160", LocationCheckType.Byte)
    };
            return abasementfromAboveLocations;
        }

        // The Convent Room
        private static List<GenericLocationData> GetTheConventRoomData()
        {
            List<GenericLocationData> theConventRoomLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - The Convent Room Entered", Addresses.GC2_TheConventRoomEntered, "0", "160", LocationCheckType.Byte)
    };
            return theConventRoomLocations;
        }

        // The Hall of Broken Vows
        private static List<GenericLocationData> GetTheHallOfBrokenVowsData()
        {
            List<GenericLocationData> theHallofBrokenVowsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - The Hall of Broken Vows - Acacia Sigil Unlock", Addresses.GC2_TheHallofBrokenVowsAcaciaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - The Hall of Broken Vows - Flame Dragon Boss", Addresses.GC2_TheHallofBrokenVowsFlameDragonBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - The Hall of Broken Vows Entered", Addresses.GC2_TheHallofBrokenVowsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theHallofBrokenVowsLocations;
        }

        // Light and Dark Wage War
        private static List<GenericLocationData> GetLightAndDarkWageWarData()
        {
            List<GenericLocationData> lightandDarkWageWarLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - Light and Dark Wage War Entered", Addresses.GC2_LightandDarkWageWarEntered, "0", "160", LocationCheckType.Byte)
    };
            return lightandDarkWageWarLocations;
        }

        // An Arrow into Darkness
        private static List<GenericLocationData> GetAnArrowIntoDarknessData()
        {
            List<GenericLocationData> anArrowintoDarknessLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - An Arrow into Darkness - Chest", Addresses.GC2_AnArrowintoDarknessChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - An Arrow into Darkness Entered", Addresses.GC2_AnArrowintoDarknessEntered, "0", "160", LocationCheckType.Byte)
    };
            return anArrowintoDarknessLocations;
        }

        // He Screams for Mercy
        private static List<GenericLocationData> GetHeScreamsForMercyData()
        {
            List<GenericLocationData> heScreamsforMercyLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - He Screams for Mercy - Terra Thrust Floor Trap", Addresses.GC2_HeScreamsforMercyTerraThrustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - He Screams for Mercy - Cure Panel Floor Trap", Addresses.GC2_HeScreamsforMercyCurePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - He Screams for Mercy Entered", Addresses.GC2_HeScreamsforMercyEntered, "0", "160", LocationCheckType.Byte)
    };
            return heScreamsforMercyLocations;
        }

        // The Acolyte's Weakness
        private static List<GenericLocationData> GetTheAcolytesWeaknessData()
        {
            List<GenericLocationData> theAcolytesWeaknessLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - The Acolyte's Weakness Entered", Addresses.GC2_TheAcolytesWeaknessEntered, "0", "160", LocationCheckType.Byte)
    };
            return theAcolytesWeaknessLocations;
        }

        // Maelstrom of Malice
        private static List<GenericLocationData> GetMaelstromOfMaliceData()
        {
            List<GenericLocationData> maelstromOfMaliceLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - Maelstrom of Malice - Lich Lord Boss", Addresses.GC2_MaelstromOfMaliceLichLordBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - Maelstrom of Malice Entered", Addresses.GC2_MaelstromOfMaliceEntered, "0", "160", LocationCheckType.Byte)
    };
            return maelstromOfMaliceLocations;
        }

        // The Melodics of Madness
        private static List<GenericLocationData> GetTheMelodicsOfMadnessData()
        {
            List<GenericLocationData> theMelodicsOfMadnessLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - The Melodics of Madness - Palm Sigil Unlock", Addresses.GC2_TheMelodicsOfMadnessPalmSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - The Melodics of Madness Entered", Addresses.GC2_TheMelodicsOfMadnessEntered, "0", "160", LocationCheckType.Byte)
    };
            return theMelodicsOfMadnessLocations;
        }

        // What Ails You, Kills You
        private static List<GenericLocationData> GetWhatAilsYouKillsYouData()
        {
            List<GenericLocationData> whatAilsYouKillsYouLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC2 - What Ails You, Kills You - Nightmare Boss", Addresses.GC2_WhatAilsYouKillsYouNightmareBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC2 - What Ails You, Kills You Entered", Addresses.GC2_WhatAilsYouKillsYouEntered, "0", "160", LocationCheckType.Byte)
    };
            return whatAilsYouKillsYouLocations;
        }

        // The Wine-Lecher's Fall
        private static List<GenericLocationData> GetTheWineLechersFallData()
        {
            List<GenericLocationData> theWineLechersFallLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC3 - The Wine-Lecher's Fall Entered", Addresses.GC3_TheWineLechersFallEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWineLechersFallLocations;
        }

        // The Heretics' Story (Lower)
        private static List<GenericLocationData> GetTheHereticsStoryLowerData()
        {
            List<GenericLocationData> theHereticsStoryLowerLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC3 - The Heretics' Story (Lower) - Calla Sigil Unlock", Addresses.GC3_TheHereticsStoryLowerCallaSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC3 - The Heretics' Story (Lower) Entered", Addresses.GC3_TheHereticsStoryLowerEntered, "0", "160", LocationCheckType.Byte)
    };
            return theHereticsStoryLowerLocations;
        }

        // The Heretics' Story (Upper)
        private static List<GenericLocationData> GetTheHereticsStoryUpperData()
        {
            List<GenericLocationData> theHereticsStoryUpperLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC3 - The Heretics' Story (Upper) Entered", Addresses.GC3_TheHereticsStoryUpperEntered, "0", "160", LocationCheckType.Byte)
    };
            return theHereticsStoryUpperLocations;
        }

        // Despair of the Fallen
        private static List<GenericLocationData> GetDespairOfTheFallenData()
        {
            List<GenericLocationData> despairOfTheFallenLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC3 - Despair of the Fallen Entered", Addresses.GC3_DespairOfTheFallenEntered, "0", "160", LocationCheckType.Byte)
    };
            return despairOfTheFallenLocations;
        }

        // Hopes of the Idealist
        private static List<GenericLocationData> GetHopesOfTheIdealistData()
        {
            List<GenericLocationData> hopesOfTheIdealistLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC3 - Hopes of the Idealist - Dao Boss", Addresses.GC3_HopesOfTheIdealistDaoBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("GC3 - Hopes of the Idealist Entered", Addresses.GC3_HopesOfTheIdealistEntered, "0", "160", LocationCheckType.Byte)
    };
            return hopesOfTheIdealistLocations;
        }

        // Where the Soul Rots
        private static List<GenericLocationData> GetWhereTheSoulRotsData()
        {
            List<GenericLocationData> whereTheSoulRotsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC3 - Where the Soul Rots Entered", Addresses.GC3_WhereTheSoulRotsEntered, "0", "160", LocationCheckType.Byte)
    };
            return whereTheSoulRotsLocations;
        }

        // The Atrium
        private static List<GenericLocationData> GetTheAtriumData()
        {
            List<GenericLocationData> theAtriumLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("GC4 - The Atrium Entered", Addresses.GC4_TheAtriumEntered, "0", "160", LocationCheckType.Byte)
    };
            return theAtriumLocations;
        }

        private static List<GenericLocationData> GetDomeData()
        {
            List<GenericLocationData> domeLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("GCD - Dome - Guildenstern Boss", Addresses.GCD_DomeGuildesternBossDefeat, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("GCD - Dome Entered", Addresses.GCD_DomeEntered, "0", "160", LocationCheckType.Byte)
            };
            return domeLocations;
        }

        private static List<GenericLocationData> GetPalingData()
        {
            List<GenericLocationData> palingLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("GCD - Paling - Guildenstern Apotheos Boss", Addresses.GCD_PalingGuildesternApotheosBossDefeat, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("GCD - Paling Entered", Addresses.GCD_PalingEntered, "0", "160", LocationCheckType.Byte)
            };
            return palingLocations;
        }

        private static List<GenericLocationData> GetStairToTheSinnersData()
        {
            List<GenericLocationData> stairToTheSinnersLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("FP - Stair to the Sinners Entered", Addresses.FP_StairToTheSinnersEntered, "0", "160", LocationCheckType.Byte)
            };
            return stairToTheSinnersLocations;
        }

        private static List<GenericLocationData> GetSlaughterOfTheInnocentData()
        {
            List<GenericLocationData> slaughterOfTheInnocentLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("FP - Slaughter of the Innocent - Damascus Golem Boss", Addresses.FP_SlaughterOfTheInnocentDamascusGolemBossDefeat, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("FP - Slaughter of the Innocent Entered", Addresses.FP_SlaughterOfTheInnocentEntered, "0", "160", LocationCheckType.Byte)
            };
            return slaughterOfTheInnocentLocations;
        }

        private static List<GenericLocationData> GetTheOracleSinsNoMoreData()
        {
            List<GenericLocationData> theOracleSinsNoMoreLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("FP - The Oracle Sins No More - Curse Panel Floor Trap", Addresses.FP_TheOracleSinsNoMoreCursePanelFloorTrap, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("FP - The Oracle Sins No More - Holy Light Floor Trap", Addresses.FP_TheOracleSinsNoMoreHolyLightFloorTrap, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("FP - The Oracle Sins No More Entered", Addresses.FP_TheOracleSinsNoMoreEntered, "0", "160", LocationCheckType.Byte)
            };
            return theOracleSinsNoMoreLocations;
        }

        private static List<GenericLocationData> GetTheFallenKnightData()
        {
            List<GenericLocationData> theFallenKnightLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("FP - The Fallen Knight - Chest", Addresses.FP_TheFallenKnightChest, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("FP - The Fallen Knight Entered", Addresses.FP_TheFallenKnightEntered, "0", "160", LocationCheckType.Byte)
            };
            return theFallenKnightLocations;
        }

        private static List<GenericLocationData> GetAwaitingRetributionData()
        {
            List<GenericLocationData> awaitingRetributionLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("FP - Awaiting Retribution - Chest", Addresses.FP_AwaitingRetributionChest, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("FP - Awaiting Retribution Entered", Addresses.FP_AwaitingRetributionEntered, "0", "160", LocationCheckType.Byte)
            };
            return awaitingRetributionLocations;
        }

        private static List<GenericLocationData> GetShelterFromTheQuakeData()
        {
            List<GenericLocationData> shelterFromTheQuakeLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("ESC - Shelter From the Quake - Gold Key Unlock", Addresses.ESC_ShelterFromTheQuakeGoldKeyUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("ESC - Shelter From the Quake - Silver Key Unlock", Addresses.ESC_ShelterFromTheQuakeSilverKeyUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("ESC - Shelter From the Quake Entered", Addresses.ESC_ShelterFromTheQuakeEntered, "0", "160", LocationCheckType.Byte)
            };
            return shelterFromTheQuakeLocations;
        }

        private static List<GenericLocationData> GetBuriedAliveData()
        {
            List<GenericLocationData> buriedAliveLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("ESC - Buried Alive - Chest", Addresses.ESC_BuriedAliveChest, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("ESC - Buried Alive Entered", Addresses.ESC_BuriedAliveEntered, "0", "160", LocationCheckType.Byte)
            };
            return buriedAliveLocations;
        }

        private static List<GenericLocationData> GetMovementOfFearData()
        {
            List<GenericLocationData> movementOfFearLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("ESC - Movement of Fear Entered", Addresses.ESC_MovementOfFearEntered, "0", "160", LocationCheckType.Byte)
            };

            return movementOfFearLocations;
        }

        private static List<GenericLocationData> GetFacingYourIllusionsData()
        {
            List<GenericLocationData> facingYourIllusionsLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("ESC - Facing Your Illusions - Diabolos Floor Trap", Addresses.ESC_FacingYourIllusionsDiabolosFloorTrap, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("ESC - Facing Your Illusions Entered", Addresses.ESC_FacingYourIllusionsEntered, "0", "160", LocationCheckType.Byte)
            };

            return facingYourIllusionsLocations;
        }

        private static List<GenericLocationData> GetTheDarknessDrinksData()
        {
            List<GenericLocationData> theDarknessDrinksLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("ESC - The Darkness Drinks Entered", Addresses.ESC_TheDarknessDrinksEntered, "0", "160", LocationCheckType.Byte)
            };

            return theDarknessDrinksLocations;
        }

        private static List<GenericLocationData> GetFearAndLoathingData()
        {
            List<GenericLocationData> fearAndLoathingLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("ESC - Fear and Loathing - Ifrit Boss", Addresses.ESC_FearAndLoathingIfritBossDefeat, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("ESC - Fear and Loathing - Marid Boss", Addresses.ESC_FearAndLoathingMaridBossDefeat, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("ESC - Fear and Loathing Entered", Addresses.ESC_FearAndLoathingEntered, "0", "160", LocationCheckType.Byte)
            };

            return fearAndLoathingLocations;
        }

        private static List<GenericLocationData> GetBloodAndTheBeastData()
        {
            List<GenericLocationData> bloodAndTheBeastLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("ESC - Blood and The Beast - Poison Panel Floor Trap", Addresses.ESC_BloodAndTheBeastPoisonPanelFloorTrap, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("ESC - Blood and The Beast Entered", Addresses.ESC_BloodAndTheBeastEntered, "0", "160", LocationCheckType.Byte)
            };

            return bloodAndTheBeastLocations;
        }

        private static List<GenericLocationData> GetWhereBodyAndSoulPartData()
        {
            List<GenericLocationData> whereBodyAndSoulPartLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("ESC - Where Body and Soul Part - Chest", Addresses.ESC_WhereBodyAndSoulPartChest, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("ESC - Where Body and Soul Part Entered", Addresses.ESC_WhereBodyAndSoulPartEntered, "0", "160", LocationCheckType.Byte)
            };

            return whereBodyAndSoulPartLocations;
        }

        private static List<GenericLocationData> GetStudentsOfDeathData()
        {
            List<GenericLocationData> studentsOfDeathLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("CWW - Students of Death - Crimson Key Unlock", Addresses.CWW_StudentsOfDeathCrimsonKeyUnlock, "0", "160", LocationCheckType.Byte),
                new GenericLocationData("CWW - Students of Death Entered", Addresses.CWW_StudentsOfDeathEntered, "0", "160", LocationCheckType.Byte)
            };

            return studentsOfDeathLocations;
        }

        private static List<GenericLocationData> GetTheGabledHallData()
        {
            List<GenericLocationData> theGabledHallLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("CWW - The Gabled Hall Entered", Addresses.CWW_TheGabledHallEntered, "0", "160", LocationCheckType.Byte)
            };

            return theGabledHallLocations;
        }

        private static List<GenericLocationData> GetWhereTheMasterFellData()
        {
            List<GenericLocationData> whereTheMasterFellLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("CWW - Where the Master Fell Entered", Addresses.CWW_WhereTheMasterFellEntered, "0", "160", LocationCheckType.Byte)
            };

            return whereTheMasterFellLocations;
        }

        private static List<GenericLocationData> GetInWaitOfTheFoeData()
        {
            List<GenericLocationData> inWaitOfTheFoeLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("CWS - In Wait of the Foe Entered", Addresses.CWS_InWaitOfTheFoeEntered, "0", "160", LocationCheckType.Byte)
            };

            return inWaitOfTheFoeLocations;
        }

        private static List<GenericLocationData> GetSwordsForTheLandData()
        {
            List<GenericLocationData> swordsForTheLandLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("CWS - Swords for the Land Entered", Addresses.CWS_SwordsForTheLandEntered, "0", "160", LocationCheckType.Byte)
            };

            return swordsForTheLandLocations;
        }

        private static List<GenericLocationData> GetTheWeepingBoyData()
        {
            List<GenericLocationData> theWeepingBoyLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("CWS - The Weeping Boy Entered", Addresses.CWS_TheWeepingBoyEntered, "0", "160", LocationCheckType.Byte)
            };

            return theWeepingBoyLocations;
        }

        private static List<GenericLocationData> GetWhereWearyRidersRestData()
        {
            List<GenericLocationData> whereWearyRidersRestLocations = new List<GenericLocationData>()
            {
                new GenericLocationData("CWS - Where Weary Riders Rest Entered", Addresses.CWS_WhereWearyRidersRestEntered, "0", "160", LocationCheckType.Byte)
            };

            return whereWearyRidersRestLocations;
        }

        private static List<GenericLocationData> GetTheBoysTrainingRoomData()
        {
            List<GenericLocationData> theBoysTrainingRoomLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWS - The Boy's Training Room Entered", Addresses.CWS_TheBoysTrainingRoomEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBoysTrainingRoomLocations;
        }

        private static List<GenericLocationData> GetFromSquireToKnightData()
        {
            List<GenericLocationData> fromSquireToKnightLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWN - From Squire to Knight - Iron Key Unlock", Addresses.CWN_FromSquiretoKnightIronKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CWN - From Squire to Knight Entered", Addresses.CWN_FromSquiretoKnightEntered, "0", "160", LocationCheckType.Byte)
    };
            return fromSquireToKnightLocations;
        }

        private static List<GenericLocationData> GetTracesOfInvasionPastData()
        {
            List<GenericLocationData> tracesOfInvasionPastLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWN - Traces of Invasion Past Entered", Addresses.CWN_TracesofInvasionPastEntered, "0", "160", LocationCheckType.Byte)
    };
            return tracesOfInvasionPastLocations;
        }

        private static List<GenericLocationData> GetBeForBattlePreparedData()
        {
            List<GenericLocationData> beForBattlePreparedLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWN - Be for Battle Prepared Entered", Addresses.CWN_BeforBattlePreparedEntered, "0", "160", LocationCheckType.Byte)
    };
            return beForBattlePreparedLocations;
        }

        private static List<GenericLocationData> GetDestructionAndRebirthData()
        {
            List<GenericLocationData> destructionAndRebirthLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWN - Destruction and Rebirth Entered", Addresses.CWN_DestructionandRebirthEntered, "0", "160", LocationCheckType.Byte)
    };
            return destructionAndRebirthLocations;
        }

        private static List<GenericLocationData> GetFromBoyToHeroData()
        {
            List<GenericLocationData> fromBoyToHeroLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWN - From Boy to Hero - Clematis Sigil Unlock", Addresses.CWN_FromBoytoHeroClematisSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CWN - From Boy to Hero Entered", Addresses.CWN_FromBoytoHeroEntered, "0", "160", LocationCheckType.Byte)
    };
            return fromBoyToHeroLocations;
        }

        private static List<GenericLocationData> GetAWelcomeInvasionData()
        {
            List<GenericLocationData> aWelcomeInvasionLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWN - A Welcome Invasion Entered", Addresses.CWN_AWelcomeInvasionEntered, "0", "160", LocationCheckType.Byte)
    };
            return aWelcomeInvasionLocations;
        }

        private static List<GenericLocationData> GetTrainAndGrowStrongData()
        {
            List<GenericLocationData> trainAndGrowStrongLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWE - Train and Grow Strong - Rood Inverse Unlock", Addresses.CWE_TrainandGrowStrongRoodInverseUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CWE - Train and Grow Strong Entered", Addresses.CWE_TrainandGrowStrongEntered, "0", "160", LocationCheckType.Byte)
    };
            return trainAndGrowStrongLocations;
        }

        private static List<GenericLocationData> GetTheSquiresGatheringData()
        {
            List<GenericLocationData> theSquiresGatheringLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWE - The Squire's Gathering Entered", Addresses.CWE_TheSquiresGatheringEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSquiresGatheringLocations;
        }

        private static List<GenericLocationData> GetTheInvadersAreFoundData()
        {
            List<GenericLocationData> theInvadersAreFoundLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWE - The Invaders are Found Entered", Addresses.CWE_TheInvadersareFoundEntered, "0", "160", LocationCheckType.Byte)
    };
            return theInvadersAreFoundLocations;
        }

        private static List<GenericLocationData> GetTheDreamWeaversData()
        {
            List<GenericLocationData> theDreamWeaversLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWE - The Dream Weavers Entered", Addresses.CWE_TheDreamWeaversEntered, "0", "160", LocationCheckType.Byte)
    };
            return theDreamWeaversLocations;
        }

        private static List<GenericLocationData> GetTheCorneredSavageData()
        {
            List<GenericLocationData> theCorneredSavageLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CWE - The Cornered Savage Entered", Addresses.CWE_TheCorneredSavageEntered, "0", "160", LocationCheckType.Byte)
    };
            return theCorneredSavageLocations;
        }

        private static List<GenericLocationData> GetHallOfSwornRevengeData()
        {
            List<GenericLocationData> hallofSwornRevengeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Hall of Sworn Revenge - Heal Panel Floor Trap", Addresses.CAT_HallofSwornRevengeHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - Hall of Sworn Revenge - Cure Panel Floor Trap", Addresses.CAT_HallofSwornRevengeCurePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - Hall of Sworn Revenge Entered", Addresses.CAT_HallofSwornRevengeEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallofSwornRevengeLocations;
        }

        private static List<GenericLocationData> GetTheLastBlessingData()
        {
            List<GenericLocationData> theLastBlessingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Last Blessing Entered", Addresses.CAT_TheLastBlessingEntered, "0", "160", LocationCheckType.Byte)
    };
            return theLastBlessingLocations;
        }

        private static List<GenericLocationData> GetTheWeepingCorridorData()
        {
            List<GenericLocationData> theWeepingCorridorLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Weeping Corridor - Freeze Floor Trap", Addresses.CAT_TheWeepingCorridorFreezeFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - The Weeping Corridor Entered", Addresses.CAT_TheWeepingCorridorEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWeepingCorridorLocations;
        }

        private static List<GenericLocationData> GetPersecutionHallData()
        {
            List<GenericLocationData> persecutionHallLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Persecution Hall Entered", Addresses.CAT_PersecutionHallEntered, "0", "160", LocationCheckType.Byte)
    };
            return persecutionHallLocations;
        }

        private static List<GenericLocationData> GetRodentRiddenChamberData()
        {
            List<GenericLocationData> rodentRiddenChamberLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Rodent-Ridden Chamber - Chest", Addresses.CAT_RodentRiddenChamberChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - Rodent-Ridden Chamber Entered", Addresses.CAT_RodentRiddenChamberEntered, "0", "160", LocationCheckType.Byte)
    };
            return rodentRiddenChamberLocations;
        }

        private static List<GenericLocationData> GetShrineToTheMartyrsData()
        {
            List<GenericLocationData> shrinetotheMartyrsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Shrine to the Martyrs Entered", Addresses.CAT_ShrinetotheMartyrsEntered, "0", "160", LocationCheckType.Byte)
    };
            return shrinetotheMartyrsLocations;
        }

        private static List<GenericLocationData> GetTheLamentingMotherWestData()
        {
            List<GenericLocationData> theLamentingMotherWestLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Lamenting Mother (West) - Ghost Boss", Addresses.CAT_TheLamentingMotherWestGhostBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - The Lamenting Mother (West) Entered", Addresses.CAT_TheLamentingMotherWestEntered, "0", "160", LocationCheckType.Byte)
    };
            return theLamentingMotherWestLocations;
        }

        private static List<GenericLocationData> GetTheLamentingMotherEastData()
        {
            List<GenericLocationData> theLamentingMotherEastLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Lamenting Mother (East) - Chest", Addresses.CAT_TheLamentingMotherEastChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - The Lamenting Mother (East) Entered", Addresses.CAT_TheLamentingMotherEastEntered, "0", "160", LocationCheckType.Byte)
    };
            return theLamentingMotherEastLocations;
        }

        private static List<GenericLocationData> GetHallOfDyingHopeData()
        {
            List<GenericLocationData> hallofDyingHopeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Hall of Dying Hope Entered", Addresses.CAT_HallofDyingHopeEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallofDyingHopeLocations;
        }

        private static List<GenericLocationData> GetBanditsHideoutData()
        {
            List<GenericLocationData> banditsHideoutLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Bandits' Hideout - Chest", Addresses.CAT_BanditsHideoutChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - Bandits' Hideout Entered", Addresses.CAT_BanditsHideoutEntered, "0", "160", LocationCheckType.Byte)
    };
            return banditsHideoutLocations;
        }

        private static List<GenericLocationData> GetTheBloodyHallwayData()
        {
            List<GenericLocationData> theBloodyHallwayLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Bloody Hallway Entered", Addresses.CAT_TheBloodyHallwayEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBloodyHallwayLocations;
        }

        private static List<GenericLocationData> GetFaithOvercameFearData()
        {
            List<GenericLocationData> faithOvercameFearLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Faith Overcame Fear Entered", Addresses.CAT_FaithOvercameFearEntered, "0", "160", LocationCheckType.Byte)
    };
            return faithOvercameFearLocations;
        }

        private static List<GenericLocationData> GetTheWitheredSpringData()
        {
            List<GenericLocationData> theWitheredSpringLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Withered Spring - Lily Sigil Unlock", Addresses.CAT_TheWitheredSpringLilySigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - The Withered Spring Entered", Addresses.CAT_TheWitheredSpringEntered, "0", "160", LocationCheckType.Byte)
    };
            return theWitheredSpringLocations;
        }

        private static List<GenericLocationData> GetWorkshopWorkOfArtData()
        {
            List<GenericLocationData> workshopWorkofArtLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Workshop \"Work of Art\" Entered", Addresses.CAT_WorkshopWorkofArtEntered, "0", "160", LocationCheckType.Byte)
    };
            return workshopWorkofArtLocations;
        }

        private static List<GenericLocationData> GetRepentOYeSinnersData()
        {
            List<GenericLocationData> repentOyeSinnersLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Repent, O ye Sinners Entered", Addresses.CAT_RepentOyeSinnersEntered, "0", "160", LocationCheckType.Byte)
    };
            return repentOyeSinnersLocations;
        }

        private static List<GenericLocationData> GetTheReapersVictimsData()
        {
            List<GenericLocationData> theReapersVictimsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Reaper's Victims Entered", Addresses.CAT_TheReapersVictimsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theReapersVictimsLocations;
        }

        private static List<GenericLocationData> GetTheLastStabOfHopeData()
        {
            List<GenericLocationData> theLastStabofHopeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Last Stab of Hope - Cure Panel Floor Trap", Addresses.CAT_TheLastStabofHopeCurePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - The Last Stab of Hope Entered", Addresses.CAT_TheLastStabofHopeEntered, "0", "160", LocationCheckType.Byte)
    };
            return theLastStabofHopeLocations;
        }

        private static List<GenericLocationData> GetHallwayOfHeroesData()
        {
            List<GenericLocationData> hallwayofHeroesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - Hallway of Heroes Entered", Addresses.CAT_HallwayofHeroesEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallwayofHeroesLocations;
        }

        private static List<GenericLocationData> GetTheBeastsDomainData()
        {
            List<GenericLocationData> theBeastsDomainLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("CAT - The Beast's Domain - Lizardman Boss", Addresses.CAT_TheBeastsDomainLizardmanBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("CAT - The Beast's Domain Entered", Addresses.CAT_TheBeastsDomainEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBeastsDomainLocations;
        }

        private static List<GenericLocationData> GetDreamersEntranceData()
        {
            List<GenericLocationData> dreamersEntranceLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Dreamers' Entrance Entered", Addresses.AM1_DreamersEntranceEntered, "0", "160", LocationCheckType.Byte)
    };
            return dreamersEntranceLocations;
        }

        private static List<GenericLocationData> GetTheCrossingData()
        {
            List<GenericLocationData> theCrossingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Crossing Entered", Addresses.AM1_TheCrossingEntered, "0", "160", LocationCheckType.Byte)
    };
            return theCrossingLocations;
        }

        private static List<GenericLocationData> GetMinersRestingHallData()
        {
            List<GenericLocationData> minersRestingHallLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Miners' Resting Hall - Chest", Addresses.AM1_MinersRestingHallChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Miners' Resting Hall Entered", Addresses.AM1_MinersRestingHallEntered, "0", "160", LocationCheckType.Byte)
    };
            return minersRestingHallLocations;
        }

        private static List<GenericLocationData> GetConflictAndAccordData()
        {
            List<GenericLocationData> conflictandAccordLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Conflict and Accord Entered", Addresses.AM1_ConflictandAccordEntered, "0", "160", LocationCheckType.Byte)
    };
            return conflictandAccordLocations;
        }

        private static List<GenericLocationData> GetTheEndOfTheLineData()
        {
            List<GenericLocationData> theEndoftheLineLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The End of the Line Entered", Addresses.AM1_TheEndoftheLineEntered, "0", "160", LocationCheckType.Byte)
    };
            return theEndoftheLineLocations;
        }

        private static List<GenericLocationData> GetTheEarthquakesMarkData()
        {
            List<GenericLocationData> theEarthquakesMarkLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Earthquake's Mark - Hyacinth Sigil Unlock", Addresses.AM1_TheEarthquakesMarkHyacinthSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - The Earthquake's Mark - Eruption Floor Trap", Addresses.AM1_TheEarthquakesMarkEruptionFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - The Earthquake's Mark Entered", Addresses.AM1_TheEarthquakesMarkEntered, "0", "160", LocationCheckType.Byte)
    };
            return theEarthquakesMarkLocations;
        }


        private static List<GenericLocationData> GetCoalMineStorageData()
        {
            List<GenericLocationData> coalMineStorageLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Coal Mine Storage - Chest", Addresses.AM1_CoalMineStorageChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Coal Mine Storage - Poison Panel Floor Trap", Addresses.AM1_CoalMineStoragePoisonPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Coal Mine Storage - Trap Clear Floor Trap", Addresses.AM1_CoalMineStorageTrapClearFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Coal Mine Storage Entered", Addresses.AM1_CoalMineStorageEntered, "0", "160", LocationCheckType.Byte)
    };
            return coalMineStorageLocations;
        }

        private static List<GenericLocationData> GetTheSuicideKingData()
        {
            List<GenericLocationData> theSuicideKingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Suicide King Entered", Addresses.AM1_TheSuicideKingEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSuicideKingLocations;
        }

        private static List<GenericLocationData> GetTheBattlesBeginningData()
        {
            List<GenericLocationData> theBattlesBeginningLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Battle's Beginning - Wyvern Boss", Addresses.AM1_TheBattlesBeginningWyvernBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - The Battle's Beginning Entered", Addresses.AM1_TheBattlesBeginningEntered, "0", "160", LocationCheckType.Byte)
    };
            return theBattlesBeginningLocations;
        }

        private static List<GenericLocationData> GetWhatLiesAheadData()
        {
            List<GenericLocationData> whatLiesAheadLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - What Lies Ahead? - Heal Panel Floor Trap", Addresses.AM1_WhatLiesAheadHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - What Lies Ahead? Entered", Addresses.AM1_WhatLiesAheadEntered, "0", "160", LocationCheckType.Byte)
    };
            return whatLiesAheadLocations;
        }

        private static List<GenericLocationData> GetTheFruitsOfFriendshipData()
        {
            List<GenericLocationData> theFruitsofFriendshipLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Fruits of Friendship Entered", Addresses.AM1_TheFruitsofFriendshipEntered, "0", "160", LocationCheckType.Byte)
    };
            return theFruitsofFriendshipLocations;
        }

        private static List<GenericLocationData> GetThePassionOfLoversData()
        {
            List<GenericLocationData> thePassionofLoversLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Passion of Lovers - Hyacinth Sigil Unlock", Addresses.AM1_ThePassionofLoversHyacinthSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - The Passion of Lovers Entered", Addresses.AM1_ThePassionofLoversEntered, "0", "160", LocationCheckType.Byte)
    };
            return thePassionofLoversLocations;
        }

        private static List<GenericLocationData> GetTheHallOfHopeData()
        {
            List<GenericLocationData> theHallofHopeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Hall of Hope Entered", Addresses.AM1_TheHallofHopeEntered, "0", "160", LocationCheckType.Byte)
    };
            return theHallofHopeLocations;
        }

        private static List<GenericLocationData> GetTheDarkTunnelData()
        {
            List<GenericLocationData> theDarkTunnelLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Dark Tunnel Entered", Addresses.AM1_TheDarkTunnelEntered, "0", "160", LocationCheckType.Byte)
    };
            return theDarkTunnelLocations;
        }

        private static List<GenericLocationData> GetEverwantPassageData()
        {
            List<GenericLocationData> everwantPassageLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Everwant Passage - Silver Key Unlock", Addresses.AM1_EverwantPassageSilverKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Everwant Passage Entered", Addresses.AM1_EverwantPassageEntered, "0", "160", LocationCheckType.Byte)
    };
            return everwantPassageLocations;
        }

        private static List<GenericLocationData> GetMiningRegretsData()
        {
            List<GenericLocationData> miningRegretsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Mining Regrets - Chest", Addresses.AM1_MiningRegretsChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Mining Regrets - Death Vapor Floor Trap", Addresses.AM1_MiningRegretsDeathVaporFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Mining Regrets Entered", Addresses.AM1_MiningRegretsEntered, "0", "160", LocationCheckType.Byte)
    };
            return miningRegretsLocations;
        }

        private static List<GenericLocationData> GetRustInPeaceData()
        {
            List<GenericLocationData> rustinPeaceLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Rust in Peace - Chest", Addresses.AM1_RustinPeaceChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Rust in Peace Entered", Addresses.AM1_RustinPeaceEntered, "0", "160", LocationCheckType.Byte)
    };
            return rustinPeaceLocations;
        }

        private static List<GenericLocationData> GetTheSmeltryData()
        {
            List<GenericLocationData> theSmeltryLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - The Smeltry - Fire Elemental Boss", Addresses.AM1_TheSmeltryFireElementalBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - The Smeltry Entered", Addresses.AM1_TheSmeltryEntered, "0", "160", LocationCheckType.Byte)
    };
            return theSmeltryLocations;
        }

        private static List<GenericLocationData> GetClashOfHyaenasData()
        {
            List<GenericLocationData> clashOfHyaenasLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Clash of Hyaenas Entered", Addresses.AM1_ClashOfHyaenasEntered, "0", "160", LocationCheckType.Byte)
    };
            return clashOfHyaenasLocations;
        }

        private static List<GenericLocationData> GetGreedKnowsNoBoundsData()
        {
            List<GenericLocationData> greedKnowsNoBoundsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Greed Knows No Bounds Entered", Addresses.AM1_GreedKnowsNoBoundsEntered, "0", "160", LocationCheckType.Byte)
    };
            return greedKnowsNoBoundsLocations;
        }

        private static List<GenericLocationData> GetLiveLongAndProsperData()
        {
            List<GenericLocationData> liveLongAndProsperLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Live Long and Prosper - Fern Sigil Unlock", Addresses.AM1_LiveLongAndProsperFernSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Live Long and Prosper Entered", Addresses.AM1_LiveLongAndProsperEntered, "0", "160", LocationCheckType.Byte)
    };
            return liveLongAndProsperLocations;
        }

        private static List<GenericLocationData> GetPrayToTheMineralGodsData()
        {
            List<GenericLocationData> prayToTheMineralGodsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Pray to the Mineral Gods - Fern Sigil Unlock", Addresses.AM1_PrayToTheMineralGodsFernSigilUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Pray to the Mineral Gods Entered", Addresses.AM1_PrayToTheMineralGodsEntered, "0", "160", LocationCheckType.Byte)
    };
            return prayToTheMineralGodsLocations;
        }

        private static List<GenericLocationData> GetTraitorsPartingData()
        {
            List<GenericLocationData> traitorsPartingLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Traitor's Parting - Ogre Boss", Addresses.AM1_TraitorsPartingOgreBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM1 - Traitor's Parting Entered", Addresses.AM1_TraitorsPartingEntered, "0", "160", LocationCheckType.Byte)
    };
            return traitorsPartingLocations;
        }

        private static List<GenericLocationData> GetEscapewayData()
        {
            List<GenericLocationData> escapewayLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM1 - Escapeway Entered", Addresses.AM1_EscapewayEntered, "0", "160", LocationCheckType.Byte)
    };
            return escapewayLocations;
        }

        private static List<GenericLocationData> GetSubtellurianHorrorsData()
        {
            List<GenericLocationData> subtellurianHorrorsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Subtellurian Horrors Entered", Addresses.AM2_SubtellurianHorrorsEntered, "0", "160", LocationCheckType.Byte)
    };
            return subtellurianHorrorsLocations;
        }

        private static List<GenericLocationData> GetDiningInDarknessData()
        {
            List<GenericLocationData> diningInDarknessLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Dining in Darkness - Sky Dragon Boss", Addresses.AM2_DiningInDarknessSkyDragonBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Dining in Darkness Entered", Addresses.AM2_DiningInDarknessEntered, "0", "160", LocationCheckType.Byte)
    };
            return diningInDarknessLocations;
        }

        private static List<GenericLocationData> GetBanditsHollowData()
        {
            List<GenericLocationData> banditsHollowLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Bandit's Hollow - Iron Key Unlock", Addresses.AM2_BanditsHollowIronKeyUnlock, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Bandit's Hollow Entered", Addresses.AM2_BanditsHollowEntered, "0", "160", LocationCheckType.Byte)
    };
            return banditsHollowLocations;
        }

        private static List<GenericLocationData> GetDelusionsOfHappinessData()
        {
            List<GenericLocationData> delusionsOfHappinessLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Delusions of Happiness - Chest", Addresses.AM2_DelusionsOfHappinessChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Delusions of Happiness Entered", Addresses.AM2_DelusionsOfHappinessEntered, "0", "160", LocationCheckType.Byte)
    };
            return delusionsOfHappinessLocations;
        }

        private static List<GenericLocationData> GetWorkThenDieData()
        {
            List<GenericLocationData> workThenDieLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Work, Then Die Entered", Addresses.AM2_WorkThenDieEntered, "0", "160", LocationCheckType.Byte)
    };
            return workThenDieLocations;
        }

        private static List<GenericLocationData> GetRockBottomData()
        {
            List<GenericLocationData> rockBottomLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Rock Bottom Entered", Addresses.AM2_RockBottomEntered, "0", "160", LocationCheckType.Byte)
    };
            return rockBottomLocations;
        }

        private static List<GenericLocationData> GetTheLunaticVeinsData()
        {
            List<GenericLocationData> theLunaticVeinsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - The Lunatic Veins Entered", Addresses.AM2_TheLunaticVeinsEntered, "0", "160", LocationCheckType.Byte)
    };
            return theLunaticVeinsLocations;
        }

        private static List<GenericLocationData> GetTombOfTheRebornData()
        {
            List<GenericLocationData> tombOfTheRebornLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Tomb of the Reborn - Earth Elemental Boss", Addresses.AM2_TombOfTheRebornEarthElementalBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Tomb of the Reborn Entered", Addresses.AM2_TombOfTheRebornEntered, "0", "160", LocationCheckType.Byte)
    };
            return tombOfTheRebornLocations;
        }

        private static List<GenericLocationData> GetFoolsGoldFoolsLossData()
        {
            List<GenericLocationData> foolsGoldFoolsLossLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Fool's Gold, Fool's Loss - Paralysis Panel Floor Trap", Addresses.AM2_FoolsGoldFoolsLossParalysisPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Fool's Gold, Fool's Loss Entered", Addresses.AM2_FoolsGoldFoolsLossEntered, "0", "160", LocationCheckType.Byte)
    };
            return foolsGoldFoolsLossLocations;
        }

        private static List<GenericLocationData> GetKilroyWasHereData()
        {
            List<GenericLocationData> kilroyWasHereLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Kilroy Was Here Entered", Addresses.AM2_KilroyWasHereEntered, "0", "160", LocationCheckType.Byte)
    };
            return kilroyWasHereLocations;
        }

        private static List<GenericLocationData> GetAWagerOfNobleGoldData()
        {
            List<GenericLocationData> aWagerOfNobleGoldLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - A Wager of Noble Gold Entered", Addresses.AM2_AWagerOfNobleGoldEntered, "0", "160", LocationCheckType.Byte)
    };
            return aWagerOfNobleGoldLocations;
        }

        private static List<GenericLocationData> GetLambsToTheSlaughterData()
        {
            List<GenericLocationData> lambsToTheSlaughterLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Lambs to the Slaughter - Heal Panel Floor Trap", Addresses.AM2_LambsToTheSlaughterHealPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Lambs to the Slaughter Entered", Addresses.AM2_LambsToTheSlaughterEntered, "0", "160", LocationCheckType.Byte)
    };
            return lambsToTheSlaughterLocations;
        }

        private static List<GenericLocationData> GetTheOreOfLegendData()
        {
            List<GenericLocationData> theOreOfLegendLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - The Ore of Legend Entered", Addresses.AM2_TheOreOfLegendEntered, "0", "160", LocationCheckType.Byte)
    };
            return theOreOfLegendLocations;
        }

        private static List<GenericLocationData> GetSuicidalDesiresData()
        {
            List<GenericLocationData> suicidalDesiresLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Suicidal Desires - Chest", Addresses.AM2_SuicidalDesiresChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires - Death Vapor Floor Trap", Addresses.AM2_SuicidalDesiresDeathVaporFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires - Paralysis Panel Floor Trap", Addresses.AM2_SuicidalDesiresParalysisPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires - Holy Light Floor Trap", Addresses.AM2_SuicidalDesiresHolyLightFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires - Terra Thrust Floor Trap", Addresses.AM2_SuicidalDesiresTeraThrustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires - Gust Floor Trap", Addresses.AM2_SuicidalDesiresGustFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires - Freeze Floor Trap", Addresses.AM2_SuicidalDesiresFreezeFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires - Eruption Floor Trap", Addresses.AM2_SuicidalDesiresEruptionFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires - Trap Clear Floor Trap", Addresses.AM2_SuicidalDesiresTrapClearFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Suicidal Desires Entered", Addresses.AM2_SuicidalDesiresEntered, "0", "160", LocationCheckType.Byte)
    };
            return suicidalDesiresLocations;
        }

        private static List<GenericLocationData> GetCryOfTheBeastData()
        {
            List<GenericLocationData> cryOfTheBeastLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Cry of the Beast Entered", Addresses.AM2_CryOfTheBeastEntered, "0", "160", LocationCheckType.Byte)
    };
            return cryOfTheBeastLocations;
        }

        private static List<GenericLocationData> GetTheFallenBricklayerData()
        {
            List<GenericLocationData> theFallenBricklayerLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - The Fallen Bricklayer Entered", Addresses.AM2_TheFallenBricklayerEntered, "0", "160", LocationCheckType.Byte)
    };
            return theFallenBricklayerLocations;
        }

        private static List<GenericLocationData> GetHallOfContemplationData()
        {
            List<GenericLocationData> hallOfContemplationLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Hall of Contemplation - Eruption Floor Trap", Addresses.AM2_HallOfContemplationEruptionFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Hall of Contemplation Entered", Addresses.AM2_HallOfContemplationEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallOfContemplationLocations;
        }


        // Hall of the Empty Sconce
        private static List<GenericLocationData> GetHallOfTheEmptySconceData()
        {
            List<GenericLocationData> hallOfTheEmptySconceLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Hall of the Empty Sconce Entered", Addresses.AM2_HallOfTheEmptySconceEntered, "0", "160", LocationCheckType.Byte)
    };
            return hallOfTheEmptySconceLocations;
        }

        // Acolyte's Burial Vault
        private static List<GenericLocationData> GetAcolytesBurialVaultData()
        {
            List<GenericLocationData> acolytesBurialVaultLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Acolyte's Burial Vault - Chest", Addresses.AM2_AcolytesBurialVaultChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Acolyte's Burial Vault Entered", Addresses.AM2_AcolytesBurialVaultEntered, "0", "160", LocationCheckType.Byte)
    };
            return acolytesBurialVaultLocations;
        }

        // The Abandoned Catspaw
        private static List<GenericLocationData> GetTheAbandonedCatspawData()
        {
            List<GenericLocationData> theAbandonedCatspawLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - The Abandoned Catspaw Entered", Addresses.AM2_TheAbandonedCatspawEntered, "0", "160", LocationCheckType.Byte)
    };
            return theAbandonedCatspawLocations;
        }

        // Crossing of Blood
        private static List<GenericLocationData> GetCrossingOfBloodData()
        {
            List<GenericLocationData> crossingOfBloodLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Crossing of Blood - Holy Light Floor Trap", Addresses.AM2_CrossingOfBloodHolyLightFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Crossing of Blood - Diabolos Floor Trap", Addresses.AM2_CrossingOfBloodDiabolosFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Crossing of Blood Entered", Addresses.AM2_CrossingOfBloodEntered, "0", "160", LocationCheckType.Byte)
    };
            return crossingOfBloodLocations;
        }

        // Senses Lost
        private static List<GenericLocationData> GetSensesLostData()
        {
            List<GenericLocationData> sensesLostLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Senses Lost - Eruption Floor Trap", Addresses.AM2_SensesLostEruptionFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Senses Lost - Poison Panel Floor Trap", Addresses.AM2_SensesLostPoisonPanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Senses Lost Entered", Addresses.AM2_SensesLostEntered, "0", "160", LocationCheckType.Byte)
    };
            return sensesLostLocations;
        }

        // Desire's Passage
        private static List<GenericLocationData> GetDesiresPassageData()
        {
            List<GenericLocationData> desiresPassageLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Desire's Passage - Cure Panel Floor Trap", Addresses.AM2_DesiresPassageCurePanelFloorTrap, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Desire's Passage Entered", Addresses.AM2_DesiresPassageEntered, "0", "160", LocationCheckType.Byte)
    };
            return desiresPassageLocations;
        }

        // Way of Lost Children
        private static List<GenericLocationData> GetWayOfLostChildrenData()
        {
            List<GenericLocationData> wayOfLostChildrenLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Way of Lost Children Entered", Addresses.AM2_WayOfLostChildrenEntered, "0", "160", LocationCheckType.Byte)
    };
            return wayOfLostChildrenLocations;
        }

        // Hidden Resources
        private static List<GenericLocationData> GetHiddenResourcesData()
        {
            List<GenericLocationData> hiddenResourcesLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Hidden Resources - Chest", Addresses.AM2_HiddenResourcesChest, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - Hidden Resources Entered", Addresses.AM2_HiddenResourcesEntered, "0", "160", LocationCheckType.Byte)
    };
            return hiddenResourcesLocations;
        }

        // Treaty Room
        private static List<GenericLocationData> GetTreatyRoomData()
        {
            List<GenericLocationData> treatyRoomLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Treaty Room Entered", Addresses.AM2_TreatyRoomEntered, "0", "160", LocationCheckType.Byte)
    };
            return treatyRoomLocations;
        }

        // The Miner's End
        private static List<GenericLocationData> GetTheMinersEndData()
        {
            List<GenericLocationData> theMinersEndLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - The Miner's End - Air Elemental Boss", Addresses.AM2_TheMinersEndAirElementalBossDefeat, "0", "160", LocationCheckType.Byte),
        new GenericLocationData("AM2 - The Miner's End Entered", Addresses.AM2_TheMinersEndEntered, "0", "160", LocationCheckType.Byte)
    };
            return theMinersEndLocations;
        }

        // Gambler's Passage
        private static List<GenericLocationData> GetGamblersPassageData()
        {
            List<GenericLocationData> gamblersPassageLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Gambler's Passage Entered", Addresses.AM2_GamblersPassageEntered, "0", "160", LocationCheckType.Byte)
    };
            return gamblersPassageLocations;
        }

        // Revelation Shaft
        private static List<GenericLocationData> GetRevelationShaftData()
        {
            List<GenericLocationData> revelationShaftLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Revelation Shaft Entered", Addresses.AM2_RevelationShaftEntered, "0", "160", LocationCheckType.Byte)
    };
            return revelationShaftLocations;
        }

        // Corridor of Shade
        private static List<GenericLocationData> GetCorridorOfShadeData()
        {
            List<GenericLocationData> corridorOfShadeLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("AM2 - Corridor of Shade Entered", Addresses.AM2_CorridorOfShadeEntered, "0", "160", LocationCheckType.Byte)
    };
            return corridorOfShadeLocations;
        }

        // Credits
        private static List<GenericLocationData> GetCreditsData()
        {
            List<GenericLocationData> creditsLocations = new List<GenericLocationData>()
    {
        new GenericLocationData("Game End: Credits", Addresses.GE_Credits, "0", "160", LocationCheckType.Byte)
    };
            return creditsLocations;
        }

    }
}