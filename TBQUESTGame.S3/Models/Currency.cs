using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Currency : GameItem
    {
        public enum Booty
        {
            Gold, Silver, Copper
        }

        public Booty BootyType { get; set; }

        public Currency(int itemID, string itemName, string itemDescription, int itemDurability, int currencyValue, Booty bootyType)
            : base(itemID, itemName, itemDescription, itemDurability, currencyValue)
        {
            BootyType = bootyType;            
        }

        public override string ItemInfoString()
        {
            return $"{ItemName}: {ItemDescription}\nValue: {CurrencyValue}";
        }
    }
}
