using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ESM.Models;
using ESM.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ESM
{
	public partial class Startup
	{
		public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ESMDbContext.Create);
            app.CreatePerOwinContext<ESMUserManager>(ESMUserManager.Create);
            app.CreatePerOwinContext<ESMSignInManager>(ESMSignInManager.Create);
        }

        private void CreateRoles()
        {
            ESMDbContext db = new ESMDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }
    }
}