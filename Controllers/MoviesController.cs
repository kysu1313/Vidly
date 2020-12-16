using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
            var movies = _context.Movies;
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model

            // Try not to use these methods to pass objects to view.
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            //return View(movie);
            //return Content("Hello World");
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            return View(viewModel);
        }

        // Using custom route
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        /**
         * Return the details of a movie.
         */
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("Details", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            movie.Genre = _context.Genres.Find(movie.GenreId);
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("Details", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                // This method to update customer has issues because it uses magic strings.
                //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" });

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return View(movies);
        }
    }
}