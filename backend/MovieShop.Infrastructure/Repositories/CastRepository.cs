using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cast> GetCastDetailsWithMovies(int id)
        {
            //TODO:
            /*            var casts = await _dbContext.Casts
                                        .FindAsync(c => c.id == id);*/
            var cast = await _dbContext.Casts.Where(c => c.Id == id).Include(c => c.MovieCasts)
                                       .ThenInclude(c => c.Movie).FirstOrDefaultAsync();
            return cast;
        }

    }
}
