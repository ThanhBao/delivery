using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LGT_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            App_Start.FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            App_Start.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
