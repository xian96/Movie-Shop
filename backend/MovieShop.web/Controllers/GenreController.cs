﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.web.Controllers
{
    public class GenreController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
