namespace WEXO_CodeChallenge
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAuthenticationAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.themoviedb.org/3/authentication"),
                Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJlYjVmYWIxYmI4NWFhODFiY2VmZD" +
                "MyYzJkMGZmYzIyNCIsIm5iZiI6MTc0MzA4MTYxOS4wNDksInN1YiI6IjY3ZTU1MDkzMzNhNzQzNDFlMzEwYTN" +
                "lZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.LWd88oUbV5NzEsqim_G-c6EIsrP-bVJSYs" +
                "fWK9P3TJQ" },
            },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
