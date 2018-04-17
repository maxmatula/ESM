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
        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }
        [ForeignKey("Companies")]
        public Guid CompanyId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Company Companies { get; set; }
    }
}
