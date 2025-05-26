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

namespace WorldCup.WPF
{
    /// <summary>
    /// Interaction logic for PlayerDetailWindow.xaml
    /// </summary>
    public partial class PlayerDetailWindow : Window
    {
        public PlayerDetailWindow(Player player, Match match, string fifaCode)
        {
            InitializeComponent();

            txtTitle.Text = player.Name;
            txtNumber.Text = $"Shirt number: #{player.ShirtNumber}";
            txtPosition.Text = $"Position: {player.Position}";
            txtCaptain.Text = player.Captain ? "Captain: Yes" : "Captain: No";

            string imagePath = $"Images/{player.Name}.jpg";
            if (!File.Exists(imagePath))
                imagePath = "Images/goat.jpg";

            imgPlayer.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(imagePath)));

            var events = match.HomeTeam.Code == fifaCode
                ? match.HomeTeamEvents
                : match.AwayTeamEvents;

            int goals = events.Count(e => e.Player == player.Name && e.TypeOfEvent == "goal");
            int cards = events.Count(e => e.Player == player.Name && e.TypeOfEvent == "yellow-card");

            txtGoals.Text = $"Goals in match: {goals}";
            txtCards.Text = $"Yellow cards: {cards}";
        }
    }
}
