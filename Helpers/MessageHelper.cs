namespace VagrantStoryArchipelago.Helpers
{
    public class MessageHelper
    {
        // The goal is to find the memory address where i can trigger messages on teh screen and update the text based on a dictionary. This means that in-game we can 
        // get notifications.

        public Dictionary<string, byte> LetterDictionary = new Dictionary<string, byte>
        {
            // Control Codes & Placeholders
            { "[filler byte]", 0xEB },
            { "[end string]", 0xE7 },
            { "[carriage return]", 0xE8 },
            //{ "«p1»", 0xF801 },
            //{ "«p2»", 0xF802 },
            //{ "«p8»", 0xF808 },
            //{ "«p10»", 0xF80A },
            { " ", 0x8f }, 

            // Numbers
            { "0", 0x00 }, { "1", 0x01 }, { "2", 0x02 }, { "3", 0x03 }, { "4", 0x04 },
            { "5", 0x05 }, { "6", 0x06 }, { "7", 0x07 }, { "8", 0x08 }, { "9", 0x09 },

            // Uppercase
            { "A", 0x0A }, { "B", 0x0B }, { "C", 0x0C }, { "D", 0x0D }, { "E", 0x0E },
            { "F", 0x0F }, { "G", 0x10 }, { "H", 0x11 }, { "I", 0x12 }, { "J", 0x13 },
            { "K", 0x14 }, { "L", 0x15 }, { "M", 0x16 }, { "N", 0x17 }, { "O", 0x18 },
            { "P", 0x19 }, { "Q", 0x1A }, { "R", 0x1B }, { "S", 0x1C }, { "T", 0x1D },
            { "U", 0x1E }, { "V", 0x1F }, { "W", 0x20 }, { "X", 0x21 }, { "Y", 0x22 }, { "Z", 0x23 },

            // Lowercase
            { "a", 0x24 }, { "b", 0x25 }, { "c", 0x26 }, { "d", 0x27 }, { "e", 0x28 },
            { "f", 0x29 }, { "g", 0x2A }, { "h", 0x2B }, { "i", 0x2C }, { "j", 0x2D },
            { "k", 0x2E }, { "l", 0x2F }, { "m", 0x30 }, { "n", 0x31 }, { "o", 0x32 },
            { "p", 0x33 }, { "q", 0x34 }, { "r", 0x35 }, { "s", 0x36 }, { "t", 0x37 },
            { "u", 0x38 }, { "v", 0x39 }, { "w", 0x3A }, { "x", 0x3B }, { "y", 0x3C }, { "z", 0x3D },

            // Special / Accented
            { "Ć", 0x40 }, { "Â", 0x41 }, { "Ä", 0x42 }, { "Ç", 0x43 }, { "È", 0x44 },
            { "É", 0x45 }, { "Ê", 0x46 }, { "Ë", 0x47 }, { "Ì", 0x48 }, { "ő", 0x49 },
            { "Î", 0x4A }, { "í", 0x4B }, { "Ò", 0x4C }, { "Ó", 0x4D }, { "Ô", 0x4E },
            { "Ö", 0x4F }, { "Ù", 0x50 }, { "Ú", 0x51 }, { "Û", 0x52 }, { "Ü", 0x53 },
            { "ß", 0x54 }, { "æ", 0x55 }, { "à", 0x56 }, { "á", 0x57 }, { "â", 0x58 },
            { "ä", 0x59 }, { "ç", 0x5A }, { "è", 0x5B }, { "é", 0x5C }, { "ê", 0x5D },
            { "ë", 0x5E }, { "ì", 0x5F }, { "î", 0x61 }, { "ï", 0x62 }, { "ò", 0x63 },
            { "ó", 0x64 }, { "ô", 0x65 }, { "ö", 0x66 }, { "ù", 0x67 }, { "ú", 0x68 },
            { "û", 0x69 }, { "ü", 0x6A },

            // Symbols & Punctuation
            { "‼", 0x87 }, { "≠", 0x88 }, { "≦", 0x89 }, { "≧", 0x8A }, { "÷", 0x8B },
            { "-", 0xA7 }, { "—", 0x8D }, { "⋯", 0x8E }, { "!", 0x90 }, { "\"", 0x91 },
            { "#", 0x92 }, { "$", 0x93 }, { "%", 0x94 }, { "&", 0x95 }, { "'", 0x96 },
            { "(", 0x97 }, { ")", 0x98 }, { "{", 0xAB }, { "}", 0xAC }, { "[", 0x9B },
            { "]", 0x9C }, { ";", 0x9D }, { ":", 0x9E }, { ",", 0x9F }, { ".", 0xA0 },
            { "/", 0xA1 }, { "\\", 0xA2 }, { ">", 0xA4 }, { "?", 0xA5 }, { "_", 0xA6 },
            { "+", 0xA8 }, { "*", 0xA9 }, { "♪", 0xAD }, { "Lv.", 0xB6 }
        };

        public void OpenInGameMessage()
        {             // Logic to open in-game message box by writing to specific memory address
            Console.WriteLine("In-game message box opened.");
        }

        public void CreateInGameMessage(string message)
        {
            // for each string in message, look up the corresponding byte in the dictionary and print it out.
            List<byte> messageBytes = new List<byte>();
            foreach (char c in message)
            {
                string charStr = c.ToString();
                if (LetterDictionary.ContainsKey(charStr))
                {
                    messageBytes.Add(LetterDictionary[charStr]);
                }
                else
                {
                    // If character not found, use a placeholder (e.g., space)
                    messageBytes.Add(LetterDictionary[" "]);
                }
            }
            Console.WriteLine("Message Bytes: " + BitConverter.ToString(messageBytes.ToArray()));

        }
    }
}
