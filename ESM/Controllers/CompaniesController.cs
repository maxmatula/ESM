using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESM.Models;
using ESM.DAL;
using Microsoft.AspNet.Identity;
using ESM.Services;

namespace ESM.Controllers
{
    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly ESMDbContext _db;
        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _db = ESMDbContext.Create();
            _companiesService = companiesService;
        }

        // GET: Companies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = _companiesService.FindByid(id.Value);

            if (company == null)
            {
                return HttpNotFound();
            }

            Response.Cookies["currentCompanyId"].Value = id.ToString();
            Response.Cookies["currentCompanyId"].Expires = DateTime.Now.AddDays(2);
            Response.SetCookie(Response.Cookies["currentCompanyId"]);

            Session["currCompName"] = company.Name;
            return RedirectToAction("Index", "Employees");
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View("Create", new Company());
        }

        // POST: Companies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company, UserCompanyRef userCompanyRef, string picture)
        {
            if (ModelState.IsValid)
            {
                var result = _companiesService.Create(company, userCompanyRef, User.Identity.GetUserId().ToString(), picture);
                return RedirectToAction("Index", "UserPanel");
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = _companiesService.FindByid(id.Value);

            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company, string picture)
        {
            if (ModelState.IsValid)
            {
                var result = _companiesService.Edit(company, picture);
                return RedirectToAction("Index", "UserPanel");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = _companiesService.FindByid(id.Value);

            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var result = _companiesService.Delete(id);
            return RedirectToAction("Index", "UserPanel");
        }

        public FileContentResult GetLogo(Guid companyId)
        {
            var company = _companiesService.FindByid(companyId);

            if (company != null)
            {
                return File(company.LogoData, company.LogoMimeType);
            }
            else
            {
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
