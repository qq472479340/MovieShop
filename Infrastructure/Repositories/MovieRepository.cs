using ApplicationCore.Entities;
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

        public async Task<IEnumerable<Movie>> Get30HighestRevenueMovies()
        {
            return await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
        }
    }
}
