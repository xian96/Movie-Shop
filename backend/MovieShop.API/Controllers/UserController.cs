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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> CreatePurchase(PurchaseRequestModel purchaseRequest)
        {
            await _userService.PurchaseMovie(purchaseRequest);
            return Ok();
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> CreateFavorite(FavoriteRequestModel favoriteRequest)
        {
            await _userService.AddFavorite(favoriteRequest);
            return Ok();
        }

        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> Deletefavorite(FavoriteRequestModel favoriteRequest)
        {
            return BadRequest(new { message = "TODO: unfavorite" });
        }

        [HttpGet]
        [Route("{id}/movie/{movieId}/favorite")]
        public async Task<IActionResult> IsFavoriteExists(int id, int movieId)
        {
            var favoriteExists = await _userService.FavoriteExists(id, movieId);
            return Ok(new { isFavorited = favoriteExists });
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> CreateReview(ReviewRequestModel reviewRequest)
        {
            await _userService.AddMovieReview(reviewRequest);
            return Ok();
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview(ReviewRequestModel reviewRequest)
        {
            await _userService.UpdateMovieReview(reviewRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("{userId:int}/movie/{movieId:int}")]
        public async Task<IActionResult> DeleteMovieReview(int userId, int movieId)
        {
            await _userService.DeleteMovieReview(userId, movieId);
            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetUserPurchasedMoviesAsync(int id)
        {
            var userMovies = await _userService.GetAllPurchasesForUser(id);
            return Ok(userMovies);
        }

        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetUserFavoriteMoviesAsync(int id)
        {
            var userMovies = await _userService.GetAllFavoritesForUser(id);
            return Ok(userMovies);
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetUserReviewedMoviesAsync(int id)
        {
            var reviews = _userService.GetAllReviewsByUser(id);
            return Ok(reviews);
        }
    }
}
