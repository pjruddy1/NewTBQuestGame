using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Location
    {
        #region FIELDS
        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _experiencePnts;
        private int _requiredExperiencePnts;

        #endregion

        #region PROPERTIES
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessibble
        {
            get { return _accessible; }
            set { _accessible = value; }
        }

        public int ModifiyExperiencePoints
        {
            get { return _experiencePnts; }
            set { _experiencePnts = value; }
        }

        public int RequiredExperiencePnts
        {
            get { return _requiredExperiencePnts; }
            set { _requiredExperiencePnts = value; }
        }
        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS
        public override string ToString()
        {
            return _name;
        }
        #endregion
    }
}
