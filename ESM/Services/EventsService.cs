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

        public bool CreateCompanyEvent(Event esmevent)
        {
            try
            {
                db.Events.Add(esmevent);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
            }
        }

        public bool CreateEmployeeEvent(Event esmevent)
        {
            try
            {
                db.Events.Add(esmevent);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
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
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
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
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
            }
        }

        public List<Event> EventListCompany(Guid companyId)
        {
            var esmeventlist = db.Events.Where(x => x.CompanyId == companyId).ToList();
            esmeventlist = esmeventlist.Where(x => x.EventDate <= DateTime.Now.AddDays(60)).OrderBy(x => x.EventDate).ToList();
            return esmeventlist;
        }

        public List<Event> EventListEmployee(Guid employeeId)
        {
            var esmeventlist = db.Events.Where(x => x.EmployeeId == employeeId).OrderBy(x => x.EventDate).ToList();
            return esmeventlist;
        }

        public Event FindById(Guid eventId)
        {
            var esmevent = db.Events.FirstOrDefault(x => x.EventId == eventId);
            return esmevent;
        }
    }
}