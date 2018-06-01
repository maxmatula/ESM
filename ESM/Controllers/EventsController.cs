using ESM.Models;
using ESM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESM.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }


        public ActionResult CompanyEvents()
        {
            var companyId = Session["currentCompanyId"].ToString();
            if (companyId != null)
            {
                var model = _eventsService.EventListCompany(Guid.Parse(companyId));
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult EmployeeEvents(Guid? employeeId)
        {
            if (employeeId != null)
            {
                var model = _eventsService.EventListEmployee(employeeId.Value);
                return View(model);
            }
            return HttpNotFound();
        }


        public ActionResult CreateEventCompany()
        {
            var companyId = Session["currentCompanyId"].ToString();
            if (companyId != null)
            {
                Event esmevent = new Event();
                esmevent.CompanyId = Guid.Parse(companyId);
                return View(esmevent);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEventCompany(Event esmevent)
        {
            if (ModelState.IsValid)
            {
                var result = _eventsService.CreateCompanyEvent(esmevent);
                if (result == true)
                {
                    return RedirectToAction("Index", "Employees");
                }
            }
            return View(esmevent);
        }


        public ActionResult CreateEventEmployee(Guid? employeeId)
        {
            if (employeeId != null)
            {
                string companyId = Session["currentCompanyId"].ToString();
                Event esmevent = new Event();
                esmevent.CompanyId = Guid.Parse(companyId);
                esmevent.EmployeeId = employeeId;
                return View(esmevent);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEventEmployee(Event esmevent)
        {
            if (ModelState.IsValid)
            {
                var result = _eventsService.CreateEmployeeEvent(esmevent);
                if (result == true)
                {
                    return RedirectToAction("Details", "Employees", new { id = esmevent.EmployeeId });
                }
            }
            return View(esmevent);
        }

        public ActionResult EditEventEmployee(Guid? eventId)
        {
            if (eventId != null)
            {
                var esmevent = _eventsService.FindById(eventId.Value);
                return View(esmevent);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEventEmployee(Event esmevent)
        {
            if (ModelState.IsValid)
            {
                var result = _eventsService.EditEvent(esmevent);
                if (result == true)
                {
                    return RedirectToAction("Details", "Employees", new { id = esmevent.EmployeeId });
                }
            }
            return View(esmevent);
        }

        public ActionResult EditEventCompany(Guid? eventId)
        {
            if (eventId != null)
            {
                var esmevent = _eventsService.FindById(eventId.Value);
                return View(esmevent);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEventCompany(Event esmevent)
        {
            if (ModelState.IsValid)
            {
                var result = _eventsService.EditEvent(esmevent);
                if (result == true)
                {
                    return RedirectToAction("Index", "Employees");
                }
            }
            return View(esmevent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventCompany(Guid? eventId)
        {
            if (eventId != null)
            {
                var esmevent = _eventsService.FindById(eventId.Value);
                var result = _eventsService.DeleteEvent(eventId.Value);
                return RedirectToAction("Index", "Employees");
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventEmployee(Guid? eventId)
        {
            if (eventId != null)
            {
                var esmevent = _eventsService.FindById(eventId.Value);
                var empId = esmevent.EmployeeId;
                var result = _eventsService.DeleteEvent(eventId.Value);
                return RedirectToAction("Details", "Employees", new { id = empId });
            }
            return HttpNotFound();
        }
    }
}