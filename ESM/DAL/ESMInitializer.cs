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
            var employees = new List<Employee>{
                new Employee{Name="Zbyszek", Surname="Kowalski", BirthDate="2017-01-01", Title="Marketing Specialist", Picture="http://1.bp.blogspot.com/-BtCpds1720g/UIruddlUqTI/AAAAAAAAHis/aTC2tMLU8NU/s400/zjarany-zbyszek-10-guy-stoner-guy-oryginalne-zdjecia-2-mem.jpg" }
            };

            employees.ForEach(s => context.Employees.Add(s)); context.SaveChanges();

            users.ForEach(s => context.Users.Add(s)); context.SaveChanges();
        }
    }
}
        