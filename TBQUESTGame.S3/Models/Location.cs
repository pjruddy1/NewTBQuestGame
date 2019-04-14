using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace TBQUESTGame.Models
{
    public class Location
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
        private GameItemQuantity _actionItemRequired;

       




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

        public GameItemQuantity ActionItemRequired
        {
            get { return _actionItemRequired; }
            set { _actionItemRequired = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
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
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return _name;
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
