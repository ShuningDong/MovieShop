using MovieShop.MVC.Filter;
using MovieShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    //[MovieShopExceptionFilter]
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //[LogActionFilter]
        public ActionResult Index()
        {
            //int x = 1;
            //int y = 0;
            //int z = x / y;
            // get top revenue movies and show them in home page,
            // use same Movie Card as you did for genres movies
            var movies = _movieService.GetTopGrossingMovies();
            return View("TopRevenueMovie",movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}