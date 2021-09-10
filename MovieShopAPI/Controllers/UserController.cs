using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> PurchaseMovie([FromBody] PurchaseRequestModel model)
        {
            var purchase = await _userService.PurchaseMovie(model);
            if (purchase == null)
            {
                return BadRequest("Purchase Failed");
            }
            return Ok(purchase);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> FavoriteMovie([FromBody] FavoriteRequestModel model)
        {
            var favorite = await _userService.FavoriteMovie(model);
            if(favorite == null)
            {
                return BadRequest("Favorite Failed");
            }
            return Ok(favorite);
        }

        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> UnfavoriteMovie([FromBody] UnfavoriteModel model)
        {
            var unfavorite = await _userService.UnfavoriteMovie(model);
            if(unfavorite == null)
            {
                return BadRequest("Unfavorite Failed");
            }
            return Ok(unfavorite);
        }

        [HttpGet]
        [Route("{id:int}/movie/{movieId:int}/favorite")]
        public async Task<IActionResult> GetFavoriteMovieDetails(int id, int movieId)
        {
            var movieDetails = await _userService.GetFavoriteMovieDetails(id, movieId);
            if(movieDetails == null)
            {
                return NotFound("No Movie Details Found");
            }
            return Ok(movieDetails);
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> WriteReview([FromBody] ReviewRequestModel model)
        {
            var review = await _userService.WriteReview(model);
            if(review == null)
            {
                return BadRequest("Write Review Failed");
            }
            return Ok(review);
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewRequestModel model)
        {
            var review = await _userService.UpdateReview(model);
            if(review == null)
            {
                return BadRequest("Update Review Failed");
            }
            return Ok(review);
        }

        [HttpDelete]
        [Route("{userId:int}/movie/{movieId:int}")]
        public async Task<IActionResult> DeleteReview(int userId, int movieId)
        {
            var review = await _userService.DeleteReview(userId, movieId);
            if(review == null)
            {
                return BadRequest("Delete Review Failed");
            }
            return Ok(review);
        }

        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetAllPurchases(int id)
        {
            var movies = await _userService.GetPurchaseMovies(id);
            if(movies == null)
            {
                return NotFound("No Movie Found");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetAllFavorites(int id)
        {
            var movies = await _userService.GetFavoriteMovies(id);
            if (movies == null)
            {
                return NotFound("No Movie Found");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetAllReviews(int id)
        {
            var reviews = await _userService.GetReviews(id);
            if (reviews == null)
            {
                return NotFound("No Review Found");
            }
            return Ok(reviews);
        }

    }
}
