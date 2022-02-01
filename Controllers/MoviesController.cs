using System.Collections.Generic;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;
using System.Linq;


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
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View (movies);

              
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