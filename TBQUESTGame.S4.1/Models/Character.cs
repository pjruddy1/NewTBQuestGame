using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQUESTGame.Models
{
    public class Character : ObservableObject
    {
        #region Fields
        private int _characterID;        
        protected string _name;
        protected int _hitPoints;
        protected int _gold;
        protected string _currentItem;
        protected int _locationID;
        private GameItemQuantity _itemCarried;

        protected Random random = new Random();

        public GameItemQuantity ItemCarried
        {
            get { return _itemCarried; }
            set { _itemCarried = value; }
        }

        #endregion

        #region Properties
        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }        

        public string CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged(nameof(CurrentItem));
            }
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

        public int CharacterID
        {
            get { return _characterID; }
            set { _characterID = value; }
        }



        #endregion

        #region Constructors
        public Character()
        {

        }

        public Character(string name, int locationID, int characterID)
        {
            _name = name;
            _locationID = locationID;
            _characterID = characterID;
        }
        #endregion

        #region Methods
        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {Name}";
        }

        public string ReturnItemCarried()
        {
            if (ItemCarried != null)
            {
                return $"{ItemCarried.GameItem.ItemName}";
            }
            else
            {
                return "";
            }
        }

        

        public string UpdateItem()
        {
            ItemCarried = null;
            return "";
        }

        #endregion
    }
}
