using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.Models;
using ApplicationCore.Contracts.Services;

namespace MovieWebAppMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.CompanyName = "Antra";
            ViewData["CurrentDate"] = DateTime.Now;
            var data = await _castService.GetAllCastAsyncAll();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CastResponseModel model)
        {
            if (ModelState.IsValid)
            {
                await _castService.InsertCastAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _castService.DeleteCastAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
