using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    public class GenreResponse
    {
        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }
    }
}
