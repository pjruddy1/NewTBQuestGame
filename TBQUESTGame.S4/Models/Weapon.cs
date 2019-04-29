using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Weapon : GameItem
    {
        #region Properties
        public int MinWeaponDefend { get; set; }
        public int MaxWeaponDefend { get; set; }
        public int MaxWeaponAttack { get; set; }
        public int MinWeaponAttack { get; set; }
        #endregion

        #region Constructors
        public Weapon(int itemID, string itemName, string itemDescription,  int itemDurability, int maxWeaponAttack, int minWeaponAttack, int maxWeaponDefend, int minWeaponDefend, int currencyValue, int healthChange, int itemCost)
            : base(itemID, itemName, itemDescription, itemDurability, currencyValue, healthChange, itemCost)
        {
            MinWeaponAttack = minWeaponAttack;
            MaxWeaponAttack = maxWeaponAttack;
            MinWeaponDefend = minWeaponDefend;
            MaxWeaponDefend = maxWeaponDefend;
        }
        #endregion

        #region methods
        public override string ItemInfoString()
        {
            return $"{ItemName}: {ItemDescription}\nDurability: {ItemDurability}\tAttack: {MaxWeaponAttack}-{MinWeaponAttack}\tDefend: {MaxWeaponDefend}-{MinWeaponDefend}";
        }
        #endregion
    }
}
