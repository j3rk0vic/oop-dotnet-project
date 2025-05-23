using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WorldCup.DataLayer.Models
{
    public class Match
    {
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("attendance")]
        public string Attendance { get; set; }

        [JsonPropertyName("home_team")]
        public TeamInfo HomeTeam { get; set; }

        [JsonPropertyName("away_team")]
        public TeamInfo AwayTeam { get; set; }

        [JsonPropertyName("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonPropertyName("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

        [JsonPropertyName("home_team_events")]
        public List<MatchEvent> HomeTeamEvents { get; set; }

        [JsonPropertyName("away_team_events")]
        public List<MatchEvent> AwayTeamEvents { get; set; }
    }

    public class TeamInfo
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("goals")]
        public int Goals { get; set; }

        [JsonPropertyName("penalties")]
        public int Penalties { get; set; }
    }

    public class TeamStatistics
    {
        [JsonPropertyName("starting_eleven")]
        public List<Player> StartingEleven { get; set; }

        [JsonPropertyName("substitutes")]
        public List<Player> Substitutes { get; set; }
    }
}
