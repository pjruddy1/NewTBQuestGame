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

            /// loading player without create player button
            return new Player()
            {
                Name = "PJ",
                HitPoints = 100,
                Lives = 5,
                Gold = 25,
                ExpierencePnts = 0,
                Inventory = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(203), 20),
                    new GameItemQuantity(GameItemById(304), 1),
                    new GameItemQuantity(GameItemById(305), 1),
                    new GameItemQuantity(GameItemById(105), 1)
                }
            };
        }
        //
        // Initial game Message
        //
        public static string InitialMessages()
        {
            return 
            
                "After a 14 hour flight from northern Michigan you land in San Pedro, Belize.  You quickly meet up with friends that you haven't seen in years. There's a bunch of commosion coming from all your friends standing in a circle.  As you walk up John " +
                "quickly runs up to you and informs you that Sally was murdered" +
                "You will need to go from location to location to find out more about what happened to Sally and who is behind it.";
        }
        /// <summary>
        /// Creating Map and Locations
        /// </summary>
        /// <returns></returns>
        #region
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
                ActionItemRequired = 301,
                ModifiyExperiencePoints = 10,
                ImageName = "/media/palmsRoom.jpg",                
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(201), 3),
                    new GameItemQuantity(GameItemById(202), 5),
                    new GameItemQuantity(GameItemById(203), 10),
                    new GameItemQuantity(GameItemById(304), 1)
                }
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
                
                ImageName = "/media/palms.jpg",
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(301),1)
                }
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
                ImageName = "/media/palmBeach.jpg",
               
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 1),
                    new GameItemQuantity(GameItemById(201), 3),
                    new GameItemQuantity(GameItemById(202), 3),
                    new GameItemQuantity(GameItemById(303), 1),
                    new GameItemQuantity(GameItemById(302), 1)
                }
            };
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 1,
                Name = "San Pedro Airport",
                Description = "The San Pedro Airport is located close to the center of San Pedro Island. This is the main source of travel to Belize City.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tAfter a 14 hour flight from northern Michigan you land in San Pedro, Belize.  You quickly meet up with friends that you haven't seen in years. There's a bunch of commosion coming from all your friends standing in a circle.  As you walk up John " +
                "quickly runs up to you and informs you that Sally is Missing" +
                "You will need to go from location to location to find out more about what happened to Sally and who is behind it.",
                ImageName = "/media/airport.jpg",
                GameCharacters = new ObservableCollection<Character>
                {
                    CharacterByID(701)
                }
            };
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 5,
                Name = "San Pedro Market",
                Description = "The San Pedro Market is located between the San Pedro Airport, San Mateo and Boca Del Rio neighborhoods",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tHere you can purchase tools, weapons, food, water and medical supplies.",
                ImageName = "/media/market.jpg",
                GameCharacters = new ObservableCollection<Character>
                {
                    CharacterByID(901)
                }
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
                ImageName = "/media/bocaDelRio.jpg",
                GameCharacters = new ObservableCollection<Character>
                {
                    CharacterByID(601)
                }
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
                ImageName = "/media/emptyBeach.jpg",
                
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 1),                    
                    new GameItemQuantity(GameItemById(202), 3),
                    new GameItemQuantity(GameItemById(203), 7),
                },
                GameCharacters = new ObservableCollection<Character>
                {
                    CharacterByID(702)
                }
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
                ImageName = "/media/police.jpg",
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(303),1)
                },
                GameCharacters = new ObservableCollection<Character>
                {
                    CharacterByID(801)
                }
            };
            gameMap.MapLocations[2, 2] = new Location()
            {
                Id = 9,
                Name = "San Mateo",
                Description = "San Mateo Neighborhood is a tougher area of the island.  This is where most of the local gang activity is located.  In the last year there" +
                "have been 10 known murders and several missing people.  There are barking dogs in every yard and almost every window is borded up with plywood",

                ModifiyExperiencePoints = 50,
                Message = "\tIf you are not carrying a weapon in hand, you should either turn around or pull a weapon out.  Because you were not prepared you've lost" +
                "a life",
                ImageName = "/media/sanMateo.jpg",
                ModifyLives = 0,
                Accessible = true,
                               
                 GameCharacters = new ObservableCollection<Character>
                {
                    CharacterByID(602)
                }

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
                ImageName = "/media/secretBeach.jpg",
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(307),1)
                },
            };

            return gameMap;
        }
        #endregion

        /// <summary>
        /// Creating game Items
        /// </summary>
        /// <returns></returns>
        #region
        public static List<GameItem> GameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(101, "Bamboo Stick", "5 Feet Long with a pointy end", 50, 10, 5, 10, 5, 0, 0 ,0),
                new Weapon(102, "Bat", "Louisville Slugger", 75, 25, 10, 35, 7, 0 , 0, 10),
                new Weapon(103, "Machette", "3 Feet long with a tapped wooden handle", 40, 10, 65, 45, 10, 0 , 0, 20),
                new Weapon(104, "Pistol", "Colt 45 with 6 Bullets", 60, 85, 45, 5, 0, 0, 0, 50),
                new Weapon(105, "Pocket Knife", "Granpa's Old Pocket Knife", 30, 5, 0, 5, 0, 0, 0, 0),
                new Currency(201, "Gold Coin", "Old Spanish Booty made of Gold", 100, 10, Currency.Booty.Gold, 0, 0),
                new Currency(202, "Silver Coin", "Old Spanish Booty made of Silver", 100, 5, Currency.Booty.Silver, 0 , 0),
                new Currency(203, "Copper Coin", "Old Spanish Booty made of Copper", 100, 1, Currency.Booty.Copper, 0 , 0),
                new ActionItem(301, "Key", "Electronic Entry Room Key made of plastic", 75, ActionItem.ItemAction.OpenDoor, 0, 0, 25 ),
                new ActionItem(302, "Rope", "30 Feet of nylon rope", 75,  ActionItem.ItemAction.TieUpCharacter, 0, 0, 0),
                new ActionItem(303, "Hammer", "Old Hammer with a wooden handle", 65, ActionItem.ItemAction.Build, 0, 0, 0),
                new ActionItem(304, "Medkit", "Medical Supplies", 10,  ActionItem.ItemAction.Heal, 0, 55, 25),
                new ActionItem(305, "Lunch Box", "An Old Scooby Doo lunch box", 10,  ActionItem.ItemAction.None, 0, 33, 0),
                new ActionItem(306, "Handcuffs", "Stainless steel cuffs", 100,  ActionItem.ItemAction.TieUpCharacter, 0, 0, 0),
                new ActionItem(307, "Sally", "Laying on the ground unconscious", 100,  ActionItem.ItemAction.None, 0, 0, 0)
            };
        }

        public static List<Character> characters()
        {
            return new List<Character>()
            {
                new Gangster()
                {
                    Name ="Jose",
                    CharacterID = 601,
                    Description = "A dark complected man, about 6 feet tall, with tattos from his neck to his fingers. He seems be a member of the local cartel.",
                    HitPoints = 100,
                    Messages = new List<string>()
                    {
                        "What are you looking at pip squick?  You're in the wrong neighborhood.",
                        "If you keep asking questions you're going to end up leaving in stretcher.",
                        "Alright, that's it you've asked for it.  Here comes the pain!"
                    },
                    MyWeapon = GameItemById(102) as Weapon

                },

                new Gangster()
                {
                    Name ="Pedro",
                    CharacterID = 602,
                    Description = "A short and stocky man with tattos and a couple gold chains around his neck.  He has " +
                    "a few more rough looking guys behind him.  It seems like he may be the cartel boss.",
                    HitPoints = 125,
                    Messages = new List<string>()
                    {
                        "Listen here gringo, stop snooping around or you'll end up in a kasket",
                        "This is the cartel's neighborhood, take another step and it'll be your last.",
                        "Listen here gringo, you don't know who you're messing with."
                    },
                    MyWeapon = GameItemById(104) as Weapon

                },

                new Resident()
                {
                    Name ="Mateo",
                    CharacterID = 701,
                    Description = "A young man, well dressed, handing out flyers to tourists",
                    Messages = new List<string>()
                    {
                        "Hola como esta,  How's it going today? are you looking for some fun in the sun?",
                        "I think there was recently a murder on the island.  I heard a young, pretty, American girl went missing a few days ago.",
                        "She was last seen swimming at the secret beach."
                    }                   
                   
                },
                new Resident()
                {
                    Name ="Nicolas",
                    CharacterID = 702,
                    Description = "A fishing boat captain wearing a straw hat, a long sleeve shirt and holding",
                    Messages = new List<string>()
                    {
                        "Hola como esta,  How's it going today? Are you intrested in some fishing?",
                        "I heard a young, pretty, American girl went missing a few days ago.",
                        "She was last seen swimming at the secret beach."
                    }
                },
                new Policeman()
                {
                    Name = "Santiago",
                    CharacterID = 801,
                    Description = "A short, dark complected man, wearing an oficer's uniform and carrying a machine gun.",
                    Messages = new List<string>()
                    {
                        "Hola, what can i help you with today?",
                        "Oh, you're friends with the missing girl?",
                        "We've been searching for her for the last couple days. We were told she was last seen by the secret beach.",
                        "If you help us bring in Pedro the head of the local cartel, we will help you find your way to the secret beach.",
                        "Here are a pair of handcuffs.  After you defeat Pedro, bring him back to me."                        
                    },
                    Inventory = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(306),1)
                    }
                },
                new Merchant()
                {
                    Name = "Plato",
                    CharacterID = 901,
                    Description = "A young man, behind a counter under a tent.",
                    Messages = new List<string>()
                    {
                        "Hola, what can i help you with today?",
                        "Here you go check out my inventory prices are as marked."
                    },
                    Inventory = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(102),1),
                        new GameItemQuantity(GameItemById(103),1),
                        new GameItemQuantity(GameItemById(104),1),
                        new GameItemQuantity(GameItemById(304),1),
                        new GameItemQuantity(GameItemById(302),1)
                    }
                }

            };
        }
        

        public static Character CharacterByID(int id)
        {
            return characters().FirstOrDefault(i => i.CharacterID == id);
        }

        public static GameItem GameItemById(int id)
        {
            return GameItems().FirstOrDefault(i => i.ItemID == id);
        }

        private static GameItem WeaponRequiredId(int id)
        {
            return GameItems().FirstOrDefault(i => i.ItemID == id);
        }

        #endregion
    }
}
