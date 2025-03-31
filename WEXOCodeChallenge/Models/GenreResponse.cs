using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    public class GenreResponse
    {
        [JsonPropertyName("results")]
        public List<Genre> Results { get; set; }
    }
}
