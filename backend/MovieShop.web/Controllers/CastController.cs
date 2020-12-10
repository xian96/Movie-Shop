using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.web.Controllers
{
    public class CastController : Controller
    {
        public IActionResult Details(int castId)
        {
            return View();
        }
    }
}
