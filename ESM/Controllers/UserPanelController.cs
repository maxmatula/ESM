using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.Models;
using ESM.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ESM.Services;

namespace ESM.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly IDirectoriesService directoriesService;

        public UserPanelController()
        {
            this.directoriesService = new DirectoriesService();
        }

        // GET: UserPanel
        public ActionResult Index(string searchString = null)
        {
            ESMDbContext db = new ESMDbContext();

            var currUserId = User.Identity.GetUserId();
            var directoryResult = directoriesService.GetUserDirectory(currUserId);
            var companies = from company in db.Companies
                            join reference in db.UserCompanyRefs
                            on company.CompanyId.ToString() equals reference.CompanyId.ToString()
                            where reference.UserId.ToString() == currUserId.ToString()
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
