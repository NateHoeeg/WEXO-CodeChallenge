using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    //Class to make the movies from the response gotten through the API
    public class MovieResponse
    {
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }
    }
}
