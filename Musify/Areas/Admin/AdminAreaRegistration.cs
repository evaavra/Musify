using System.Web.Mvc;
using System.Web.Optimization;

namespace Musify.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );

            //context.Routes.MapHttpRoute(
            //    name: "Admin_DefaultApi",
            //    routeTemplate: "Admin/api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            RegisterBundles();
        }


        private void RegisterBundles()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}