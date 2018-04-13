using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ESM.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace ESM
{
    public class ESMUserStore : UserStore<AppUser>
    {
        public ESMUserStore(ESMDbContext context) : base(context)
        {

        }
    }

    public class ESMUserManager : UserManager<AppUser>
    {
        public ESMUserManager(IUserStore<AppUser> store) : base(store)
        {

        }

        public static ESMUserManager Create(IdentityFactoryOptions<ESMUserManager> options, IOwinContext context)
        {
            var store = new UserStore<AppUser>(context.Get<ESMDbContext>());

            var manager = new ESMUserManager(store);

            return manager;
        }

        
    }

    public class ESMSignInManager : SignInManager<AppUser, string>
    {
        public ESMSignInManager(ESMUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {

        }

        public static ESMSignInManager Create(IdentityFactoryOptions<ESMSignInManager> options, IOwinContext context)
        {
            return new ESMSignInManager(context.GetUserManager<ESMUserManager>(), context.Authentication);
        }
    }


}