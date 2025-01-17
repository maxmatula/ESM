﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ESM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "EmployeeDetails",
                url: "Employees/{action}/{id}",
                defaults: new { controller = "Employees", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{searchString}",
                defaults: new { controller = "Home", action = "Index", searchString = UrlParameter.Optional }
            );
        }
    }
}
