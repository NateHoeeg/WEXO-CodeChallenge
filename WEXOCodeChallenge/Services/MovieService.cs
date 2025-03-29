using System.Text.Json;
using WEXOCodeChallenge.Models;

namespace WEXOCodeChallenge{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://api.themoviedb.org/3/authentication";
        private const string ApiKey = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJlYjVmYWIxYmI4" +
            "NWFhODFiY2VmZDMyYzJkMGZmYzIyNCIsIm5iZiI6MTc0MzA4MTYxOS4wNDksInN1YiI6IjY" +
            "3ZTU1MDkzMzNhNzQzNDFlMzEwYTNlZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW" +
            "9uIjoxfQ.LWd88oUbV5NzEsqim_G-c6EIsrP-bVJSYsfWK9P3TJQ";

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

            //Log the raw response (remove this in production)
            Console.WriteLine("Raw API Response: " + response);

            try
            {
                var movieResponse = JsonSerializer.Deserialize<MovieResponse>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return movieResponse?.Results ?? new List<Movie>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deserialization Error: " + ex.Message);
                return new List<Movie>(); // Return an empty list to prevent null errors
            }
        }


    }
}
