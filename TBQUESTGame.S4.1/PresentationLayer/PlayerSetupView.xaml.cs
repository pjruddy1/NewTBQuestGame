using System;
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
using TBQUESTGame.Models;

namespace TBQUESTGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;
        private Player _newPlayer;
        private Player _ignore;



        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }

        private void SetupWindow()
        {

            ErrorTextBox.Visibility = Visibility.Hidden;
        }


        /// <summary>
        /// validate user input and generate appropriate error messages
        /// </summary>
        /// <param name="errorMessage">user feedback</param>
        /// <returns>is user input valid</returns>
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (PlayerSetupTextBox.Text == "")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                _player.Name = PlayerSetupTextBox.Text;
            }


            return errorMessage == "" ? true : false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;
            if (IsValidInput(out errorMessage))
            {
                Visibility = Visibility.Hidden;
            }
        }
    }
}
