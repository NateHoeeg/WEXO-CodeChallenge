using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    public class Genre
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

    }
}
