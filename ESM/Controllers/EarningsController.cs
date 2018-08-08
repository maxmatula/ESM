using System;
using System.Web.Mvc;
using ESM.DAL;
using ESM.Models;

namespace ESM.Controllers
{
    [Authorize]
    public class EarningsController : Controller
    {
        private readonly ESMDbContext _db;

        public EarningsController()
        {
            _db = new ESMDbContext();
        }

        // GET: Earnings
        public ActionResult AddEarning(Guid? employeeId)
        {
            Earning earning = new Earning();
            Employee employee = _db.Employees.Find(employeeId);
            earning.EmployeeId = employee.EmployeeId;
            return View(earning);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEarning(Earning earning)
        {
            var employeeId = earning.EmployeeId;
            if (ModelState.IsValid)
            {
                _db.Earnings.Add(earning);
                _db.SaveChanges();
                return RedirectToAction("Details", "Employees", new { id = employeeId });
            }
            return View(earning);
        }
    }
}