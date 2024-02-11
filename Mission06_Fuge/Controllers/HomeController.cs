using Microsoft.AspNetCore.Mvc;
using Mission06_Fuge.Models;
//using System.Diagnostics;

namespace Mission06_Fuge.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                return View(newMovie);
            }

            return View();
        }
    }
}
