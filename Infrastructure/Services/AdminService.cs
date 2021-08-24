using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AdminService: IAdminService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        public AdminService(IMovieRepository movieRepository, IPurchaseRepository purchaseRepository)
        {
            _movieRepository = movieRepository;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Movie> CreateMovie(MovieCreateRequestModel model)
        {
            var dateTime = DateTime.Now;
            var movie = new Movie
            {
                Title = model.Title,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                PosterUrl = model.PosterUrl,
                BackdropUrl = model.BackdropUrl,
                OriginalLanguage = model.OriginalLanguage,
                ReleaseDate = model.ReleaseDate,
                RunTime = model.RunTime,
                Price = model.Price,
                CreatedDate = dateTime,
                UpdatedDate = dateTime,
            };
            
            var createdMovie = await _movieRepository.AddAsync(movie);

            return createdMovie;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            return await _purchaseRepository.ListAllAsync();
        }

        public async Task<Movie> UpdateMovie(MovieCreateRequestModel model)
        {
            var exist = await _movieRepository.GetExistsAsync(m => m.Id == model.Id);
            if (!exist)
            {
                throw new Exception($"No movie found for id = {model.Id}");
            }
            var dateTime = DateTime.Now;
            var movie = new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                PosterUrl = model.PosterUrl,
                BackdropUrl = model.BackdropUrl,
                OriginalLanguage = model.OriginalLanguage,
                ReleaseDate = model.ReleaseDate,
                RunTime = model.RunTime,
                Price = model.Price,
                UpdatedDate = dateTime,
            };
            var updatedMovie = await _movieRepository.UpdateAsync(movie);
            return updatedMovie;
        }
    }
}
