using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ESM.Models;

namespace ESM.DAL
{
    public class ESMInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ESMContext>
    {
        protected override void Seed(ESMContext context)
        {
            var users = new List<User>{
                new User{Name="Zbyszek", Surname="Kowalski", Email="admin@admin.pl", Password="1234"}
            };
            var employees = new List<Employee>
            {
                new Employee{Name = "Zbyszek", Surname = "Kowalski", Title =  "Marketing Specialist", Picture = "http://www.pngmart.com/files/3/Man-PNG-Pic.png"},
                new Employee{Name = "Jacek", Surname = "Mak", Title =  "Project Manager", Picture = "https://static.pexels.com/photos/213117/pexels-photo-213117.jpeg"}
               
            };

            employees.ForEach(s => context.Employees.Add(s)); context.SaveChanges();

            users.ForEach(s => context.Users.Add(s)); context.SaveChanges();
        }
    }
}
        