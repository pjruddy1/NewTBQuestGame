using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Character : ObservableObject
    {
        #region Fields
        protected string _name;
        protected int _hitPoints;
        protected int _gold;
        protected string _itemCarried;
        protected int _locationID;
        #endregion

        #region Properties
        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }        

        public string ItemCarried
        {
            get { return _itemCarried; }
            set { _itemCarried = value; }
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
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Constructors
        public Character()
        {

        }

        public Character(string name, GameItemQuantity weaponsCarried, int locationID)
        {
            _name = name;
            _locationID = locationID;
        }
        #endregion

        #region Methods
        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {Name}";
        }

       
        #endregion
    }
}
