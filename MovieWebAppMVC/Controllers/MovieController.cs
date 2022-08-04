using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebAppMVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetMoviesByPaginationAsync(10, 1, "");
            return View(movies);
        }
        [HttpGet]
        public async Task<IActionResult> Genre(int id)
        {
            var data = await _movieService.MoviesSameGenreAsync(id);
            return View(data);
        }

        [HttpGet]
        public  async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateRequestModel model)
        {
            try
            {
               await  _movieService.AddMovieAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }


    }
}
