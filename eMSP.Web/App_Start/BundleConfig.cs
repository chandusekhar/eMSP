using System.Web;
using System.Web.Optimization;

namespace eMSP.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.min.css",
                       "~/font-awesome/css/font-awesome.css",
                       "~/Content/plugins/toastr/toastr.min.css",
                       "~/Scripts/plugins/gritter/jquery.gritter.css",
                       "~/Content/animate.css",
                       "~/Content/style.css"));

            //My project required bundles
            bundles.Add(new ScriptBundle("~/bundles/plugin").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/plugins/metisMenu/jquery.metisMenu.js",
                        "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js",
                        "~/Scripts/plugins/flot/jquery.flot.js",
                        "~/Scripts/plugins/flot/jquery.flot.tooltip.min.js",
                        "~/Scripts/plugins/flot/jquery.flot.spline.js",
                        "~/Scripts/plugins/flot/jquery.flot.resize.js",
                        "~/Scripts/plugins/flot/jquery.flot.pie.js",
                        "~/Scripts/plugins/peity/jquery.peity.min.js",
                        "~/Scripts/inspinia.js",
                        "~/Scripts/plugins/pace/pace.min.js",
                        "~/Scripts/plugins/jquery-ui/jquery-ui.min.js",
                        "~/Scripts/plugins/gritter/jquery.gritter.min.js",
                        "~/Scripts/plugins/sparkline/jquery.sparkline.min.js",
                        "~/Scripts/plugins/chartJs/Chart.min.js",
                        "~/Scripts/plugins/toastr/toastr.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                        "~/app/app.js",
                        "~/app/components/home/homeController.js"
                        ));


        }
    }
}
