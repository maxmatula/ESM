using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESM.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }
        [Required]
        [StringLength(128),Display(Name="Nazwa")]
        public string Name { get; set; }
        public byte[] LogoData { get; set; }
        [StringLength(50)]
        public string LogoMimeType { get; set; }
        [Display(Name= "Opis")]
        public string Description { get; set; }
        public decimal? TotalEarnings { get; set; }
        public virtual ICollection<UserCompanyRef> UserCompanyRefs { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Company()
        {
            CompanyId = Guid.NewGuid();
        }
    }
}
