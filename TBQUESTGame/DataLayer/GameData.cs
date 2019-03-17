using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQUESTGame.Models;
using System.Collections.ObjectModel;

namespace TBQUESTGame.DataLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Name = "PJ",
                HitPoints = 100,
                Lives = 5,
                Gold = 25,
                WeaponCarried = Player.Items.BowieKnife,
                ItemCarried = Player.Items.Rope,
                
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "After a 14 hour flight from northern Michigan you land in San Pedro, Belize.  You quickly meet up with friends that you haven't seen in years. There's a bunch of commosion coming from all your friends standing in a circle.  As you walk up John " +
                "quickly runs up to you and informs you that Sally was murdered" +
                "You will need to go from location to location to find out more about what happened to Sally and who is behind it."
            };
        }

        public static Location InitialGameMapLocaiton()
        {
            return new Location()
            {
                ID = 4,
                Name = "San Pedro Airport",
                Description = "The San Pedro Airport is located close to the center of San Pedro Island. This is the main source of travel to Belize City. ",
                Accessibble = true,
            };
        }

        public static Map GameMapData()
        {
            Map gameMap = new Map();

            ObservableCollection<Location> locations = new ObservableCollection<Location>()
            {              

                //
                // row 1
                //
               new Location()
                {
                    ID = 4,
                Name = "San Pedro Airport",
                Description = "The San Pedro Airport is located close to the center of San Pedro Island. This is the main source of travel to Belize City. ",
                Accessibble = true,
                ModifiyExperiencePoints = 0
                },

               new Location()
                {
                    ID = 10,
                    Name = "Secret Beach",
                    Description = "Secret Beach is located in the north east corner of the island.  It's a beautiful remote location with several palm trees and soft white sand." +
                    "There is also a restaurant and bar next to the beach.",
                    Accessibble = true,
                    ModifiyExperiencePoints = 10
                },

               new Location()
                {
                    ID = 7,
                    Name = "The Palms",
                    Description = "The Palms is a beautiful beach side resort with excellecnt accomidations.  Each room includes a king-size bed and a personal safe to keep belongings." +
                    "Loacated in the main lobby is complimentary food and beverages.",
                    Accessibble = true,
                    ModifiyExperiencePoints = 10
                },

               new Location()
                {
                    ID = 8,
                    Name = "Police Department",
                    Description = "San Pedro Police Department is located close to the center of the island.  The police force is made up of local men and it's rummored " +
                    "that police are in the hands of polaticians and some of the local gangs",
                    Accessibble = true,
                    ModifiyExperiencePoints = 10
                }

            };
            gameMap.Locations = locations;


            //
            // row 2
            //
            //gameMap.MapLocations[1, 1] = new Location()
            //{
            //    Id = 2,
            //    Name = "Felandrian Plains",
            //    Description = "The Felandrian Plains are a common destination for tourist. Located just north of the " +
            //    "equatorial line on the planet of Corlon, they provide excellent habitat for a rich ecosystem of flora and fauna.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};
            //gameMap.MapLocations[1, 2] = new Location()
            //{
            //    Id = 2,
            //    Name = "Epitoria's Reading Room",
            //    Description = "Queen Epitoria, the Torian Monarh of the 5th Dynasty, was know for her passion for " +
            //    "galactic history. The room has a tall vaulted ceiling, open in the middle  with four floors of wrapping " +
            //    "balconies filled with scrolls, texts, and infocrystals. As you enter the room a red fog desends from the ceiling " +
            //    "and you begin feeling your life energy slip away slowly until you are dead.",
            //    Accessible = false,
            //    ModifiyExperiencePoints = 50,
            //    ModifyLives = -1,
            //    RequiredExperiencePoints = 40
            //};

            ////
            //// row 3
            ////
            //gameMap.MapLocations[2, 0] = new Location()
            //{
            //    Id = 3,
            //    Name = "Xantoria Market",
            //    Description = "The Xantoria market, once controlled by the Thorian elite, is now an open market managed " +
            //    "by the Xantorian Commerce Coop. It is a place where many races from various systems trade goods." +
            //    "You purchase a blue potion in a thin, clear flask, drink it and receive 50 points of health.",
            //    Accessible = false,
            //    ModifiyExperiencePoints = 20,
            //    ModifyHealth = 50,
            //    Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions."
            //};
            //gameMap.MapLocations[2, 1] = new Location()
            //{
            //    Id = 4,
            //    Name = "The Tamfasia Galactic Academy",
            //    Description = "The Tamfasia Galactic Academy was founded in the early 4th galactic metachron. " +
            //    "You are currently in the library, standing next to the protoplasmic encabulator that stores all " +
            //    "recorded information of the galactic history.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};

            return gameMap;
        }
    }
}
