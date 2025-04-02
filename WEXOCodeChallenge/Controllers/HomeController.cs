using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEXOCodeChallenge.Models;

namespace WEXOCodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        //Main (and only for now) controller for this service. 
        //This controller is responsible for the main page and the genre pages
        //The methods to get the information from the API are in the MovieService class
        private readonly MovieService _movieService;

        public HomeController(MovieService movieService)
        {
            _movieService = movieService;
        }

        //Gets the trending movies for the front page
        public async Task<IActionResult> TrendingMovies()
        {
            List<Movie> movies = await _movieService.GetTrendingMoviesAsync();
            return View("index", movies);
        }

        //Gets the movies by genre for the genre pages
        public async Task<IActionResult> GetMoviesByGenre([FromQuery(Name = "genre")] string genre)
        {
            //Viewbag to pass the genre to the view
            ViewBag.Genre = genre;
            //Get the movies in the wanted genre
            List<Movie> movies = await _movieService.GetMoviesByGenreAsync(genre);
            return View("MovieLists", movies);
        }

        //Gets the details for one specific movie using the movie Id
        public async Task<IActionResult> GetMovieDetails(int movieId)
        {
            Movie specificMovie = await _movieService.GetMovieDetailsAsync(movieId + "");
            return View("MovieInfo", specificMovie);
        }
    }
}
