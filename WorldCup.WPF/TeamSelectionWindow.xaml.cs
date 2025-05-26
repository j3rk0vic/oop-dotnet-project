using System;
using System.Collections.Generic;
using System.IO;
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
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.Services;

namespace WorldCup.WPF
{
    /// <summary>
    /// Interaction logic for TeamSelectionWindow.xaml
    /// </summary>
    public partial class TeamSelectionWindow : Window
    {
        public TeamSelectionWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("favorite.txt"))
            {
                MessageBox.Show("Favorite team not found.");
                Close();
                return;
            }

            string fifaCode = File.ReadAllText("favorite.txt").Trim();
            File.WriteAllText("config.txt", "json");

            cbHomeTeam.Items.Add(fifaCode);
            cbHomeTeam.SelectedIndex = 0;

            MatchService service = new MatchService();
            List<Match> matches = await service.GetMatchesForTeamAsync("men", fifaCode);

            HashSet<string> opponents = new HashSet<string>();

            foreach (Match match in matches)
            {
                if (match.HomeTeam.Code == fifaCode)
                    opponents.Add(match.AwayTeam.Code);
                else
                    opponents.Add(match.HomeTeam.Code);
            }

            cbOpponent.ItemsSource = opponents;
        }

        // ovo ne valjaaaaa!!!
        private async void cbOpponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbOpponent.SelectedItem == null)
                return;

            string fifaCode = File.ReadAllText("favorite.txt").Trim(); // ne smi bit null jer ga citan iz filea (ne more bit null ustvari)
            string? opponentCode = cbOpponent.SelectedItem.ToString();

            File.WriteAllText("config.txt", "json");

            MatchService service = new MatchService();
            List<Match> matches = await service.GetMatchesForTeamAsync("men", fifaCode);

            foreach (var match in matches)
            {
                bool playedAgainst = (match.HomeTeam.Code == fifaCode && match.AwayTeam.Code == opponentCode)
                                  || (match.AwayTeam.Code == fifaCode && match.HomeTeam.Code == opponentCode);

                if (playedAgainst)
                {
                    string result = $"{match.HomeTeam.Goals} : {match.AwayTeam.Goals}";
                    txtResult.Text = result;
                    return;
                }
            }

            txtResult.Text = "No result found.";
        }

        private void btnShowField_Click(object sender, RoutedEventArgs e)
        {
            FieldViewWindow field = new FieldViewWindow();
            field.Show();
            this.Close();
        }
    }
}
