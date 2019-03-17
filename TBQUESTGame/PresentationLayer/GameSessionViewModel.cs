using System;
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
        private DateTime _gameStartTime;
        private Player _player;
        private List<string> _messages;
        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationName;
        private ObservableCollection<Location> _accessibleLocations;

        public DateTime GameStartTime
        {
            get { return _gameStartTime; }
            set { _gameStartTime = value; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return FormatMessagesForViewer(); }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set {
                _currentLocationName = value;
                OnPlayMove();
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set { _accessibleLocations = value; }
        }

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player, List<string> initialMessages, Map gameMap, Location currentLocation )
        {
            _player = player;
            _messages = initialMessages;
            _gameMap = gameMap;
            _currentLocation = currentLocation;
            _accessibleLocations = _gameMap.AccessibleLocaitons();
            InitializeView();
        }

        private string FormatMessagesForViewer()
        {
            List<string> lifoMessages = new List<string>();

            for (int index = 0; index < _messages.Count; index++)
            {
                lifoMessages.Add($" <T:{GameTime().ToString(@"hh\:mm\:ss")}> " + _messages[index]);
            }

            lifoMessages.Reverse();

            return string.Join("\n\n", lifoMessages);
        }

        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
        }

        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        private void OnPlayMove()
        {
            Location newLocation = new Location();

            foreach (Location location in AccessibleLocations)
            {
                if (location.Name == _currentLocationName)
                {
                    newLocation = location;
                    _currentLocation = newLocation;
                    _player.ExpierencePnts += _currentLocation.ModifiyExperiencePoints;
                }
            }

            //Location newLocation = AccessibleLocations.FirstOrDefault(1 => 1.Name == _currentLocationName);
            _gameMap.CurrentLocation = newLocation;
        }
    }
}
