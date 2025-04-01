using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    public class Genre
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public override string? ToString()
        {
            return Name + " ";
        }
    }
}
