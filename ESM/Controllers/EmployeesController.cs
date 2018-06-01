﻿using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESM.Models;
using ESM.DAL;
using ESM.Services;

namespace ESM.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly ESMDbContext _db;
        private readonly IEmployeesService _employeesService;
        private readonly IDirectoriesService _directoriesService;

        public EmployeesController(IEmployeesService employeesService, IDirectoriesService directoriesService)
        {
            _db = new ESMDbContext();
            _employeesService = employeesService;
            _directoriesService = directoriesService;
        }

        // GET: Employees
        public ActionResult Index(string searchString = null)
        {
            var currentCompanyId = Session["currentCompanyId"];
            var employees = from emp in _db.Employees
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
            var employee = _employeesService.GetById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View("Create", new Employee());
        }

        // POST: Employees/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, string picture)
        {
            string currentCompanyId = Session["currentCompanyId"].ToString();
            if (ModelState.IsValid)
            {
                var result = _employeesService.Create(employee, currentCompanyId, picture);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
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
            Employee employee = _db.Employees.Find(id);
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
        public ActionResult Edit(Employee employee, string picture)
        {

            string currentCompanyId = Session["currentCompanyId"].ToString();
            if (ModelState.IsValid)
            {
                var result = _employeesService.Edit(employee, currentCompanyId, picture);
                return RedirectToAction("Index");
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
            Employee employee = _db.Employees.Find(id);
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
            var result = _employeesService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult GetPicture(Guid employeeId)
        {
            Employee employee = _db.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null && employee.PictureData != null)
            {
                return File(employee.PictureData, employee.PictureMimeType);
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
