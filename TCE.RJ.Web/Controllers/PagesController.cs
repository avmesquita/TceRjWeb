using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCE.RJ.Web.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index()
        {
            return RedirectToAction("Books");
        }

        public ActionResult Books()
        {
            return View("Books");
        }
    }
}