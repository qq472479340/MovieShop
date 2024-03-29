﻿using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<Movie>> Get30HighestRatedMovies()
        {
            return await _dbContext.Reviews.Include(r => r.Movie)
                .GroupBy(r => new { r.Movie.Id, r.Movie.PosterUrl, r.Movie.Title })
                .OrderByDescending(o => o.Average(r => r.Rating))
                .Select(m => new Movie { Id = m.Key.Id, PosterUrl = m.Key.PosterUrl, Title = m.Key.Title })
                .Take(30).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> Get30HighestRevenueMovies()
        {
            return await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetAllReviewsByMovieId(int id)
        {
            return await _dbContext.Reviews.Where(r => r.MovieId == id).ToListAsync();
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);
            if(movie == null)
            {
                throw new Exception($"No Movie Found for the id {id}");
            }

            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == id).DefaultIfEmpty().AverageAsync(r => r == null ? 0 : r.Rating);

            movie.Rating = movieRating;
            return movie;

        }

    }
}
