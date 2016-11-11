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

        public ActionResult ClassOne()
        {
            return View();
        }

        public ActionResult ClassTwo()
        {
            return View();
        }

        public ActionResult ClassThree()
        {
            return View();
        }

        public ActionResult ClassFour()
        {
            return View();
        }

        public ActionResult ClassFive()
        {
            return View();
        }

        public ActionResult ClassSix()
        {
            return View();
        }

        public ActionResult ClassSeven()
        {
            return View();
        }

        public ActionResult ClassEight()
        {
            return View();
        }

        public ActionResult ClassNine()
        {
            return View();
        }

        public ActionResult ClassTen()
        {
            return View();
        }

    }
}