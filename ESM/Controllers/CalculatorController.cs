using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.Models;

namespace ESM.Controllers
{
    public class CalculatorController : Controller
    {
       

        public ActionResult Index(string homeWorker, decimal brutto = 0)
        {

            Calculator calc = new Calculator();

            if (brutto == 0)
            {
                return View(calc);
            }

            calc.HomeWorker = homeWorker;
            calc.Brutto = brutto;
            calc.Netto = calc.CalcNetto();
            calc.EmployeeCost = calc.CalcEmployeeCost();

            return PartialView("_CalculatorCalc", calc);
        }
    }
}