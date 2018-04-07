using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.Models;
using ESM.DAL;

namespace ESM.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "O aplikacji";

            return View();
        }

            }

            return RedirectToAction("Login");
        }

        public ActionResult Index(string searchString = null)
        {
            

            if (Session["Id"] != null)
            {
                ESMContext db = new ESMContext();

                var employees = from s in db.Employees select s;

                if (!String.IsNullOrEmpty(searchString))
                {
                    employees = employees.Where(x => x.Name.Contains(searchString) 
                        || x.Surname.Contains(searchString) 
                        || x.Title.Contains(searchString));

                }

            return View();
        }

                return View(employees.ToList());
                

                
            }
            else
            {
                return RedirectToAction("Login");
            }

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