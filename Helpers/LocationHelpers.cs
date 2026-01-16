using Archipelago.Core.Models;
using VagrantStoryArchipelago;

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
            // create a new list of locations thats empty
            List<ILocation> locations = new List<ILocation>();

            // regular example: A simple location and a simple change

            locations.Add(new Location()
            {
                Id = 1, // the id of the location in the ap world
                Name = "Test Location 1", // the name you want to give this location
                Address = Addresses.test, // the address of the location you want to deal with
                CheckType = LocationCheckType.UShort, // the type of value you're watching
                CompareType = LocationCheckCompareType.Match, // the kind of compare you want to do on the value
                CheckValue = "111" // the value in integer string value
            });

            // a bit related address example: Looks for a specific bit going from 0 to 1, counting from the right.

            locations.Add(new Location()
            {
                Id = -1,
                Name = "Cleared Level",
                Address = 0x000,
                CheckType = LocationCheckType.Bit,
                AddressBit = 4
            });

            // conditional example. Notice that conditions use an Id of -1 but the CompositLocation uses the ID of the location
            // this is a quick example of an AND condition, you can also use OR and a few other things. 

            List<ILocation> conditionalChoice = new List<ILocation>();

            conditionalChoice.Add(new Location()
            {
                Id = -1,
                Name = "Cleared Level",
                Address = 0x000,
                CheckType = LocationCheckType.Bit,
                AddressBit = 4
            });
            CompositeLocation location = new CompositeLocation()
            {
                Name = "test",
                Id = 111,
                CheckType = LocationCheckType.AND,
                Conditions = conditionalChoice
            };

            locations.Add(location);

            // loop, define and put your addresses together and at the end of this function make sure to return the original locations list we created

            return locations; 
        }
    }
}