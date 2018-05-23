using ESM.DAL;
using ESM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ESM.Services
{
    public class EventsService : IEventsService
    {
        private ESMDbContext db = new ESMDbContext();

        public bool CreateCompanyEvent(Event esmevent, Guid companyId)
        {
            try
            {
                esmevent.CompanyId = companyId;
                db.Events.Add(esmevent);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Can't create event for company!");
            }
        }

        public bool CreateEmployeeEvent(Event esmevent, Guid companyId, Guid employeeId)
        {
            try
            {
                esmevent.CompanyId = companyId;
                esmevent.EmployeeId = employeeId;
                db.Events.Add(esmevent);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Can't create event for employee!");
            }
        }

        public bool DeleteEvent(Guid eventId)
        {
            try
            {
                var esmevent = db.Events.Find(eventId);
                db.Events.Remove(esmevent);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Can't find or delete event");
            }
        }

        public bool EditEvent(Event esmevent)
        {
            try
            {
                db.Entry(esmevent).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Can't edit event");
            }
        }

        public List<Event> EventListCompany(Guid companyId)
        {
            var esmeventlist = db.Events.Where(x => x.CompanyId == companyId).ToList();
            return esmeventlist;
        }

        public List<Event> EventListEmployee(Guid employeeId)
        {
            var esmeventlist = db.Events.Where(x => x.EmployeeId == employeeId).ToList();
            return esmeventlist;
        }

        public Event FindById(Guid eventId)
        {
            var esmevent = db.Events.Find(eventId);
            return esmevent;
        }
    }
}