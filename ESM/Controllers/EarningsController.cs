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

        public ActionResult AddEarning([Bind(Include = "EarningId,Amount,AddDate,EmployeeId")] Earning earning)
        {
            if (ModelState.IsValid)
            {

            }
            return View(earning);
        }
    }
}