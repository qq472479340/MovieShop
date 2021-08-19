using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMemoryCache _memoryCache;
        public GenreService(IGenreRepository genreRepository, IMemoryCache memoryCache)
        {
            _genreRepository = genreRepository;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
        {
            var genres = await _memoryCache.GetOrCreateAsync("genresData", async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(30);
                return await _genreRepository.ListAllAsync();
            });
            var genresModel = new List<GenreResponseModel>();
            foreach (var genre in genres)
            {
                genresModel.Add(new GenreResponseModel { Id = genre.Id, Name = genre.Name });
            }
            return genresModel;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetAllMovies(int id)
        {
            var genre = await _genreRepository.GetMoviesByGenreId(id);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in genre.Movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }
    }
}
