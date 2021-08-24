using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewRepository _reviewRepository;
        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewRequestModel> DeleteReview(int userId, int movieId)
        {
            var exist = await _reviewRepository.GetExistsAsync(r => r.UserId == userId && r.MovieId == movieId);
            if (!exist)
            {
                throw new Exception("This user has not written review for this movie");
            }
            var review = new Review
            {
                UserId = userId,
                MovieId = movieId,
            };
            var createdReview = await _reviewRepository.DeleteAsync(review);
            var reviewResponse = new ReviewRequestModel 
            { 
                UserId = createdReview.UserId, 
                MovieId = createdReview.MovieId, 
                ReviewText = createdReview.ReviewText, 
                Rating = createdReview.Rating 
            };
            return reviewResponse;
        }

        public async Task<FavoriteResponseModel> FavoriteMovie(FavoriteRequestModel model)
        {
            var exist = await _favoriteRepository.GetExistsAsync(f => f.MovieId == model.MovieId && f.UserId == model.UserId);
            if (exist)
            {
                throw new Exception("This user has already favorite this movie");
            }
            var favorite = new Favorite { MovieId = model.MovieId, UserId = model.UserId };
            var createdFavorite = await _favoriteRepository.AddAsync(favorite);
            var favoriteResponse = new FavoriteResponseModel { Id = createdFavorite.Id, MovieId = createdFavorite.MovieId, UserId = createdFavorite.UserId };
            return favoriteResponse;
        }

        public async Task<MovieDetailsResponseModel> GetFavoriteMovieDetails(int userId, int movieId)
        {
            var favorite = await _favoriteRepository.GetFavoriteMovieDetails(userId, movieId);
            if(favorite == null)
            {
                throw new Exception("This user did not favorite this movie");
            }
            var movieDetails = new MovieDetailsResponseModel
            {
                Id = favorite.Movie.Id,
                Title = favorite.Movie.Title,
                Overview = favorite.Movie.Overview,
                Budget = favorite.Movie.Budget,
                Revenue = favorite.Movie.Revenue,
                PosterUrl = favorite.Movie.PosterUrl,
                ReleaseDate = favorite.Movie.ReleaseDate,
                RunTime = favorite.Movie.RunTime
            };
            return movieDetails;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetFavoriteMovies(int userId)
        {
            var user = await _userRepository.GetUserFavoriteById(userId);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in user.Favorites)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PosterUrl = movie.Movie.PosterUrl
                });
            }
            return movieCards;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetPurchaseMovies(int userId)
        {
            var user = await _userRepository.GetUserPurchaseById(userId);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in user.Purchases)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PosterUrl = movie.Movie.PosterUrl
                });
            }
            return movieCards;
        }

        public async Task<IEnumerable<Review>> GetReviews(int userId)
        {
            return await _reviewRepository.GetReviewsByUserId(userId);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<UserLoginResponseModel> Login(LoginRequestModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser == null)
            {
                return null;
            }

            var hashedPassword = GetHashedPassword(model.Password, dbUser.Salt);
            if(hashedPassword == dbUser.HashedPassword)
            {
                var userLoginResponseModel = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Email = dbUser.Email
                };
                return userLoginResponseModel;
            }

            return null;

        }

        public async Task<PurchaseResponseModel> PurchaseMovie(PurchaseRequestModel model)
        {
            var exist = await _purchaseRepository.GetExistsAsync(p => p.MovieId == model.MovieId && p.UserId == model.UserId);
            if(exist)
            {
                throw new Exception("This User has already purchased this movie");
            }
            var dateTime = DateTime.Now;
            var uniqueId = Guid.NewGuid();
            var purchase = new Purchase 
            { 
                MovieId = model.MovieId, 
                PurchaseDateTime = dateTime, 
                PurchaseNumber = uniqueId, 
                TotalPrice = model.TotalPrice,
                UserId = model.UserId 
            };
            var createdPurchase = await _purchaseRepository.AddAsync(purchase);
            var purchaseResponse = new PurchaseResponseModel
            {
                Id = createdPurchase.Id,
                MovieId = createdPurchase.MovieId,
                PurchaseDateTime = createdPurchase.PurchaseDateTime,
                UserId = createdPurchase.UserId,
                PurchaseNumber = createdPurchase.PurchaseNumber,
                TotalPrice = createdPurchase.TotalPrice
            };
            return purchaseResponse;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser != null)
            {
                throw new ConflictException("Email already exists");
            }

            var salt = GenerateSalt();
            var hashedPassword = GetHashedPassword(model.Password, salt);

            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword
            };

            var createdUser = await _userRepository.AddAsync(user);

            var userRegisterResponseModel = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return userRegisterResponseModel;

        }

        public async Task<UnfavoriteModel> UnfavoriteMovie(UnfavoriteModel model)
        {
            var exist = await _favoriteRepository.GetExistsAsync(f => f.Id==model.Id);
            if (!exist)
            {
                throw new Exception("This user did not favorite this movie");
            }
            var favorite = new Favorite { Id = model.Id, MovieId = model.MovieId, UserId = model.UserId };
            var unfavorite = await _favoriteRepository.DeleteAsync(favorite);
            return model;
        }

        public async Task<ReviewRequestModel> UpdateReview(ReviewRequestModel model)
        {
            var exist = await _reviewRepository.GetExistsAsync(r => r.UserId == model.UserId && r.MovieId == model.MovieId);
            if (!exist)
            {
                throw new Exception("This user has not written review for this movie");
            }
            var review = new Review
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                ReviewText = model.ReviewText,
                Rating = model.Rating
            };
            var createdReview = await _reviewRepository.UpdateAsync(review);
            return model;
        }

        public async Task<ReviewRequestModel> WriteReview(ReviewRequestModel model)
        {
            var exist = await _reviewRepository.GetExistsAsync(r => r.UserId == model.UserId && r.MovieId == model.MovieId);
            if (exist)
            {
                throw new Exception("This user has already written review for this movie");
            }
            var review = new Review
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                ReviewText = model.ReviewText,
                Rating = model.Rating
            };
            var createdReview = await _reviewRepository.AddAsync(review);
            return model;
        }

        private string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                     password: password,
                                                                     salt: Convert.FromBase64String(salt),
                                                                     prf: KeyDerivationPrf.HMACSHA512,
                                                                     iterationCount: 10000,
                                                                     numBytesRequested: 256 / 8));
            return hashed;
        }

    }
}
