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
    //attribute based routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies([FromQuery] int pageSize = 30, [FromQuery] int page = 1,
            string title = "")
        {
            var movies = await _movieService.GetMoviesByPagination(pageSize, page, title);
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopreatedMovie(int id)
        {
            var movies = await _movieService.GetTopRatedMovies();
            return Ok(movies);
        }

        ///api/movies/toprevenue
        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            // call our service and call the method
            // var movies = _movieService.GetTopMovies();
            // http status code
            var movies = await _movieService.GetHighestGrossingMovies();
            if (!movies.Any())
            {
                return NotFound("no Movies Found");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMovieByGenreId(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId);
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var reviews = await _movieService.GetReviewsForMovie(id);
            return Ok(reviews);
        }
    }
}
