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
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserFavoriteById(int id)
        {
            return await _dbContext.Users.Include(u => u.Favorites).ThenInclude(u => u.Movie).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserPurchaseById(int id)
        {
            return await _dbContext.Users.Include(u => u.Purchases).ThenInclude(u => u.Movie).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
