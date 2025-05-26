using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.Services;

namespace WorldCup.WPF
{
    public partial class FieldViewWindow : Window
    {
        public FieldViewWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("favorite.txt"))
                return;

            string fifaCode = File.ReadAllText("favorite.txt").Trim();
            File.WriteAllText("config.txt", "json");

            MatchService service = new MatchService();
            List<Match> matches = await service.GetMatchesForTeamAsync("men", fifaCode);

            if (matches.Count == 0)
                return;

            Match match = matches[0];

            List<Player> players = match.HomeTeam.Code == fifaCode
                ? match.HomeTeamStatistics.StartingEleven
                : match.AwayTeamStatistics.StartingEleven;

            var goalies = players.Where(p => p.Position == "Goalie").ToList();
            var defenders = players.Where(p => p.Position == "Defender").ToList();
            var midfielders = players.Where(p => p.Position == "Midfield").ToList();
            var forwards = players.Where(p => p.Position == "Forward").ToList();

            // previsoko mi jee! moran pomaknit nekako doli sve, a i vezu isto doli na sridu stavit :(
            DrawGoalie(goalies, x: 100, match, fifaCode);
            DrawPlayers(defenders, x: 250, match, fifaCode);
            DrawPlayers(midfielders, x: 400, match, fifaCode);
            DrawPlayers(forwards, x: 550, match, fifaCode);
        }

        private void DrawGoalie(List<Player> goalies, double x, Match match, string fifaCode)
        {
            if (goalies.Count == 0) return;

            Player player = goalies[0];

            var box = CreatePlayerBox(player, match, fifaCode);

            double y = 200;

            Canvas.SetLeft(box, x);
            Canvas.SetTop(box, y);
            fieldCanvas.Children.Add(box);
        }

        private void DrawPlayers(List<Player> players, double x, Match match, string fifaCode)
        {
            double startY = 50;
            double spacing = 100;

            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                var box = CreatePlayerBox(player, match, fifaCode);

                double y = startY + (i * spacing);
                Canvas.SetLeft(box, x);
                Canvas.SetTop(box, y);

                fieldCanvas.Children.Add(box);
            }
        }

        private Border CreatePlayerBox(Player player, Match match, string fifaCode)
        {
            Border box = new Border
            {
                Width = 100,
                Height = 80,
                Background = Brushes.White,
                BorderBrush = Brushes.DarkGreen,
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(5)
            };

            StackPanel content = new StackPanel { Orientation = Orientation.Vertical };

            string imagePath = $"Images/{player.Name}.jpg";
            if (!File.Exists(imagePath))
                imagePath = "Images/goat.jpg";

            Image img = new Image
            {
                Width = 40,
                Height = 40,
                Source = new BitmapImage(new Uri(Path.GetFullPath(imagePath)))
            };

            TextBlock name = new TextBlock
            {
                Text = player.Name,
                FontSize = 10,
                TextAlignment = TextAlignment.Center
            };

            TextBlock number = new TextBlock
            {
                Text = "#" + player.ShirtNumber,
                FontWeight = FontWeights.Bold,
                FontSize = 12,
                TextAlignment = TextAlignment.Center
            };

            content.Children.Add(img);
            content.Children.Add(number);
            content.Children.Add(name);

            box.Child = content;

            box.MouseLeftButtonUp += (s, e) =>
            {
                PlayerDetailWindow detail = new PlayerDetailWindow(player, match, fifaCode);
                detail.ShowDialog();
            };

            return box;
        }
    }
}
