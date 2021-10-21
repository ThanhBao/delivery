using System.Web;
using System.Web.Optimization;

namespace LGT_Project.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/sb-admin.css",
                      "~/Content/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
              "~/Content/js/jquery.js",
              "~/Content/js/bootstrap.min.js",
              "~/Content/js/MyCustom.js"
              ));

            //bundles.Add(new ScriptBundle("~/Content/js").Include(
            // "~/Content/js/jquery-2.0.0.min.js",
            // "~/Content/js/bootstrap.min.js",
            // "~/Content/js/MyCustom.js",             
            // "~/Content/js/jquery.validate.min.js",
            // "~/Content/js/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/Content/js/plugins").Include(
            "~/Content/js/plugins/morris/raphael.min.js",
            "~/Content/js/plugins/morris/morris.min.js",
            "~/Content/js/plugins/morris/morris-data.js"));

        }
    }
}