using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("Movies/Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}