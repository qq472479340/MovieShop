using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IFavoriteRepository: IAsyncRepository<Favorite>
    {
        Task<Favorite> GetFavoriteMovieDetails(int userId, int movieId);
    }
}
