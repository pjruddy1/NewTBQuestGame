﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TBQUESTGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeWindowTheme();

            InitializeComponent();
        }

        private void InitializeWindowTheme()
        {
            this.Title = "Peej Funtastic Design";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.CloseScreen();
           
        }

        private void NorthTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveNorth();
        }

        private void EastTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveEast();
        }

        private void SouthTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveSouth();
        }

        private void WestTravelButton_Click(object sender, RoutedEventArgs e)
        {            
            _gameSessionViewModel.MoveWest();
        }

        private void PickUpButton_Click_1(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.AddItemToInventory();
           
        }

        private void DropButton_Click_1(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.RemoveItemFromInventory();
        }

        private void EquipButton_Click_1(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.EquipWeapon();
        }

        private void UseButton_Click_1(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.UseGameItem();
        }        

        private void CommunicateButton_Click_1(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerCommunicate();
        }

        private void AttackButton_Click_1(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.Battle();
        }

        private void TradeButton_Click_1(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.Trade();
        }
    }
}
