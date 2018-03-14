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
            if(Session["UserId"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ESMContext db = new ESMContext())
                    {
                        var obj = db.Users.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                        if (obj != null)
                        {
                            Session["UserId"] = obj.UserId.ToString();
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
            
            return View(objUser);
        }

        public ActionResult Index()
        {
            if(Session["UserId"] != null)
            {
                ViewBag.UserName = Session["UserName"];
                ViewBag.UserSurname = Session["UserSurname"];
                return View();
            }
            else
            {
                return View("Login", "_FluidLayout", User);
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