using MovieShop.Entities;
using MovieShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        // GET: Cast
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        public ActionResult Index()
        {
            return View();
        }

        // step 1 Create a action method that returns empty view to enter Cast information

            // cast/create HTTP Get
         [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cast cast)
        {
            // save this information tocast Table

            _castService.UpdateToCastTable(cast);
            return View();
        }
                
    }
}