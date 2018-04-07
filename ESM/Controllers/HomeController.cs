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
            if (Session["Id"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            ESMContext db = new ESMContext();
            try
            {
                if (ModelState.IsValid)
                {
                    using (db)
                    {
                        var obj = db.Users.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                        if (obj != null)
                        {
                            Session["Id"] = obj.Id.ToString();
                            Session["UserName"] = obj.Name.ToString();
                            Session["UserSurname"] = obj.Surname.ToString();
                            Session["UserAvatarPath"] = obj.AvatarPath.ToString();
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch (Exception)
            {

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