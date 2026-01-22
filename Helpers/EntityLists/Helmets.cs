using VagrantStoryArchipelago.Enums;

using VagrantStoryArchipelago.Models.Inventory;

namespace VagrantStoryArchipelago.Helpers.EntityLists
{
    internal class HelmetDatabase
    {


        public static readonly Dictionary<string, InventoryArmorData> Helmets = new Dictionary<string, InventoryArmorData>
        {
            // ===== HELMS =====
            // Bandana (ID 0x00) - Base: STR 1, INT 3, AGI 0, Blunt 0, Edged 0, Piercing 0
            ["Leather Bandana"] = new InventoryArmorData("Leather Bandana", 0x00, ArmorType.HELM, 0x64, 0x64, 0x02, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x05, 0x05, 0xFE, 0xFE, 0xFA, 0xFA, ArmorMaterials.LEATHER, 0x00),
            ["Wood Bandana"] = new InventoryArmorData("Wood Bandana", 0x00, ArmorType.HELM, 0x64, 0x64, 0x06, 0x0B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x06, 0x08, 0x08, 0x06, 0x04, 0x04, ArmorMaterials.WOOD, 0x00),
            //    ["Bronze Bandana"] = new InventoryArmorData("Bronze Bandana", 0x00, ArmorType.HELM, 100, 100, 4, 5, -2, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Bandana"] = new InventoryArmorData("Iron Bandana", 0x00, ArmorType.HELM, 100, 100, 6, 5, -2, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Bandana"] = new InventoryArmorData("Hagane Bandana", 0x00, ArmorType.HELM, 100, 100, 7, 6, -1, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Bandana"] = new InventoryArmorData("Silver Bandana", 0x00, ArmorType.HELM, 100, 100, 5, 5, -1, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Bandana"] = new InventoryArmorData("Damascus Bandana", 0x00, ArmorType.HELM, 100, 100, 10, 7, -1, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Bear Mask (ID 0x01) - Base: STR 2, INT 4, AGI 0, Blunt 2, Edged 0, Piercing 0
            //    ["Leather Bear Mask"] = new InventoryArmorData("Leather Bear Mask", 0x01, ArmorType.HELM, 100, 100, 3, 10, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Bear Mask"] = new InventoryArmorData("Wood Bear Mask", 0x01, ArmorType.HELM, 100, 100, 7, 12, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Bear Mask"] = new InventoryArmorData("Bronze Bear Mask", 0x01, ArmorType.HELM, 100, 100, 5, 6, -2, 2, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Bear Mask"] = new InventoryArmorData("Iron Bear Mask", 0x01, ArmorType.HELM, 100, 100, 7, 6, -2, 2, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Bear Mask"] = new InventoryArmorData("Hagane Bear Mask", 0x01, ArmorType.HELM, 100, 100, 8, 7, -1, 2, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Bear Mask"] = new InventoryArmorData("Silver Bear Mask", 0x01, ArmorType.HELM, 100, 100, 6, 6, -1, 2, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Bear Mask"] = new InventoryArmorData("Damascus Bear Mask", 0x01, ArmorType.HELM, 100, 100, 11, 8, -1, 2, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Wizard Hat (ID 0x02) - Base: STR 1, INT 10, AGI 0, Blunt 1, Edged 0, Piercing 0
            //    ["Leather Wizard Hat"] = new InventoryArmorData("Leather Wizard Hat", 0x02, ArmorType.HELM, 100, 100, 2, 16, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Wizard Hat"] = new InventoryArmorData("Wood Wizard Hat", 0x02, ArmorType.HELM, 100, 100, 6, 18, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Wizard Hat"] = new InventoryArmorData("Bronze Wizard Hat", 0x02, ArmorType.HELM, 100, 100, 4, 12, -2, 1, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Wizard Hat"] = new InventoryArmorData("Iron Wizard Hat", 0x02, ArmorType.HELM, 100, 100, 6, 12, -2, 1, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Wizard Hat"] = new InventoryArmorData("Hagane Wizard Hat", 0x02, ArmorType.HELM, 100, 100, 7, 13, -1, 1, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Wizard Hat"] = new InventoryArmorData("Silver Wizard Hat", 0x02, ArmorType.HELM, 100, 100, 5, 12, -1, 1, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Wizard Hat"] = new InventoryArmorData("Damascus Wizard Hat", 0x02, ArmorType.HELM, 100, 100, 10, 14, -1, 1, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Bone Helm (ID 0x03) - Base: STR 2, INT 3, AGI -1, Blunt 0, Edged 2, Piercing 0
            //    ["Leather Bone Helm"] = new InventoryArmorData("Leather Bone Helm", 0x03, ArmorType.HELM, 100, 100, 3, 9, -1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Bone Helm"] = new InventoryArmorData("Wood Bone Helm", 0x03, ArmorType.HELM, 100, 100, 7, 11, -1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Bone Helm"] = new InventoryArmorData("Bronze Bone Helm", 0x03, ArmorType.HELM, 100, 100, 5, 5, -3, 0, 2, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Bone Helm"] = new InventoryArmorData("Iron Bone Helm", 0x03, ArmorType.HELM, 100, 100, 7, 5, -3, 0, 2, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Bone Helm"] = new InventoryArmorData("Hagane Bone Helm", 0x03, ArmorType.HELM, 100, 100, 8, 6, -2, 0, 2, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Bone Helm"] = new InventoryArmorData("Silver Bone Helm", 0x03, ArmorType.HELM, 100, 100, 6, 5, -2, 0, 2, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Bone Helm"] = new InventoryArmorData("Damascus Bone Helm", 0x03, ArmorType.HELM, 100, 100, 11, 7, -2, 0, 2, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Chain Coif (ID 0x04) - Base: STR 3, INT 5, AGI -1, Blunt 2, Edged 3, Piercing 0
            //    ["Leather Chain Coif"] = new InventoryArmorData("Leather Chain Coif", 0x04, ArmorType.HELM, 100, 100, 4, 11, -1, 2, 3, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Chain Coif"] = new InventoryArmorData("Wood Chain Coif", 0x04, ArmorType.HELM, 100, 100, 8, 13, -1, 2, 3, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Chain Coif"] = new InventoryArmorData("Bronze Chain Coif", 0x04, ArmorType.HELM, 100, 100, 6, 7, -3, 2, 3, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Chain Coif"] = new InventoryArmorData("Iron Chain Coif", 0x04, ArmorType.HELM, 100, 100, 8, 7, -3, 2, 3, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Chain Coif"] = new InventoryArmorData("Hagane Chain Coif", 0x04, ArmorType.HELM, 100, 100, 9, 8, -2, 2, 3, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Chain Coif"] = new InventoryArmorData("Silver Chain Coif", 0x04, ArmorType.HELM, 100, 100, 7, 7, -2, 2, 3, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Chain Coif"] = new InventoryArmorData("Damascus Chain Coif", 0x04, ArmorType.HELM, 100, 100, 12, 9, -2, 2, 3, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Spangenhelm (ID 0x05) - Base: STR 3, INT 5, AGI -1, Blunt 1, Edged 1, Piercing 1
            //    ["Leather Spangenhelm"] = new InventoryArmorData("Leather Spangenhelm", 0x05, ArmorType.HELM, 100, 100, 4, 11, -1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Spangenhelm"] = new InventoryArmorData("Wood Spangenhelm", 0x05, ArmorType.HELM, 100, 100, 8, 13, -1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Spangenhelm"] = new InventoryArmorData("Bronze Spangenhelm", 0x05, ArmorType.HELM, 100, 100, 6, 7, -3, 1, 1, 1, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Spangenhelm"] = new InventoryArmorData("Iron Spangenhelm", 0x05, ArmorType.HELM, 100, 100, 8, 7, -3, 1, 1, 1, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Spangenhelm"] = new InventoryArmorData("Hagane Spangenhelm", 0x05, ArmorType.HELM, 100, 100, 9, 8, -2, 1, 1, 1, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Spangenhelm"] = new InventoryArmorData("Silver Spangenhelm", 0x05, ArmorType.HELM, 100, 100, 7, 7, -2, 1, 1, 1, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Spangenhelm"] = new InventoryArmorData("Damascus Spangenhelm", 0x05, ArmorType.HELM, 100, 100, 12, 9, -2, 1, 1, 1, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Cabasset (ID 0x06) - Base: STR 4, INT 5, AGI -1, Blunt 2, Edged 2, Piercing 2
            //    ["Leather Cabasset"] = new InventoryArmorData("Leather Cabasset", 0x06, ArmorType.HELM, 100, 100, 5, 11, -1, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Cabasset"] = new InventoryArmorData("Wood Cabasset", 0x06, ArmorType.HELM, 100, 100, 9, 13, -1, 2, 2, 2, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Cabasset"] = new InventoryArmorData("Bronze Cabasset", 0x06, ArmorType.HELM, 100, 100, 7, 7, -3, 2, 2, 2, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Cabasset"] = new InventoryArmorData("Iron Cabasset", 0x06, ArmorType.HELM, 100, 100, 9, 7, -3, 2, 2, 2, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Cabasset"] = new InventoryArmorData("Hagane Cabasset", 0x06, ArmorType.HELM, 100, 100, 10, 8, -2, 2, 2, 2, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Cabasset"] = new InventoryArmorData("Silver Cabasset", 0x06, ArmorType.HELM, 100, 100, 8, 7, -2, 2, 2, 2, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Cabasset"] = new InventoryArmorData("Damascus Cabasset", 0x06, ArmorType.HELM, 100, 100, 13, 9, -2, 2, 2, 2, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Sallet (ID 0x07) - Base: STR 5, INT 6, AGI -1, Blunt 1, Edged 3, Piercing 3
            //    ["Leather Sallet"] = new InventoryArmorData("Leather Sallet", 0x07, ArmorType.HELM, 100, 100, 6, 12, -1, 1, 3, 3, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Sallet"] = new InventoryArmorData("Wood Sallet", 0x07, ArmorType.HELM, 100, 100, 10, 14, -1, 1, 3, 3, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Sallet"] = new InventoryArmorData("Bronze Sallet", 0x07, ArmorType.HELM, 100, 100, 8, 8, -3, 1, 3, 3, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Sallet"] = new InventoryArmorData("Iron Sallet", 0x07, ArmorType.HELM, 100, 100, 10, 8, -3, 1, 3, 3, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Sallet"] = new InventoryArmorData("Hagane Sallet", 0x07, ArmorType.HELM, 100, 100, 11, 9, -2, 1, 3, 3, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Sallet"] = new InventoryArmorData("Silver Sallet", 0x07, ArmorType.HELM, 100, 100, 9, 8, -2, 1, 3, 3, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Sallet"] = new InventoryArmorData("Damascus Sallet", 0x07, ArmorType.HELM, 100, 100, 14, 10, -2, 1, 3, 3, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Barbut (ID 0x08) - Base: STR 6, INT 7, AGI -1, Blunt 5, Edged 0, Piercing 5
            //    ["Leather Barbut"] = new InventoryArmorData("Leather Barbut", 0x08, ArmorType.HELM, 100, 100, 7, 13, -1, 5, 0, 5, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Barbut"] = new InventoryArmorData("Wood Barbut", 0x08, ArmorType.HELM, 100, 100, 11, 15, -1, 5, 0, 5, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Barbut"] = new InventoryArmorData("Bronze Barbut", 0x08, ArmorType.HELM, 100, 100, 9, 9, -3, 5, 0, 5, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Barbut"] = new InventoryArmorData("Iron Barbut", 0x08, ArmorType.HELM, 100, 100, 11, 9, -3, 5, 0, 5, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Barbut"] = new InventoryArmorData("Hagane Barbut", 0x08, ArmorType.HELM, 100, 100, 12, 10, -2, 5, 0, 5, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Barbut"] = new InventoryArmorData("Silver Barbut", 0x08, ArmorType.HELM, 100, 100, 10, 9, -2, 5, 0, 5, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Barbut"] = new InventoryArmorData("Damascus Barbut", 0x08, ArmorType.HELM, 100, 100, 15, 11, -2, 5, 0, 5, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Basinet (ID 0x09) - Base: STR 7, INT 8, AGI -1, Blunt 7, Edged 3, Piercing 5
            //    ["Leather Basinet"] = new InventoryArmorData("Leather Basinet", 0x09, ArmorType.HELM, 100, 100, 8, 14, -1, 7, 3, 5, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Basinet"] = new InventoryArmorData("Wood Basinet", 0x09, ArmorType.HELM, 100, 100, 12, 16, -1, 7, 3, 5, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Basinet"] = new InventoryArmorData("Bronze Basinet", 0x09, ArmorType.HELM, 100, 100, 10, 10, -3, 7, 3, 5, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Basinet"] = new InventoryArmorData("Iron Basinet", 0x09, ArmorType.HELM, 100, 100, 12, 10, -3, 7, 3, 5, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Basinet"] = new InventoryArmorData("Hagane Basinet", 0x09, ArmorType.HELM, 100, 100, 13, 11, -2, 7, 3, 5, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Basinet"] = new InventoryArmorData("Silver Basinet", 0x09, ArmorType.HELM, 100, 100, 11, 10, -2, 7, 3, 5, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Basinet"] = new InventoryArmorData("Damascus Basinet", 0x09, ArmorType.HELM, 100, 100, 16, 12, -2, 7, 3, 5, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
            //    // Armet (ID 0x0A) - Base: STR 8, INT 9, AGI -2, Blunt 4, Edged 6, Piercing 4
            //    ["Leather Armet"] = new InventoryArmorData("Leather Armet", 0x0A, ArmorType.HELM, 100, 100, 9, 15, -2, 4, 6, 4, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Armet"] = new InventoryArmorData("Wood Armet", 0x0A, ArmorType.HELM, 100, 100, 13, 17, -2, 4, 6, 4, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Armet"] = new InventoryArmorData("Bronze Armet", 0x0A, ArmorType.HELM, 100, 100, 11, 11, -4, 4, 6, 4, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Armet"] = new InventoryArmorData("Iron Armet", 0x0A, ArmorType.HELM, 100, 100, 13, 11, -4, 4, 6, 4, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Armet"] = new InventoryArmorData("Hagane Armet", 0x0A, ArmorType.HELM, 100, 100, 14, 12, -3, 4, 6, 4, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Armet"] = new InventoryArmorData("Silver Armet", 0x0A, ArmorType.HELM, 100, 100, 12, 11, -3, 4, 6, 4, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Armet"] = new InventoryArmorData("Damascus Armet", 0x0A, ArmorType.HELM, 100, 100, 17, 13, -3, 4, 6, 4, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Close Helm (ID 0x0B) - Base: STR 9, INT 10, AGI -2, Blunt 5, Edged 10, Piercing 10
            //    ["Leather Close Helm"] = new InventoryArmorData("Leather Close Helm", 0x0B, ArmorType.HELM, 100, 100, 10, 16, -2, 5, 10, 10, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Close Helm"] = new InventoryArmorData("Wood Close Helm", 0x0B, ArmorType.HELM, 100, 100, 14, 18, -2, 5, 10, 10, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Close Helm"] = new InventoryArmorData("Bronze Close Helm", 0x0B, ArmorType.HELM, 100, 100, 12, 12, -4, 5, 10, 10, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Close Helm"] = new InventoryArmorData("Iron Close Helm", 0x0B, ArmorType.HELM, 100, 100, 14, 12, -4, 5, 10, 10, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Close Helm"] = new InventoryArmorData("Hagane Close Helm", 0x0B, ArmorType.HELM, 100, 100, 15, 13, -3, 5, 10, 10, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Close Helm"] = new InventoryArmorData("Silver Close Helm", 0x0B, ArmorType.HELM, 100, 100, 13, 12, -3, 5, 10, 10, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Close Helm"] = new InventoryArmorData("Damascus Close Helm", 0x0B, ArmorType.HELM, 100, 100, 18, 14, -3, 5, 10, 10, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Burgonet (ID 0x0C) - Base: STR 10, INT 11, AGI -2, Blunt 7, Edged 7, Piercing 7
            //    ["Leather Burgonet"] = new InventoryArmorData("Leather Burgonet", 0x0C, ArmorType.HELM, 100, 100, 11, 17, -2, 7, 7, 7, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Burgonet"] = new InventoryArmorData("Wood Burgonet", 0x0C, ArmorType.HELM, 100, 100, 15, 19, -2, 7, 7, 7, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Burgonet"] = new InventoryArmorData("Bronze Burgonet", 0x0C, ArmorType.HELM, 100, 100, 13, 13, -4, 7, 7, 7, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Burgonet"] = new InventoryArmorData("Iron Burgonet", 0x0C, ArmorType.HELM, 100, 100, 15, 13, -4, 7, 7, 7, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Burgonet"] = new InventoryArmorData("Hagane Burgonet", 0x0C, ArmorType.HELM, 100, 100, 16, 14, -3, 7, 7, 7, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Burgonet"] = new InventoryArmorData("Silver Burgonet", 0x0C, ArmorType.HELM, 100, 100, 14, 13, -3, 7, 7, 7, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Burgonet"] = new InventoryArmorData("Damascus Burgonet", 0x0C, ArmorType.HELM, 100, 100, 19, 15, -3, 7, 7, 7, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Hoplite Helm (ID 0x0D) - Base: STR 11, INT 15, AGI -2, Blunt 13, Edged 5, Piercing 0
            //    ["Leather Hoplite Helm"] = new InventoryArmorData("Leather Hoplite Helm", 0x0D, ArmorType.HELM, 100, 100, 12, 21, -2, 13, 5, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Hoplite Helm"] = new InventoryArmorData("Wood Hoplite Helm", 0x0D, ArmorType.HELM, 100, 100, 16, 23, -2, 13, 5, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Hoplite Helm"] = new InventoryArmorData("Bronze Hoplite Helm", 0x0D, ArmorType.HELM, 100, 100, 14, 17, -4, 13, 5, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Hoplite Helm"] = new InventoryArmorData("Iron Hoplite Helm", 0x0D, ArmorType.HELM, 100, 100, 16, 17, -4, 13, 5, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Hoplite Helm"] = new InventoryArmorData("Hagane Hoplite Helm", 0x0D, ArmorType.HELM, 100, 100, 17, 18, -3, 13, 5, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Hoplite Helm"] = new InventoryArmorData("Silver Hoplite Helm", 0x0D, ArmorType.HELM, 100, 100, 15, 17, -3, 13, 5, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Hoplite Helm"] = new InventoryArmorData("Damascus Hoplite Helm", 0x0D, ArmorType.HELM, 100, 100, 20, 19, -3, 13, 5, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Jazeraint Helm (ID 0x0E) - Base: STR 12, INT 13, AGI -2, Blunt ?, Edged ?, Piercing ?
            //    ["Leather Jazeraint Helm"] = new InventoryArmorData("Leather Jazeraint Helm", 0x0E, ArmorType.HELM, 100, 100, 13, 19, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Jazeraint Helm"] = new InventoryArmorData("Wood Jazeraint Helm", 0x0E, ArmorType.HELM, 100, 100, 17, 21, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Jazeraint Helm"] = new InventoryArmorData("Bronze Jazeraint Helm", 0x0E, ArmorType.HELM, 100, 100, 15, 15, -4, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Jazeraint Helm"] = new InventoryArmorData("Iron Jazeraint Helm", 0x0E, ArmorType.HELM, 100, 100, 17, 15, -4, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Jazeraint Helm"] = new InventoryArmorData("Hagane Jazeraint Helm", 0x0E, ArmorType.HELM, 100, 100, 18, 16, -3, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Jazeraint Helm"] = new InventoryArmorData("Silver Jazeraint Helm", 0x0E, ArmorType.HELM, 100, 100, 16, 15, -3, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Jazeraint Helm"] = new InventoryArmorData("Damascus Jazeraint Helm", 0x0E, ArmorType.HELM, 100, 100, 21, 17, -3, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),

            //    // Dread Helm (ID 0x0F) - Base: STR 13, INT 12, AGI -2, Blunt ?, Edged ?, Piercing ?
            //    ["Leather Dread Helm"] = new InventoryArmorData("Leather Dread Helm", 0x0F, ArmorType.HELM, 100, 100, 14, 18, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 5, 5, 1, 1, 5, 5, 0x00, 0x00),
            //    ["Wood Dread Helm"] = new InventoryArmorData("Wood Dread Helm", 0x0F, ArmorType.HELM, 100, 100, 18, 20, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 8, 8, 6, 4, 4, 0x01, 0x00),
            //    ["Bronze Dread Helm"] = new InventoryArmorData("Bronze Dread Helm", 0x0F, ArmorType.HELM, 100, 100, 16, 14, -4, 0, 0, 0, 1, 1, 2, 1, 1, 5, 8, 5, 5, 3, 3, 2, 2, 0x02, 0x00),
            //    ["Iron Dread Helm"] = new InventoryArmorData("Iron Dread Helm", 0x0F, ArmorType.HELM, 100, 100, 18, 14, -4, 0, 0, 0, -1, -1, 2, -1, -1, 0, 10, 0, 4, 4, 0, 1, 1, 0x03, 0x00),
            //    ["Hagane Dread Helm"] = new InventoryArmorData("Hagane Dread Helm", 0x0F, ArmorType.HELM, 100, 100, 19, 15, -3, 0, 0, 0, -5, -5, -1, 0, -5, -5, 14, 3, 3, 5, 5, 5, 5, 0x04, 0x00),
            //    ["Silver Dread Helm"] = new InventoryArmorData("Silver Dread Helm", 0x0F, ArmorType.HELM, 100, 100, 17, 14, -3, 0, 0, 0, 0, 0, -20, -15, 0, -5, 5, 5, 5, 5, 5, 5, -20, 0x05, 0x00),
            //    ["Damascus Dread Helm"] = new InventoryArmorData("Damascus Dread Helm", 0x0F, ArmorType.HELM, 100, 100, 22, 16, -3, 0, 0, 0, -10, -10, 2, 0, -10, -10, 20, 5, 5, 5, 5, -20, 20, 0x06, 0x00),
        };
    }
}