using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IAdminService
    {
        Task<Movie> CreateMovie(MovieCreateRequestModel model);
        Task<Movie> UpdateMovie(MovieCreateRequestModel model);
        Task<IEnumerable<Purchase>> GetAllPurchases();
    }
}
