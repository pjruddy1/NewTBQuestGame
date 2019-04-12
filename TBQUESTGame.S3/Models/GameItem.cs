using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public abstract class GameItem : ObservableObject
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemDurability { get; set; }
        public int CurrencyValue { get; set; }

        public string ItemInfo
        {
            get
            {
                return ItemInfoString();
            }
        }

        public GameItem(int itemID, string itemName, string itemDescription, int itemDurability, int currencyValue)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemDurability = itemDurability;
            CurrencyValue = currencyValue;
        }

        public abstract string ItemInfoString();
    }
}
