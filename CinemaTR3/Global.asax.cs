
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CinemaTR3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public Controllers.HomeController HomeController
        {
            get => default;
            set
            {
            }
        }

        public Controllers.AdminController AdminController
        {
            get => default;
            set
            {
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
