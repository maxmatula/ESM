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
using ESM.ViewModels;
using ESM.Services;
using Microsoft.AspNet.Identity;

namespace ESM.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ESMDbContext db;
        private readonly IEmployeesService employeesService;
        private readonly IDirectoriesService directoriesService;

        public EmployeesController()
        {
            this.db = new ESMDbContext();
            this.employeesService = new EmployeesService();
            this.directoriesService = new DirectoriesService();
        }

        // GET: Employees
        public ActionResult Index(string searchString = null)
        {
            var currentCompanyId = Session["currentCompanyId"];
            var employees = from emp in db.Employees
                            where emp.CompanyId.ToString() == currentCompanyId.ToString()
                            select emp;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(x => x.Name.Contains(searchString)
                    || x.Surname.Contains(searchString)
                    || x.Title.Contains(searchString));
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_EmployeesList", employees.ToList());
            }
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Surname,Title,Picture,BirthDate,CompanyId")] Employee employee)
        {
            string currentCompanyId = Session["currentCompanyId"].ToString();
            if (ModelState.IsValid)
            {
                var result = employeesService.Create(employee, currentCompanyId);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Surname,BirthDate,Title,Picture")] Employee employee, HttpPostedFileBase file)
        {
            string currUser = User.Identity.GetUserId().ToString();
            string userPath = directoriesService.GetDirectory(currUser);
            string avatarPath = directoriesService.UploadFile(userPath, file);
            string currentCompanyId = Session["currentCompanyId"].ToString();
            if (ModelState.IsValid)
            {
                var result = employeesService.Edit(employee, currentCompanyId, avatarPath);
            }

            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var result = employeesService.Delete(id);
            return RedirectToAction("Index");
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
