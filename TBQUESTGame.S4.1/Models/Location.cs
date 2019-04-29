using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace TBQUESTGame.Models
{
    public class Location : ObservableObject
    {
        public enum Action
        {
            None, PurchaseRoom, SpeakToNPC
        }
        #region FIELDS

        private int _id; // must be a unique value for each object
        private string _name;
        private string _description;
        private bool _accessible;
        private int _requiredExperiencePoints;
        private int _modifiyExperiencePoints;
        private int _modifyHealth;
        private int _modifyLives;
        private string _message;
        private string _imagename;
        private ObservableCollection<GameItemQuantity> _gameItems;
        private ObservableCollection<GameItemQuantity> _booty;
        private List<GameItem> _weaponRequired;
        private int _actionItemRequired;
        private ObservableCollection<Character> _gameCharacters;
        private ObservableCollection<Merchant> _gameMerchants;
        private ObservableCollection<Gangster> _gameGangsters;
        private ObservableCollection<Resident> _gameResidents;
        private ObservableCollection<Policeman> _gamePolice;

        public ObservableCollection<Policeman> GamePolice
        {
            get { return _gamePolice; }
            set { _gamePolice = value; }
        }


        public ObservableCollection<Resident> GameResidents
        {
            get { return _gameResidents; }
            set { _gameResidents = value; }
        }


        public ObservableCollection<Gangster> GameGangsters
        {
            get { return _gameGangsters; }
            set { _gameGangsters = value; }
        }


        public ObservableCollection<Merchant> GameMerchants
        {
            get { return _gameMerchants; }
            set { _gameMerchants = value; }
        }




        public ObservableCollection<Character> GameCharacters
        {
            get { return _gameCharacters; }
            set { _gameCharacters = value; }
        }

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }

        public int ModifiyExperiencePoints
        {
            get { return _modifiyExperiencePoints; }
            set { _modifiyExperiencePoints = value; }
        }

        public int RequiredExperiencePoints
        {
            get { return _requiredExperiencePoints; }
            set { _requiredExperiencePoints = value; }
        }

        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set { _modifyHealth = value; }
        }

        public int ModifyLives
        {
            get { return _modifyLives; }
            set { _modifyLives = value; }
        }

        public int ActionItemRequired
        {
            get { return _actionItemRequired; }
            set { _actionItemRequired = value; }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public string ImageName
        {
            get { return _imagename; }
            set { _imagename = value; }
        }

        public ObservableCollection<GameItemQuantity> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        public ObservableCollection<GameItemQuantity> Booty
        {
            get { return _booty; }
            set { _booty = value; }
        }

        public List<GameItem> WeaponRequired
        {
            get { return _weaponRequired; }
            set { _weaponRequired = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Location()
        {
            _gameResidents = new ObservableCollection<Resident>();
            _gameMerchants = new ObservableCollection<Merchant>();
            _gameGangsters = new ObservableCollection<Gangster>();
            _gameCharacters = new ObservableCollection<Character>();
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return _name;
        }
                

        public void UpdateLocationGameCharacters()
        {
            ObservableCollection<Character> updatedLocationCharacters = new ObservableCollection<Character>();

            foreach (Character character in _gameCharacters)
            {
                updatedLocationCharacters.Add(character);
            }

            GameItems.Clear();

            foreach (Character character in updatedLocationCharacters)
            {
                GameCharacters.Add(character);
            }
        }

        #region GameItem Methods
        /// <summary>
        /// Used to update both GameItems and Booty
        /// </summary>
        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItemQuantity> updatedLocationGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (GameItemQuantity gameItemQuantity in _gameItems)
            {
                updatedLocationGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (GameItemQuantity gameItemQuantity in updatedLocationGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }

        /// <summary>
        /// Used to load booty to locatitons
        /// </summary>
        /// <param name="selectedGameItemQuantity"></param>
        public void AddGameItemQuantityToLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.ItemID == selectedGameItemQuantity.GameItem.ItemID);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _gameItems.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateLocationGameItems();
        }

        /// <summary>
        /// Used to Remove Booty From Location
        /// </summary>
        /// <param name="selectedGameItemQuantity"></param>
        public void RemoveGameItemQuantityFromLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.ItemID == selectedGameItemQuantity.GameItem.ItemID);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _gameItems.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateLocationGameItems();
        }
              

        #endregion
        //public bool IsAccessibleByWeaponCarried(GameItemQuantity WeaponCarried, List<GameItem> WeaponRequired)
        //{
        //    if (WeaponCarried != null)
        //    {
        //        foreach (GameItem weapon in WeaponRequired)
        //        {
        //            if (WeaponCarried.GameItem.ItemID == weapon.ItemID)
        //            {
        //                return true;

        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
            
        //}

        public bool IsAccessibleByExperiencePoints(int playerExperiencePoints)
        {
            return playerExperiencePoints >= _requiredExperiencePoints ? true : false;
        }
        #endregion
    }
}
