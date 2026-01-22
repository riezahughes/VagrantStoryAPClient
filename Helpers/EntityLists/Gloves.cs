//using VagrantStoryArchipelago.Enums;

//namespace VagrantStoryArchipelago.Helpers.EntityLists
//{
//    internal class InventoryArmorData
//    {
//        public static readonly Dictionary<string, InventoryArmorData> Armours = new Dictionary<string, InventoryArmorData>
//        {
//            // ===== GLOVES (ARM) =====
//            // Bandage (ID 0x20) - Base: STR 1, INT 8, AGI 0, Blunt 1, Edged 0, Piercing 0
//            ["Leather Bandage"] = new InventoryArmorData("Leather Bandage", 0x20, ArmorType.ARM, 100, 100, 2, 14, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Bandage"] = new InventoryArmorData("Wood Bandage", 0x20, ArmorType.ARM, 100, 100, 6, 16, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Bandage"] = new InventoryArmorData("Bronze Bandage", 0x20, ArmorType.ARM, 100, 100, 4, 10, -2, 1, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Bandage"] = new InventoryArmorData("Iron Bandage", 0x20, ArmorType.ARM, 100, 100, 6, 10, -2, 1, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Bandage"] = new InventoryArmorData("Hagane Bandage", 0x20, ArmorType.ARM, 100, 100, 7, 11, -1, 1, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Bandage"] = new InventoryArmorData("Silver Bandage", 0x20, ArmorType.ARM, 100, 100, 5, 10, -1, 1, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Bandage"] = new InventoryArmorData("Damascus Bandage", 0x20, ArmorType.ARM, 100, 100, 10, 12, -1, 1, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Leather Glove (ID 0x21) - Base: STR 2, INT 4, AGI 0, Blunt 3, Edged 0, Piercing 0
//            ["Leather Leather Glove"] = new InventoryArmorData("Leather Leather Glove", 0x21, ArmorType.ARM, 100, 100, 3, 10, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Leather Glove"] = new InventoryArmorData("Wood Leather Glove", 0x21, ArmorType.ARM, 100, 100, 7, 12, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Leather Glove"] = new InventoryArmorData("Bronze Leather Glove", 0x21, ArmorType.ARM, 100, 100, 5, 6, -2, 3, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Leather Glove"] = new InventoryArmorData("Iron Leather Glove", 0x21, ArmorType.ARM, 100, 100, 7, 6, -2, 3, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Leather Glove"] = new InventoryArmorData("Hagane Leather Glove", 0x21, ArmorType.ARM, 100, 100, 8, 7, -1, 3, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Leather Glove"] = new InventoryArmorData("Silver Leather Glove", 0x21, ArmorType.ARM, 100, 100, 6, 6, -1, 3, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Leather Glove"] = new InventoryArmorData("Damascus Leather Glove", 0x21, ArmorType.ARM, 100, 100, 11, 8, -1, 3, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Reinforced Glove (ID 0x22) - Base: STR 2, INT 4, AGI 0, Blunt 5, Edged 0, Piercing 3
//            ["Leather Reinforced Glove"] = new InventoryArmorData("Leather Reinforced Glove", 0x22, ArmorType.ARM, 100, 100, 3, 10, 0, 5, 0, 3, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Reinforced Glove"] = new InventoryArmorData("Wood Reinforced Glove", 0x22, ArmorType.ARM, 100, 100, 7, 12, 0, 5, 0, 3, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Reinforced Glove"] = new InventoryArmorData("Bronze Reinforced Glove", 0x22, ArmorType.ARM, 100, 100, 5, 6, -2, 5, 0, 3, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Reinforced Glove"] = new InventoryArmorData("Iron Reinforced Glove", 0x22, ArmorType.ARM, 100, 100, 7, 6, -2, 5, 0, 3, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Reinforced Glove"] = new InventoryArmorData("Hagane Reinforced Glove", 0x22, ArmorType.ARM, 100, 100, 8, 7, -1, 5, 0, 3, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Reinforced Glove"] = new InventoryArmorData("Silver Reinforced Glove", 0x22, ArmorType.ARM, 100, 100, 6, 6, -1, 5, 0, 3, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Reinforced Glove"] = new InventoryArmorData("Damascus Reinforced Glove", 0x22, ArmorType.ARM, 100, 100, 11, 8, -1, 5, 0, 3, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Knuckles (ID 0x23) - Base: STR 3, INT 5, AGI 0, Blunt 0, Edged 1, Piercing 5
//            ["Leather Knuckles"] = new InventoryArmorData("Leather Knuckles", 0x23, ArmorType.ARM, 100, 100, 4, 11, 0, 0, 1, 5, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Knuckles"] = new InventoryArmorData("Wood Knuckles", 0x23, ArmorType.ARM, 100, 100, 8, 13, 0, 0, 1, 5, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Knuckles"] = new InventoryArmorData("Bronze Knuckles", 0x23, ArmorType.ARM, 100, 100, 6, 7, -2, 0, 1, 5, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Knuckles"] = new InventoryArmorData("Iron Knuckles", 0x23, ArmorType.ARM, 100, 100, 8, 7, -2, 0, 1, 5, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Knuckles"] = new InventoryArmorData("Hagane Knuckles", 0x23, ArmorType.ARM, 100, 100, 9, 8, -1, 0, 1, 5, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Knuckles"] = new InventoryArmorData("Silver Knuckles", 0x23, ArmorType.ARM, 100, 100, 7, 7, -1, 0, 1, 5, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Knuckles"] = new InventoryArmorData("Damascus Knuckles", 0x23, ArmorType.ARM, 100, 100, 12, 9, -1, 0, 1, 5, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Ring Sleeve (ID 0x24) - Base: STR 4, INT 5, AGI -1, Blunt 0, Edged 3, Piercing 3
//            ["Leather Ring Sleeve"] = new InventoryArmorData("Leather Ring Sleeve", 0x24, ArmorType.ARM, 100, 100, 5, 11, -1, 0, 3, 3, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Ring Sleeve"] = new InventoryArmorData("Wood Ring Sleeve", 0x24, ArmorType.ARM, 100, 100, 9, 13, -1, 0, 3, 3, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Ring Sleeve"] = new InventoryArmorData("Bronze Ring Sleeve", 0x24, ArmorType.ARM, 100, 100, 7, 7, -3, 0, 3, 3, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Ring Sleeve"] = new InventoryArmorData("Iron Ring Sleeve", 0x24, ArmorType.ARM, 100, 100, 9, 7, -3, 0, 3, 3, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Ring Sleeve"] = new InventoryArmorData("Hagane Ring Sleeve", 0x24, ArmorType.ARM, 100, 100, 10, 8, -2, 0, 3, 3, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Ring Sleeve"] = new InventoryArmorData("Silver Ring Sleeve", 0x24, ArmorType.ARM, 100, 100, 8, 7, -2, 0, 3, 3, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Ring Sleeve"] = new InventoryArmorData("Damascus Ring Sleeve", 0x24, ArmorType.ARM, 100, 100, 13, 9, -2, 0, 3, 3, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Chain Sleeve (ID 0x25) - Base: STR 4, INT 6, AGI -1, Blunt 0, Edged 4, Piercing 0
//            ["Leather Chain Sleeve"] = new InventoryArmorData("Leather Chain Sleeve", 0x25, ArmorType.ARM, 100, 100, 5, 12, -1, 0, 4, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Chain Sleeve"] = new InventoryArmorData("Wood Chain Sleeve", 0x25, ArmorType.ARM, 100, 100, 9, 14, -1, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Chain Sleeve"] = new InventoryArmorData("Bronze Chain Sleeve", 0x25, ArmorType.ARM, 100, 100, 7, 8, -3, 0, 4, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Chain Sleeve"] = new InventoryArmorData("Iron Chain Sleeve", 0x25, ArmorType.ARM, 100, 100, 9, 8, -3, 0, 4, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Chain Sleeve"] = new InventoryArmorData("Hagane Chain Sleeve", 0x25, ArmorType.ARM, 100, 100, 10, 9, -2, 0, 4, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Chain Sleeve"] = new InventoryArmorData("Silver Chain Sleeve", 0x25, ArmorType.ARM, 100, 100, 8, 8, -2, 0, 4, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Chain Sleeve"] = new InventoryArmorData("Damascus Chain Sleeve", 0x25, ArmorType.ARM, 100, 100, 13, 10, -2, 0, 4, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Gauntlet (ID 0x26) - Base: STR 5, INT 6, AGI -1, Blunt 7, Edged 4, Piercing 4
//            ["Leather Gauntlet"] = new InventoryArmorData("Leather Gauntlet", 0x26, ArmorType.ARM, 100, 100, 6, 12, -1, 7, 4, 4, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Gauntlet"] = new InventoryArmorData("Wood Gauntlet", 0x26, ArmorType.ARM, 100, 100, 10, 14, -1, 7, 4, 4, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Gauntlet"] = new InventoryArmorData("Bronze Gauntlet", 0x26, ArmorType.ARM, 100, 100, 8, 8, -3, 7, 4, 4, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Gauntlet"] = new InventoryArmorData("Iron Gauntlet", 0x26, ArmorType.ARM, 100, 100, 10, 8, -3, 7, 4, 4, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Gauntlet"] = new InventoryArmorData("Hagane Gauntlet", 0x26, ArmorType.ARM, 100, 100, 11, 9, -2, 7, 4, 4, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Gauntlet"] = new InventoryArmorData("Silver Gauntlet", 0x26, ArmorType.ARM, 100, 100, 9, 8, -2, 7, 4, 4, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Gauntlet"] = new InventoryArmorData("Damascus Gauntlet", 0x26, ArmorType.ARM, 100, 100, 14, 10, -2, 7, 4, 4, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//            // Vambrace (ID 0x27) - Base: STR 6, INT 7, AGI -1, Blunt 0, Edged 5, Piercing 10
//            ["Leather Vambrace"] = new InventoryArmorData("Leather Vambrace", 0x27, ArmorType.ARM, 100, 100, 7, 13, -1, 0, 5, 10, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Vambrace"] = new InventoryArmorData("Wood Vambrace", 0x27, ArmorType.ARM, 100, 100, 11, 15, -1, 0, 5, 10, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Vambrace"] = new InventoryArmorData("Bronze Vambrace", 0x27, ArmorType.ARM, 100, 100, 9, 9, -3, 0, 5, 10, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Vambrace"] = new InventoryArmorData("Iron Vambrace", 0x27, ArmorType.ARM, 100, 100, 11, 9, -3, 0, 5, 10, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Vambrace"] = new InventoryArmorData("Hagane Vambrace", 0x27, ArmorType.ARM, 100, 100, 12, 10, -2, 0, 5, 10, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Vambrace"] = new InventoryArmorData("Silver Vambrace", 0x27, ArmorType.ARM, 100, 100, 10, 9, -2, 0, 5, 10, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Vambrace"] = new InventoryArmorData("Damascus Vambrace", 0x27, ArmorType.ARM, 100, 100, 15, 11, -2, 0, 5, 10, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Plate Glove (ID 0x28) - Base: STR 7, INT 8, AGI -1, Blunt 5, Edged 6, Piercing 7
//            ["Leather Plate Glove"] = new InventoryArmorData("Leather Plate Glove", 0x28, ArmorType.ARM, 100, 100, 8, 14, -1, 5, 6, 7, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Plate Glove"] = new InventoryArmorData("Wood Plate Glove", 0x28, ArmorType.ARM, 100, 100, 12, 16, -1, 5, 6, 7, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Plate Glove"] = new InventoryArmorData("Bronze Plate Glove", 0x28, ArmorType.ARM, 100, 100, 10, 10, -3, 5, 6, 7, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Plate Glove"] = new InventoryArmorData("Iron Plate Glove", 0x28, ArmorType.ARM, 100, 100, 12, 10, -3, 5, 6, 7, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Plate Glove"] = new InventoryArmorData("Hagane Plate Glove", 0x28, ArmorType.ARM, 100, 100, 13, 11, -2, 5, 6, 7, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Plate Glove"] = new InventoryArmorData("Silver Plate Glove", 0x28, ArmorType.ARM, 100, 100, 11, 10, -2, 5, 6, 7, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Plate Glove"] = new InventoryArmorData("Damascus Plate Glove", 0x28, ArmorType.ARM, 100, 100, 16, 12, -2, 5, 6, 7, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Rondanche (ID 0x29) - Base: STR 8, INT 9, AGI -1, Blunt 8, Edged 6, Piercing 0
//            ["Leather Rondanche"] = new InventoryArmorData("Leather Rondanche", 0x29, ArmorType.ARM, 100, 100, 9, 15, -1, 8, 6, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Rondanche"] = new InventoryArmorData("Wood Rondanche", 0x29, ArmorType.ARM, 100, 100, 13, 17, -1, 8, 6, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Rondanche"] = new InventoryArmorData("Bronze Rondanche", 0x29, ArmorType.ARM, 100, 100, 11, 11, -3, 8, 6, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Rondanche"] = new InventoryArmorData("Iron Rondanche", 0x29, ArmorType.ARM, 100, 100, 13, 11, -3, 8, 6, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Rondanche"] = new InventoryArmorData("Hagane Rondanche", 0x29, ArmorType.ARM, 100, 100, 14, 12, -2, 8, 6, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Rondanche"] = new InventoryArmorData("Silver Rondanche", 0x29, ArmorType.ARM, 100, 100, 12, 11, -2, 8, 6, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Rondanche"] = new InventoryArmorData("Damascus Rondanche", 0x29, ArmorType.ARM, 100, 100, 17, 13, -2, 8, 6, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Rondanche (ID 0x29) - Base: STR 8, INT 9, AGI -1, Blunt 8, Edged 6, Piercing 0
//            ["Leather Rondanche"] = new InventoryArmorData("Leather Rondanche", 0x29, ArmorType.ARM, 100, 100, 9, 15, -1, 8, 6, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Rondanche"] = new InventoryArmorData("Wood Rondanche", 0x29, ArmorType.ARM, 100, 100, 13, 17, -1, 8, 6, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Rondanche"] = new InventoryArmorData("Bronze Rondanche", 0x29, ArmorType.ARM, 100, 100, 11, 11, -3, 8, 6, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Rondanche"] = new InventoryArmorData("Iron Rondanche", 0x29, ArmorType.ARM, 100, 100, 13, 11, -3, 8, 6, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Rondanche"] = new InventoryArmorData("Hagane Rondanche", 0x29, ArmorType.ARM, 100, 100, 14, 12, -2, 8, 6, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Rondanche"] = new InventoryArmorData("Silver Rondanche", 0x29, ArmorType.ARM, 100, 100, 12, 11, -2, 8, 6, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Rondanche"] = new InventoryArmorData("Damascus Rondanche", 0x29, ArmorType.ARM, 100, 100, 17, 13, -2, 8, 6, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Freiturnier (ID 0x2B) - Base: STR 9, INT 10, AGI -1, Blunt 7, Edged 7, Piercing 7
//            ["Leather Freiturnier"] = new InventoryArmorData("Leather Freiturnier", 0x2B, ArmorType.ARM, 100, 100, 10, 16, -1, 7, 7, 7, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Freiturnier"] = new InventoryArmorData("Wood Freiturnier", 0x2B, ArmorType.ARM, 100, 100, 14, 18, -1, 7, 7, 7, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Freiturnier"] = new InventoryArmorData("Bronze Freiturnier", 0x2B, ArmorType.ARM, 100, 100, 12, 12, -3, 7, 7, 7, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Freiturnier"] = new InventoryArmorData("Iron Freiturnier", 0x2B, ArmorType.ARM, 100, 100, 14, 12, -3, 7, 7, 7, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Freiturnier"] = new InventoryArmorData("Hagane Freiturnier", 0x2B, ArmorType.ARM, 100, 100, 15, 13, -2, 7, 7, 7, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Freiturnier"] = new InventoryArmorData("Silver Freiturnier", 0x2B, ArmorType.ARM, 100, 100, 13, 12, -2, 7, 7, 7, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Freiturnier"] = new InventoryArmorData("Damascus Freiturnier", 0x2B, ArmorType.ARM, 100, 100, 18, 14, -2, 7, 7, 7, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Fluted Glove (ID 0x2C) - Base: STR 10, INT 11, AGI -3, Blunt 9, Edged 9, Piercing 9
//            ["Leather Fluted Glove"] = new InventoryArmorData("Leather Fluted Glove", 0x2C, ArmorType.ARM, 100, 100, 11, 17, -3, 9, 9, 9, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Fluted Glove"] = new InventoryArmorData("Wood Fluted Glove", 0x2C, ArmorType.ARM, 100, 100, 15, 19, -3, 9, 9, 9, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Fluted Glove"] = new InventoryArmorData("Bronze Fluted Glove", 0x2C, ArmorType.ARM, 100, 100, 13, 13, -5, 9, 9, 9, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Fluted Glove"] = new InventoryArmorData("Iron Fluted Glove", 0x2C, ArmorType.ARM, 100, 100, 15, 13, -5, 9, 9, 9, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Fluted Glove"] = new InventoryArmorData("Hagane Fluted Glove", 0x2C, ArmorType.ARM, 100, 100, 16, 14, -4, 9, 9, 9, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Fluted Glove"] = new InventoryArmorData("Silver Fluted Glove", 0x2C, ArmorType.ARM, 100, 100, 14, 13, -4, 9, 9, 9, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Fluted Glove"] = new InventoryArmorData("Damascus Fluted Glove", 0x2C, ArmorType.ARM, 100, 100, 19, 15, -4, 9, 9, 9, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Hoplite Glove (ID 0x2D) - Base: STR 11, INT 15, AGI -3, Blunt 13, Edged 5, Piercing 0
//            ["Leather Hoplite Glove"] = new InventoryArmorData("Leather Hoplite Glove", 0x2D, ArmorType.ARM, 100, 100, 12, 21, -3, 13, 5, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Hoplite Glove"] = new InventoryArmorData("Wood Hoplite Glove", 0x2D, ArmorType.ARM, 100, 100, 16, 23, -3, 13, 5, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Hoplite Glove"] = new InventoryArmorData("Bronze Hoplite Glove", 0x2D, ArmorType.ARM, 100, 100, 14, 17, -5, 13, 5, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Hoplite Glove"] = new InventoryArmorData("Iron Hoplite Glove", 0x2D, ArmorType.ARM, 100, 100, 16, 17, -5, 13, 5, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Hoplite Glove"] = new InventoryArmorData("Hagane Hoplite Glove", 0x2D, ArmorType.ARM, 100, 100, 17, 18, -4, 13, 5, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Hoplite Glove"] = new InventoryArmorData("Silver Hoplite Glove", 0x2D, ArmorType.ARM, 100, 100, 15, 17, -4, 13, 5, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Hoplite Glove"] = new InventoryArmorData("Damascus Hoplite Glove", 0x2D, ArmorType.ARM, 100, 100, 20, 19, -4, 13, 5, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Jazeraint Glove (ID 0x2E) - Base: STR 12, INT 14, AGI -3
//            ["Leather Jazeraint Glove"] = new InventoryArmorData("Leather Jazeraint Glove", 0x2E, ArmorType.ARM, 100, 100, 13, 20, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Jazeraint Glove"] = new InventoryArmorData("Wood Jazeraint Glove", 0x2E, ArmorType.ARM, 100, 100, 17, 22, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Jazeraint Glove"] = new InventoryArmorData("Bronze Jazeraint Glove", 0x2E, ArmorType.ARM, 100, 100, 15, 16, -5, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Jazeraint Glove"] = new InventoryArmorData("Iron Jazeraint Glove", 0x2E, ArmorType.ARM, 100, 100, 17, 16, -5, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Jazeraint Glove"] = new InventoryArmorData("Hagane Jazeraint Glove", 0x2E, ArmorType.ARM, 100, 100, 18, 17, -4, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Jazeraint Glove"] = new InventoryArmorData("Silver Jazeraint Glove", 0x2E, ArmorType.ARM, 100, 100, 16, 16, -4, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Jazeraint Glove"] = new InventoryArmorData("Damascus Jazeraint Glove", 0x2E, ArmorType.ARM, 100, 100, 21, 18, -4, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Dread Glove (ID 0x2F) - Base: STR 13, INT 13, AGI -3
//            ["Leather Dread Glove"] = new InventoryArmorData("Leather Dread Glove", 0x2F, ArmorType.ARM, 100, 100, 14, 19, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Dread Glove"] = new InventoryArmorData("Wood Dread Glove", 0x2F, ArmorType.ARM, 100, 100, 18, 21, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Dread Glove"] = new InventoryArmorData("Bronze Dread Glove", 0x2F, ArmorType.ARM, 100, 100, 16, 15, -5, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Dread Glove"] = new InventoryArmorData("Iron Dread Glove", 0x2F, ArmorType.ARM, 100, 100, 18, 15, -5, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Dread Glove"] = new InventoryArmorData("Hagane Dread Glove", 0x2F, ArmorType.ARM, 100, 100, 19, 16, -4, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Dread Glove"] = new InventoryArmorData("Silver Dread Glove", 0x2F, ArmorType.ARM, 100, 100, 17, 15, -4, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Dread Glove"] = new InventoryArmorData("Damascus Dread Glove", 0x2F, ArmorType.ARM, 100, 100, 22, 17, -4, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//        }
//}
