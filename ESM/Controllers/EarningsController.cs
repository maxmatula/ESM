using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Earning earning = _db.Earnings.Include(g => g.PartialEarnings).FirstOrDefault(x => x.EarningId == id);

            if (earning == null)
            {
                return HttpNotFound();
            }

            ViewBag.Total = earning.PartialEarnings.Sum(x => x.Ammount).ToString("c");

            return View(earning);
        }

        public ActionResult DetailsArchive(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Earning earning = _db.Earnings.Include(g => g.PartialEarnings).FirstOrDefault(x => x.EarningId == id);

            if (earning == null)
            {
                return HttpNotFound();
            }

            ViewBag.Total = earning.PartialEarnings.Sum(x => x.Ammount).ToString("c");

            return View(earning);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConnectAgreement(Guid? earningId, Guid? agreementId)
        {
            if (ModelState.IsValid)
            {
                if(earningId != null && agreementId != null)
                {
                    var earning = _db.Earnings.Find(earningId);
                    var agreement = _db.Agreements.Find(agreementId);

                    earning.AgreementId = agreementId;
                    agreement.EarningId = earningId;

                    _db.Entry(earning).State = EntityState.Modified;
                    _db.Entry(agreement).State = EntityState.Modified;
                    _db.SaveChanges();

                    return RedirectToAction("Details", "Employees", new { id = earning.EmployeeId });
                }
                
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DisconnectAgreement(Guid? earningId, Guid? agreementId)
        {
            if (ModelState.IsValid)
            {
                if (earningId != null && agreementId != null)
                {
                    var earning = _db.Earnings.Find(earningId);
                    var agreement = _db.Agreements.Find(agreementId);

                    earning.AgreementId = null;
                    agreement.EarningId = null;

                    _db.Entry(earning).State = EntityState.Modified;
                    _db.Entry(agreement).State = EntityState.Modified;
                    _db.SaveChanges();

                    return RedirectToAction("Details", "Employees", new { id = earning.EmployeeId });
                }

            }

            return View();
        }
    }
}