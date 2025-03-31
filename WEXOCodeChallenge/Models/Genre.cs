using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    public class Genre
    {
        //So far, this class isn't used because I don't know exactly how to do what 
        //I did with the movies for the genre at well.
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

    }
}
