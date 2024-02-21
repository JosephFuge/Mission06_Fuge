using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Fuge.Models;
using System.Reflection;

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

        // Save the movie to the database
        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
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

            // Only save movie to database if the form inputs are valid
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
            ViewBag.MovieSuccess = true;
            
            return View("AddMovie");
        }


        [HttpGet]
        public IActionResult MovieList()
        {
            var movieList = _context.Movies.Include("Category").OrderBy(mov => mov.Title).ToList();

            return View(movieList);
        }

        [HttpGet]
        public IActionResult EditMovie(int movieId)
        {
            ViewBag.CategoryList = _context.Categories.OrderBy(cat => cat.CategoryId).ToList();
            ViewBag.IsEditing = true;

            var editMovie = _context.Movies.Single(mov => mov.MovieId == movieId);

            return View("AddMovie", editMovie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            // Replace LentTo and Notes with empty strings if they are null values
            if (movie.LentTo == null)
            {
                movie.LentTo = "";
            }

            if (movie.Notes == null)
            {
                movie.Notes = "";
            }

            // Only save changes to database if the form inputs are valid
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges(true);
                return RedirectToAction("MovieList");
            }
            
            return View("AddMovie", new Movie());
        }

        [HttpGet]
        public IActionResult DeleteMovie(int movieId)
        {
            var recordToDelete = _context.Movies.Single(mov => mov.MovieId == movieId);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
