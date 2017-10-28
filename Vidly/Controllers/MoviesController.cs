using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("Movies/Index")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if ( !pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("Movies/Edit")]
        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        [Route("Movies/Released/{year:regex(\\d{4})}/{month:int:range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(String.Format("{0} / {1}", year, month));
        }
    }
}