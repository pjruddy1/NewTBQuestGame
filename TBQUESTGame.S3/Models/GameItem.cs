using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public abstract class GameItem : ObservableObject
    {
        #region Fields
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemDurability { get; set; }
        public int CurrencyValue { get; set; }
        public int HealthChange { get; set; }
        public int ItemCost { get; set; }
        #endregion

        #region Properties
        public string ItemInfo
        {
            get
            {
                return ItemInfoString();
            }
        }
        #endregion

        #region Constructors
        public GameItem(int itemID, string itemName, string itemDescription, int itemDurability, int currencyValue,int healthChange, int itemCost)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemDurability = itemDurability;
            CurrencyValue = currencyValue;
            HealthChange = healthChange;
            ItemCost = itemCost;
        }
        #endregion

        #region Methods
        public abstract string ItemInfoString();
        #endregion
    }
}
