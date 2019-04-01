using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Character : ObservableObject
    {
        public enum Items
        {
            None, Machette, BowieKnife, Pistol, Riffle, Bat, Hammer, BoltCutters, Rope, GrapplingHook, Banana, BBQMeat, Melon
        }

        protected string _name;
        protected int _hitPoints;
        protected int _gold;
        protected Items _weaponCarried;
        protected Items _itemCarried;
        protected int _locationID;

        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }        

        public Items ItemCarried
        {
            get { return _itemCarried; }
            set { _itemCarried = value; }
        }

        public Items WeaponCarried
        {
            get { return _weaponCarried; }
            set { _weaponCarried = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }

        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                //OnPropertyChanged(nameof(HitPoints));
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Character()
        {

        }

        public Character(string name, Items weaponsCarried, int locationID)
        {
            _name = name;
            _weaponCarried = weaponsCarried;
            _locationID = locationID;
        }

        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {Name}";
        }
    }
}
