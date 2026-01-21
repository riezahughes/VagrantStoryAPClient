using Archipelago.Core.Util;

namespace VagrantStoryArchipelago.Models.Inventory
{
    public class InventoryWeaponData
    {
        [MemoryOffset(0x00)]
        public byte WeaponSlot { get; set; }
        [MemoryOffset(0x02)]
        public byte GripSlot { get; set; }
        [MemoryOffset(0x04)]
        public byte Equipped { get; set; }
        [MemoryOffset(0x06)]
        public byte Gem1 { get; set; }
        [MemoryOffset(0x08)]
        public byte Gem2 { get; set; }
        [MemoryOffset(0x0a)]
        public byte Gem3 { get; set; }
        [MemoryOffset(0x0c)]
        public byte FirstNameChar1 { get; set; }
        [MemoryOffset(0x0e)]
        public byte FirstNameChar2 { get; set; }
        [MemoryOffset(0x11)]
        public byte FirstNameChar3 { get; set; }
        [MemoryOffset(0x13)]
        public byte FirstNameChar4 { get; set; }
        [MemoryOffset(0x15)]
        public byte FirstNameChar5 { get; set; }
        [MemoryOffset(0x17)]
        public byte FirstNameChar6 { get; set; }
        [MemoryOffset(0x19)]
        public byte FirstNameChar7 { get; set; }
        [MemoryOffset(0x1b)]
        public byte FirstNameChar8 { get; set; }
        [MemoryOffset(0x1d)]
        public byte FirstNameChar9 { get; set; }
        [MemoryOffset(0x1f)]
        public byte FirstNameChar10 { get; set; }
        [MemoryOffset(0x22)]
        public byte LastNameChar1 { get; set; }
        [MemoryOffset(0x24)]
        public byte LastNameChar2 { get; set; }
        [MemoryOffset(0x26)]
        public byte LastNameChar3 { get; set; }
        [MemoryOffset(0x28)]
        public byte LastNameChar4 { get; set; }
        [MemoryOffset(0x2a)]
        public byte LastNameChar5 { get; set; }
        [MemoryOffset(0x2c)]
        public byte LastNameChar6 { get; set; }
        [MemoryOffset(0x2e)]
        public byte LastNameChar7 { get; set; }
        [MemoryOffset(0x31)]
        public byte LastNameChar8 { get; set; }
        [MemoryOffset(0x33)]
        public byte LastNameChar9 { get; set; }
        [MemoryOffset(0x35)]
        public byte LastNameChar10 { get; set; }


        public InventoryWeaponData(
            byte weaponSlot,
            byte gripSlot,
            byte equipped,
            byte firstNameChar1,
            byte gem1 = 0x00,
            byte gem2 = 0x00,
            byte gem3 = 0x00,
            byte firstNameChar2 = 0x00,
            byte firstNameChar3 = 0x00,
            byte firstNameChar4 = 0x00,
            byte firstNameChar5 = 0x00,
            byte firstNameChar6 = 0x00,
            byte firstNameChar7 = 0x00,
            byte firstNameChar8 = 0x00,
            byte firstNameChar9 = 0x00,
            byte firstNameChar10 = 0x00,
            byte lastNameChar1 = 0x00,
            byte lastNameChar2 = 0x00,
            byte lastNameChar3 = 0x00,
            byte lastNameChar4 = 0x00,
            byte lastNameChar5 = 0x00,
            byte lastNameChar6 = 0x00,
            byte lastNameChar7 = 0x00,
            byte lastNameChar8 = 0x00,
            byte lastNameChar9 = 0x00,
            byte lastNameChar10 = 0x00
        )
        {
            WeaponSlot = weaponSlot;
            GripSlot = gripSlot;
            Equipped = equipped;
            Gem1 = gem1;
            Gem2 = gem2;
            Gem3 = gem3;
            FirstNameChar1 = firstNameChar1;
            FirstNameChar2 = firstNameChar2;
            FirstNameChar3 = firstNameChar3;
            FirstNameChar4 = firstNameChar4;
            FirstNameChar5 = firstNameChar5;
            FirstNameChar6 = firstNameChar6;
            FirstNameChar7 = firstNameChar7;
            FirstNameChar8 = firstNameChar8;
            FirstNameChar9 = firstNameChar9;
            FirstNameChar10 = firstNameChar10;
            LastNameChar1 = lastNameChar1;
            LastNameChar2 = lastNameChar2;
            LastNameChar3 = lastNameChar3;
            LastNameChar4 = lastNameChar4;
            LastNameChar5 = lastNameChar5;
            LastNameChar6 = lastNameChar6;
            LastNameChar7 = lastNameChar7;
            LastNameChar8 = lastNameChar8;
            LastNameChar9 = lastNameChar9;
            LastNameChar10 = lastNameChar10;
        }
    }
}
