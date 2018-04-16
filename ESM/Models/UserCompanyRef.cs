using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    [Table("UserCompanyRefs")]
    public class UserCompanyRef
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<Company> Companies { get; set; }

        public UserCompanyRef()
        {
            Id = Guid.NewGuid();
        }
    }
}