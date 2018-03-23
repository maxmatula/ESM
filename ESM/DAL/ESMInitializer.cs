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


            users.ForEach(s => context.Users.Add(s)); context.SaveChanges();
        }
    }
}
        