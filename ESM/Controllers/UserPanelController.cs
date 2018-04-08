using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.DAL;
using ESM.Models;

namespace ESM.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        public ActionResult Index(string searchString = null)
        {
            ViewBag.Title = "Panel użytkownika";
            ESMContext db = new ESMContext();

            string currentUserId = Session["UserId"].ToString();

            var companies = from company in db.Companies
                            join reference in db.userCompanyReferences
                            on company.Id.ToString() equals reference.CompanyId
                            where reference.UserId == currentUserId
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
