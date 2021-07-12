using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LMSweb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
            AntiForgeryConfig.UniqueClaimTypeIdentifier = System.Security.Claims.ClaimTypes.Name;

            //HttpCookie cLang = Request.Cookies["Lang"];

            //if (cLang != null)
            //{
            //    System.Threading.Thread.CurrentThread.CurrentCulture
            //        = new System.Globalization.CultureInfo(cLang.Value);
            //    System.Threading.Thread.CurrentThread.CurrentUICulture
            //        = new System.Globalization.CultureInfo(cLang.Value);
            //}
        }
    }
}
