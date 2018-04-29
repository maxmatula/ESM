using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.DAL;
using ESM.Models;

namespace ESM.Controllers
{
    public class EarningsController : Controller
    {
        private readonly ESMDbContext db;

        public EarningsController()
        {
            this.db = new ESMDbContext();
        }

        // GET: Earnings
        public ActionResult AddEarning(Guid? employeeId)
        {
            Earning earning = new Earning();
            Employee employee = db.Employees.Find(employeeId);
            earning.EmployeeId = employee.EmployeeId;
            return View(earning);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEarning([Bind(Include = "Ammount, EmployeeId")] Earning earning)
        {
            var employeeId = earning.EmployeeId;
            if (ModelState.IsValid)
            {
                db.Earnings.Add(earning);
                db.SaveChanges();
                return RedirectToAction("Details", "Employees", new { id = employeeId });
            }
            return View(earning);
        }
    }
}