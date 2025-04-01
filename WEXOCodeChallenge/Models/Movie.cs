using System.Text.Json.Serialization;

namespace WEXOCodeChallenge.Models
{
    //Class to make movies so they can be shown in the view
    //For now it doesn't include information about actors and directors,
    //because I couldn't find out how to get that information from the API,
    //and there are other things I want to focus on first.
    public class Movie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonPropertyName("genre_ids")]
        public List<int> GenresIds { get; set; }
        public List<Genre> Genres { get; internal set; }

    }
}

