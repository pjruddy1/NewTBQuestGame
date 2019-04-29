using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQUESTGame.Models;
using System.Collections.ObjectModel;
using TBQUESTGame.DataLayer;

namespace TBQUESTGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        private TimeSpan _gameTime;

        private Player _player;

        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationName;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private string _nothLocationName, _eastLocationName, _southLocationName, _westLocationName;
        private GameItemQuantity _currentGameItem;
        private GameItemQuantity _currentInventoryItem;
        private GameItemQuantity _currentBootyItem;
        private string _currentWeapon;
        private ObservableCollection<GameItemQuantity> _playerBooty;
        protected Random random = new Random();
        private GameItem _myWeapon;
        private Character _currentCharacter;
        private string _messageDisplay;
        private ObservableCollection<GameItemQuantity> _characterInventory;

        public ObservableCollection<GameItemQuantity> CharacterInventory
        {
            get { return _characterInventory; }
            set
            {
                _characterInventory = value;
                OnPropertyChanged(nameof(CharacterInventory));
            }
        }


        public Character CurrentCharacter
        {
            get { return _currentCharacter; }
            set { _currentCharacter = value; }
        }

        public GameItem MyWeapon
        {
            get { return _myWeapon; }
            set { _myWeapon = value; }
        }


        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get
            {
                return _messageDisplay;
            }
            set
            {
                _messageDisplay = value; 
                OnPropertyChanged(nameof(MessageDisplay));
            }
        }
        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set
            {
                _currentLocationName = value;
                OnPropertyChanged(nameof(CurrentLocationName));
            }
        }

        public string NorthLocationName
        {
            get { return _nothLocationName; }
            set
            {
                _nothLocationName = NorthLocation.Name;
                OnPropertyChanged(nameof(NorthLocationName));
            }
        }        

        public string EastLocationName
        {
            get { return _eastLocationName; }
            set
            {
                _eastLocationName = EastLocation.Name;
                OnPropertyChanged(nameof(EastLocationName));
            }
        }       

        public string SouthLocationName
        {
            get { return _southLocationName; }
            set
            {
                _southLocationName = SouthLocation.Name;
                OnPropertyChanged(nameof(SouthLocationName));
            }
        }

        public string WestLocationName
        {
            get { return _westLocationName; }
            set
            {
                _westLocationName = WestLocation.Name;
                OnPropertyChanged(nameof(WestLocationName));
            }
        }

        //
        // expose information about travel points from current location
        //
        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }
        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }
        public GameItemQuantity CurrentBootyItem
        {
            get { return _currentBootyItem; }
            set { _currentBootyItem = value; }
        }

        public GameItemQuantity CurrentInventoryItem
        {
            get { return _currentInventoryItem; }
            set { _currentInventoryItem = value; }
        }

        public ObservableCollection<GameItemQuantity> PlayerBooty
        {
            get { return _playerBooty; }
            set { _playerBooty = value; }
        }

        public bool HasNorthLocation
        {
            get
            {
                if (NorthLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string CurrentWeapon
        {
            get{ return _currentWeapon; }
            set
            {
                _currentWeapon = value;
                OnPropertyChanged(nameof(CurrentWeapon));
            }
        }


        //
        // shortened code with same functionality as above
        //
        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }

        public string MissionTimeDisplay
        {
            get { return _gameTimeDisplay; }
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(MissionTimeDisplay));
            }
        }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates)
        {
            
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            InitializeView();

            //GameTimer();
        }

        #endregion

        #region METHODS
        public void Trade()
        {
            
            if(CurrentCharacter is ITrade)
            {
                if (CurrentCharacter is Policeman)
                {
                    Policeman policeman = CurrentCharacter as Policeman;
                    _currentLocation.Message = "Go to my Inventory and grab the cuffs.";
                    CharacterInventory = policeman.Inventory;                    
                }
                else if(CurrentCharacter is Merchant)
                {
                    Merchant merchant = CurrentCharacter as Merchant;
                    CharacterInventory = merchant.Inventory;
                }
            
                
            }
        }

        public void Battle()
        {
            int newHitPoints;
            if (CurrentCharacter is IBattle)
            {
               
                int playerAttackPoints = 0;
                int characterAttackPoints = 0;
                int playerDefendPoints = 0;
                int characterDefendPoints = 0;
                string battleResults = "";

                IBattle battleCharacter = CurrentCharacter as IBattle;
              
                    if (_player.MyWeapon != null)
                    {
                        playerAttackPoints = _player.Attack();
                        playerDefendPoints = _player.Defend();
                    }
                    if (battleCharacter.MyWeapon != null)
                    {
                        characterAttackPoints = battleCharacter.Attack();
                        characterDefendPoints = battleCharacter.Defend();
                    }

                    battleResults = $"{_player.Name}: Attack = {playerAttackPoints}\t Defend = {playerDefendPoints}\n" +
                        $"{CurrentCharacter.Name}: Attack = {characterAttackPoints}\t Defend = {characterDefendPoints}";
                     
                if (playerDefendPoints <= characterAttackPoints)
                {
                    newHitPoints = _player.HitPoints + playerDefendPoints - characterAttackPoints;
                    _player.HitPoints = newHitPoints;
                    if (_player.HitPoints <= 0)
                    {
                        Character selectedCharacter = CurrentCharacter;
                        OnPlayerDeath();
                        battleResults += $"\n{selectedCharacter.Name} has killed you.";
                    }
                    
                }
                else
                {
                    newHitPoints = _player.HitPoints - characterAttackPoints;
                    if (_player.HitPoints <= 0)
                    {
                        Character selectedCharacter = CurrentCharacter;
                        battleResults += $"\n{selectedCharacter.Name} has killed you."; 
                    }
                }
                if (characterDefendPoints <= playerAttackPoints)
                {
                    newHitPoints = CurrentCharacter.HitPoints + characterDefendPoints - playerAttackPoints;
                    if (newHitPoints<0)
                    {
                        newHitPoints = 0;
                    }
                    CurrentCharacter.HitPoints = newHitPoints;
                    if (CurrentCharacter.HitPoints == 0)
                    {
                        Character selectedCharacter = CurrentCharacter;
                        CurrentLocation.GameCharacters.Remove(CurrentCharacter);
                        battleResults += $"\nYou've attacked and defeated {selectedCharacter.Name}.";
                    }
                }
                if (CurrentCharacter != null)
                {
                    newHitPoints = CurrentCharacter.HitPoints - playerAttackPoints;
                    CurrentCharacter.HitPoints = newHitPoints;
                    if (CurrentCharacter.HitPoints <= 0)
                    {
                        battleResults += $"\nYou've attacked and defeated {CurrentCharacter.Name}.";
                        CurrentLocation.GameCharacters.Remove(CurrentCharacter);
                       
                    }
                    else
                    {
                        battleResults += $"\n{CurrentCharacter.Name}'s Hit Points: {CurrentCharacter.HitPoints}";
                    }                   
                   
                }

                _currentLocation.Message = battleResults;
            }
            else if(CurrentCharacter is Merchant || CurrentCharacter is Policeman || CurrentCharacter is Resident)
            {
                const int innocentAttackPenalty = 25;
                newHitPoints = _player.HitPoints - innocentAttackPenalty;
                
                _currentLocation.Message = $"{CurrentCharacter.Name} is an innocent person. You loose 25 hit points.";
                _player.HitPoints = newHitPoints;
            }

           
        }       

        public void OnPlayerDeath()
        {
            if (_player.Lives>=2)
            {
                _player.Lives--;
                _player.HitPoints = 100;
                if (_gameMap.MapLocations[0, 0].Accessible)
                {
                    _gameMap.ResetLocationPalm();
                }
                else
                {
                    _gameMap.ResetLocation();
                }
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
            }
            else
            {
                Environment.Exit(0);
            }
            

        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 1, Column = 1 };
        }

        public void OnPlayerCommunicate()
        {
            if (CurrentCharacter != null && CurrentCharacter is ICommunicate)
            {
                ICommunicate spokesperson = CurrentCharacter as ICommunicate;
                _currentLocation.Message = spokesperson.CurrentMessage();
            }
        }

        public void EquipWeapon()
        {
            GameItemQuantity selectedgameitem = _currentGameItem as GameItemQuantity;

            if (_currentGameItem != null && _player.Inventory.Contains(selectedgameitem))
            {               

                if (selectedgameitem.GameItem is Weapon)
                {
                    if (_player.WeaponCarried != null)
                    {
                        _player.AddGameItemQuantityToInventory(_player.WeaponCarried);
                    }
                    _player.WeaponCarried = selectedgameitem;
                    _player.RemoveGameItemQuantityFromInventory(selectedgameitem);
                    _player.CurrentWeapon = _player.WeaponName();
                    _player.MyWeapon = selectedgameitem.GameItem as Weapon;
                }
                else if (selectedgameitem.GameItem is ActionItem)
                {
                    if (_player.ItemCarried != null)
                    {
                        _player.AddGameItemQuantityToInventory(_player.ItemCarried);
                    }
                    _player.ItemCarried = selectedgameitem;
                    _player.RemoveGameItemQuantityFromInventory(selectedgameitem);
                    _player.CurrentItem = _player.ReturnItemCarried();
                }
                _currentGameItem = null;
            }
            else if (_currentGameItem != null && _currentLocation.GameItems.Contains(selectedgameitem))
            {
                if (selectedgameitem.GameItem is Weapon)
                {
                    if (_player.WeaponCarried != null)
                    {
                        _player.AddGameItemQuantityToInventory(_player.WeaponCarried);
                    }
                    _player.WeaponCarried = selectedgameitem;
                    _currentLocation.RemoveGameItemQuantityFromLocation(selectedgameitem);
                    _player.CurrentWeapon = _player.WeaponName();
                    _player.MyWeapon = selectedgameitem.GameItem as Weapon;
                }
                else if (selectedgameitem.GameItem is ActionItem)
                {
                    if (_player.ItemCarried != null)
                    {
                        _player.AddGameItemQuantityToInventory(_player.ItemCarried);
                    }
                    _player.ItemCarried = selectedgameitem;
                    _currentLocation.RemoveGameItemQuantityFromLocation(selectedgameitem);
                    _player.CurrentItem = _player.ReturnItemCarried();
                }
                _currentGameItem = null;
            }
            
        }

        public void AddItemToInventory()
        {
           
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem) && (_currentLocation.Id != 2 || _currentLocation.Id != 5))
            {
                //
                // cast selected game item 
                //
               
                    GameItemQuantity selectedGameItem = _currentGameItem as GameItemQuantity;
                if (selectedGameItem.GameItem is Currency)
                {
                    OnPlayerPickUp(selectedGameItem);
                    _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItem);
                }
                else
                {
                    if (selectedGameItem.GameItem.ItemID == 307)
                    {
                        
                    }
                    _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItem);
                    _player.AddGameItemQuantityToInventory(selectedGameItem);
                    OnPlayerPickUp(selectedGameItem);
                }
                   
            }

            else if (_currentGameItem != null && CharacterInventory.Contains(_currentGameItem))
            {
                GameItemQuantity selectedGameItem = _currentGameItem as GameItemQuantity;
                if(selectedGameItem.GameItem.ItemCost == 0)
                {
                    _player.AddGameItemQuantityToInventory(selectedGameItem);
                    CharacterInventory.Remove(selectedGameItem);
                    
                }
                else if(_player.BootyValue >= selectedGameItem.GameItem.ItemCost)
                {
                    int newBoooty = _player.BootyValue;

                    _player.AddGameItemQuantityToInventory(selectedGameItem);
                    _player.BootyValue = newBoooty - selectedGameItem.GameItem.ItemCost;
                    CharacterInventory.Remove(selectedGameItem);
                                        
                }
                else
                {
                    _currentLocation.Message = "Please comeback with proper funds";
                }
                
               
               
            }


        }

        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null && _player.Inventory.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedgameitem = _currentGameItem as GameItemQuantity;
                if (selectedgameitem.GameItem.ItemID < 200 || selectedgameitem.GameItem.ItemID > 300)
                {
                    if (_currentLocation.Id == 3)
                    {
                        _currentLocation.AddGameItemQuantityToLocation(selectedgameitem);
                        _player.RemoveGameItemQuantityFromInventory(selectedgameitem);
                    }
                    else
                    {
                        _player.RemoveGameItemQuantityFromInventory(selectedgameitem);
                    }
                }

            }
        }

        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
           
            _player.BootyValue += gameItemQuantity.GameItem.CurrencyValue;

        }

        ///
        /// This is for purchasing items
        /// Need to figure out how to remove certain Booty and then refactor the remaining price

        //private void OnPlayerPurchase(GameItemQuantity gameItemQuantity, ObservableCollection<GameItemQuantity> currentBooty)
        //{
        //    GameItemQuantity selectedGameItem = _currentGameItem as GameItemQuantity;
        //    int purchaseBalance = 0;

        //    if (selectedGameItem.GameItem.ItemCost == 50 && _player.BootyValue == 50)
        //    {
        //        foreach (GameItemQuantity booty in currentBooty)
        //        {
        //            _player.Inventory.Remove(booty);
        //        }
        //    }
        //    else if (true)
        //    {
        //        foreach (GameItemQuantity booty in currentBooty)
        //        {
        //            if (booty.GameItem.ItemID==)
        //            {

        //            }
        //            _player.Inventory.Remove(booty);
        //        }
        //    }
        //}

        /// <summary>
        /// game time event, publishes every 1 second
        /// </summary>
        //public void GameTimer()
        //{
        //    DispatcherTimer timer = new DispatcherTimer();
        //    timer.Interval = TimeSpan.FromMilliseconds(1000);
        //    timer.Tick += OnGameTimerTick;
        //    timer.Start();
        //}


        //public void PurchaseGameItem()
        //{
        //    _
        //}

        /// <summary>
        /// calculate the available travel points from current location
        /// game slipstreams are a mapping against the 2D array where 
        /// </summary>

        private void UpdateAvailableTravelPoints()
        {
            //
            // reset travel location information
            //
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            //
            // north location exists
            //
            if (_gameMap.NorthLocation(_player) != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation(_player);

                //
                // location generally accessible or player has required conditions
                //
                if (nextNorthLocation.Accessible == true )
                {
                    NorthLocation = _gameMap.NorthLocation(_player);
                    NorthLocationName = _gameMap.NorthLocationName(_player);
                }
            }

            //
            // east location exists
            //
            if (_gameMap.EastLocation(_player) != null)
            {
                Location nextEastLocation = _gameMap.EastLocation(_player);

                //
                // location generally accessible or player has required conditions
                //
                if (nextEastLocation.Accessible == true )
                {
                    EastLocation = _gameMap.EastLocation(_player);
                    EastLocationName = _gameMap.EastLocationName(_player);
                }
            }

            //
            // south location exists
            //
            if (_gameMap.SouthLocation(_player) != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation(_player);
                
                //
                // location generally accessible or player has required conditions
                //
                if (nextSouthLocation.Accessible == true )
                {
                    SouthLocation = _gameMap.SouthLocation(_player);
                    SouthLocationName = _gameMap.SouthLocationName(_player);

                    
                }
            }

            //
            // west location exists
            //
            if (_gameMap.WestLocation(_player) != null)
            {
                Location nextWestLocation = _gameMap.WestLocation(_player);

                //
                // location generally accessible or player has required conditions
                //
                if (nextWestLocation.Accessible == true)
                {
                    WestLocation = _gameMap.WestLocation(_player);
                    WestLocationName = _gameMap.WestLocationName(_player);
                }
            }
        }

        /// <summary>
        /// player move event handler
        /// </summary>
        private void OnPlayerMove()
        {

            CharacterInventory = null;
            //
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentLocation))
            {
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentLocation);

                // 
                // update experience points
                //
                _player.ExpierencePnts += _currentLocation.ModifiyExperiencePoints;
                
                //
                // update health
                //
                if (_currentLocation.ModifyHealth != 0)
                {
                    _player.HitPoints += _currentLocation.ModifyHealth;
                    if (_player.HitPoints > 100)
                    {
                        _player.HitPoints = 100;
                        _player.Lives++;
                    }
                }

                //
                // update lives
                //
                if (_currentLocation.ModifyLives != 0) _player.Lives += _currentLocation.ModifyLives;

                //
                // display a new message if available
                //
                OnPropertyChanged(nameof(MessageDisplay));

               
            }
        }

        /// <summary>
        /// travel north
        /// </summary>
        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel east
        /// </summary>
        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel south
        /// </summary>
        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel west
        /// </summary>
        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        public void UseGameItem()
        {
            GameItemQuantity selectedgameitem = _currentGameItem as GameItemQuantity;
            GameItemQuantity selectedBootyItem = _currentBootyItem as GameItemQuantity;
            if (selectedBootyItem!=null)
            {
                Currency bootyCurrency = selectedBootyItem.GameItem as Currency;
                if (_currentLocation.GameItems.Contains(selectedgameitem))
                {
                    _currentBootyItem.GameItem.ItemCost = selectedgameitem.GameItem.ItemCost - bootyCurrency.CurrencyValue;
                    _player.RemoveGameItemQuantityFromInventory(selectedBootyItem);
                    _player.UpdateInventoryCategories();
                }
            }
            if (_player.ItemCarried != null)
            {
                selectedgameitem = _player.ItemCarried;

                if (selectedgameitem.GameItem is ActionItem)
                {
                    ActionItem selectedActionItem = selectedgameitem.GameItem as ActionItem;
                    if ( selectedActionItem.ActionOfItem == ActionItem.ItemAction.OpenDoor && (_currentLocation.Id == 2 || _currentLocation.Id ==4))
                    {
                        _gameMap.UpdateLocationAccesible(_player);
                        UpdateAvailableTravelPoints();
                    }
                    else if (selectedActionItem.ActionOfItem == ActionItem.ItemAction.Heal)
                    {
                        _player.HitPoints += selectedgameitem.GameItem.HealthChange;
                        if (_player.HitPoints >= 100)
                        {
                            _player.Lives++;
                            _player.HitPoints -= 100;
                        }
                    }
                    _player.CurrentItem = _player.UpdateItem();
                }
            }
            else if (_currentGameItem != null)
            {
                selectedgameitem = _currentGameItem ;

                if (selectedgameitem.GameItem is ActionItem)
                {
                    ActionItem selectedActionItem = selectedgameitem.GameItem as ActionItem;
                    if (selectedActionItem.ActionOfItem == ActionItem.ItemAction.OpenDoor && (_currentLocation.Id == 2 || _currentLocation.Id == 4))
                    {
                        _gameMap.UpdateLocationAccesible(_player);
                        UpdateAvailableTravelPoints();
                        if (_currentLocation.GameItems.Contains(_currentGameItem))
                        {
                            _currentLocation.RemoveGameItemQuantityFromLocation(_currentGameItem);
                        }
                        else if (_player.Inventory.Contains(_currentGameItem))
                        {
                            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
                        }
                    }
                    else if (selectedActionItem.ActionOfItem == ActionItem.ItemAction.Heal)
                    {
                        _player.HitPoints += selectedgameitem.GameItem.HealthChange;
                        if (_player.HitPoints >= 100)
                        {
                            _player.Lives++;
                            _player.HitPoints -= 100;
                        }
                        if (_currentLocation.GameItems.Contains(_currentGameItem))
                        {
                            _currentLocation.RemoveGameItemQuantityFromLocation(_currentGameItem);
                        }
                        else if (_player.Inventory.Contains(_currentGameItem))
                        {
                            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
                        }
                    }
                    
                }
            }

           
        }

       

        #region GAME TIME METHODS

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        /// <summary>
        /// game timer event handler
        /// 1) update mission time on window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGameTimerTick(object sender, EventArgs e)
        {
            _gameTime = DateTime.Now - _gameStartTime;
            MissionTimeDisplay = "Mission Time " + _gameTime.ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// initial setup of the game session view
        /// </summary>
        private void InitializeView()
        {
            ObservableCollection<GameItemQuantity> currentBooty = new ObservableCollection<GameItemQuantity>();
            currentBooty = _player.Booty;
            _gameStartTime = DateTime.Now;
            UpdateAvailableTravelPoints();
            _player.UpdateInventoryCategories();
            _player.GoldValueCalculate();
            _player.WeaponName();
            _player.ReturnItemCarried();
            _player.MyWeapon = null;
            _messageDisplay = _currentLocation.Message;
        }

        public void CloseScreen()
        {
            Environment.Exit(0);
        }

        #endregion

        #endregion

        #region EVENTS



        #endregion
    }
}
