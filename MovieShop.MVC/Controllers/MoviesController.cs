using MovieShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {

        // GET  http:localhost:34234/Movies/Index
        // Routing
        // DI with  Constructor Injection
       // private readonly int x ;
        private readonly  IMovieService _movieService ;
     // MVC 5 requires Parameterless Contructor
     //For IMovieService movieService, we need to inject an  implementation
     // we can pass any object/instance that implements IMovieService interface
     // In our Project MovieService class is implementing IMovieService Interface
     // IOC should inject instance of MovieService for Constructor
     // .NET Framework there are no built-in IOC, we need to download 3rd party IOC's
     // Popular 3rd party IOC's like Ninject, Autofac, Unity etc
     // in .NET Core or ASP.NET Core Dependecny Injection is builtin, so we dont't need any 3rd pary IOC

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

       [HttpGet]
       [Route("")]
        public ActionResult Index()
        {
           
            // All URL's always map to COntroller and Action Method
            // they dont map to View
            // Every HTTP REQUEST (GET, POST, PUT, DELETE) they always go
            //to Controller first, then action method, then Action method needs to return View

            // call service layer to get top 20 revenue movies

            var movies = _movieService.GetTopGrossingMovies();
            return View(movies);
        }

        //take genre id from url and then call movie service to get list of movie
        //belong to the genre.


        [HttpGet]
        [Route("genre/{genreId}")]
        public ActionResult GenreMovies(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId).OrderBy(m => m.title).ToList();

            return View("MoviesByGenre", movies);
        }

        //[Route("details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }
    }
}