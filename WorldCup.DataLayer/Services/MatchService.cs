using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WorldCup.DataLayer.Configuration;
using WorldCup.DataLayer.Models;

namespace WorldCup.DataLayer.Services
{
    public class MatchService
    {
        private string menApiUrl = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";
        private string womenApiUrl = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";
        private string menJsonPath = "Data/Men/matches.json";
        private string womenJsonPath = "Data/Women/matches.json";

        public async Task<List<Match>> GetMatchesForTeamAsync(string championship, string fifaCode)
        {
            var source = ConfigManager.GetDataSource();

            if (source == DataSourceType.Json)
            {
                string path = championship == "men" ? menJsonPath : womenJsonPath;

                // puca mi u throw new... liniji kad runan WorldCup.WPF -> (vidi poslje)
                if (!File.Exists(path))
                    throw new FileNotFoundException($"JSON file not found: {path}");

                string json = await File.ReadAllTextAsync(path);
                var allMatches = JsonSerializer.Deserialize<List<Match>>(json);

                List<Match> filtered = new List<Match>();

                //// ovo ne valja ----> valja sad :), vidi oce tribat minjat ista :|
                foreach (Match match in allMatches)
                {
                    if (match.HomeTeam == null || match.AwayTeam == null)
                        continue;

                    if (match.HomeTeam.Code == fifaCode || match.AwayTeam.Code == fifaCode)
                    {
                        filtered.Add(match);
                    }
                }

                return filtered;
            }
            else
            {
                using HttpClient client = new HttpClient();
                string url = (championship == "men" ? menApiUrl : womenApiUrl) + fifaCode;
                string json = await client.GetStringAsync(url);
                return JsonSerializer.Deserialize<List<Match>>(json);
            }
        }
    }
}
