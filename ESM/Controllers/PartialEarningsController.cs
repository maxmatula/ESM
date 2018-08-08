using ESM.DAL;
using ESM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESM.Controllers
{
    public class PartialEarningsController : Controller
    {
        private readonly ESMDbContext _context;

        public PartialEarningsController(ESMDbContext context)
        {
            _context = context;
        }

        // GET: PartialEarning
        public ActionResult AddPartial(Guid? earningId)
        {
            PartialEarning partial = new PartialEarning();
            partial.EarningId = earningId.Value;
            return View(partial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPartial(PartialEarning partial)
        {
            var earningId = partial.EarningId;
            if (ModelState.IsValid)
            {
                _context.PartialEarnings.Add(partial);
                _context.SaveChanges();
                return RedirectToAction("Details", "Earnings", new { id = earningId });
            }

            return View(partial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePartial(Guid? partialId)
        {
            if (partialId != null)
            {
                var partial = _context.PartialEarnings.Find(partialId.Value);
                var returnId = partial.EarningId;
                _context.PartialEarnings.Remove(partial);
                _context.SaveChanges();
                return RedirectToAction("Details", "Earnings", new { id = returnId });
            }

            return HttpNotFound();
        }
    }
}