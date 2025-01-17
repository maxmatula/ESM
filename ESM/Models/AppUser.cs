﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

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
        public virtual ICollection<UserCompanyRef> UserCompanyRefs { get; set; }
        public AppUser()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
