using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESM.Models
{   
    [Table("Companies")]
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public decimal TotalEarnings { get; set; }
        [ForeignKey("UserCompanyRefs")]
        public Guid ReferenceId { get; set; }
        public virtual UserCompanyRef UserCompanyRefs { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Company()
        {
            Id = Guid.NewGuid();
        }

    }


}