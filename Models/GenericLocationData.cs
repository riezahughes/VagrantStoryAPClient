using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archipelago.Core.Models;

namespace VagrantStoryArchipelago.Models
{
    public class GenericLocationData
    {
        public string Name { get; set; }

        public uint Address { get; set; }

        public string LevelId { get; set; }

        public string Check { get; set; }

        public LocationCheckType CheckType { get; set; }

        public uint RipperShiftAddress { get; set; }

        public GenericLocationData(string name, uint locationAddress, string levelId, string check, LocationCheckType checkType)
        {
            Name = name;
            Address = locationAddress;
            LevelId = levelId;
            Check = check;
            CheckType = checkType;
        }
    }
}
