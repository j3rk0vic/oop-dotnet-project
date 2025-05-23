using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Models;

namespace WorldCup.WinForms
{
    public partial class FavoriteForm : Form
    {
        public FavoriteForm()
        {
            InitializeComponent();
        }

        private void btnSaveFavorite_Click(object sender, EventArgs e)
        {
            if (cmbFavorites.SelectedItem is Team selectedTeam)
            {
                File.WriteAllText("favorite.txt", selectedTeam.FifaCode);
                MessageBox.Show("Favorite saved: " + selectedTeam.Country);
            }
            else
            {
                MessageBox.Show("Please select a team.");
            }
        }

        private async void FavoriteForm_Load(object sender, EventArgs e)
        {
            File.WriteAllText("config.txt", "json");

            TeamService service = new TeamService();
            List<Team> teams = await service.GetTeamsAsync();

            cmbFavorites.DataSource = teams;
            cmbFavorites.DisplayMember = "Country";
            cmbFavorites.ValueMember = "FifaCode";

            // automatski bira tim ako postoji favorite.txt
            if (File.Exists("favorite.txt"))
            {
                string savedFifaCode = File.ReadAllText("favorite.txt").Trim();

                foreach (Team team in teams)
                {
                    if (team.FifaCode == savedFifaCode)
                    {
                        cmbFavorites.SelectedItem = team;
                        break;
                    }
                }
            }
        }

        private void FavoriteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            PlayersForm playersForm = new PlayersForm();
            playersForm.Show();
        }
    }
}
