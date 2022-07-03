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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RockPaperScissors2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Essentials
        readonly Random Rnd = new Random();

        //Scoring System
        int PcScore = 0, PlayerScore = 0;

        void PcScoreUp()
        {
            PcScore += 1;
        }
        void PlayerScoreUp()
        {
            PlayerScore += 1;
        }

        void DisplayScore()
        {
            Scorebox.Text = $"PC {PcScore} - Player {PlayerScore}";
        }

        //Pc choices
        string PcChoice;
        void SetPcChoice()
        {
            string[] options = { "Rock", "Paper", "Scissors" };
            PcChoice = options[Rnd.Next(0, options.Length)];
        }

        //Player choices
        string PlayerChoice;

        private void BtnRock_Click(object sender, RoutedEventArgs e)
        {
            MainExecution("Rock");
        }

        private void BtnPaper_Click(object sender, RoutedEventArgs e)
        {
            MainExecution("Paper");
        }

        private void BtnScissors_Click(object sender, RoutedEventArgs e)
        {
            MainExecution("Scissors");
        }

        //Display Choices
        void DisplayChoices()
        {
            PcChoiceBox.Text = PcChoice;
            PlayerChoiceBox.Text = PlayerChoice;
        }

        //Result board
        void DisplayResult()
        {
            if (PcChoice == PlayerChoice)
            {
                ResultBox.Text = "It's a draw!";
                PcChoiceBox.Background = Brushes.Yellow;
                PlayerChoiceBox.Background = Brushes.Yellow;
            }
            else if (
                (PcChoice == "Rock" && PlayerChoice == "Scissors") ||
                (PcChoice == "Paper" && PlayerChoice == "Rock") ||
                (PcChoice == "Scissors" && PlayerChoice == "Paper"))
            {
                ResultBox.Text = "You lose, better luck next time!";
                PcScoreUp();
                PcChoiceBox.Background = Brushes.Green;
                PlayerChoiceBox.Background = Brushes.Red;
            }
            else
            {
                ResultBox.Text = "You win! Congratulations!";
                PlayerScoreUp();
                PcChoiceBox.Background = Brushes.Red;
                PlayerChoiceBox.Background = Brushes.Green;
            }
        }

        void MainExecution(string SetPlayerChoice)
        {
            PlayerChoice = SetPlayerChoice;
            SetPcChoice();
            DisplayChoices();
            DisplayResult();
            DisplayScore();
        }

        public MainWindow()
        {
            InitializeComponent();

            DisplayScore();
        }
    }
}
