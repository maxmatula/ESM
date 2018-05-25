using ESM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESM.Services
{
    public interface IEventsService
    {
        Event FindById(Guid eventId);
        List<Event> EventListCompany(Guid companyId);
        List<Event> EventListEmployee(Guid employeeId);
        bool CreateCompanyEvent(Event esmevent);
        bool CreateEmployeeEvent(Event esmevent);
        bool DeleteEvent(Guid eventId);
        bool EditEvent(Event esmevent);
    }
}
