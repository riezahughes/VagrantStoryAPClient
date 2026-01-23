//namespace VagrantStoryArchipelago.Helpers.EntityLists
//{
//    internal class LeggingArmour
//    {

//        public static readonly Dictionary<string, InventoryArmorData> Leggings = new Dictionary<string, InventoryArmorData>
//        {
// ===== LEGGINGS =====
// Sandals (ID 0x30) - Base: STR 1, INT 7, AGI 0, Blunt 0, Edged 0, Piercing 0
//["Leather Sandals"] = new InventoryArmourData("Leather Sandals", 0x30, TYPE_LEG, 100, 100, 2, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Sandals"] = new InventoryArmourData("Wood Sandals", 0x30, TYPE_LEG, 100, 100, 6, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Sandals"] = new InventoryArmourData("Bronze Sandals", 0x30, TYPE_LEG, 100, 100, 4, 9, -2, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Sandals"] = new InventoryArmourData("Iron Sandals", 0x30, TYPE_LEG, 100, 100, 6, 9, -2, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Sandals"] = new InventoryArmourData("Hagane Sandals", 0x30, TYPE_LEG, 100, 100, 7, 10, -1, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Sandals"] = new InventoryArmourData("Silver Sandals", 0x30, TYPE_LEG, 100, 100, 5, 9, -1, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Sandals"] = new InventoryArmourData("Damascus Sandals", 0x30, TYPE_LEG, 100, 100, 10, 11, -1, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Boots (ID 0x31) - Base: STR 2, INT 3, AGI 0, Blunt 1, Edged 1, Piercing 1
//["Leather Boots"] = new InventoryArmourData("Leather Boots", 0x31, TYPE_LEG, 100, 100, 3, 9, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Boots"] = new InventoryArmourData("Wood Boots", 0x31, TYPE_LEG, 100, 100, 7, 11, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Boots"] = new InventoryArmourData("Bronze Boots", 0x31, TYPE_LEG, 100, 100, 5, 5, -2, 1, 1, 1, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Boots"] = new InventoryArmourData("Iron Boots", 0x31, TYPE_LEG, 100, 100, 7, 5, -2, 1, 1, 1, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Boots"] = new InventoryArmourData("Hagane Boots", 0x31, TYPE_LEG, 100, 100, 8, 6, -1, 1, 1, 1, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Boots"] = new InventoryArmourData("Silver Boots", 0x31, TYPE_LEG, 100, 100, 6, 5, -1, 1, 1, 1, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Boots"] = new InventoryArmourData("Damascus Boots", 0x31, TYPE_LEG, 100, 100, 11, 7, -1, 1, 1, 1, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Long Boots (ID 0x32) - Base: STR 2, INT 5, AGI 0, Blunt 2, Edged 2, Piercing 2
//["Leather Long Boots"] = new InventoryArmourData("Leather Long Boots", 0x32, TYPE_LEG, 100, 100, 3, 11, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Long Boots"] = new InventoryArmourData("Wood Long Boots", 0x32, TYPE_LEG, 100, 100, 7, 13, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Long Boots"] = new InventoryArmourData("Bronze Long Boots", 0x32, TYPE_LEG, 100, 100, 5, 7, -2, 2, 2, 2, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Long Boots"] = new InventoryArmourData("Iron Long Boots", 0x32, TYPE_LEG, 100, 100, 7, 7, -2, 2, 2, 2, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Long Boots"] = new InventoryArmourData("Hagane Long Boots", 0x32, TYPE_LEG, 100, 100, 8, 8, -1, 2, 2, 2, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Long Boots"] = new InventoryArmourData("Silver Long Boots", 0x32, TYPE_LEG, 100, 100, 6, 7, -1, 2, 2, 2, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Long Boots"] = new InventoryArmourData("Damascus Long Boots", 0x32, TYPE_LEG, 100, 100, 11, 9, -1, 2, 2, 2, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Cuisse (ID 0x33) - Base: STR 3, INT 5, AGI 0, Blunt 3, Edged 3, Piercing 0
//["Leather Cuisse"] = new InventoryArmourData("Leather Cuisse", 0x33, TYPE_LEG, 100, 100, 4, 11, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Cuisse"] = new InventoryArmourData("Wood Cuisse", 0x33, TYPE_LEG, 100, 100, 8, 13, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Cuisse"] = new InventoryArmourData("Bronze Cuisse", 0x33, TYPE_LEG, 100, 100, 6, 7, -2, 3, 3, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Cuisse"] = new InventoryArmourData("Iron Cuisse", 0x33, TYPE_LEG, 100, 100, 8, 7, -2, 3, 3, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Cuisse"] = new InventoryArmourData("Hagane Cuisse", 0x33, TYPE_LEG, 100, 100, 9, 8, -1, 3, 3, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Cuisse"] = new InventoryArmourData("Silver Cuisse", 0x33, TYPE_LEG, 100, 100, 7, 7, -1, 3, 3, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Cuisse"] = new InventoryArmourData("Damascus Cuisse", 0x33, TYPE_LEG, 100, 100, 12, 9, -1, 3, 3, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Light Greaves (ID 0x34) - Base: STR 4, INT 5, AGI 0, Blunt 0, Edged 0, Piercing 4
//["Leather Light Greaves"] = new InventoryArmourData("Leather Light Greaves", 0x34, TYPE_LEG, 100, 100, 5, 11, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Light Greaves"] = new InventoryArmourData("Wood Light Greaves", 0x34, TYPE_LEG, 100, 100, 9, 13, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Light Greaves"] = new InventoryArmourData("Bronze Light Greaves", 0x34, TYPE_LEG, 100, 100, 7, 7, -2, 0, 0, 4, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Light Greaves"] = new InventoryArmourData("Iron Light Greaves", 0x34, TYPE_LEG, 100, 100, 9, 7, -2, 0, 0, 4, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Light Greaves"] = new InventoryArmourData("Hagane Light Greaves", 0x34, TYPE_LEG, 100, 100, 10, 8, -1, 0, 0, 4, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Light Greaves"] = new InventoryArmourData("Silver Light Greaves", 0x34, TYPE_LEG, 100, 100, 8, 7, -1, 0, 0, 4, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Light Greaves"] = new InventoryArmourData("Damascus Light Greaves", 0x34, TYPE_LEG, 100, 100, 13, 9, -1, 0, 0, 4, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Ring Leggings (ID 0x35) - Base: STR 5, INT 6, AGI -1, Blunt 4, Edged 3, Piercing 0
//["Leather Ring Leggings"] = new InventoryArmourData("Leather Ring Leggings", 0x35, TYPE_LEG, 100, 100, 6, 12, -1, 4, 3, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Ring Leggings"] = new InventoryArmourData("Wood Ring Leggings", 0x35, TYPE_LEG, 100, 100, 10, 14, -1, 4, 3, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Ring Leggings"] = new InventoryArmourData("Bronze Ring Leggings", 0x35, TYPE_LEG, 100, 100, 8, 8, -3, 4, 3, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Ring Leggings"] = new InventoryArmourData("Iron Ring Leggings", 0x35, TYPE_LEG, 100, 100, 10, 8, -3, 4, 3, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Ring Leggings"] = new InventoryArmourData("Hagane Ring Leggings", 0x35, TYPE_LEG, 100, 100, 11, 9, -2, 4, 3, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Ring Leggings"] = new InventoryArmourData("Silver Ring Leggings", 0x35, TYPE_LEG, 100, 100, 9, 8, -2, 4, 3, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Ring Leggings"] = new InventoryArmourData("Damascus Ring Leggings", 0x35, TYPE_LEG, 100, 100, 14, 10, -2, 4, 3, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Chain Leggings (ID 0x36) - Base: STR 6, INT 7, AGI -1, Blunt 5, Edged 4, Piercing 0
//["Leather Chain Leggings"] = new InventoryArmourData("Leather Chain Leggings", 0x36, TYPE_LEG, 100, 100, 7, 13, -1, 5, 4, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Chain Leggings"] = new InventoryArmourData("Wood Chain Leggings", 0x36, TYPE_LEG, 100, 100, 11, 15, -1, 5, 4, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Chain Leggings"] = new InventoryArmourData("Bronze Chain Leggings", 0x36, TYPE_LEG, 100, 100, 9, 9, -3, 5, 4, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Chain Leggings"] = new InventoryArmourData("Iron Chain Leggings", 0x36, TYPE_LEG, 100, 100, 11, 9, -3, 5, 4, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Chain Leggings"] = new InventoryArmourData("Hagane Chain Leggings", 0x36, TYPE_LEG, 100, 100, 12, 10, -2, 5, 4, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Chain Leggings"] = new InventoryArmourData("Silver Chain Leggings", 0x36, TYPE_LEG, 100, 100, 10, 9, -2, 5, 4, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Chain Leggings"] = new InventoryArmourData("Damascus Chain Leggings", 0x36, TYPE_LEG, 100, 100, 15, 11, -2, 5, 4, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Fusskampf (ID 0x37) - Base: STR 7, INT 8, AGI -1, Blunt 5, Edged 0, Piercing 8
//["Leather Fusskampf"] = new InventoryArmourData("Leather Fusskampf", 0x37, TYPE_LEG, 100, 100, 8, 14, -1, 5, 0, 8, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Fusskampf"] = new InventoryArmourData("Wood Fusskampf", 0x37, TYPE_LEG, 100, 100, 12, 16, -1, 5, 0, 8, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Fusskampf"] = new InventoryArmourData("Bronze Fusskampf", 0x37, TYPE_LEG, 100, 100, 10, 10, -3, 5, 0, 8, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Fusskampf"] = new InventoryArmourData("Iron Fusskampf", 0x37, TYPE_LEG, 100, 100, 12, 10, -3, 5, 0, 8, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Fusskampf"] = new InventoryArmourData("Hagane Fusskampf", 0x37, TYPE_LEG, 100, 100, 13, 11, -2, 5, 0, 8, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Fusskampf"] = new InventoryArmourData("Silver Fusskampf", 0x37, TYPE_LEG, 100, 100, 11, 10, -2, 5, 0, 8, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Fusskampf"] = new InventoryArmourData("Damascus Fusskampf", 0x37, TYPE_LEG, 100, 100, 16, 12, -2, 5, 0, 8, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Poleyn (ID 0x38) - Base: STR 8, INT 9, AGI -1, Blunt 0, Edged 5, Piercing 10
//["Leather Poleyn"] = new InventoryArmourData("Leather Poleyn", 0x38, TYPE_LEG, 100, 100, 9, 15, -1, 0, 5, 10, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Poleyn"] = new InventoryArmourData("Wood Poleyn", 0x38, TYPE_LEG, 100, 100, 13, 17, -1, 0, 5, 10, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Poleyn"] = new InventoryArmourData("Bronze Poleyn", 0x38, TYPE_LEG, 100, 100, 11, 11, -3, 0, 5, 10, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Poleyn"] = new InventoryArmourData("Iron Poleyn", 0x38, TYPE_LEG, 100, 100, 13, 11, -3, 0, 5, 10, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Poleyn"] = new InventoryArmourData("Hagane Poleyn", 0x38, TYPE_LEG, 100, 100, 14, 12, -2, 0, 5, 10, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Poleyn"] = new InventoryArmourData("Silver Poleyn", 0x38, TYPE_LEG, 100, 100, 12, 11, -2, 0, 5, 10, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Poleyn"] = new InventoryArmourData("Damascus Poleyn", 0x38, TYPE_LEG, 100, 100, 17, 13, -2, 0, 5, 10, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Jambeau (ID 0x39) - Base: STR 9, INT 10, AGI -2, Blunt 5, Edged 7, Piercing 0
//["Leather Jambeau"] = new InventoryArmourData("Leather Jambeau", 0x39, TYPE_LEG, 100, 100, 10, 16, -2, 5, 7, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Jambeau"] = new InventoryArmourData("Wood Jambeau", 0x39, TYPE_LEG, 100, 100, 14, 18, -2, 5, 7, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Jambeau"] = new InventoryArmourData("Bronze Jambeau", 0x39, TYPE_LEG, 100, 100, 12, 12, -4, 5, 7, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Jambeau"] = new InventoryArmourData("Iron Jambeau", 0x39, TYPE_LEG, 100, 100, 14, 12, -4, 5, 7, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Jambeau"] = new InventoryArmourData("Hagane Jambeau", 0x39, TYPE_LEG, 100, 100, 15, 13, -3, 5, 7, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Jambeau"] = new InventoryArmourData("Silver Jambeau", 0x39, TYPE_LEG, 100, 100, 13, 12, -3, 5, 7, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Jambeau"] = new InventoryArmourData("Damascus Jambeau", 0x39, TYPE_LEG, 100, 100, 18, 14, -3, 5, 7, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Missaglia (ID 0x3A) - Base: STR 10, INT 11, AGI -3, Blunt 12, Edged 12, Piercing 12
//["Leather Missaglia"] = new InventoryArmourData("Leather Missaglia", 0x3A, TYPE_LEG, 100, 100, 11, 17, -3, 12, 12,// ===== LEGGINGS =====
//// Sandals (ID 0x30) - Base: STR 1, INT 7, AGI 0, Blunt 0, Edged 0, Piercing 0
//["Leather Sandals"] = new InventoryArmourData("Leather Sandals", 0x30, TYPE_LEG, 100, 100, 2, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Sandals"] = new InventoryArmourData("Wood Sandals", 0x30, TYPE_LEG, 100, 100, 6, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Sandals"] = new InventoryArmourData("Bronze Sandals", 0x30, TYPE_LEG, 100, 100, 4, 9, -2, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Sandals"] = new InventoryArmourData("Iron Sandals", 0x30, TYPE_LEG, 100, 100, 6, 9, -2, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Sandals"] = new InventoryArmourData("Hagane Sandals", 0x30, TYPE_LEG, 100, 100, 7, 10, -1, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Sandals"] = new InventoryArmourData("Silver Sandals", 0x30, TYPE_LEG, 100, 100, 5, 9, -1, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Sandals"] = new InventoryArmourData("Damascus Sandals", 0x30, TYPE_LEG, 100, 100, 10, 11, -1, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Boots (ID 0x31) - Base: STR 2, INT 3, AGI 0, Blunt 1, Edged 1, Piercing 1
//["Leather Boots"] = new InventoryArmourData("Leather Boots", 0x31, TYPE_LEG, 100, 100, 3, 9, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Boots"] = new InventoryArmourData("Wood Boots", 0x31, TYPE_LEG, 100, 100, 7, 11, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Boots"] = new InventoryArmourData("Bronze Boots", 0x31, TYPE_LEG, 100, 100, 5, 5, -2, 1, 1, 1, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Boots"] = new InventoryArmourData("Iron Boots", 0x31, TYPE_LEG, 100, 100, 7, 5, -2, 1, 1, 1, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Boots"] = new InventoryArmourData("Hagane Boots", 0x31, TYPE_LEG, 100, 100, 8, 6, -1, 1, 1, 1, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Boots"] = new InventoryArmourData("Silver Boots", 0x31, TYPE_LEG, 100, 100, 6, 5, -1, 1, 1, 1, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Boots"] = new InventoryArmourData("Damascus Boots", 0x31, TYPE_LEG, 100, 100, 11, 7, -1, 1, 1, 1, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Long Boots (ID 0x32) - Base: STR 2, INT 5, AGI 0, Blunt 2, Edged 2, Piercing 2
//["Leather Long Boots"] = new InventoryArmourData("Leather Long Boots", 0x32, TYPE_LEG, 100, 100, 3, 11, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Long Boots"] = new InventoryArmourData("Wood Long Boots", 0x32, TYPE_LEG, 100, 100, 7, 13, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Long Boots"] = new InventoryArmourData("Bronze Long Boots", 0x32, TYPE_LEG, 100, 100, 5, 7, -2, 2, 2, 2, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Long Boots"] = new InventoryArmourData("Iron Long Boots", 0x32, TYPE_LEG, 100, 100, 7, 7, -2, 2, 2, 2, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Long Boots"] = new InventoryArmourData("Hagane Long Boots", 0x32, TYPE_LEG, 100, 100, 8, 8, -1, 2, 2, 2, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Long Boots"] = new InventoryArmourData("Silver Long Boots", 0x32, TYPE_LEG, 100, 100, 6, 7, -1, 2, 2, 2, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Long Boots"] = new InventoryArmourData("Damascus Long Boots", 0x32, TYPE_LEG, 100, 100, 11, 9, -1, 2, 2, 2, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Cuisse (ID 0x33) - Base: STR 3, INT 5, AGI 0, Blunt 3, Edged 3, Piercing 0
//["Leather Cuisse"] = new InventoryArmourData("Leather Cuisse", 0x33, TYPE_LEG, 100, 100, 4, 11, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Cuisse"] = new InventoryArmourData("Wood Cuisse", 0x33, TYPE_LEG, 100, 100, 8, 13, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Cuisse"] = new InventoryArmourData("Bronze Cuisse", 0x33, TYPE_LEG, 100, 100, 6, 7, -2, 3, 3, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Cuisse"] = new InventoryArmourData("Iron Cuisse", 0x33, TYPE_LEG, 100, 100, 8, 7, -2, 3, 3, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Cuisse"] = new InventoryArmourData("Hagane Cuisse", 0x33, TYPE_LEG, 100, 100, 9, 8, -1, 3, 3, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Cuisse"] = new InventoryArmourData("Silver Cuisse", 0x33, TYPE_LEG, 100, 100, 7, 7, -1, 3, 3, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Cuisse"] = new InventoryArmourData("Damascus Cuisse", 0x33, TYPE_LEG, 100, 100, 12, 9, -1, 3, 3, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Light Greaves (ID 0x34) - Base: STR 4, INT 5, AGI 0, Blunt 0, Edged 0, Piercing 4
//["Leather Light Greaves"] = new InventoryArmourData("Leather Light Greaves", 0x34, TYPE_LEG, 100, 100, 5, 11, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Light Greaves"] = new InventoryArmourData("Wood Light Greaves", 0x34, TYPE_LEG, 100, 100, 9, 13, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Light Greaves"] = new InventoryArmourData("Bronze Light Greaves", 0x34, TYPE_LEG, 100, 100, 7, 7, -2, 0, 0, 4, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Light Greaves"] = new InventoryArmourData("Iron Light Greaves", 0x34, TYPE_LEG, 100, 100, 9, 7, -2, 0, 0, 4, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Light Greaves"] = new InventoryArmourData("Hagane Light Greaves", 0x34, TYPE_LEG, 100, 100, 10, 8, -1, 0, 0, 4, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Light Greaves"] = new InventoryArmourData("Silver Light Greaves", 0x34, TYPE_LEG, 100, 100, 8, 7, -1, 0, 0, 4, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Light Greaves"] = new InventoryArmourData("Damascus Light Greaves", 0x34, TYPE_LEG, 100, 100, 13, 9, -1, 0, 0, 4, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Ring Leggings (ID 0x35) - Base: STR 5, INT 6, AGI -1, Blunt 4, Edged 3, Piercing 0
//["Leather Ring Leggings"] = new InventoryArmourData("Leather Ring Leggings", 0x35, TYPE_LEG, 100, 100, 6, 12, -1, 4, 3, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Ring Leggings"] = new InventoryArmourData("Wood Ring Leggings", 0x35, TYPE_LEG, 100, 100, 10, 14, -1, 4, 3, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Ring Leggings"] = new InventoryArmourData("Bronze Ring Leggings", 0x35, TYPE_LEG, 100, 100, 8, 8, -3, 4, 3, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Ring Leggings"] = new InventoryArmourData("Iron Ring Leggings", 0x35, TYPE_LEG, 100, 100, 10, 8, -3, 4, 3, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Ring Leggings"] = new InventoryArmourData("Hagane Ring Leggings", 0x35, TYPE_LEG, 100, 100, 11, 9, -2, 4, 3, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Ring Leggings"] = new InventoryArmourData("Silver Ring Leggings", 0x35, TYPE_LEG, 100, 100, 9, 8, -2, 4, 3, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Ring Leggings"] = new InventoryArmourData("Damascus Ring Leggings", 0x35, TYPE_LEG, 100, 100, 14, 10, -2, 4, 3, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Chain Leggings (ID 0x36) - Base: STR 6, INT 7, AGI -1, Blunt 5, Edged 4, Piercing 0
//["Leather Chain Leggings"] = new InventoryArmourData("Leather Chain Leggings", 0x36, TYPE_LEG, 100, 100, 7, 13, -1, 5, 4, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Chain Leggings"] = new InventoryArmourData("Wood Chain Leggings", 0x36, TYPE_LEG, 100, 100, 11, 15, -1, 5, 4, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Chain Leggings"] = new InventoryArmourData("Bronze Chain Leggings", 0x36, TYPE_LEG, 100, 100, 9, 9, -3, 5, 4, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Chain Leggings"] = new InventoryArmourData("Iron Chain Leggings", 0x36, TYPE_LEG, 100, 100, 11, 9, -3, 5, 4, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Chain Leggings"] = new InventoryArmourData("Hagane Chain Leggings", 0x36, TYPE_LEG, 100, 100, 12, 10, -2, 5, 4, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Chain Leggings"] = new InventoryArmourData("Silver Chain Leggings", 0x36, TYPE_LEG, 100, 100, 10, 9, -2, 5, 4, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Chain Leggings"] = new InventoryArmourData("Damascus Chain Leggings", 0x36, TYPE_LEG, 100, 100, 15, 11, -2, 5, 4, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Fusskampf (ID 0x37) - Base: STR 7, INT 8, AGI -1, Blunt 5, Edged 0, Piercing 8
//["Leather Fusskampf"] = new InventoryArmourData("Leather Fusskampf", 0x37, TYPE_LEG, 100, 100, 8, 14, -1, 5, 0, 8, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Fusskampf"] = new InventoryArmourData("Wood Fusskampf", 0x37, TYPE_LEG, 100, 100, 12, 16, -1, 5, 0, 8, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Fusskampf"] = new InventoryArmourData("Bronze Fusskampf", 0x37, TYPE_LEG, 100, 100, 10, 10, -3, 5, 0, 8, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Fusskampf"] = new InventoryArmourData("Iron Fusskampf", 0x37, TYPE_LEG, 100, 100, 12, 10, -3, 5, 0, 8, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Fusskampf"] = new InventoryArmourData("Hagane Fusskampf", 0x37, TYPE_LEG, 100, 100, 13, 11, -2, 5, 0, 8, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Fusskampf"] = new InventoryArmourData("Silver Fusskampf", 0x37, TYPE_LEG, 100, 100, 11, 10, -2, 5, 0, 8, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Fusskampf"] = new InventoryArmourData("Damascus Fusskampf", 0x37, TYPE_LEG, 100, 100, 16, 12, -2, 5, 0, 8, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Poleyn (ID 0x38) - Base: STR 8, INT 9, AGI -1, Blunt 0, Edged 5, Piercing 10
//["Leather Poleyn"] = new InventoryArmourData("Leather Poleyn", 0x38, TYPE_LEG, 100, 100, 9, 15, -1, 0, 5, 10, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Poleyn"] = new InventoryArmourData("Wood Poleyn", 0x38, TYPE_LEG, 100, 100, 13, 17, -1, 0, 5, 10, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Poleyn"] = new InventoryArmourData("Bronze Poleyn", 0x38, TYPE_LEG, 100, 100, 11, 11, -3, 0, 5, 10, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Poleyn"] = new InventoryArmourData("Iron Poleyn", 0x38, TYPE_LEG, 100, 100, 13, 11, -3, 0, 5, 10, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Poleyn"] = new InventoryArmourData("Hagane Poleyn", 0x38, TYPE_LEG, 100, 100, 14, 12, -2, 0, 5, 10, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Poleyn"] = new InventoryArmourData("Silver Poleyn", 0x38, TYPE_LEG, 100, 100, 12, 11, -2, 0, 5, 10, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Poleyn"] = new InventoryArmourData("Damascus Poleyn", 0x38, TYPE_LEG, 100, 100, 17, 13, -2, 0, 5, 10, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Jambeau (ID 0x39) - Base: STR 9, INT 10, AGI -2, Blunt 5, Edged 7, Piercing 0
//["Leather Jambeau"] = new InventoryArmourData("Leather Jambeau", 0x39, TYPE_LEG, 100, 100, 10, 16, -2, 5, 7, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Jambeau"] = new InventoryArmourData("Wood Jambeau", 0x39, TYPE_LEG, 100, 100, 14, 18, -2, 5, 7, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Jambeau"] = new InventoryArmourData("Bronze Jambeau", 0x39, TYPE_LEG, 100, 100, 12, 12, -4, 5, 7, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Jambeau"] = new InventoryArmourData("Iron Jambeau", 0x39, TYPE_LEG, 100, 100, 14, 12, -4, 5, 7, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Jambeau"] = new InventoryArmourData("Hagane Jambeau", 0x39, TYPE_LEG, 100, 100, 15, 13, -3, 5, 7, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Jambeau"] = new InventoryArmourData("Silver Jambeau", 0x39, TYPE_LEG, 100, 100, 13, 12, -3, 5, 7, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Jambeau"] = new InventoryArmourData("Damascus Jambeau", 0x39, TYPE_LEG, 100, 100, 18, 14, -3, 5, 7, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Missaglia (ID 0x3A) - Base: STR 10, INT 11, AGI -3, Blunt 12, Edged 12, Piercing 12
//["Leather Missaglia"] = new InventoryArmourData("Leather Missaglia", 0x3A, TYPE_LEG, 100, 100, 11, 17, -3, 12, 12, 12, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Missaglia"] = new InventoryArmourData("Wood Missaglia", 0x3A, TYPE_LEG, 100, 100, 15, 19, -3, 12, 12, 12, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Missaglia"] = new InventoryArmourData("Bronze Missaglia", 0x3A, TYPE_LEG, 100, 100, 13, 13, -5, 12, 12, 12, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Missaglia"] = new InventoryArmourData("Iron Missaglia", 0x3A, TYPE_LEG, 100, 100, 15, 13, -5, 12, 12, 12, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Missaglia"] = new InventoryArmourData("Hagane Missaglia", 0x3A, TYPE_LEG, 100, 100, 16, 14, -4, 12, 12, 12, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Missaglia"] = new InventoryArmourData("Silver Missaglia", 0x3A, TYPE_LEG, 100, 100, 14, 13, -4, 12, 12, 12, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Missaglia"] = new InventoryArmourData("Damascus Missaglia", 0x3A, TYPE_LEG, 100, 100, 19, 15, -4, 12, 12, 12, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//// Plate Leggings (ID 0x3B) - Base: STR 11, INT 11, AGI -2
//["Leather Plate Leggings"] = new InventoryArmourData("Leather Plate Leggings", 0x3B, TYPE_LEG, 100, 100, 12, 17, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Plate Leggings"] = new InventoryArmourData("Wood Plate Leggings", 0x3B, TYPE_LEG, 100, 100, 16, 19, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Plate Leggings"] = new InventoryArmourData("Bronze Plate Leggings", 0x3B, TYPE_LEG, 100, 100, 14, 13, -4, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Plate Leggings"] = new InventoryArmourData("Iron Plate Leggings", 0x3B, TYPE_LEG, 100, 100, 16, 13, -4, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Plate Leggings"] = new InventoryArmourData("Hagane Plate Leggings", 0x3B, TYPE_LEG, 100, 100, 17, 14, -3, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Plate Leggings"] = new InventoryArmourData("Silver Plate Leggings", 0x3B, TYPE_LEG, 100, 100, 15, 13, -3, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Plate Leggings"] = new InventoryArmourData("Damascus Plate Leggings", 0x3B, TYPE_LEG, 100, 100, 20, 15, -3, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Fluted Leggings (ID 0x3C) - Base: STR 12, INT 12, AGI -2, Blunt 10, Edged 10, Piercing 10
//["Leather Fluted Leggings"] = new InventoryArmourData("Leather Fluted Leggings", 0x3C, TYPE_LEG, 100, 100, 13, 18, -2, 10, 10, 10, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Fluted Leggings"] = new InventoryArmourData("Wood Fluted Leggings", 0x3C, TYPE_LEG, 100, 100, 17, 20, -2, 10, 10, 10, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Fluted Leggings"] = new InventoryArmourData("Bronze Fluted Leggings", 0x3C, TYPE_LEG, 100, 100, 15, 14, -4, 10, 10, 10, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Fluted Leggings"] = new InventoryArmourData("Iron Fluted Leggings", 0x3C, TYPE_LEG, 100, 100, 17, 14, -4, 10, 10, 10, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Fluted Leggings"] = new InventoryArmourData("Hagane Fluted Leggings", 0x3C, TYPE_LEG, 100, 100, 18, 15, -3, 10, 10, 10, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Fluted Leggings"] = new InventoryArmourData("Silver Fluted Leggings", 0x3C, TYPE_LEG, 100, 100, 16, 14, -3, 10, 10, 10, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Fluted Leggings"] = new InventoryArmourData("Damascus Fluted Leggings", 0x3C, TYPE_LEG, 100, 100, 21, 16, -3, 10, 10, 10, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Hoplite Leggings (ID 0x3D) - Base: STR 13, INT 18, AGI -3, Blunt 15, Edged 6, Piercing 0
//["Leather Hoplite Leggings"] = new InventoryArmourData("Leather Hoplite Leggings", 0x3D, TYPE_LEG, 100, 100, 14, 24, -3, 15, 6, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Hoplite Leggings"] = new InventoryArmourData("Wood Hoplite Leggings", 0x3D, TYPE_LEG, 100, 100, 18, 26, -3, 15, 6, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Hoplite Leggings"] = new InventoryArmourData("Bronze Hoplite Leggings", 0x3D, TYPE_LEG, 100, 100, 16, 20, -5, 15, 6, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Hoplite Leggings"] = new InventoryArmourData("Iron Hoplite Leggings", 0x3D, TYPE_LEG, 100, 100, 18, 20, -5, 15, 6, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Hoplite Leggings"] = new InventoryArmourData("Hagane Hoplite Leggings", 0x3D, TYPE_LEG, 100, 100, 19, 21, -4, 15, 6, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Hoplite Leggings"] = new InventoryArmourData("Silver Hoplite Leggings", 0x3D, TYPE_LEG, 100, 100, 17, 20, -4, 15, 6, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Hoplite Leggings"] = new InventoryArmourData("Damascus Hoplite Leggings", 0x3D, TYPE_LEG, 100, 100, 22, 22, -4, 15, 6, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Jazeraint Leggings (ID 0x3E) - Base: STR 14, INT 17, AGI -3
//["Leather Jazeraint Leggings"] = new InventoryArmourData("Leather Jazeraint Leggings", 0x3E, TYPE_LEG, 100, 100, 15, 23, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Jazeraint Leggings"] = new InventoryArmourData("Wood Jazeraint Leggings", 0x3E, TYPE_LEG, 100, 100, 19, 25, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Jazeraint Leggings"] = new InventoryArmourData("Bronze Jazeraint Leggings", 0x3E, TYPE_LEG, 100, 100, 17, 19, -5, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Jazeraint Leggings"] = new InventoryArmourData("Iron Jazeraint Leggings", 0x3E, TYPE_LEG, 100, 100, 19, 19, -5, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Jazeraint Leggings"] = new InventoryArmourData("Hagane Jazeraint Leggings", 0x3E, TYPE_LEG, 100, 100, 20, 20, -4, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Jazeraint Leggings"] = new InventoryArmourData("Silver Jazeraint Leggings", 0x3E, TYPE_LEG, 100, 100, 18, 19, -4, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Jazeraint Leggings"] = new InventoryArmourData("Damascus Jazeraint Leggings", 0x3E, TYPE_LEG, 100, 100, 23, 21, -4, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//// Dread Leggings (ID 0x3F) - Base: STR 15, INT 15, AGI -3
//["Leather Dread Leggings"] = new InventoryArmourData("Leather Dread Leggings", 0x3F, TYPE_LEG, 100, 100, 16, 21, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//["Wood Dread Leggings"] = new InventoryArmourData("Wood Dread Leggings", 0x3F, TYPE_LEG, 100, 100, 20, 23, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//["Bronze Dread Leggings"] = new InventoryArmourData("Bronze Dread Leggings", 0x3F, TYPE_LEG, 100, 100, 18, 17, -5, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//["Iron Dread Leggings"] = new InventoryArmourData("Iron Dread Leggings", 0x3F, TYPE_LEG, 100, 100, 20, 17, -5, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//["Hagane Dread Leggings"] = new InventoryArmourData("Hagane Dread Leggings", 0x3F, TYPE_LEG, 100, 100, 21, 18, -4, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//["Silver Dread Leggings"] = new InventoryArmourData("Silver Dread Leggings", 0x3F, TYPE_LEG, 100, 100, 19, 17, -4, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//["Damascus Dread Leggings"] = new InventoryArmourData("Damascus Dread Leggings", 0x3F, TYPE_LEG, 100, 100, 24, 19, -4, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//        }
//}
