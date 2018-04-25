using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESM.Models;
using ESM.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ESM.Services;

namespace ESM.Controllers
{
    public class CompaniesController : Controller
    {

        private readonly ESMDbContext db;
        private readonly ICompaniesService companiesService;

        public CompaniesController()
        {
            this.db = ESMDbContext.Create();
            this.companiesService = new CompaniesService();
        }

        // GET: Companies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            Session["currentCompanyId"] = id;
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
        public ActionResult Create([Bind(Include = "CompanyId,Name,LogoData,LogoMimeType,Description")] Company company, UserCompanyRef userCompanyRef, HttpPostedFileBase logo)
        {
            if (ModelState.IsValid)
            {
                var result = companiesService.Create(company, userCompanyRef, User.Identity.GetUserId().ToString(), logo);
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
            Company company = db.Companies.Find(id);
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
        public ActionResult Edit([Bind(Include = "CompanyId,Name,LogoData,LogoMimeType,Description")] Company company, UserCompanyRef userCompanyRef, HttpPostedFileBase logo)
        {
            if (ModelState.IsValid)
            {
                var result = companiesService.Edit(company, userCompanyRef, logo);
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
            Company company = db.Companies.Find(id);
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
            var result = companiesService.Delete(id);
            return RedirectToAction("Index", "UserPanel");
        }

        public FileContentResult GetLogo(Guid companyId)
        {
            Company company = db.Companies.FirstOrDefault(e => e.CompanyId == companyId);
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
