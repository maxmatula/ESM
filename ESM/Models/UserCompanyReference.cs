using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class UserCompanyReference
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Company Company { get; set; }

        public UserCompanyReference()
        {
            Id = Guid.NewGuid();
        }
    }
}