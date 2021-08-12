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
