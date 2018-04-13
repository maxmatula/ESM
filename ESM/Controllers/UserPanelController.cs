using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.Models;

namespace ESM.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        public ActionResult Index(string searchString = null)
        {
            ViewBag.Title = "Panel użytkownika";
            ESMDbContext db = new ESMDbContext();

            var companies = from company in db.Companies
                            select company;


            if (!String.IsNullOrEmpty(searchString))
            {
                companies = companies.Where(x => x.Name.Contains(searchString)
                    || x.Description.Contains(searchString));

                
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CompaniesList", companies.ToList());
            }

            return View(companies.ToList());
        }
    }
}
