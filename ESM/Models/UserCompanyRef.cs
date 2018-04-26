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
        public Guid RefId { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        [ForeignKey("Companies")]
        public Guid CompanyId { get; set; }
        public virtual Company Companies { get; set; }

        public UserCompanyRef()
        {
            this.RefId = Guid.NewGuid();
        }
    }
}
