﻿using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases(int pageSize = 30, int pageIndex = 0)
        {
            //TODO: need to be correct;
            //get the purchased movie order by time
            /*            var movies = await _dbContext.Purchases
                                        .Skip(pageIndex * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();*/
            var purchases = await _dbContext.Purchases.Include(m => m.Movie).OrderByDescending(p => p.PurchaseDateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return purchases;
        }


        public async Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30, int pageIndex = 0)
        {
            /*            var purchases = await _dbContext.Purchases.Where(p => p.MovieId == movieId).Include(m => m.Movie).Include(m => m.Customer)
                                                   .OrderByDescending(p => p.PurchaseDateTime)
                                                   .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                        return purchases;*/
            return null;
        }
    }
}
