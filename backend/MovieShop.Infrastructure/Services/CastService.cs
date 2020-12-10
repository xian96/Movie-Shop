using MovieShop.Core.Entities;
using MovieShop.Core.Exceptions;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRespository;

        public CastService(ICastRepository castRespository)
        {
            _castRespository = castRespository;
        }

        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRespository.GetCastDetailsWithMovies(id);
            if(cast == null)
            {
                throw new NotFoundException("Cast", id);
            }

            var result = new CastDetailsResponseModel
                {
                    Id = cast.Id,
                    Name = cast.Name,
                    Gender = cast.Gender,
                    TmdbUrl = cast.TmdbUrl,
                    ProfilePath = cast.ProfilePath,
                    Movies = null

                };

            return result;

        }
    }
}
