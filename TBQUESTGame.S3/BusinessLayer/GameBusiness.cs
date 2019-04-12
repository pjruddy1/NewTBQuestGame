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
        bool _newPlayer = false;
        GameSessionViewModel _gameSessionViewModel;
        
        Player _player = new Player();
        PlayerSetupView _playerSetupView = null;
        //List<string> _messages;
        //Map _gameMap;
        //GameMapCoordinates _initialLocationCoordinates;
        


        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
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
        /// initialize data set
        /// </summary>
        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
        }

        /// <summary>
        /// create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            //
            // instantiate the view model and initialize the data set
            //
            _gameSessionViewModel = new GameSessionViewModel(_player, GameData.GameMap(), GameData.InitialGameMapLocation());
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            //
            // dialog window is initially hidden to mitigate issue with
            // main window closing after dialog window closes
            //
            // commented out because the player setup window is disabled
            //
            //_playerSetupView.Close();
        }
    }
}
