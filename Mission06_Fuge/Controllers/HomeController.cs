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


            if (ModelState.IsValid)
            {
                _context.Movies.Add(newMovie);
                _context.SaveChanges();
                return View(newMovie);
            }
            else
            {
                // Log validation errors
                foreach (var key in ModelState.Keys)
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        var errorMessage = error.ErrorMessage;
                        // Log or handle the error message as needed
                        Console.WriteLine($"Validation error for property '{key}': {errorMessage}");
                    }
                }

                // If ModelState is not valid, return the same view with validation errors
                ViewBag.IsValid = false; // Setting a flag to indicate model state validity
                return View();
            }

            //return View();
        }
    }
}
