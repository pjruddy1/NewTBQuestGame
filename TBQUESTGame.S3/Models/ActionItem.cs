using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class ActionItem : GameItem
    {
        /// <summary>
        /// Actions from action items
        /// </summary>
        #region enums
        public enum ItemAction
        {
            None, OpenDoor, TieUpCharacter, Build, Heal
        }
        #endregion

        #region properties
        public ItemAction ActionOfItem { get; set; }
       
        #endregion

        #region Constructors
        public ActionItem(int itemID, string itemName, string itemDescription,  int itemDurability, ItemAction actionOfItem, int currencyValue, int healthChange, int itemCost)
            : base(itemID, itemName, itemDescription,  itemDurability, currencyValue, healthChange, itemCost)
        {
            ActionOfItem = actionOfItem;
            HealthChange = healthChange;
        }
        #endregion

        #region Methods
        public override string ItemInfoString()
        {
            return $"{ItemName}: {ItemDescription}";
        }
        
        #endregion
    }
}
