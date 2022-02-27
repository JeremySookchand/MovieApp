using System.Collections.Generic;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;
using System.Linq;
using System.Data.Entity;
using System;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext _context;
        public MoviesController()
        {
            _context = new MovieContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult MovieForm()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };
            return View("Movieform", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {

                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
              
            }
            if (movie.Id == 0)
            
                _context.Movies.Add(movie);
            
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ViewResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();

            return View(movie);

        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreId = movie.GenreId,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
      
        //  private IEnumerable<Movie> GetMovies()
        //    {
        //      return new List<Movie>
        //      {
        //         new Movie { Id = 1, Name = "Shrek" },
        //         new Movie { Id = 2, Name = "Wall-e" }
        //     };
        //   }

        // GET: Movies/Random
        //  public ActionResult Random()
        //  {
        //      var movie = new Movie() { Name = "Shrek!" };
        //     var customers = new List<Customer>
        //     {
        //        new Customer { Name = "Customer 1" },
        //       new Customer { Name = "Customer 2" }
        //    };

        //   var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //      Customers = customers
        //   };

        //    return View(viewModel);
        //  }
    }
}