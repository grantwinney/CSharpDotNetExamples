using System.Text.Json.Serialization;

namespace SwitchPatternMatchingVsIfElse
{
    public class IssResponse
    {
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("iss_position")]
        public IssPosition Position { get; set; }
    }

    public class IssPosition
    {
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
    }
}
