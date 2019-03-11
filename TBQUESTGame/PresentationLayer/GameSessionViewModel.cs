using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQUESTGame.Models;

namespace TBQUESTGame.PresentationLayer
{
    public class GameSessionViewModel
    {
        private DateTime _gameStartTime;
        private Player _player;
        private List<string> _messages;

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return FormatMessagesForViewer(); }
        }

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages)
        {
            _player = player;
            _messages = initialMessages;
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
    }
}
