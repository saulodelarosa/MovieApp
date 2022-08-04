using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.Models;
using ApplicationCore.Contracts.Services;

namespace MovieWebAppMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.CompanyName = "Antra";
            ViewData["CurrentDate"] = DateTime.Now;
            var data = await _genreService.GetAllGenresAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreModel model)
        {
            if (ModelState.IsValid)
            {
                await _genreService.InsertGenreAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _genreService.DeleteGenreAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
