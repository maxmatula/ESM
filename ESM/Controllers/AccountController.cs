using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.Models;
using ESM.DAL;
using ESM.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ESM.Services;

namespace ESM.Controllers
{
    public class AccountController : Controller
    {

        private ESMSignInManager _signInManager;
        private ESMUserManager _userManager;

        public ESMSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ESMSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ESMUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ESMUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public bool IsLogged()
        {
            return Session["UserId"] != null;
        }

        /// <summary>
        /// GET: Zwraca widok Logowania
        /// </summary>
        /// <returns></returns>
        /// 

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (IsLogged())
            {
                return RedirectToAction("Index", "UserPanel");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        /// <summary>
        /// POST: Obsługa procesu logowania
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    InitCurrentUserSession(model);
                    return RedirectToAction("Index", "UserPanel");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Niewłaściwa próba logowania!");
                    return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// GET: Zwraca widok rejestracji
        /// </summary>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new AppUser { UserName = model.Email, Email = model.Email };
                UserStore<AppUser> Store = new UserStore<AppUser>(new ESMDbContext());
                ESMUserManager userManager = new ESMUserManager(Store);

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                AddErrors(result);
            }
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        
        private void InitCurrentUserSession(LoginViewModel user)
        {
            UserStore<AppUser> Store = new UserStore<AppUser>(new ESMDbContext());
            ESMUserManager userManager = new ESMUserManager(Store);

            AppUser currentUser = userManager.FindByEmail(user.Email);
            Session["Name"] = currentUser.Name;
            Session["Surname"] = currentUser.Surname;
        }
    }
}