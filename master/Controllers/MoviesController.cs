using System.Collections.Generic;
using System.Web.Mvc;
using master.Models;
using master.ViewModels;
using System.Data.Entity;
using System.Linq;
namespace master.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }
        //
        // GET: /Movies/Random
        public ActionResult Random()
        {
            List<Movie> movies = _context.Movies.ToList(); 
            var ViewModel = new RandomMovieViewModel
            {
                Movies = movies,
            };
            return View(ViewModel);
        }
        public ActionResult Create()
        {
            return View("Create");
        }
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.Find(id);
            return View("Edit",movies);
        }
        public ActionResult Delete(int id)
        {
            var movies = _context.Movies.Find(id);
            _context.Movies.Remove(movies);
            _context.SaveChanges();
            return RedirectToAction("Random", "Movies");
        }
        [HttpPost]
        public ActionResult AddSave(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (movie.ID == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.ID == movie.ID);
                movieInDb.Name = movie.Name;
            }
            _context.SaveChanges();

            return RedirectToAction("Random", "Movies");
        }

        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Satish" };
        //    return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        //}
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue) pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content(String.Format("Page no {0} Sort By {1} Order", pageIndex, sortBy));
        //}
        //[Route ("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year,int month)
        //{
        //    return Content(year + "/" + month);
        //}
	}
}