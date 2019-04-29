using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Resident : NPC, ICommunicate
    {
        public List<string> Messages { get; set; }

        Random r = new Random();

        public Resident()
        {

        }

        public Resident(string name, int locationID, int characterID, string description, List<string> messages): 
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
            int randomIndex;
            randomIndex = r.Next(0, Messages.Count());

            return Messages[randomIndex];
        }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }
    }
}
