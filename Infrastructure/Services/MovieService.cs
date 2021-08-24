using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCardResponseModel>> GetAllMovies()
        {
            var movies = await _movieRepository.ListAllAsync();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;
        }

        public async Task<List<MovieReviewResponseModel>> GetAllReviews(int id)
        {
            var reviews = await _movieRepository.GetAllReviewsByMovieId(id);
            var movieReviewModel = new List<MovieReviewResponseModel>();
            foreach (var review in reviews)
            {
                movieReviewModel.Add(new MovieReviewResponseModel { Rating = review.Rating, ReviewText = review.ReviewText });
            }
            return movieReviewModel;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieDetailsModel = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                OriginalLanguage = movie.OriginalLanguage,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
                Rating = movie.Rating
            };

            movieDetailsModel.Casts = new List<CastResponseModel>();

            foreach (var cast in movie.MovieCasts)
            {
                movieDetailsModel.Casts.Add(new CastResponseModel 
                { 
                    Id = cast.CastId, 
                    Name = cast.Cast.Name, 
                    Character = cast.Character, 
                    Gender = cast.Cast.Gender, 
                    ProfilePath = cast.Cast.ProfilePath 
                });
            }

            movieDetailsModel.Genres = new List<GenreResponseModel>();
            foreach (var genre in movie.Genres)
            {
                movieDetailsModel.Genres.Add(new GenreResponseModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            return movieDetailsModel;

        }

        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.Get30HighestRatedMovies();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.Get30HighestRevenueMovies();
            var moviecards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                moviecards.Add(new MovieCardResponseModel { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }
            return moviecards;
        }
    }
}
