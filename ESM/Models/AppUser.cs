using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESM.Models
{

    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AvatarPath { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("UserCompanyRefs")]
        public Guid ReferenceId { get; set; }
        public virtual UserCompanyRef UserCompanyRefs { get; set; }
        public AppUser()
        {
            CreatedAt = DateTime.Now;
        }
    }
}