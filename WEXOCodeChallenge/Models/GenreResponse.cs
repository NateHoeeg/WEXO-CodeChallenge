using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    //Class to make the genres from the response gotten through the API
    public class GenreResponse
    {
        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }
    }
}
