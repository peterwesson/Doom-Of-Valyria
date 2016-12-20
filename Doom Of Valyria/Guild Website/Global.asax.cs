using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using GuildWebsite.Models.Global;

namespace GuildWebsite
{
    public class GuildWebsite : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Global = new Global();
        }

        public static Global Global { get; set; } 
    }
}