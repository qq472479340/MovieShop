﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTopRevenueMovies();
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
        Task<List<MovieCardResponseModel>> GetAllMovies();
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<List<MovieReviewResponseModel>> GetAllReviews(int id);
    }
}
