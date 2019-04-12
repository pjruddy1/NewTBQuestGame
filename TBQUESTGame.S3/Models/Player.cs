using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQUESTGame.Models
{
    public class Player : Character
    {
        protected int _expierencePnts;
        protected int _lives;
        private int _bootyValue;        
        private List<GameItem> _backPackItems;        
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItemQuantity> _booty;
        private ObservableCollection<GameItem> _weapons;
        private ObservableCollection<GameItem> _actionItems;
        private ObservableCollection<GameItem> _Inventory;
        private ObservableCollection<GameItemQuantity> _purse;       



        public List<GameItem> BackPackItems
        {
            get { return _backPackItems; }
            set { _backPackItems = value; }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public int ExpierencePnts
        {
            get { return _expierencePnts; }
            set
            {
                _expierencePnts = value;
               OnPropertyChanged(nameof(ExpierencePnts));
            }
        }


        public int BootyValue
        {
            get { return _bootyValue; }
            set
            {
                _bootyValue = value;
                OnPropertyChanged(nameof(BootyValue));
            }
        }

        public int Lives
        {
            get { return _lives; }
            set
            {
               _lives = value;
                OnPropertyChanged(nameof(Lives));
            }
        }

        public ObservableCollection<GameItemQuantity> Booty
        {
            get { return _booty; }
            set { _booty = value; }
        }

        public ObservableCollection<GameItem> ActionItems
        {
            get { return _actionItems; }
            set { _actionItems = value; }
        }

        public ObservableCollection<GameItem> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItem> Inventory
        {
            get { return _Inventory; }
            set { _Inventory = value; }
        }
        public ObservableCollection<GameItemQuantity> Purse
        {
            get { return _purse; }
            set { _purse = value; }
        }

        public Player()
        {
            _locationsVisited = new List<Location>();
            _backPackItems = new List<GameItem>();
            _booty = new ObservableCollection<GameItemQuantity>();
            _weapons = new ObservableCollection<GameItem>();
            _actionItems = new ObservableCollection<GameItem>();
            _purse = new ObservableCollection<GameItemQuantity>();
        }

        public void UpdateBackPackItems()
        {
           
            Weapons.Clear();
            ActionItems.Clear();

            foreach (var gameItem in _Inventory)
            {
                if (gameItem is Weapon) Weapons.Add(gameItem);
                if (gameItem is ActionItem) ActionItems.Add(gameItem);
            }
        }
        public void UpdatePurse()
        {
            Booty.Clear();
            foreach (var gameItemQuantity in _purse)
            {
                if (gameItemQuantity.GameItem is Currency) Booty.Add(gameItemQuantity);
            }
        }

        public void AddBootyToPurse(GameItemQuantity selectedBootyQuantity)
        {
            GameItemQuantity gameItemQuantity = _booty.FirstOrDefault(i => i.GameItem.ItemID == selectedBootyQuantity.GameItem.ItemID);

            if(gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedBootyQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _purse.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }
            UpdatePurse();

        }

        
        public void AddGameItemToInv(GameItem selectedGameItem)
        {
            if(selectedGameItem != null)
            {
                _backPackItems.Add(selectedGameItem);
            }
        }

        public void RemoveGameItemFromInv(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _backPackItems.Remove(selectedGameItem);
            }
        }

        public override string DefaultGreeting()
        {
            return base.DefaultGreeting();
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        public void BootyValueCalculate()
        {
            BootyValue = _booty.Sum(i => i.GameItem.CurrencyValue * i.Quantity);
        }
        
    }
}
