using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwa wydarzenia")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }
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