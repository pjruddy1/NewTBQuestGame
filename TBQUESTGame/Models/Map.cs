﻿using System;
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
        private Location[,] _mapLocations;
        private int _maxRows;
        private int _maxColumns;
        private GameMapCoordinates _currentLocationCoordinates;

        #endregion

        #region PROPERTIES

        public GameMapCoordinates CurrentLocationCoordinates
        {
            get { return _currentLocationCoordinates; }
            set { _currentLocationCoordinates = value; }
        }

        public Location[,] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        public Location CurrentLocation
        {
            get { return _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column]; }
        }

       
        #endregion

        #region CONSTRUCTORS

        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            _mapLocations = new Location[rows, columns];
        }

        #endregion

        #region METHODS

        public void MoveNorth()
        {
            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                _currentLocationCoordinates.Row -= 1;
            }
        }

        public void MoveEast()
        {
            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                _currentLocationCoordinates.Column += 1;
            }
        }

        public void MoveSouth()
        {
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                _currentLocationCoordinates.Row += 1;
            }
        }

        public void MoveWest()
        {
            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {
                _currentLocationCoordinates.Column -= 1;
            }
        }

        //
        // get the north location if it exists
        //
        public Location NorthLocation(Player player)
        {
            Location northLocation = null;

            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                Location nextNorthLocation = _mapLocations[_currentLocationCoordinates.Row - 1, _currentLocationCoordinates.Column];

                //
                // location exists and player can access location
                //
                if (nextNorthLocation != null &&
                    (nextNorthLocation.Accessible == true || nextNorthLocation.IsAccessibleByExperiencePoints(player.ExpierencePnts)))
                {
                    northLocation = nextNorthLocation;
                }
            }

            return northLocation;
        }

        public string NorthLocationName(Player player)
        {
            string northLocationName = null;

            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                Location nextNorthLocation = _mapLocations[_currentLocationCoordinates.Row - 1, _currentLocationCoordinates.Column];

                //
                // location exists and player can access location
                //
                if (nextNorthLocation != null &&
                    (nextNorthLocation.Accessible == true || nextNorthLocation.IsAccessibleByExperiencePoints(player.ExpierencePnts)))
                {
                    northLocationName = nextNorthLocation.Name;
                }
            }

            return northLocationName;
        }

        //
        // get the east location if it exists
        //
        public Location EastLocation(Player player)
        {
            Location eastLocation = null;

            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Location nextEastLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];

                //
                // location exists and player can access location
                //
                if (nextEastLocation != null &&
                    (nextEastLocation.Accessible == true || nextEastLocation.IsAccessibleByExperiencePoints(player.ExpierencePnts)))
                {
                    eastLocation = nextEastLocation;
                }
            }

            return eastLocation;
        }

        public string EastLocationName(Player player)
        {
            string eastLocationName = null;

            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Location nextEastLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];

                //
                // location exists and player can access location
                //
                if (nextEastLocation != null &&
                    (nextEastLocation.Accessible == true || nextEastLocation.IsAccessibleByExperiencePoints(player.ExpierencePnts)))
                {
                    eastLocationName = nextEastLocation.Name;
                }
            }

            return eastLocationName;
        }

        //
        // get the south location if it exists
        //
        public Location SouthLocation(Player player)
        {
            Location southLocation = null;

            //
            // not on south border
            //
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                Location nextSouthLocation = _mapLocations[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column];

                //
                // location exists and player can access location
                //
                if (nextSouthLocation != null &&
                    (nextSouthLocation.Accessible == true || nextSouthLocation.IsAccessibleByExperiencePoints(player.ExpierencePnts)))
                {
                    southLocation = nextSouthLocation;
                }
            }

            return southLocation;
        }

        public string SouthLocationName(Player player)
        {
            string southLocationName = null;

            //
            // not on south border
            //
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                Location nextSouthLocation = _mapLocations[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column];

                //
                // location exists and player can access location
                //
                if (nextSouthLocation != null &&
                    (nextSouthLocation.Accessible == true || nextSouthLocation.IsAccessibleByExperiencePoints(player.ExpierencePnts)))
                {
                    southLocationName = nextSouthLocation.Name;
                }
            }

            return southLocationName;
        }

        //
        // get the west location if it exists
        //
        public Location WestLocation(Player player)
        {
            Location westLocation = null;

            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {
                Location nextWestLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];

                //
                // location exists and player can access location
                //
                if (nextWestLocation != null &&
                    (nextWestLocation.Accessible == true || nextWestLocation.IsAccessibleByExperiencePoints(player.ExpierencePnts)))
                {
                    westLocation = nextWestLocation;
                }
            }

            return westLocation;
        }

        public string WestLocationName(Player player)
        {
            string westLocationName = null;

            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {
                Location nextWestLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];

                //
                // location exists and player can access location
                //
                if (nextWestLocation != null &&
                    (nextWestLocation.Accessible == true || nextWestLocation.IsAccessibleByExperiencePoints(player.ExpierencePnts)))
                {
                    westLocationName = nextWestLocation.Name;
                }
            }

            return westLocationName;
        }

        #endregion
    }
}
