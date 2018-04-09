using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.Models;
using ESM.DAL;

namespace ESM.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public bool IsLogged()
        {
            return Session["Id"] != null;
        }

        /// <summary>
        /// GET: Zwraca widok Logowania
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (IsLogged())
            {
                return RedirectToAction("Index", "UserPanel");
            }
            return View();

        }
        /// <summary>
        /// POST: Obsługa procesu logowania
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
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
                            return RedirectToAction("Login");
                        }
                    }
                }
            }
            catch (Exception)
            {
                //throw new Exception("Wystąpił bład podczas logowania :(");
            }

            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// GET: Zwraca widok rejestracji
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            if (IsLogged())
            {
                return RedirectToAction("Index", "UserPanel");
            }
            return View();
        }
        /// <summary>
        /// Obsługuje proces rejestracji
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Name, Surname, Email, Password, AvatarPath")] User objUser)
        {
            ESMContext db = new ESMContext();
            if (ModelState.IsValid)
            {
                db.Users.Add(objUser);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(objUser);
        }
    }
}