using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Event()
        {
            EventId = Guid.NewGuid();
        }
    }
}