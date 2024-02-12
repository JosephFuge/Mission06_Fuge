using Microsoft.AspNetCore.Mvc;
using Mission06_Fuge.Models;
//using System.Diagnostics;

namespace Mission06_Fuge.Controllers
{
    public class HomeController : Controller
    {
        private MoviesCollectionContext _context;

        public HomeController(MoviesCollectionContext tempContext) { 
            _context = tempContext;
        }

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
            if (newMovie.LentTo == null)
            {
                newMovie.LentTo = "";
            }
            
            if (newMovie.Notes == null)
            {
                newMovie.Notes = "";
            }

            if (newMovie.SubCategory == null)
            {
                newMovie.SubCategory = "";
            }


            if (ModelState.IsValid)
            {
                _context.Movies.Add(newMovie);
                _context.SaveChanges();
                return View(newMovie);
            }

            return View();
        }
    }
}
