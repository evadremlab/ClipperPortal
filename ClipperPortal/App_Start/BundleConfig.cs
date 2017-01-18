using System.Web;
using System.Web.Optimization;

namespace ClipperPortal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Client Scripts/mvcfoolproof.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/respond.min.js",
                      "~/Scripts/Widgets/operator-filter-widget.js",
                      "~/Scripts/Widgets/reporting-period-filter-widget.js",
                      "~/Scripts/Widgets/record-status-filter-widget.js",
                      "~/Scripts/gridmvc.min.js",
                      "~/Scripts/Site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Gridmvc.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/Site.css"));
        }
    }
}
