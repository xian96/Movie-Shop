﻿using MovieShop.Core.Models;
using MovieShop.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface ICastService
    {
        Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id);
    } 
}
