using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace MovieWebAppAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;
        public GenreController(IGenreService gen)
        {
            genreService = gen;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll()
        {
            var data = await genreService.GetAllGenresAsync();
            if (data == null)
            {
                return NotFound("No Genre available");
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Post(GenreModel model)
        {
            if (await genreService.InsertGenreAsync(model) > 0)
                return Ok(model);
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new { Message = "deleted" };
            if (await genreService.DeleteGenreAsync(id) > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(GenreModel m)
        {
            var response = new { Message = "Genre is updated" };
            if (await genreService.UpdateGenreAsync(m) > 0)
                return Ok(response);
            return NoContent();
        }
    }
}
