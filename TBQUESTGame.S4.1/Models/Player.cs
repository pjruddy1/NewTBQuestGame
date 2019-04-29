using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQUESTGame.Models
{
    public class Player : Character, IBattle
    {
        #region Fields
        protected int _expierencePnts;
        protected int _lives;
        private int _bootyValue;        
        private List<GameItem> _backPackItems;        
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItemQuantity> _booty;
        private ObservableCollection<GameItemQuantity> _weapons;
        private ObservableCollection<GameItemQuantity> _actionItems;
        private ObservableCollection<GameItemQuantity> _Inventory;
        private GameItemQuantity _weaponCarried;
        private string _currentWeapon;
        private BattleEnum _battleType;
        private Weapon _myWeapon;

        public Weapon MyWeapon
        {
            get { return _myWeapon; }
            set { _myWeapon = value; }
        }


        public BattleEnum BattleType
        {
            get { return _battleType; }
            set { _battleType = value; }
        }



        public string CurrentWeapon
        {
            get
            {                
                return _currentWeapon;
            }
            set
            {
                _currentWeapon = value;
                OnPropertyChanged(nameof(CurrentWeapon));
            }
        }

        #endregion

        #region Properties
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

        public ObservableCollection<GameItemQuantity> ActionItems
        {
            get { return _actionItems; }
            set { _actionItems = value; }
        }

        public ObservableCollection<GameItemQuantity> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _Inventory; }
            set { _Inventory = value; }
        }

        public GameItemQuantity WeaponCarried
        {
            get { return _weaponCarried; }
            set
            {
                _weaponCarried = value;
                OnPropertyChanged(nameof(WeaponCarried));
            }
        }
        #endregion

        #region Constructors
        public Player()
        {
            _locationsVisited = new List<Location>();
            _Inventory = new ObservableCollection<GameItemQuantity>();
            _booty = new ObservableCollection<GameItemQuantity>();
            _weapons = new ObservableCollection<GameItemQuantity>();
            _actionItems = new ObservableCollection<GameItemQuantity>();            
           
        }
        #endregion

        #region methods
        

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

            if (defendPoints <= 100 || defendPoints >= 0)
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

        public void UpdateInventoryCategories()
        {
           
            Weapons.Clear();
            ActionItems.Clear();
            Booty.Clear();

            foreach (var gameItemQuantity in _Inventory)
            {
                if (gameItemQuantity.GameItem is Weapon) Weapons.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is ActionItem) ActionItems.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Currency) Booty.Add(gameItemQuantity);
            }
        }        

        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _Inventory.FirstOrDefault(i => i.GameItem.ItemID == selectedGameItemQuantity.GameItem.ItemID);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _Inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();
        }


        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _Inventory.FirstOrDefault(i => i.GameItem.ItemID == selectedGameItemQuantity.GameItem.ItemID);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _Inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryCategories();
        }

       public string WeaponName()
        {
            if (WeaponCarried != null)
            {
                return $"{WeaponCarried.GameItem.ItemName}";
            }
            else
            {
                return "";
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

        public void GoldValueCalculate()
        {
            BootyValue = _Inventory.Sum(i => i.GameItem.CurrencyValue * i.Quantity);
        }

        


        #endregion
    }
}
