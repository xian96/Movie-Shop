using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.web.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public IActionResult Index()
        {
            return View();
        }

        // GET: MovieController/Delete/5
        public IActionResult MovieByGenre(int generId)
        {
            return View();
        }

        // GET: MovieController/Details/5
        public IActionResult Details(int movieId)
        {
            return View();
        }

    }
}
