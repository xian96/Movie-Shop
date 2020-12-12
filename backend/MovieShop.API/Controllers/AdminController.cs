using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IPurchaseService _purchaseService;

        public AdminController(IMovieService movieService, IPurchaseService purchaseServcie)
        {
            _movieService = movieService;
            _purchaseService = purchaseServcie;
        }

        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> CreateMovie(MovieCreateRequest movieCreateRequest)
        {
            // call our service and call the method
            // var movies = _movieService.GetTopMovies();
            // http status code
            if (ModelState.IsValid)
            {
                var moviesDetailResponse = await _movieService.CreateMovie(movieCreateRequest);
                //TODO: should catch exception here
                return Ok(moviesDetailResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie(MovieCreateRequest movieCreateRequest)
        {
            // call our service and call the method
            // var movies = _movieService.GetTopMovies();
            // http status code
            if (ModelState.IsValid)
            {
                var moviesDetailResponse = await _movieService.UpdateMovie(movieCreateRequest);
                //TODO: should catch exception here
                return Ok(moviesDetailResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpGet]
        [Route("purchases")]
        //[Route("purchases/{pageSize?:int}{pageNumber?:int}")]
        public async Task<IActionResult> GetAllPurchases(int pageSize = 30, int page = 1)
        {
            var movies = await _movieService.GetAllMoviePurchasesByPagination(pageSize, page);
            //TODO: should catch exception here
            return Ok(movies);

            //return BadRequest(new { message = "please correct the input information" });
        }

        [HttpGet]
        [Route("top")]
        //[Route("purchases/{pageSize?:int}{pageNumber?:int}")]
        public async Task<IActionResult> GetTopMovies()
        {
            /*            
             *            var movies = _cache.Get<IEnumerable<MovieChartResponseModel>>("chartsData");
            return Ok(movies);
            */

            
            return BadRequest(new { message = "//TODO: not correctly implemented!" });
        }

        [HttpGet("push/{data}")]
        public async Task<IActionResult> PushNotification(string data)
        {
            /*await _hubContext.Clients.All.SendAsync("discountNotification", data);
            return Ok();*/

            return BadRequest(new { message = "TODO: PushNotification" });
        }
    }
}
