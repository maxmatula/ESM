using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.Models;

namespace ESM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "O aplikacji";

            return View();
        }

        public ActionResult Benefits()
        {
            ViewBag.Title = "Korzyści";

            return View();
        }

        public ActionResult Team()
        {
            ViewBag.Title = "Zespół";

            return View();
        }

        public ActionResult Cooperation()
        {
            ViewBag.Title = "Współpraca";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Kontakt";

            return View();
        }

    }
}