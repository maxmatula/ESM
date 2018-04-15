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

namespace ESM.Controllers
{
    public class CompaniesController : Controller
    {
        private ESMDbContext db = new ESMDbContext();

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

            Session["currentCompanyId"] = id.ToString();
            return RedirectToAction("Index", "Employees");
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Logo,Description")] Company company, UserCompanyRef userCompanyRef)
        {
            if (ModelState.IsValid)
            {
                userCompanyRef.Id = Guid.NewGuid();
                userCompanyRef.UserId = User.Identity.GetUserId().ToString();
                userCompanyRef.CompanyId = company.Id.ToString();
                db.UserCompanyRefs.Add(userCompanyRef);
                db.Companies.Add(company);
                db.SaveChanges();
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
        public ActionResult Edit([Bind(Include = "Id,Name,Logo,Description")] Company company, UserCompanyRef userCompanyRef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.Entry(userCompanyRef).State = EntityState.Unchanged;
                db.SaveChanges();
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
            Company company = db.Companies.Find(id);
            var refid = db.UserCompanyRefs.Where(x => x.CompanyId.Equals(company.Id)).Select(x => x.Id);
            UserCompanyRef userCompanyRef = db.UserCompanyRefs.Find(refid);
            db.Companies.Remove(company);
            db.UserCompanyRefs.Remove(userCompanyRef);
            db.SaveChanges();
            return RedirectToAction("Index", "UserPanel");
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
