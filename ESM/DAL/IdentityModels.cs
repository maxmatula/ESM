using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ESM.Models;


namespace ESM.DAL
{
    public class ESMDbContext : IdentityDbContext<AppUser>
    {
        public ESMDbContext() : base("ESMDbContext", throwIfV1Schema: false)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserCompanyRef> UserCompanyRefs { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<RecruitmentDocument> RecruitmentDocuments { get; set; }
        public DbSet<Certyfication> Certyfications { get; set; }
        public DbSet<Agreement> Agreements { get; set; }

        public static ESMDbContext Create()
        {
            return new ESMDbContext();
        }
    }
}