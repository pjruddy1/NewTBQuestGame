using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQUESTGame.DataLayer;
using TBQUESTGame.Models;
using TBQUESTGame.PresentationLayer;

namespace TBQUESTGame.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        bool _newPlayer = true; 
        Player _player = new Player();
        PlayerSetupView _playerSetupView = null;

        public GameBusiness()
        {
            SetupPlayer();
            InstantiateAndShowView();
        }

        /// <summary>
        /// setup new or existing player
        /// </summary>
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                //
                // setup up game based player properties
                //
                _player.HitPoints = 100;
                _player.Lives = 5;
                _player.ExpierencePnts = 0;
                _player.Gold = 50;
                _player.ItemCarried = Character.Items.Rope;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        /// <summary>
        /// create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            //
            // instantiate the view model and initialize the data set
            //
            _gameSessionViewModel = new GameSessionViewModel(_player, GameData.InitialMessages());
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();
            _playerSetupView.Close();
        }
    }
}
