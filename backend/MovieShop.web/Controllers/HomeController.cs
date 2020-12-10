using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            /*var movies = await _movieService.GetHighestGrossingMovies();
            return View(movies);*/

            /*
            using when adding more information
            var testdata = "list of movies";
            ViewBag.myproperty = testdata;*/

            var topGrossingMovies = await _movieService.GetHighestGrossingMovies();
            return View(topGrossingMovies);

            /*
             pass the data from controller to view
            viewbag, viewedata.
            strongly typed models
             */
            //controller will call sercvices ==>> repositories

            //navigation ==> list of genres as a dropdown
            //showing top 20 higest revenus movies as movie cards .. with images
            // card in bootstrap, card image , movieid title
            //entity has all the abouve
            //models based on your ui/api requirement
            //
            /*
            
            models/viewmodels in mvc
            dto data transfer object in api
            we create

             */
        }

/*        public async Task<IActionResult> Detail(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            return View(movie);
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
