using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Repositories;
using ApplicationCore.Contracts.Services;

namespace MovieWebAppAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;

        }


        [HttpGet]
        [Route("")]
        // http://localhost:73434/api/movies?pagesize=30&page=2&title=ave
        public async Task<IActionResult> GetMoviesByPagination([FromQuery] int pageSize = 30, [FromQuery] int page = 1, string title = "")
        {
            var movies = await _movieService.GetMoviesByPaginationAsync(pageSize, page, title);
            if (movies == null || movies.Count == 0)
            {
                return NotFound($"no movies found for your search term {title}");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            //throw new Exception("some error has occured");
            var movies = await _movieService.GetTop30GrossingMoviesAsync();

            if (!movies.Any())
            {
                return NotFound();
            }

            return Ok(movies);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsAsync(id);

            if (movie == null)
                return NotFound();
            return Ok(movie);
        }
        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetTop30GRatedMoviesAsync();

            if (!movies.Any() || movies.Count == 0)
            {
                return NotFound();
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("genre/{id:int}")]
        public async Task<IActionResult> GetMovieByGenreId(int id)
        {
            var genreMovies = await _movieService.MoviesSameGenreAsync(id);

            if (!genreMovies.Any())
            {
                return NotFound();
            }
            return Ok(genreMovies);
        }
    }
}
