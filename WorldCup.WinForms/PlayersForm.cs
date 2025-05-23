using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.Services;

namespace WorldCup.WinForms
{
    public partial class PlayersForm : Form
    {
        private const char SEPARATOR = ',';
        public PlayersForm()
        {
            InitializeComponent();
        }

        private async void PlayersForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists("favorite.txt"))
            {
                MessageBox.Show("Favorite team not selected.");
                return;
            }

            string fifaCode = File.ReadAllText("favorite.txt").Trim();

            File.WriteAllText("config.txt", "json"); // samo cu za sad koristit ovi json da mi bude lokalno (za testiranje)

            MatchService matchService = new MatchService();
            List<DataLayer.Models.Match> matches = await matchService.GetMatchesForTeamAsync("men", fifaCode);

            if (matches == null || matches.Count == 0)
            {
                MessageBox.Show("No matches found.");
                return;
            }

            DataLayer.Models.Match firstMatch = matches[0];

            List<Player> players = new List<Player>();

            // ako je reprezentacija domaćin
            if (firstMatch.HomeTeam.Code == fifaCode)
            {
                players.AddRange(firstMatch.HomeTeamStatistics.StartingEleven);
                players.AddRange(firstMatch.HomeTeamStatistics.Substitutes);
            }
            else
            {
                players.AddRange(firstMatch.AwayTeamStatistics.StartingEleven);
                players.AddRange(firstMatch.AwayTeamStatistics.Substitutes);
            }

            lstPlayers.Items.Clear();

            foreach (Player player in players)
            {
                lstPlayers.Items.Add(player);
            }


            // pokazujen favorite players odma na otvaranju forme ako ima filea:
            if (File.Exists("favorite_players.txt"))
            {
                string[] lines = File.ReadAllLines("favorite_players.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(SEPARATOR);

                    if (parts.Length == 3)
                    {
                        Player p = new Player
                        {
                            Name = parts[0],
                            ShirtNumber = int.Parse(parts[1]),
                            Position = parts[2]
                        };

                        lstFavoritePlayers.Items.Add(p);
                    }
                }
            }
        }

        private void btnAddToFavorites_Click(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select a player first.");
                return;
            }

            if (lstFavoritePlayers.Items.Count >= 3)
            {
                MessageBox.Show("You can only select up to 3 favorite players.");
                return;
            }

            Player selectedPlayer = (Player)lstPlayers.SelectedItem;

            // ode provjeravan da nije mozda vec dodan
            foreach (Player p in lstFavoritePlayers.Items)
            {
                if (p.Name == selectedPlayer.Name && p.ShirtNumber == selectedPlayer.ShirtNumber)
                {
                    MessageBox.Show("This player is already in your favorites.");
                    return;
                }
            }

            lstFavoritePlayers.Items.Add(selectedPlayer);
        }

        private void btnSaveFavoritePlayers_Click(object sender, EventArgs e)
        {
            if (lstFavoritePlayers.Items.Count == 0)
            {
                MessageBox.Show("No favorite players to save.");
                return;
            }

            List<string> lines = new List<string>();

            foreach (Player player in lstFavoritePlayers.Items)
            {
                string line = $"{player.Name}, {player.ShirtNumber}, {player.Position}";
                lines.Add(line);
            }

            File.WriteAllLines("favorite_players.txt", lines);
            MessageBox.Show("Favorite players saved!");
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItem == null)
                return;

            Player player = (Player)lstPlayers.SelectedItem;

            string imagePath = "Images/" + player.Name + ".jpg";

            if (File.Exists(imagePath))
            {
                picPlayer.Image = Image.FromFile(imagePath);
            }
            else
            {
                picPlayer.Image = Image.FromFile("Images/goat.jpg");
            }
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItem is not Player player)
            {
                MessageBox.Show("Please select a player first.");
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose player image";
            dialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = dialog.FileName;
                string imageName = player.Name + ".jpg";
                string destPath = Path.Combine("Images", imageName);

                File.Copy(sourcePath, destPath, true);

                MessageBox.Show("Image saved!");

                // odma prikazuj novu sliku
                picPlayer.Image = Image.FromFile(destPath);
            }
        }

    }
}
