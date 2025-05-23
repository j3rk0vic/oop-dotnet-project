using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorldCup.DataLayer.Models
{
    public class MatchEvent
    {
        [JsonPropertyName("type_of_event")]
        public string TypeOfEvent { get; set; }

        [JsonPropertyName("player")]
        public string Player {  get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }
    }
}
