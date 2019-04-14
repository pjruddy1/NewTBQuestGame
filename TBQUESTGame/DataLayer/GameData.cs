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
                WeaponCarried = Player.Items.None,
                ItemCarried = Player.Items.Rope,
                ExpierencePnts = 0

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

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 1, Column = 1 };
        }

        public static Map GameMap()
        {
            int rows = 5;
            int columns = 5;

            Map gameMap = new Map(rows, columns);

            //
            // row 1
            //
            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 3,
                Name = "Palms Room",
                Description = "You walk into your room.  The airconditioner is keeping the room at a perfect temperature.  Right in front is a king-size bed, which would make for a " +
                "great night sleep.  On the otherside of the bed is a personal safe where you can store the majority of your belongings.",
                Accessible = false,
                ModifiyExperiencePoints = 10,
                ImageName = "/media/palmsRoom.jpg"
            };
            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 2,
                Name = "The Palms",
                Description = "The Palms is a beautiful beach side resort with excellecnt accomidations.  Each room includes a king-size bed and a personal safe to keep belongings." +
                           "Located in the main lobby is complimentary food and beverages.  To purchase a room to rent speak with the hotel" +
                            "clerk.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tThe cost of a room per night is 25 gold.",
                AvailableAciton1 = Location.Action.SpeakToNPC,
                AvailableAction2 = Location.Action.PurchaseRoom,
                ImageName = "/media/palms.jpg"
            };
            //
            // row 2
            //

            gameMap.MapLocations[1, 0] = new Location()
            {
                Id = 4,
                Name = "Palms' Beach",
                Description = "The Palms Beach is full of soft white sand is surrounded by large palm trees.  There is also a dock leading out 100yds into the ocean." +
                "At the end of the dock there are a few locals fishing (this seems like a good spot to fish). From the beach you can walk into the backdoor of the hotel rooms if you have a key.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                ImageName = "/media/palmBeach.jpg"
            };
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 1,
                Name = "San Pedro Airport",
                Description = "The San Pedro Airport is located close to the center of San Pedro Island. This is the main source of travel to Belize City.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tAfter a 14 hour flight from northern Michigan you land in San Pedro, Belize.  You quickly meet up with friends that you haven't seen in years. There's a bunch of commosion coming from all your friends standing in a circle.  As you walk up John " +
                "quickly runs up to you and informs you that Sally was murdered" +
                "You will need to go from location to location to find out more about what happened to Sally and who is behind it.",
                ImageName = "/media/airport.jpg"
            };
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 5,
                Name = "San Pedro Market",
                Description = "The San Pedro Market is located between the San Pedro Airport, San Mateo and Boca Del Rio neighborhoods",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tHere you can purchase tools, weapons, food, water and medical supplies.",
                ImageName = "/media/market.jpg"
            };
            gameMap.MapLocations[1, 3] = new Location()
            {
                Id = 7,
                Name = "Boca Del Rio",
                Description = "Boca Del Rio is a neighborhood on San Pedro.  This is where most of the wealthier locals live.  It is however still a tough place to live" +
                "and you do need to be careful of gangs",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tAs you enter the neighborhood you're greeted with stares and dirty looks",
                ImageName = "/media/bocaDelRio.jpg"
            };
            //
            // row 3
            //
            gameMap.MapLocations[2, 0] = new Location()
            {
                Id = 8,
                Name = "Empty Beach",
                Description = "This beach is not taken care of. Sargasum(type of seeweed) is washed up across the shore.  It looks like people leave trash and other " +
                "belongings close to the beach",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                ModifyHealth = 0,
                Message = "\tIf you decide to look around you may find some useful items.",
                ImageName = "/media/emptyBeach.jpg"
            };
            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 6,
                Name = "Police Department",
                Description = "San Pedro Police Department is located close to the center of the island.  The police force is made up of local men and it's rummored " +
                            "that police are in the hands of polaticians and some of the local gangs",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tIt would be a good idea to ask an officer to share any details of Sally's murder. Just becareful to not ask to many.",
                ImageName = "/media/police.jpg"
            };
            gameMap.MapLocations[2, 2] = new Location()
            {
                Id = 9,
                Name = "San Mateo",
                Description = "San Mateo Neighborhood is a tougher area of the island.  This is where most of the local gang activity is located.  In the last year there" +
                "have been 10 known murders and several missing people.  There are barking dogs in every yard and almost every window is borded up with plywood",
                Accessible = false,
                ModifiyExperiencePoints = 50,
                RequiredExperiencePoints = 70,
                Message = "\tIf you are not carrying a weapon in hand, you should either turn around or pull a weapon out.  Because you were not prepared you've lost" +
                "a life",
                ImageName = "/media/sanMateo.jpg",
                ModifyLives = -1
            };
            //
            //Row 4
            //
            gameMap.MapLocations[3, 2] = new Location()
            {
                Id = 10,
                Name = "Secret Beach",
                Description = "Secret Beach is located in the north east corner of the island.  It's a beautiful remote location with several palm trees and soft white sand." +
                            "There is also a restaurant and bar next to the beach.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tThis seems like a good place to hide a body, maybe you should look around.",
                ImageName = "/media/secretBeach.jpg"
            };

            return gameMap;
        }

        //public static Location InitialGameMapLocaiton()
        //{
        //    return new Location()
        //    {
        //        ID = 4,
        //        Name = "San Pedro Airport",
        //        Description = "The San Pedro Airport is located close to the center of San Pedro Island. This is the main source of travel to Belize City. ",
        //        Accessibble = true,
        //    };
        //}

        //public static Map GameMapData()
        //{
        //    Map gameMap = new Map();

        //    ObservableCollection<Location> locations = new ObservableCollection<Location>()
        //    {              

        //        //
        //        // row 1
        //        //
        //       new Location()
        //        {
        //            ID = 4,
        //        Name = "San Pedro Airport",
        //        Description = "The San Pedro Airport is located close to the center of San Pedro Island. This is the main source of travel to Belize City. ",
        //        Accessibble = true,
        //        ModifiyExperiencePoints = 0
        //        },

        //       new Location()
        //        {
        //            ID = 10,
        //            Name = "Secret Beach",
        //            Description = "Secret Beach is located in the north east corner of the island.  It's a beautiful remote location with several palm trees and soft white sand." +
        //            "There is also a restaurant and bar next to the beach.",
        //            Accessibble = true,
        //            ModifiyExperiencePoints = 10
        //        },

        //       new Location()
        //        {
        //            ID = 7,
        //            Name = "The Palms",
        //            Description = "The Palms is a beautiful beach side resort with excellecnt accomidations.  Each room includes a king-size bed and a personal safe to keep belongings." +
        //            "Loacated in the main lobby is complimentary food and beverages.",
        //            Accessibble = true,
        //            ModifiyExperiencePoints = 10
        //        },

        //       new Location()
        //        {
        //            ID = 8,
        //            Name = "Police Department",
        //            Description = "San Pedro Police Department is located close to the center of the island.  The police force is made up of local men and it's rummored " +
        //            "that police are in the hands of polaticians and some of the local gangs",
        //            Accessibble = true,
        //            ModifiyExperiencePoints = 10
        //        }

        //    };
        //    gameMap.Locations = locations;


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

        //return gameMap;
        //}
    }
}
