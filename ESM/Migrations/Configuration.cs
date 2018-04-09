namespace ESM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ESM.DAL;
    using ESM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ESM.DAL.ESMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ESM.DAL.ESMContext";
        }

        protected override void Seed(ESM.DAL.ESMContext context)
        {
            context.Employees.AddOrUpdate(x => x.Id,

               new Employee { Name = "Piotr", Surname = "Makowski", Title = ".Net Specialist", Picture = "http://placehold.it/200x200" },
               new Employee { Name = "Jakub", Surname = "Jan", Title = ".Net Specialist", Picture = "http://placehold.it/200x200" },
               new Employee { Name = "Maciej", Surname = "Szthur", Title = ".Net Specialist", Picture = "http://placehold.it/200x200" },
               new Employee { Name = "Katarzyna", Surname = "Zaj¹c", Title = "Manager", Picture = "http://placehold.it/200x200" },
               new Employee { Name = "Zofia", Surname = "Ko³aczka", Title = "Accountant", Picture = "http://placehold.it/200x200" },
               new Employee { Name = "W³adys³aw", Surname = "Kupierz", Title = ".Net Specialist", Picture = "http://placehold.it/200x200" },
               new Employee { Name = "Magdalena", Surname = "Sabkowska", Title = "C# junior", Picture = "http://placehold.it/200x200" },
               new Employee { Name = "S³awomir", Surname = "Murias", Title = "C# Specialist", Picture = "http://placehold.it/200x200" },
               new Employee { Name = "Zbyszek", Surname = "Sok", Title = ".Net Specialist", Picture = "http://placehold.it/200x200" }

           );

            context.Users.AddOrUpdate(x => x.Id,

                new User { Name = "Zbyszek", Surname = "Kowalski", Email = "admin@admin.pl", Password = "1234", IsActive = true}
            );

        }
    }
}
