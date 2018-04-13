using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ESM.Models
{
    public class ESMDbContext : IdentityDbContext<AppUser>
    {
        public ESMDbContext() : base("ESMDbContextConnectionString", throwIfV1Schema: false)
        {
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserCompanyReference> UserCompanyReferences { get; set; }


        public static ESMDbContext Create()
        {
            return new ESMDbContext();
        }



    }
}