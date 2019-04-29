using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQUESTGame.Models
{
    public abstract class NPC : Character
    {
        public string Description { get; set; }
        

        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        public NPC()
        {

        }

        public NPC( string name, int locationID, int characterID, string description)
            : base(name, locationID, characterID)
        {
            LocationID = locationID;
            Name = name;
            Description = description;
            CharacterID = characterID;
        }

        

        protected abstract string InformationText();

    }
}
