using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Action _availableAction1;
        private Action _availableAction2;
        private string _imagename;

        

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

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public Action AvailableAciton1
        {
            get { return _availableAction1; }
            set { _availableAction1 = value; }
        }

        public Action AvailableAction2
        {
            get { return _availableAction2; }
            set { _availableAction2 = value; }
        }

        public string ImageName
        {
            get { return _imagename; }
            set { _imagename = value; }
        }

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS
        public override string ToString()
        {
            return _name;
        }



        public bool IsAccessibleByExperiencePoints(int playerExperiencePoints)
        {
            return playerExperiencePoints >= _requiredExperiencePoints ? true : false;
        }
        #endregion
    }
}
