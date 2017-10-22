using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCore.Models;

namespace WebApplicationCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult angular(string data)
        {
            return Content(data);
        }

        [HttpPost]
        public IActionResult jquery(string data)
        {
            return Content(data);
        }

    }
}
