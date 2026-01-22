//using VagrantStoryArchipelago.Enums;
//using VagrantStoryArchipelago.Models.Inventory;

//namespace VagrantStoryArchipelago.Helpers.EntityLists
//{
//    internal class ChestpieceArmour
//    {
//        public static readonly Dictionary<string, InventoryArmorData> Chestpieces = new Dictionary<string, InventoryArmorData>
//        {
//            // ===== BODY ARMOR =====
//            // Jerkin (ID 0x10) - Base: STR 5, INT 5, AGI 0, Blunt 1, Edged 1, Piercing 0
//            ["Leather Jerkin"] = new InventoryArmorData("Leather Jerkin", 0x10, ArmorType.CHEST, 100, 100, 6, 11, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, ArmorMaterials.LEATHER, 0x00),
//            ["Wood Jerkin"] = new InventoryArmorData("Wood Jerkin", 0x10, ArmorType.CHEST, 100, 100, 10, 13, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, ArmorMaterials.WOOD, 0x00),
//            ["Bronze Jerkin"] = new InventoryArmorData("Bronze Jerkin", 0x10, ArmorType.CHEST, 100, 100, 8, 7, -2, 1, 1, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, ArmorMaterials.BRONZE, 0x00),
//            ["Iron Jerkin"] = new InventoryArmorData("Iron Jerkin", 0x10, ArmorType.CHEST, 100, 100, 10, 7, -2, 1, 1, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, ArmorMaterials.IRON, 0x00),
//            ["Hagane Jerkin"] = new InventoryArmorData("Hagane Jerkin", 0x10, ArmorType.CHEST, 100, 100, 11, 8, -1, 1, 1, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, ArmorMaterials.HAGANE, 0x00),
//            ["Silver Jerkin"] = new InventoryArmorData("Silver Jerkin", 0x10, ArmorType.CHEST, 100, 100, 9, 7, -1, 1, 1, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, ArmorMaterials.SILVER, 0x00),
//            ["Damascus Jerkin"] = new InventoryArmorData("Damascus Jerkin", 0x10, ArmorType.CHEST, 100, 100, 14, 9, -1, 1, 1, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, ArmorMaterials.DAMASCUS, 0x00),

//            // Hauberk (ID 0x11) - Base: STR 5, INT 10, AGI 0, Blunt 0, Edged 0, Piercing 1
//            ["Leather Hauberk"] = new InventoryArmorData("Leather Hauberk", 0x11, ArmorType.CHEST, 100, 100, 6, 16, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Hauberk"] = new InventoryArmorData("Wood Hauberk", 0x11, ArmorType.CHEST, 100, 100, 10, 18, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Hauberk"] = new InventoryArmorData("Bronze Hauberk", 0x11, ArmorType.CHEST, 100, 100, 8, 12, -2, 0, 0, 1, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Hauberk"] = new InventoryArmorData("Iron Hauberk", 0x11, ArmorType.CHEST, 100, 100, 10, 12, -2, 0, 0, 1, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Hauberk"] = new InventoryArmorData("Hagane Hauberk", 0x11, ArmorType.CHEST, 100, 100, 11, 13, -1, 0, 0, 1, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Hauberk"] = new InventoryArmorData("Silver Hauberk", 0x11, ArmorType.CHEST, 100, 100, 9, 12, -1, 0, 0, 1, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Hauberk"] = new InventoryArmorData("Damascus Hauberk", 0x11, ArmorType.CHEST, 100, 100, 14, 14, -1, 0, 0, 1, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//            // Wizard Robe (ID 0x12) - Base: STR 3, INT 20, AGI 0, Blunt 0, Edged 0, Piercing 0
//            ["Leather Wizard Robe"] = new InventoryArmorData("Leather Wizard Robe", 0x12, ArmorType.CHEST, 100, 100, 4, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Wizard Robe"] = new InventoryArmorData("Wood Wizard Robe", 0x12, ArmorType.CHEST, 100, 100, 8, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Wizard Robe"] = new InventoryArmorData("Bronze Wizard Robe", 0x12, ArmorType.CHEST, 100, 100, 6, 22, -2, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Wizard Robe"] = new InventoryArmorData("Iron Wizard Robe", 0x12, ArmorType.CHEST, 100, 100, 8, 22, -2, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Wizard Robe"] = new InventoryArmorData("Hagane Wizard Robe", 0x12, ArmorType.CHEST, 100, 100, 9, 23, -1, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Wizard Robe"] = new InventoryArmorData("Silver Wizard Robe", 0x12, ArmorType.CHEST, 100, 100, 7, 22, -1, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Wizard Robe"] = new InventoryArmorData("Damascus Wizard Robe", 0x12, ArmorType.CHEST, 100, 100, 12, 24, -1, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//            // Cuirass (ID 0x13) - Base: STR 7, INT 8, AGI 0, Blunt 3, Edged 0, Piercing 0
//            ["Leather Cuirass"] = new InventoryArmorData("Leather Cuirass", 0x13, ArmorType.CHEST, 100, 100, 8, 14, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Cuirass"] = new InventoryArmorData("Wood Cuirass", 0x13, ArmorType.CHEST, 100, 100, 12, 16, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Cuirass"] = new InventoryArmorData("Bronze Cuirass", 0x13, ArmorType.CHEST, 100, 100, 10, 10, -2, 3, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Cuirass"] = new InventoryArmorData("Iron Cuirass", 0x13, ArmorType.CHEST, 100, 100, 12, 10, -2, 3, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Cuirass"] = new InventoryArmorData("Hagane Cuirass", 0x13, ArmorType.CHEST, 100, 100, 13, 11, -1, 3, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Cuirass"] = new InventoryArmorData("Silver Cuirass", 0x13, ArmorType.CHEST, 100, 100, 11, 10, -1, 3, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Cuirass"] = new InventoryArmorData("Damascus Cuirass", 0x13, ArmorType.CHEST, 100, 100, 16, 12, -1, 3, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Banded Mail (ID 0x14) - Base: STR 8, INT 8, AGI -1, Blunt 0, Edged 0, Piercing 3
//            ["Leather Banded Mail"] = new InventoryArmorData("Leather Banded Mail", 0x14, ArmorType.CHEST, 100, 100, 9, 14, -1, 0, 0, 3, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Banded Mail"] = new InventoryArmorData("Wood Banded Mail", 0x14, ArmorType.CHEST, 100, 100, 13, 16, -1, 0, 0, 3, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Banded Mail"] = new InventoryArmorData("Bronze Banded Mail", 0x14, ArmorType.CHEST, 100, 100, 11, 10, -3, 0, 0, 3, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Banded Mail"] = new InventoryArmorData("Iron Banded Mail", 0x14, ArmorType.CHEST, 100, 100, 13, 10, -3, 0, 0, 3, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Banded Mail"] = new InventoryArmorData("Hagane Banded Mail", 0x14, ArmorType.CHEST, 100, 100, 14, 11, -2, 0, 0, 3, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Banded Mail"] = new InventoryArmorData("Silver Banded Mail", 0x14, ArmorType.CHEST, 100, 100, 12, 10, -2, 0, 0, 3, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Banded Mail"] = new InventoryArmorData("Damascus Banded Mail", 0x14, ArmorType.CHEST, 100, 100, 17, 12, -2, 0, 0, 3, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00)
//            // Ring Mail (ID 0x15) - Base: STR 7, INT 12, AGI -1, Blunt 0, Edged 3, Piercing 5
//            ["Leather Ring Mail"] = new InventoryArmorData("Leather Ring Mail", 0x15, ArmorType.CHEST, 100, 100, 8, 18, -1, 0, 3, 5, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Ring Mail"] = new InventoryArmorData("Wood Ring Mail", 0x15, ArmorType.CHEST, 100, 100, 12, 20, -1, 0, 3, 5, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Ring Mail"] = new InventoryArmorData("Bronze Ring Mail", 0x15, ArmorType.CHEST, 100, 100, 10, 14, -3, 0, 3, 5, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Ring Mail"] = new InventoryArmorData("Iron Ring Mail", 0x15, ArmorType.CHEST, 100, 100, 12, 14, -3, 0, 3, 5, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Ring Mail"] = new InventoryArmorData("Hagane Ring Mail", 0x15, ArmorType.CHEST, 100, 100, 13, 15, -2, 0, 3, 5, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Ring Mail"] = new InventoryArmorData("Silver Ring Mail", 0x15, ArmorType.CHEST, 100, 100, 11, 14, -2, 0, 3, 5, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Ring Mail"] = new InventoryArmorData("Damascus Ring Mail", 0x15, ArmorType.CHEST, 100, 100, 16, 16, -2, 0, 3, 5, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Chain Mail (ID 0x16) - Base: STR 9, INT 12, AGI -1, Blunt 5, Edged 5, Piercing 0
//            ["Leather Chain Mail"] = new InventoryArmorData("Leather Chain Mail", 0x16, ArmorType.CHEST, 100, 100, 10, 18, -1, 5, 5, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Chain Mail"] = new InventoryArmorData("Wood Chain Mail", 0x16, ArmorType.CHEST, 100, 100, 14, 20, -1, 5, 5, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Chain Mail"] = new InventoryArmorData("Bronze Chain Mail", 0x16, ArmorType.CHEST, 100, 100, 12, 14, -3, 5, 5, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Chain Mail"] = new InventoryArmorData("Iron Chain Mail", 0x16, ArmorType.CHEST, 100, 100, 14, 14, -3, 5, 5, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Chain Mail"] = new InventoryArmorData("Hagane Chain Mail", 0x16, ArmorType.CHEST, 100, 100, 15, 15, -2, 5, 5, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Chain Mail"] = new InventoryArmorData("Silver Chain Mail", 0x16, ArmorType.CHEST, 100, 100, 13, 14, -2, 5, 5, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Chain Mail"] = new InventoryArmorData("Damascus Chain Mail", 0x16, ArmorType.CHEST, 100, 100, 18, 16, -2, 5, 5, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Breastplate (ID 0x17) - Base: STR 11, INT 12, AGI -2, Blunt 8, Edged 0, Piercing 8
//            ["Leather Breastplate"] = new InventoryArmorData("Leather Breastplate", 0x17, ArmorType.CHEST, 100, 100, 12, 18, -2, 8, 0, 8, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Breastplate"] = new InventoryArmorData("Wood Breastplate", 0x17, ArmorType.CHEST, 100, 100, 16, 20, -2, 8, 0, 8, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Breastplate"] = new InventoryArmorData("Bronze Breastplate", 0x17, ArmorType.CHEST, 100, 100, 14, 14, -4, 8, 0, 8, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Breastplate"] = new InventoryArmorData("Iron Breastplate", 0x17, ArmorType.CHEST, 100, 100, 16, 14, -4, 8, 0, 8, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Breastplate"] = new InventoryArmorData("Hagane Breastplate", 0x17, ArmorType.CHEST, 100, 100, 17, 15, -3, 8, 0, 8, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Breastplate"] = new InventoryArmorData("Silver Breastplate", 0x17, ArmorType.CHEST, 100, 100, 15, 14, -3, 8, 0, 8, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Breastplate"] = new InventoryArmorData("Damascus Breastplate", 0x17, ArmorType.CHEST, 100, 100, 20, 16, -3, 8, 0, 8, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),        // Segmentata (ID 0x18) - Base: STR 13, INT 13, AGI -1, Blunt 10, Edged 8, Piercing 5
//            ["Leather Segmentata"] = new InventoryArmorData("Leather Segmentata", 0x18, ArmorType.CHEST, 100, 100, 14, 19, -1, 10, 8, 5, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Segmentata"] = new InventoryArmorData("Wood Segmentata", 0x18, ArmorType.CHEST, 100, 100, 18, 21, -1, 10, 8, 5, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Segmentata"] = new InventoryArmorData("Bronze Segmentata", 0x18, ArmorType.CHEST, 100, 100, 16, 15, -3, 10, 8, 5, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Segmentata"] = new InventoryArmorData("Iron Segmentata", 0x18, ArmorType.CHEST, 100, 100, 18, 15, -3, 10, 8, 5, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Segmentata"] = new InventoryArmorData("Hagane Segmentata", 0x18, ArmorType.CHEST, 100, 100, 19, 16, -2, 10, 8, 5, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Segmentata"] = new InventoryArmorData("Silver Segmentata", 0x18, ArmorType.CHEST, 100, 100, 17, 15, -2, 10, 8, 5, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Segmentata"] = new InventoryArmorData("Damascus Segmentata", 0x18, ArmorType.CHEST, 100, 100, 22, 17, -2, 10, 8, 5, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Scale Armor (ID 0x19) - Base: STR 15, INT 15, AGI -1, Blunt 0, Edged 5, Piercing 10
//            ["Leather Scale Armour"] = new InventoryArmorData("Leather Scale Armour", 0x19, ArmorType.CHEST, 100, 100, 16, 21, -1, 0, 5, 10, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Scale Armour"] = new InventoryArmorData("Wood Scale Armour", 0x19, ArmorType.CHEST, 100, 100, 20, 23, -1, 0, 5, 10, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Scale Armour"] = new InventoryArmorData("Bronze Scale Armour", 0x19, ArmorType.CHEST, 100, 100, 18, 17, -3, 0, 5, 10, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Scale Armour"] = new InventoryArmorData("Iron Scale Armour", 0x19, ArmorType.CHEST, 100, 100, 20, 17, -3, 0, 5, 10, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Scale Armour"] = new InventoryArmorData("Hagane Scale Armour", 0x19, ArmorType.CHEST, 100, 100, 21, 18, -2, 0, 5, 10, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Scale Armour"] = new InventoryArmorData("Silver Scale Armour", 0x19, ArmorType.CHEST, 100, 100, 19, 17, -2, 0, 5, 10, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Scale Armour"] = new InventoryArmorData("Damascus Scale Armour", 0x19, ArmorType.CHEST, 100, 100, 24, 19, -2, 0, 5, 10, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),        // Brigandine (ID 0x1A) - Base: STR 17, INT 17, AGI -2, Blunt 5, Edged 10, Piercing 0
//            ["Leather Brigandine"] = new InventoryArmorData("Leather Brigandine", 0x1A, ArmorType.CHEST, 100, 100, 18, 23, -2, 5, 10, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Brigandine"] = new InventoryArmorData("Wood Brigandine", 0x1A, ArmorType.CHEST, 100, 100, 22, 25, -2, 5, 10, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Brigandine"] = new InventoryArmorData("Bronze Brigandine", 0x1A, ArmorType.CHEST, 100, 100, 20, 19, -4, 5, 10, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Brigandine"] = new InventoryArmorData("Iron Brigandine", 0x1A, ArmorType.CHEST, 100, 100, 22, 19, -4, 5, 10, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Brigandine"] = new InventoryArmorData("Hagane Brigandine", 0x1A, ArmorType.CHEST, 100, 100, 23, 20, -3, 5, 10, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Brigandine"] = new InventoryArmorData("Silver Brigandine", 0x1A, ArmorType.CHEST, 100, 100, 21, 19, -3, 5, 10, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Brigandine"] = new InventoryArmorData("Damascus Brigandine", 0x1A, ArmorType.CHEST, 100, 100, 26, 21, -3, 5, 10, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),        // Plate Mail (ID 0x1B) - Base: STR 18, INT 17, AGI -2, Blunt 10, Edged 10, Piercing 10
//            ["Leather Plate Mail"] = new InventoryArmorData("Leather Plate Mail", 0x1B, ArmorType.CHEST, 100, 100, 19, 23, -2, 10, 10, 10, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Plate Mail"] = new InventoryArmorData("Wood Plate Mail", 0x1B, ArmorType.CHEST, 100, 100, 23, 25, -2, 10, 10, 10, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Plate Mail"] = new InventoryArmorData("Bronze Plate Mail", 0x1B, ArmorType.CHEST, 100, 100, 21, 19, -4, 10, 10, 10, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Plate Mail"] = new InventoryArmorData("Iron Plate Mail", 0x1B, ArmorType.CHEST, 100, 100, 23, 19, -4, 10, 10, 10, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Plate Mail"] = new InventoryArmorData("Hagane Plate Mail", 0x1B, ArmorType.CHEST, 100, 100, 24, 20, -3, 10, 10, 10, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Plate Mail"] = new InventoryArmorData("Silver Plate Mail", 0x1B, ArmorType.CHEST, 100, 100, 22, 19, -3, 10, 10, 10, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Plate Mail"] = new InventoryArmorData("Damascus Plate Mail", 0x1B, ArmorType.CHEST, 100, 100, 27, 21, -3, 10, 10, 10, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Fluted Armour (ID 0x1C) - Base: STR 18, INT 18, AGI -2, Blunt 15, Edged 15, Piercing 15
//            ["Leather Fluted Armour"] = new InventoryArmorData("Leather Fluted Armour", 0x1C, ArmorType.CHEST, 100, 100, 19, 24, -2, 15, 15, 15, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Fluted Armour"] = new InventoryArmorData("Wood Fluted Armour", 0x1C, ArmorType.CHEST, 100, 100, 23, 26, -2, 15, 15, 15, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Fluted Armour"] = new InventoryArmorData("Bronze Fluted Armour", 0x1C, ArmorType.CHEST, 100, 100, 21, 20, -4, 15, 15, 15, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Fluted Armour"] = new InventoryArmorData("Iron Fluted Armour", 0x1C, ArmorType.CHEST, 100, 100, 23, 20, -4, 15, 15, 15, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Fluted Armour"] = new InventoryArmorData("Hagane Fluted Armour", 0x1C, ArmorType.CHEST, 100, 100, 24, 21, -3, 15, 15, 15, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Fluted Armour"] = new InventoryArmorData("Silver Fluted Armour", 0x1C, ArmorType.CHEST, 100, 100, 22, 20, -3, 15, 15, 15, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Fluted Armour"] = new InventoryArmorData("Damascus Fluted Armour", 0x1C, ArmorType.CHEST, 100, 100, 27, 22, -3, 15, 15, 15, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

//            // Hoplite Armour (ID 0x1D) - Base: STR 18, INT 22, AGI -3, Blunt 20, Edged 8, Piercing 0
//            ["Leather Hoplite Armour"] = new InventoryArmorData("Leather Hoplite Armour", 0x1D, ArmorType.CHEST, 100, 100, 19, 28, -3, 20, 8, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Hoplite Armour"] = new InventoryArmorData("Wood Hoplite Armour", 0x1D, ArmorType.CHEST, 100, 100, 23, 30, -3, 20, 8, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Hoplite Armour"] = new InventoryArmorData("Bronze Hoplite Armour", 0x1D, ArmorType.CHEST, 100, 100, 21, 24, -5, 20, 8, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Hoplite Armour"] = new InventoryArmorData("Iron Hoplite Armour", 0x1D, ArmorType.CHEST, 100, 100, 23, 24, -5, 20, 8, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Hoplite Armour"] = new InventoryArmorData("Hagane Hoplite Armour", 0x1D, ArmorType.CHEST, 100, 100, 24, 25, -4, 20, 8, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Hoplite Armour"] = new InventoryArmorData("Silver Hoplite Armour", 0x1D, ArmorType.CHEST, 100, 100, 22, 24, -4, 20, 8, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Hoplite Armour"] = new InventoryArmorData("Damascus Hoplite Armour", 0x1D, ArmorType.CHEST, 100, 100, 27, 26, -4, 20, 8, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Jazeraint Armour (ID 0x1E) - Base: STR 19, INT 20, AGI -3
//            ["Leather Jazeraint Armour"] = new InventoryArmorData("Leather Jazeraint Armour", 0x1E, ArmorType.CHEST, 100, 100, 20, 26, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Jazeraint Armour"] = new InventoryArmorData("Wood Jazeraint Armour", 0x1E, ArmorType.CHEST, 100, 100, 24, 28, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Jazeraint Armour"] = new InventoryArmorData("Bronze Jazeraint Armour", 0x1E, ArmorType.CHEST, 100, 100, 22, 22, -5, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Jazeraint Armour"] = new InventoryArmorData("Iron Jazeraint Armour", 0x1E, ArmorType.CHEST, 100, 100, 24, 22, -5, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Jazeraint Armour"] = new InventoryArmorData("Hagane Jazeraint Armour", 0x1E, ArmorType.CHEST, 100, 100, 25, 23, -4, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Jazeraint Armour"] = new InventoryArmorData("Silver Jazeraint Armour", 0x1E, ArmorType.CHEST, 100, 100, 23, 22, -4, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Jazeraint Armour"] = new InventoryArmorData("Damascus Jazeraint Armour", 0x1E, ArmorType.CHEST, 100, 100, 28, 24, -4, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//            // Dread Armour (ID 0x1F) - Base: STR 20, INT 19, AGI -3
//            ["Leather Dread Armour"] = new InventoryArmorData("Leather Dread Armour", 0x1F, ArmorType.CHEST, 100, 100, 21, 25, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
//            ["Wood Dread Armour"] = new InventoryArmorData("Wood Dread Armour", 0x1F, ArmorType.CHEST, 100, 100, 25, 27, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
//            ["Bronze Dread Armour"] = new InventoryArmorData("Bronze Dread Armour", 0x1F, ArmorType.CHEST, 100, 100, 23, 21, -5, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
//            ["Iron Dread Armour"] = new InventoryArmorData("Iron Dread Armour", 0x1F, ArmorType.CHEST, 100, 100, 25, 21, -5, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
//            ["Hagane Dread Armour"] = new InventoryArmorData("Hagane Dread Armour", 0x1F, ArmorType.CHEST, 100, 100, 26, 22, -4, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
//            ["Silver Dread Armour"] = new InventoryArmorData("Silver Dread Armour", 0x1F, ArmorType.CHEST, 100, 100, 24, 21, -4, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
//            ["Damascus Dread Armour"] = new InventoryArmorData("Damascus Dread Armour", 0x1F, ArmorType.CHEST, 100, 100, 29, 23, -4, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
//        }
//}
