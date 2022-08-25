using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace MovieWebAppAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCast(int id)
        {
            var cast = await _castService.GetAllCastAsync(id);

            if (cast != null)
            {
                return Ok(cast);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
