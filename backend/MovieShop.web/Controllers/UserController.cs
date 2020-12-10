using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.web.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail(int userId)
        {
            return View();
        }

    }
}
