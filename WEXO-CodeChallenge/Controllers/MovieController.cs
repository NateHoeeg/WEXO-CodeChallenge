using Microsoft.AspNetCore.Mvc;

namespace WEXO_CodeChallenge.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/Movies")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService tmdbService)
        {
            _movieService = tmdbService;
        }

        [HttpGet("auth")]
        public async Task<IActionResult> GetAuth()
        {
            var result = await _movieService.GetAuthenticationAsync();
            return Ok(result);
        }
    }
}
