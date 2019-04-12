using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class ActionItem : GameItem
    {
        public enum ItemAction
        {
            None, OpenDoor, TieUpCharacter, Build, Heal
        }

        public ItemAction ActionOfItem { get; set; }

        public ActionItem(int itemID, string itemName, string itemDescription,  int itemDurability, ItemAction actionOfItem, int currencyValue)
            : base(itemID, itemName, itemDescription,  itemDurability, currencyValue)
        {
            ActionOfItem = actionOfItem;
        }


        public override string ItemInfoString()
        {
            return "";
        }
    }
}
