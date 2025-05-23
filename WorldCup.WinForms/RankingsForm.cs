using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.Services;

namespace WorldCup.WinForms
{
    public partial class RankingsForm : Form
    {
        public RankingsForm()
        {
            InitializeComponent();
        }

        private async void RankingsForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists("favorite.txt"))
                return;

            string fifaCode = File.ReadAllText("favorite.txt").Trim();
            File.WriteAllText("config.txt", "json");

            MatchService service = new MatchService();
            List<Match> matches = await service.GetMatchesForTeamAsync("men", fifaCode);

            // Golovi 
            Dictionary<string, int> goals = new Dictionary<string, int>();

            foreach (Match match in matches)
            {
                // ode san tija da se prikazuju golovi i ako nije moj home team ali ne radi mi :(
                List<MatchEvent> events = new List<MatchEvent>();

                if (match.HomeTeam.Code == fifaCode)
                    events.AddRange(match.HomeTeamEvents);

                if (match.AwayTeam.Code == fifaCode)
                    events.AddRange(match.AwayTeamEvents);

                foreach (MatchEvent ev in events)
                {
                    if (ev.TypeOfEvent == "goals")
                    {
                        if (!goals.ContainsKey(ev.Player))
                            goals[ev.Player] = 0;

                        goals[ev.Player]++;
                    }
                }
            }

            // Zuti
            Dictionary<string, int> cards = new Dictionary<string, int>();

            foreach (Match match in matches)
            {
                List<MatchEvent> events = match.HomeTeam.Code == fifaCode
                    ? match.HomeTeamEvents : match.AwayTeamEvents;

                foreach (MatchEvent ev in events)
                {
                    if (ev.TypeOfEvent == "yellow-card")
                    {
                        if (!cards.ContainsKey(ev.Player))
                            cards[ev.Player] = 0;

                        cards[ev.Player]++;
                    }
                }
            }

            foreach (var player in cards)
            {
                lstYellowCards.Items.Add(player.Key + " - " + player.Value + " cards");
            }

            // Posjetitelji
            foreach (Match match in matches)
            {
                int num;
                if (int.TryParse(match.Attendance, out num))
                {
                    string info = match.Location + " - " + match.Attendance + " people";
                    info += " (" + match.HomeTeam.Country + " vs " + match.AwayTeam.Country + ")";
                    lstAttendance.Items.Add(info);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();

            lines.Add("Top Scorers:");
            foreach (var item in lstTopScorers.Items)
            {
                lines.Add(item.ToString());
            }

            lines.Add("");
            lines.Add("Most Yellow Cards:");
            foreach (var item in lstYellowCards.Items)
            {
                lines.Add(item.ToString());
            }

            File.WriteAllLines("rankings.txt", lines);
            MessageBox.Show("Exported to rankings.txt!");
        }
    }
}
