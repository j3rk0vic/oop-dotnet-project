using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WorldCup.DataLayer.Configuration;
using WorldCup.DataLayer.Models;

namespace WorldCup.DataLayer
{
    public class TeamService
    {
        private string apiUrl = "https://worldcup-vua.nullbit.hr/men/teams/results";
        private string jsonPath = "data/Men/teams.json";

        public async Task<List<Team>> GetTeamsAsync()
        {
            string source = ConfigManager.GetDataSource().ToString();

            if (source == "Json")
            {
                if (!File.Exists(jsonPath))
                    throw new FileNotFoundException("JSON file not found.");

                string json = File.ReadAllText(jsonPath);
                return JsonSerializer.Deserialize<List<Team>>(json);
            }
            else
            {
                using HttpClient client = new HttpClient();
                string api = await client.GetStringAsync(apiUrl);
                return JsonSerializer.Deserialize<List<Team>>(api);
            }
        }
    }
}