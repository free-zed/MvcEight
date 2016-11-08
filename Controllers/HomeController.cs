using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEight.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Students()
        {
            ViewBag.Message = "All Students Information";

            return View();
        }

        public ActionResult Teachers()
        {
            ViewBag.Message = "All Teachers Information";

            return View();
        }
    }
}