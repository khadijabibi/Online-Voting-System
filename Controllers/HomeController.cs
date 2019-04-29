using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpicConstruction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
           return View();
        }

        public ActionResult Voted()
        {
            return View();
        }
        public ActionResult Thankyou()
        {
            return View();
        }

    }
}