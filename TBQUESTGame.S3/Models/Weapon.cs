using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Weapon : GameItem
    {
        public int MinWeaponDefend { get; set; }
        public int MaxWeaponDefend { get; set; }
        public int MaxWeaponAttack { get; set; }
        public int MinWeaponAttack { get; set; }

        public Weapon(int itemID, string itemName, string itemDescription,  int itemDurability, int maxWeaponAttack, int minWeaponAttack, int maxWeaponDefend, int minWeaponDefend, int currencyValue)
            : base(itemID, itemName, itemDescription, itemDurability, currencyValue)
        {
            MinWeaponAttack = minWeaponAttack;
            MaxWeaponAttack = maxWeaponAttack;
            MinWeaponDefend = minWeaponDefend;
            MaxWeaponDefend = maxWeaponDefend;
        }

        public override string ItemInfoString()
        {
            return $"{ItemName}: {ItemDescription}\nDurability: {ItemDurability}\tAttack: {MaxWeaponAttack}-{MinWeaponAttack}\tDefend: {MaxWeaponDefend}-{MinWeaponDefend}";
        }
    }
}
