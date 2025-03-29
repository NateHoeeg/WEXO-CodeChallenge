using System.Text.Json;
using WEXOCodeChallenge.Models;

namespace WEXOCodeChallenge{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://api.themoviedb.org/3/authentication";
        private const string ApiKey = "eb5fab1bb85aa81bcefd32c2d0ffc224";

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAuthenticationAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ApiUrl);
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {ApiKey}");

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var requestUri = $"https://api.themoviedb.org/3/trending/movie/week?api_key={ApiKey}";
            var response = await _httpClient.GetStringAsync(requestUri);

            var movieResponse = JsonSerializer.Deserialize<MovieResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Handles different JSON casing
            });

            return movieResponse?.Results ?? new List<Movie>();
        }

    }
}
