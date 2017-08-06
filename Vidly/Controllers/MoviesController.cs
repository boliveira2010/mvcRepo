using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> _movies = new List<Movie>();
        private Random _randomizer = new Random(0);
        public MoviesController()
        {
            _movies.Add(new Movie() { Id = 1, Name = "ScarFace" });
            _movies.Add(new Movie() { Id = 2, Name = "Shrek" });
        }
        // GET: Movies/Random
        public ActionResult Randomize()
        {
            var movie = _movies[_randomizer.Next(_movies.Count - 1)];
            
            return View(movie);
        }

        public ActionResult View(int index)
        {
            if ((0 <= index) && (index >= _movies.Count))
                return new HttpNotFoundResult("Movie not found.");
            else
                return View(_movies[index]);
        }
        public ActionResult All()
        {
            return View(_movies);
        }
    }
}