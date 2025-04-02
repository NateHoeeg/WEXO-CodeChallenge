using System.Text.Json;
using WEXOCodeChallenge.Models;

namespace WEXOCodeChallenge{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        //API key for the movie database
        private const string ApiKey = "eb5fab1bb85aa81bcefd32c2d0ffc224";
        //Bearer token for the movie database
        private const string Bearer = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJlYjVmYWIxYmI" +
            "4NWFhODFiY2VmZDMyYzJkMGZmYzIyNCIsIm5iZiI6MTc0MzA4MTYxOS4wNDksInN1YiI6I" +
            "jY3ZTU1MDkzMzNhNzQzNDFlMzEwYTNlZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJ" +
            "zaW9uIjoxfQ.LWd88oUbV5NzEsqim_G-c6EIsrP-bVJSYsfWK9P3TJQ";

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //Get the current trending movies (for front page)
        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var requestUri = $"https://api.themoviedb.org/3/trending/movie/week?api_key={ApiKey}";
            var response = await _httpClient.GetStringAsync(requestUri);

            var movieResponse = JsonSerializer.Deserialize<MovieResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var genres = await GetGenresAsync();

            foreach (var movie in movieResponse?.Results ?? new List<Movie>())
            {
                movie.Genres = genres.Where(g => movie.GenresIds.Contains(g.Id)).ToList();
            }

            return movieResponse?.Results ?? new List<Movie>();
        }

        //Method to get movies by genre, so when you click the genre at the top of the home page,
        //you get redirected to a page with a list of movies from said genre, sorted by popularity
        public async Task<List<Movie>> GetMoviesByGenreAsync(string genre)
        {
            var requestUri = $"https://api.themoviedb.org/3/discover/movie?sort_by=popularity.desc&with_genres={genre}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri),
                Headers =
        {
            { "accept", "application/json" },
            { "Authorization", $"Bearer {Bearer}" },
        },
            };

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var movieResponse = JsonSerializer.Deserialize<MovieResponse>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            });

            var genres = await GetGenresAsync();

            foreach (var movie in movieResponse?.Results ?? new List<Movie>())
            {
                movie.Genres = genres.Where(g => movie.GenresIds.Contains(g.Id)).ToList();
            }

            return movieResponse?.Results ?? new List<Movie>();
        }


        public async Task<Movie> GetMovieDetailsAsync(string movieId)
        {
            var requestUri = $"https://api.themoviedb.org/3/movie/{movieId}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri),
                Headers =
        {
            { "accept", "application/json" },
            { "Authorization", $"Bearer {Bearer}" },
        },
            };

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            Movie movie = JsonSerializer.Deserialize<Movie>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });            

            return movie;
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            var requestUri = $"https://api.themoviedb.org/3/genre/movie/list";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri),
                Headers =
        {
            { "accept", "application/json" },
            { "Authorization", $"Bearer {Bearer}" },
        },
            };
            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var genreResponse = JsonSerializer.Deserialize<GenreResponse>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return genreResponse?.Genres ?? new List<Genre>();
        }

    }
}
