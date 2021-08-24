using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel model);
        Task<UserLoginResponseModel> Login(LoginRequestModel model);
        Task<IEnumerable<MovieCardResponseModel>> GetPurchaseMovies(int userId);
        Task<IEnumerable<MovieCardResponseModel>> GetFavoriteMovies(int userId);
        Task<User> GetUserById(int userId);
        Task<PurchaseResponseModel> PurchaseMovie(PurchaseRequestModel model);
        Task<FavoriteResponseModel> FavoriteMovie(FavoriteRequestModel model);
        Task<UnfavoriteModel> UnfavoriteMovie(UnfavoriteModel model);
        Task<MovieDetailsResponseModel> GetFavoriteMovieDetails(int userId, int movieId);
        Task<ReviewRequestModel> WriteReview(ReviewRequestModel model);
        Task<ReviewRequestModel> UpdateReview(ReviewRequestModel model);
        Task<ReviewRequestModel> DeleteReview(int userId, int movieId);
        Task<IEnumerable<Review>> GetReviews(int userId);
    }
}
