using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseModel>> GetAllGenres();
        Task<IEnumerable<MovieCardResponseModel>> GetAllMovies(int id);
        Task<Genre> GetGenreById(int id);
    }
}
