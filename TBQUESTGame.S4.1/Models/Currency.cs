using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Currency : GameItem
    {
        #region Enums
        public enum Booty
        {
            Gold, Silver, Copper
        }
        #endregion

        #region propeties
        public Booty BootyType { get; set; }
        #endregion

        #region Constructor
        public Currency(int itemID, string itemName, string itemDescription, int itemDurability, int currencyValue, Booty bootyType, int healthChange, int itemCost)
            : base(itemID, itemName, itemDescription, itemDurability, currencyValue, healthChange, itemCost)
        {
            BootyType = bootyType;            
        }
        #endregion

        #region Methods
        public override string ItemInfoString()
        {
            return $"{ItemName}: {ItemDescription}\nValue: {CurrencyValue}";
        }
        #endregion
    }
}
