using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Gangster : NPC, ICommunicate, IBattle
    {
        public string TradeMessage { get; set; }
        public List<string> Messages { get; set; }
        public BattleEnum BattleType { get; set; }
        public Weapon MyWeapon { get; set; }
        Random r = new Random();

        public Gangster()
        {
            
        }

        public Gangster(string name, int locationID, int characterID, string description, List<string> messages, Weapon currentWeapon, BattleEnum battleType) : 
            base(name, locationID, characterID, description)
        {
            Messages = messages;
            MyWeapon = currentWeapon;
            BattleType = battleType;
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

        public int Attack()
        {
            int attackPoints = random.Next(MyWeapon.MinWeaponAttack, MyWeapon.MaxWeaponAttack);

            if (attackPoints <= 100)
            {
                return attackPoints;
            }
            else
            {
                return 100;
            }
        }

        public int Defend()
        {
            int defendPoints = random.Next(MyWeapon.MinWeaponDefend, MyWeapon.MaxWeaponDefend);

            if(defendPoints <= 100 || defendPoints >= 0)
            {
                return defendPoints;
            }
            else if (defendPoints > 100)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }
    }
}
