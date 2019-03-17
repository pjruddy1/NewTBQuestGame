using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQUESTGame.Models
{
    public class Map
    {
        #region FIELDS
        private ObservableCollection<Location> _locations;
        private Location _currentLocation;
        private Location[,] _mapLocations;
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public Location[,] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        #endregion

        #region PROPERTIES
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

        public ObservableCollection<Location> AccessibleLocaitons()
        {
            ObservableCollection<Location> accessibleLocation = new ObservableCollection<Location>();

            foreach (var location in _locations)
            {
                if (location.Accessibble == true)
                {
                    accessibleLocation.Add(location);
                }
            }
            return accessibleLocation;
        }
        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS
        public void Move(Location location)
        {
            _currentLocation = location;
        }
        #endregion
    }
}
