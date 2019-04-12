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
        private int _actionItemRequired;       

        private string _message;
        private string _imagename;
        private ObservableCollection<GameItem> _gameItems;
        private ObservableCollection<GameItemQuantity> _booty;

       




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
            set { _message = value; }
        }

        public string ImageName
        {
            get { return _imagename; }
            set { _imagename = value; }
        }


        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        public ObservableCollection<GameItemQuantity> Booty
        {
            get { return _booty; }
            set { _booty = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Location()
        {
            _booty = new ObservableCollection<GameItemQuantity>();
            _gameItems = new ObservableCollection<GameItem>();
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return _name;
        }

        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();
            ObservableCollection<GameItemQuantity> UpdatedBooty = new ObservableCollection<GameItemQuantity>();

            foreach (GameItem gameItem in _gameItems)
            {
                
                    updatedLocationGameItems.Add(gameItem);
                
            }
            foreach (GameItemQuantity gameItemQuantity in _booty)
            {
                UpdatedBooty.Add(gameItemQuantity);
            }
            Booty.Clear();
            GameItems.Clear();

            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
            foreach (GameItemQuantity gameItemQuantity in UpdatedBooty)
            {
                Booty.Add(gameItemQuantity);
            }
        }

        public void AddGameItemQuantityToLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            GameItemQuantity gameItemQuantity = _booty.FirstOrDefault(i => i.GameItem.ItemID == selectedGameItemQuantity.GameItem.ItemID);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _booty.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateLocationGameItems();
        }

        public void RemoveGameItemQuantityFromLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            GameItemQuantity gameItemQuantity = _booty.FirstOrDefault(i => i.GameItem.ItemID == selectedGameItemQuantity.GameItem.ItemID);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _booty.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateLocationGameItems();
        }

        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem.ItemID < 200 && selectedGameItem.ItemID > 300)
            {
                _gameItems.Add(selectedGameItem);
                
            }
            UpdateLocationGameItems();

        }

        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Remove(selectedGameItem);
            }

            UpdateLocationGameItems();
        }

        public bool IsAccessibleByExperiencePoints(int playerExperiencePoints)
        {
            return playerExperiencePoints >= _requiredExperiencePoints ? true : false;
        }
        #endregion
    }
}
