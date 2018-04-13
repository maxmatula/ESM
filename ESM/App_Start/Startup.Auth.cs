using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ESM.Models;
using Microsoft.AspNet.Identity;




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
	}
}