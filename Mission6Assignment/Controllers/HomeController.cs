using Microsoft.AspNetCore.Mvc;
using Mission06_Croft.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Mission06_Croft.Controllers
{
    public class HomeController : Controller
    {
        private AddMovieContext _context;
        public HomeController(AddMovieContext temp) //Constructor
        {
            _context = temp;
        }

        // Home Page
        public IActionResult Index()
        {
            return View();
        }

        // Get to know you page
        public IActionResult GetToKnow()
        {
            return View();
        }

        // View to add movie
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", new Movie());
        }


        // Posting movie details to database
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }

            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }


        }

        public IActionResult Collection()
        {
            var movies = _context.Movies
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
           var recordToEdit = _context.Movies
               .Single(x => x.MovieId == id);

           ViewBag.Categories = _context.Categories
               .OrderBy(x => x.CategoryName)
               .ToList();

           return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }

    }
}
