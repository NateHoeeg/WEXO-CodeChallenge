using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEXOCodeChallenge.Models;

namespace WEXOCodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieService _movieService;

        public HomeController(MovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var authData = await _movieService.GetAuthenticationAsync();
            return View("Index", authData);  // Pass data to a View
        }

        public async Task<IActionResult> TrendingMovies()
        {
            List<Movie> movies = await _movieService.GetTrendingMoviesAsync();
            return View(movies);
        }
    }
}
