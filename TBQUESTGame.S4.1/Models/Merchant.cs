using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQUESTGame.Models
{
    public class Merchant : NPC, ITrade, ICommunicate
    {
        private ObservableCollection<GameItemQuantity> _inventory;        
        public List<string> Messages { get; set; }
        bool WillTrade { get; set; }
        private ObservableCollection<GameItemQuantity> _gameItems;

        public ObservableCollection<GameItemQuantity> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }


        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public Merchant(string name, int locationID, int characterID, string description, List<string> messages) : base(name, locationID, characterID, description)
        {
            Name = name;
            LocationID = locationID;
            CharacterID = characterID;
            Description = description;
            Messages = messages;
        }

        public Merchant()
        {

        }

        //public bool WillTrade(GameItemQuantity currentGameItem)
        //{
        //    int itemCost;

        //    itemCost = currentGameItem.GameItem.ItemCost;




        //}
        public string CurrentMessage()
        {

            if (Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        public string GetMessage()
        {
            if (Messages.Count == 0)
            {
                return "Check out my inventory";
            }
            else
            {
                string Message;
                Message = Messages[0];
                Messages.Remove(Message);
                return Message;
            }
            
        }

        public void RemoveGameItemQuantityFromCharacter(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.ItemID == selectedGameItemQuantity.GameItem.ItemID);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryGameItems();
        }

        public void UpdateInventoryGameItems()
        {
            ObservableCollection<GameItemQuantity> updatedInventoryGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (GameItemQuantity gameItemQuantity in _gameItems)
            {
                updatedInventoryGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (GameItemQuantity gameItemQuantity in updatedInventoryGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }

        public bool MakeTrade(GameItemQuantity currentItem)
        {
            return Inventory.Contains(currentItem) ? true : false;
        }

        public string TradeMessage( GameItemQuantity currentGameItem)
        {
            string tradeMessage = "";
            if (currentGameItem != null)
            {
                foreach (GameItemQuantity item in Inventory)
                {
                    if (currentGameItem.GameItem.ItemID == item.GameItem.ItemID)
                    {
                        tradeMessage = $"The cost of the {item.GameItem.ItemName} is {item.GameItem.ItemCost}. I accept gold coins";
                    }
                    else
                    {
                        tradeMessage = $"Sorry, the {item.GameItem.ItemName} is out of stock";
                    }
                }

            }
            else
            {
                 tradeMessage = "";
            }
            return tradeMessage;
        }


        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }
    }
}
