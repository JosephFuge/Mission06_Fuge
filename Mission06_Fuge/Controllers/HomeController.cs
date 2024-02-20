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
            ViewBag.CategoryList = _context.Categories.OrderBy(cat => cat.CategoryId).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movies newMovie)
        {
            ViewBag.CategoryList = _context.Categories.OrderBy(cat => cat.CategoryId).ToList();

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
                return RedirectToAction("AddMovieForm");
            } else
            {
                return View(newMovie);
            }            
        }

        // This action returns a view with a new, empty Movie model to clear the form inputs
        public ActionResult AddMovieForm()
        {
            ViewBag.CategoryList = _context.Categories.OrderBy(cat => cat.CategoryId).ToList();
            
            return View("AddMovie");
        }


        [HttpGet]
        public IActionResult MovieList()
        {
            ViewBag.CategoryList = _context.Categories.OrderBy(cat => cat.CategoryId).ToList();

            var movieList = _context.Movies.OrderBy(mov => mov.Title).ToList();

            return View(movieList);
        }

        [HttpGet]
        public IActionResult EditMovie(int movieId)
        {
            ViewBag.CategoryList = _context.Categories.OrderBy(cat => cat.CategoryId).ToList();

            var editMovie = _context.Movies.Single(mov => mov.MovieId == movieId);

            return View("AddMovie", editMovie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movies movie)
        {
            if (movie.LentTo == null)
            {
                movie.LentTo = "";
            }

            if (movie.Notes == null)
            {
                movie.Notes = "";
            }


            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges(true);
                return RedirectToAction("MovieList");
            }
            
            return View("AddMovie", new Movies());
        }
    }
}
