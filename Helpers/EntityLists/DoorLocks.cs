namespace VagrantStoryArchipelago.Data
{
    /// <summary>One locked doorway on one side of a room. Both sides of every key/sigil door are listed.</summary>
    /// <param name="MapId">Value of Addresses.CurrentMapandRoomID (mpd index &lt;&lt; 8 | zone id).</param>
    /// <param name="TileX">Tile of the door in that room (same as the lock entry / warp tile).</param>
    /// <param name="KeyName">Key in ItemDatabase.Items.</param>
    public record DoorLockData(ushort MapId, byte TileX, byte TileZ, byte Surface, string KeyName)
    {
        /// <summary>Item id as the game stores it in a lock entry (0x100 | inventory item id).</summary>
        public ushort KeyItemId => (ushort)(0x100 | ItemDatabase.Items[KeyName].ItemID);
    }

    /// <summary>
    /// Every key/sigil door in the game, taken from the MPD room files (section A lock entries and the
    /// door warps). In the original game many doors only lock from one side; the Archipelago logic treats them as
    /// locked from both, so MapHelper.UpdateDoorLocksInMap writes the missing side into the loaded room.
    /// Doors with no lock entry on the open side cannot be patched (the entry array is fixed size) and are listed in NoLockSlot.
    /// </summary>
    public static class DoorLocks
    {
        public static readonly List<DoorLockData> All = new()
        {
            // The Gallows
            new(0x000C, 7, 0, 0, "Stock Sigil"), // to Blackmarket of Wines

            // Prisoners' Niche
            new(0x000F, 0, 2, 0, "Lily Sigil"), // to The Withered Spring
            new(0x000F, 0, 3, 0, "Lily Sigil"), // to The Withered Spring

            // Students of Death
            new(0x001C, 6, 7, 0, "Crimson Key"), // to Rue Vermillion

            // Rue Vermillion
            new(0x0020, 0, 11, 0, "Crimson Key"), // to Students of Death

            // The House Khazabas
            new(0x0025, 7, 0, 0, "Mandrake Sigil"), // to Rue Aliano

            // Wkshop \
            new(0x002E, 8, 3, 0, "Cattleya Sigil"), // to Rue Crimnade

            // Hall to a New World
            new(0x0031, 3, 15, 0, "Bronze Key"), // to Shasras Hill Park

            // Shelter From the Quake
            new(0x0034, 0, 6, 0, "Gold Key"), // to Buried Alive
            new(0x0034, 17, 9, 0, "Silver Key"), // to Movement of Fear

            // Dark Abhors Light
            new(0x0035, 3, 15, 0, "Iron Key"), // to The Sunless Way

            // Stair to the Sinners
            new(0x0036, 3, 0, 0, "Gold Key"), // to The Soldier's Bedding

            // Room of Cheap Red Wine
            new(0x0109, 3, 0, 0, "Chamomile Sigil"), // to Smokebarrel Stair

            // ?010C
            new(0x010C, 7, 0, 0, "Stock Sigil"), // to Blackmarket of Wines

            // What Ails You, Kills You
            new(0x0119, 7, 12, 0, "Palm Sigil"), // to The Melodics of Madness
            new(0x0119, 8, 12, 0, "Palm Sigil"), // to The Melodics of Madness

            // Buried Alive
            new(0x0134, 10, 4, 0, "Gold Key"), // to Shelter From the Quake

            // Dream of the Holy Land
            new(0x0135, 6, 0, 0, "Aster Sigil"), // to The Ore Road

            // The Cauldron
            new(0x0137, 5, 0, 0, "Tearose Sigil"), // to Wooden Horse

            // The Soldier's Bedding
            new(0x021D, 6, 8, 0, "Gold Key"), // to Stair to the Sinners

            // Those who Drink the Dark
            new(0x021E, 13, 7, 0, "Silver Key"), // to Ants Prepare for Winter

            // Sewer of Ravenous Rats
            new(0x0230, 9, 11, 0, "Silver Key"), // to Beggars of the Mouthharp

            // Movement of Fear
            new(0x0234, 0, 2, 0, "Silver Key"), // to Shelter From the Quake

            // The Ore Road
            new(0x0235, 8, 14, 0, "Aster Sigil"), // to Dream of the Holy Land

            // Wooden Horse
            new(0x0237, 2, 10, 0, "Tearose Sigil"), // to The Cauldron

            // Noble Gold and Silk
            new(0x0331, 16, 3, 0, "Iron Key"), // to A Knight Sells his Sword

            // Smokebarrel Stair
            new(0x0409, 3, 14, 0, "Chamomile Sigil"), // to Room of Cheap Red Wine

            // The Heretics' Story
            new(0x0417, 0, 12, 0, "Calla Sigil"), // to Hopes of the Idealist

            // A Light in the Dark
            new(0x0418, 7, 0, 0, "Laurel Sigil"), // to The Poisoned Chapel
            new(0x0418, 8, 0, 0, "Laurel Sigil"), // to The Poisoned Chapel

            // The Resentful Ones
            new(0x041E, 17, 17, 0, "Silver Key"), // to Those who Fear the Light
            new(0x041E, 18, 17, 0, "Silver Key"), // to Those who Fear the Light

            // The Sunless Way
            new(0x0430, 8, 0, 0, "Iron Key"), // to Dark Abhors Light

            // A Knight Sells his Sword
            new(0x0431, 0, 8, 0, "Iron Key"), // to Noble Gold and Silk

            // Bandits' Hollow
            new(0x0433, 12, 5, 0, "Iron Key"), // to Delusions of Happiness

            // The Poisoned Chapel
            new(0x0518, 9, 26, 0, "Laurel Sigil"), // to A Light in the Dark
            new(0x0518, 10, 26, 0, "Laurel Sigil"), // to A Light in the Dark

            // Those who Fear the Light
            new(0x051E, 4, 0, 0, "Silver Key"), // to The Resentful Ones
            new(0x051E, 5, 0, 0, "Silver Key"), // to The Resentful Ones

            // Remembering Days of Yore
            new(0x0530, 0, 8, 0, "Iron Key"), // to Larder for a Lean Winter

            // Delusions of Happiness
            new(0x0533, 0, 4, 0, "Iron Key"), // to Bandits' Hollow

            // Larder for a Lean Winter
            new(0x0730, 10, 5, 0, "Iron Key"), // to Remembering Days of Yore

            // The Washing-Woman's Way
            new(0x0930, 11, 3, 0, "Silver Key"), // to Nameless Dark Oblivion

            // The Earthquake's Mark
            new(0x0932, 9, 0, 0, "Hyacinth Sigil"), // to The Passion of Lovers

            // Beggars of the Mouthharp
            new(0x0A30, 3, 0, 0, "Silver Key"), // to Sewer of Ravenous Rats

            // The Hall of Broken Vows
            new(0x0B18, 9, 0, 0, "Acacia Sigil"), // to The Melodics of Madness
            new(0x0B18, 10, 0, 0, "Acacia Sigil"), // to The Melodics of Madness

            // Rue Aliano
            new(0x0B20, 14, 3, 0, "Mandrake Sigil"), // to The House Khazabas

            // The Passion of Lovers
            new(0x0B32, 2, 13, 0, "Hyacinth Sigil"), // to The Earthquake's Mark

            // The Withered Spring
            new(0x0C0D, 21, 7, 0, "Lily Sigil"), // to Prisoners' Niche
            new(0x0C0D, 21, 8, 0, "Lily Sigil"), // to Prisoners' Niche

            // The Melodics of Madness
            new(0x0C18, 4, 0, 0, "Palm Sigil"), // to What Ails You, Kills You
            new(0x0C18, 4, 15, 0, "Acacia Sigil"), // to The Hall of Broken Vows
            new(0x0C18, 5, 0, 0, "Palm Sigil"), // to What Ails You, Kills You
            new(0x0C18, 5, 15, 0, "Acacia Sigil"), // to The Hall of Broken Vows

            // The Dreamer's Climb
            new(0x0C35, 8, 15, 0, "Eulelia Sigil"), // to Sinner's Sustenence

            // Traces of Invasion Past
            new(0x0D1C, 2, 14, 0, "Iron Key"), // to From Squire to Knight

            // Rue Morgue
            new(0x0D20, 13, 9, 0, "Bronze Key"), // to Corridor of Shade

            // Crossroads of Rest
            new(0x0D30, 3, 0, 0, "Iron Key"), // to Path of the Children

            // Sinner's Sustenence
            new(0x0D35, 3, 0, 0, "Eulelia Sigil"), // to The Dreamer's Climb

            // From Squire to Knight
            new(0x0E1C, 4, 0, 0, "Iron Key"), // to Traces of Invasion Past

            // Path of the Children
            new(0x0E30, 3, 12, 0, "Iron Key"), // to Crossroads of Rest

            // The Timely Dew of Sleep
            new(0x0E35, 17, 12, 0, "Gold Key"), // to Companions in Arms

            // Hopes of the Idealist
            new(0x0F18, 10, 7, 0, "Calla Sigil"), // to The Heretics' Story

            // Everwant Passage
            new(0x0F32, 0, 11, 0, "Silver Key"), // to Mining Regrets

            // Companions in Arms
            new(0x0F35, 0, 4, 0, "Gold Key"), // to The Timely Dew of Sleep

            // Mining Regrets
            new(0x1032, 10, 4, 0, "Silver Key"), // to Everwant Passage

            // The Auction Block
            new(0x1035, 8, 14, 0, "Silver Key"), // to Ascension

            // Hanging
            new(0x1037, 2, 0, 0, "Steel Key"), // to Impalement

            // Blackmarket of Wines
            new(0x1109, 2, 9, 0, "Stock Sigil"), // to The Gallows

            // From Boy to Hero
            new(0x111C, 4, 14, 0, "Clematis Sigil"), // to A Welcome Invasion

            // Rue Crimnade
            new(0x1120, 0, 3, 0, "Cattleya Sigil"), // to Wkshop \

            // Nameless Dark Oblivion
            new(0x1130, 0, 9, 0, "Silver Key"), // to The Washing-Woman's Way

            // Ascension
            new(0x1135, 3, 0, 0, "Silver Key"), // to The Auction Block

            // Impalement
            new(0x1137, 2, 0, 0, "Platinum Key"), // to Knotting
            new(0x1137, 2, 10, 0, "Steel Key"), // to Hanging

            // A Welcome Invasion
            new(0x121C, 2, 0, 0, "Clematis Sigil"), // to From Boy to Hero

            // Corner of Prayers
            new(0x1230, 16, 3, 0, "Gold Key"), // to Salvation for the Mother

            // Knotting
            new(0x1237, 6, 17, 0, "Platinum Key"), // to Impalement

            // Shasras Hill Park
            new(0x1320, 0, 11, 0, "Bronze Key"), // to Hall to a New World

            // Ants Prepare for Winter
            new(0x1335, 0, 2, 0, "Silver Key"), // to Those who Drink the Dark

            // Live Long and Prosper
            new(0x1432, 11, 13, 0, "Fern Sigil"), // to Pray to the Mineral Gods

            // Pray to the Mineral Gods
            new(0x1532, 3, 0, 0, "Fern Sigil"), // to Live Long and Prosper

            // The Laborer's Bonfire
            new(0x1535, 9, 0, 0, "Melissa Sigil"), // to Torture Without End

            // Tears from Empty Sockets
            new(0x1630, 8, 0, 0, "Gold Key"), // to The Body Fragile Yields

            // Torture Without End
            new(0x1735, 6, 17, 0, "Melissa Sigil"), // to The Laborer's Bonfire

            // The Body Fragile Yields
            new(0x1830, 3, 15, 0, "Gold Key"), // to Tears from Empty Sockets

            // Salvation for the Mother
            new(0x1930, 0, 3, 0, "Gold Key"), // to Corner of Prayers

            // Corridor of Shade
            new(0x1B33, 2, 0, 0, "Bronze Key"), // to Rue Morgue
        };

        /// <summary>Doors whose room has no lock entry at the tile, so they cannot be locked from that side.</summary>
        public static readonly HashSet<(ushort MapId, byte TileX, byte TileZ)> NoLockSlot = new()
        {
            (0x0D20, 13, 9), // Rue Morgue -> Corridor of Shade (Bronze Key)
            (0x1320, 0, 11), // Shasras Hill Park -> Hall to a New World (Bronze Key)
        };

        public static readonly ILookup<ushort, DoorLockData> ByMap = All.ToLookup(d => d.MapId);
    }
}
