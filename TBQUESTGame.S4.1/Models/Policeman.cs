using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace TBQUESTGame.Models
{
    public class Policeman : NPC, ICommunicate, ITrade
    {
        public List<string> Messages { get; set; }
        public ObservableCollection<GameItemQuantity> Inventory { get; set; }
        

        Random r = new Random();

        public Policeman()
        {

        }

        public Policeman(string name, int locationID, int characterID, string description, List<string> messages) :
            base(name, locationID, characterID, description)
        {
            Messages = messages;
        }

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
                return "Go to my inventory";
            }
            else
            {
                string Message;
                Message = Messages[0];
                Messages.Remove(Message);
                return Message;
            }

        }

        public bool MakeTrade(GameItemQuantity currentItem)
        {
            return Inventory.Contains(currentItem) ? true : false;
        }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }
    }
}
