using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    public class MovieResponse
    {
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }
    }
}
