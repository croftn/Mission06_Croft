using Microsoft.AspNetCore.Mvc;
using Mission06_Croft.Models;
using System.Diagnostics;

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
        public IActionResult AddMovie()
        {
            return View();
        }

        // Posting movie details to database
        [HttpPost]
        public IActionResult AddMovie(AddMovieForm response)
        {
            _context.Movies.Add(response); //Add record to the database
            _context.SaveChanges();

            return View("Confirmation", response);
        }



    }
}
