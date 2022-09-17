using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Musify.Areas.Admin
{
    internal class BundleConfig 
    {
        internal static void RegisterBundles(BundleCollection bundles)
        {
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery2").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery.easing.min.js",
                        "~/Scripts/sb-admin-2.min.js",
                        "~/Scripts/Chart.min.js",
                        "~/Scripts/chart-area-demo.js",
                        "~/Scripts/chart-pie-demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval2").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr2").Include(
                        "~/Scripts/modernizr-*"));

            //bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap2").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/dataTables.bootstrap4.js"));

            //css
            bundles.Add(new StyleBundle("~/Content/css2").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/all.css",
                      "~/Content/sb-admin-2.css",
                       "~/Content/dataTables.bootstrap4.css"));
        }
    }
}