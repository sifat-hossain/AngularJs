using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AngularJS.AutoMapper;

namespace AngularJS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        [Obsolete]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Automapper.Run();
        }
    }
}
