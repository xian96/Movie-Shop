using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
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
        public async Task<IActionResult> CastInfo(int id)
        {
            var castDetailsResponseModel = await _castService.GetCastDetailsWithMovies(id);
            if (castDetailsResponseModel == null)
            {
                return NotFound("no user Found");
            }
            return Ok(castDetailsResponseModel);
        }
    }
}
