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
    public class FavoriteRepository : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Favorite> GetFavoriteMovieDetails(int userId, int movieId)
        {
            return await _dbContext.Favorites.Include(f => f.Movie).Where(f => f.MovieId == movieId && f.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
