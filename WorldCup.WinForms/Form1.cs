using System.Threading.Tasks;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Models;
using System.IO;

namespace WorldCup.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private async Task LoadTeamsAsync()
        {
            TeamService service = new TeamService();

            try
            {
                List<Team> teams = await service.GetTeamsAsync();

                //cmbTeams.DataSource = teams;
                //cmbTeams.DisplayMember = "country";
                //cmbTeams.ValueMember = "fifa_code";

                //MessageBox.Show("Loaded teams: " + teams.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teams: " + ex.Message);
            }
        }




        private const char SEPARATOR = ',';
        private void LoadSettings()
        {
            if (!File.Exists("settings.txt"))
                return;

            string settings = File.ReadAllText("settings.txt");
            string[] parts = settings.Split(SEPARATOR);

            if (parts.Length == 2)
            {
                string championship = parts[0];
                string language = parts[1];

                if (championship == "men")
                    rbMen.Checked = true;
                else
                    rbWomen.Checked = true;

                if (language == "hr")
                    rbCroatian.Checked = true;
                else
                    rbEnglish.Checked = true;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            string selectedChampionShip = rbMen.Checked ? "men" : "women";
            string selectedLanguage = rbCroatian.Checked ? "hr" : "en";

            string settings = $"{selectedChampionShip},{selectedLanguage}";
            File.WriteAllText("settings.txt", settings);

            FavoriteForm favoriteForm = new FavoriteForm();
            favoriteForm.Show();
            this.Hide();
        }

    }
}
