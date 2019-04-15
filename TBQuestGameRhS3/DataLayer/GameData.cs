using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGameRH.Models;

namespace TBQuestGameRH.DataLayer
{
    public static class GameData
    {

        public static Player PlayerData()
        {
            return new Player()
            {
                ID = 1,
                Name = "Raoul Duke",
                Level = 0,
                CurrentStatus = Player.Status.Hallucinating,
                HP = 100,
                LocationId = 0,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(1001),
                    GameItemById(2001),
                    GameItemById(3001)
                }
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "We were somewhere around Barstow, near the edge of the desert, when the drugs began to take hold."
            };
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Location EmptyLocation()
        {
            return new Location()
            {
                Id = 0,
                Name = "",
                Description = "All energy flows according to the whims of the great magnet. What a fool I was to defy him.",
                Accessible = true
                
            };
        }

        public static Map GameMap()
        {
            int rows = 5;
            int columns = 4;

            Map gameMap = new Map(rows, columns);



            //
            // row 1
            //
            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 4,
                Name = "The Desert",
                Description = "We can't stop here! This is bat country...",
                Accessible = true,
                
            };

            gameMap.MapLocations[0, 1] = EmptyLocation();

            gameMap.MapLocations[0, 2] = EmptyLocation();

            gameMap.MapLocations[0, 3] = EmptyLocation();

            //
            // row 2
            //
            gameMap.MapLocations[1, 0] = new Location()
            {
                Id = 1,
                Name = "Beverly Heights Hotel",
                Description = "",
                Accessible = true,
                RequiredLevel = 1
            };

            
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 2,
                Name = "The Circus Casino",
                Description = "The Circus-Circus is what the whole hep world would be doing if the Nazi's had won the war." +
                " This is the sixth Reich. The ground floor is full of gambling tables, like all the other casinos..." +
                " but the places is about four stories high, in the style of a circus tent, " +
                " and all manner of strange County-Fair/Polish Carnival madness is going on up in this space.",
                Accessible = true,
                RequiredLevel = 2
            };

            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 3,
                Name = "Las Vegas Strip A",
                Description = "",
                Accessible = true,
                RequiredLevel = 2
            };

            gameMap.MapLocations[1, 3] = EmptyLocation();

            //
            // row 3
            //
            gameMap.MapLocations[2, 0] = new Location()
            {
                Id = 4,
                Name = "Mint 400 Race Track",
                Description = "",
                Accessible = true,
                RequiredLevel = 1
            };

            gameMap.MapLocations[2, 1] = EmptyLocation();

            gameMap.MapLocations[2, 2] = new Location()
            {
                Id = 5,
                Name = "The Matrix",
                Description = "",
                Accessible = true,
                RequiredLevel = 2
            };

            gameMap.MapLocations[2, 3] = EmptyLocation();

            //
            // row 4
            //

            gameMap.MapLocations[3, 0] = new Location()
            {
                Id = 6,
                Name = "Las Vegas Strip B",
                Description = "",
                Accessible = true,
                RequiredLevel = 1
            };

            gameMap.MapLocations[3, 1] = new Location()
            {
                Id = 7,
                Name = "The Flamingo Hotel",
                Description = "If the pigs were gathering in Vegas, I felt the drug culture should be represented as well. " +
                "And there was a certain bent appeal in the notion of running a savage burn in one Las Vegas Hotel, " +
                "and then just wheeling across town and checking into another. Me and a thousand ranking cops from all over America. " +
                "Why not? Move confidently into their midst.",
                Accessible = true,
                RequiredLevel = 2
                
            };

            gameMap.MapLocations[3, 2] = new Location()
            {
                Id = 8,
                Name = "Police Drug Conference",
                Description = "",
                Accessible = true,
                RequiredLevel = 2
            };

            gameMap.MapLocations[3, 0] = new Location()
            {
                Id = 9,
                Name = "Las Vegas Airport",
                Description = "",
                Accessible = true,
                RequiredLevel = 3
            };

            //
            // row 5
            //

            gameMap.MapLocations[4, 0] = EmptyLocation();

            gameMap.MapLocations[4, 1] = EmptyLocation();

            gameMap.MapLocations[4, 2] = new Location()
            {
                Id = 10,
                Name = "Baker",
                Description = "",
                Accessible = true,
                RequiredLevel = 2
            };

            gameMap.MapLocations[4, 3] = EmptyLocation();

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, ".357 Magnum", 75, 1, 4, "", 10),
                new Loot(2001, "", 10, Loot.Loottype.Coin, "24 karat gold coin", 1),                
                new Drug(3001, "Sunshine Blotter Acid", 5, 1, "As your attorney, I advise you to drive at top speed, and it'll be a damn miracle if we get ther before you turn into a wild animal.", 5)
            };
        }
    }
}
