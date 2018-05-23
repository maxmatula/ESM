using ESM.Models;
using ESM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESM.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;

        public EventsController()
        {
            this.eventsService = new EventsService();
        }


        public ActionResult CompanyEvents(Guid? companyId)
        {
            if (companyId != null)
            {
                var model = eventsService.EventListCompany(companyId.Value);
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult EmployeeEvents(Guid? employeeId)
        {
            if (employeeId != null)
            {
                var model = eventsService.EventListEmployee(employeeId.Value);
                return View(model);
            }
            return HttpNotFound();
        }


        public ActionResult CreateEventCompany(Guid? companyId)
        {
            if (companyId != null)
            {
                Event esmevent = new Event();
                esmevent.CompanyId = companyId.Value;
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
                var result = eventsService.CreateCompanyEvent(esmevent);
                if (result == true)
                {
                    return RedirectToAction("Index", "UserPanel");
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
                var result = eventsService.CreateEmployeeEvent(esmevent);
                if (result == true)
                {
                    return RedirectToAction("Details", "Employees", new { id = esmevent.EmployeeId });
                }
            }
            return View(esmevent);
        }

        public ActionResult EditEventEmployee(Guid? eventId)
        {
            if(eventId != null)
            {
                var esmevent = eventsService.FindById(eventId.Value);
                return View(esmevent);
            }
            return HttpNotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEventEmployee(Event esmevent)
        {
            if(ModelState.IsValid)
            {
                var result = eventsService.EditEvent(esmevent);
                if(result == true)
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
                var esmevent = eventsService.FindById(eventId.Value);
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
                var result = eventsService.EditEvent(esmevent);
                if (result == true)
                {
                    return RedirectToAction("Index", "UserPanel");
                }
            }
            return View(esmevent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventCompany(Guid? eventId)
        {
            if(eventId != null)
            {
                var result = eventsService.DeleteEvent(eventId.Value);
                return RedirectToAction("Index", "UserPanel");
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventEmployee(Guid? eventId)
        {
            if (eventId != null)
            {
                var esmevent = eventsService.FindById(eventId.Value);
                var result = eventsService.DeleteEvent(eventId.Value);
                return RedirectToAction("Details", "Employees", new { id = esmevent.EmployeeId });
            }
            return HttpNotFound();
        }
    }
}