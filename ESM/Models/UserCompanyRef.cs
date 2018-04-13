using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class UserCompanyRef
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }

        public string CompanyId { get; set; }
        public virtual ICollection<Company> Companies { get; set; }

        public UserCompanyRef()
        {
            Id = Guid.NewGuid();
        }
    }
}