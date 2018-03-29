using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ESM.Models;

namespace ESM.DAL
{
    public class ESMContext : DbContext
    {
        public ESMContext() : base("ESMContext"){}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) { modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); }

        public System.Data.Entity.DbSet<ESM.Models.Company> Companies { get; set; }

        
    }
}