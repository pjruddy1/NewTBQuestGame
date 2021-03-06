﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQUESTGame.Models;
using System.Collections.ObjectModel;

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
        

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return _currentLocation.Message; }
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

        public void EquipWeapon()
        {
            GameItemQuantity selectedgameitem = _currentGameItem as GameItemQuantity;

            if (_currentGameItem != null)
            {
                

                if (selectedgameitem.GameItem.ItemID < 200 && selectedgameitem.GameItem.ItemID > 100)
                {
                    if (_player.WeaponCarried != null)
                    {
                        _player.AddGameItemQuantityToInventory(_player.WeaponCarried);
                    }
                    _player.WeaponCarried = selectedgameitem;
                    _player.RemoveGameItemQuantityFromInventory(selectedgameitem);
                    _player.CurrentWeapon = _player.WeaponName();
                }
                else if (selectedgameitem.GameItem.ItemID > 300 && selectedgameitem.GameItem.ItemID < 400)
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
            
        }

        public void AddItemToInventory()
        {
           
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
               
                    GameItemQuantity selectedGameItem = _currentGameItem as GameItemQuantity;

                    _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItem);
                    _player.AddGameItemQuantityToInventory(selectedGameItem);
                    OnPlayerPickUp(selectedGameItem);
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
            if (_player.ItemCarried != null)
            {
                selectedgameitem = _player.ItemCarried;

                if (selectedgameitem.GameItem.ItemID < 400 && selectedgameitem.GameItem.ItemID > 300)
                {
                    if (selectedgameitem.GameItem.ItemID == 301)
                    {
                        _gameMap.UpdateLocationAccesible(_player);
                        UpdateAvailableTravelPoints();
                    }
                    _player.HitPoints += selectedgameitem.GameItem.HealthChange;
                    if (_player.HitPoints >= 100)
                    {
                        _player.Lives++;
                        _player.HitPoints -= 100;
                    }
                    
                    _player.CurrentItem = _player.UpdateItem();
                }
            }
            else if (_currentGameItem != null)
            {
                if (selectedgameitem.GameItem.ItemID < 400 && selectedgameitem.GameItem.ItemID > 300)
                {
                    _player.HitPoints += selectedgameitem.GameItem.HealthChange;
                    if (_player.HitPoints >= 100)
                    {
                        _player.Lives++;
                        _player.HitPoints -= 100;
                    }
                    _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
                    _player.CurrentWeapon = _player.ReturnItemCarried();
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
