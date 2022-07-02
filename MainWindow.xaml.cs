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

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ScorePC = 0, ScorePL = 0;

        public MainWindow()
        {
            InitializeComponent();

            //Default player choice
            playerChoice.SelectedIndex = 0;

            //Default ratio
            resultRatio.Text = $"PC [{ScorePC}] - Player [{ScorePL}]";
        }

        private void ExecuteBtn_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            string[] PcOptions = { "Rock", "Paper", "Scissors" };
            string PcChoice = PcOptions[random.Next(0, PcOptions.Length)];

            string PlayerChoice;
            if (playerChoice.SelectedIndex == 0)
            {
                PlayerChoice = "Rock";
            }
            else if (playerChoice.SelectedIndex == 1) {
                PlayerChoice = "Paper";
            }
            else
            {
                PlayerChoice = "Scissors";
            }

            //Result
            pcChoice.Text = PcChoice;
            if (PcChoice == PlayerChoice)
            {
                resultBox.Text = "It's a draw!";
            }
            else if (
                (PcChoice == "Rock" && PlayerChoice == "Scissors") ||
                (PcChoice == "Paper" && PlayerChoice == "Rock") ||
                (PcChoice == "Scissors" && PlayerChoice == "Paper"))
            {
                resultBox.Text = "You lose, better luck next time!";
                ScorePC += 1;
            }
            else
            {
                resultBox.Text = "You win! Congratulations!";
                ScorePL += 1;
            }

            resultRatio.Text = $"PC [{ScorePC}] - Player [{ScorePL}]";
        }
    }
}
