using System.Text.Json.Serialization;

namespace WorldCup.DataLayer.Models
{
    public class Player
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("captain")]
        public bool Captain { get; set; }

        public override string ToString()
        {
            string info = $"#{ShirtNumber} {Name} - {Position}";
            if (Captain)
            {
                info += " (Captain)";
            }

            return info;
        }
    }
}
