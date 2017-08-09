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
                        "~/Scripts/angular-*",
                        "~/Scripts/angular-local-storage.min.js"
                        //"~/Scripts/angular-idle.js",
                        //"~/Scripts/angular-translate.min.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      //"~/Scripts/ui-bootstrap-tpls-1.1.2.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.min.css",
                       "~/font-awesome/css/font-awesome.css",
                       "~/Content/plugins/toastr/toastr.min.css",
                       "~/Content/plugins/iCheck/custom.css",
                       "~/Scripts/plugins/gritter/jquery.gritter.css",
                       "~/Content/animate.css",
                       "~/Content/style.css"));

            //My project required bundles
            bundles.Add(new ScriptBundle("~/bundles/plugin").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/plugins/metisMenu/jquery.metisMenu.js",
                        "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js",
                        //"~/Scripts/ocLazyLoad.min.js",
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
                        "~/Scripts/plugins/toastr/toastr.min.js",
                        "~/Scripts/plugins/iCheck/icheck.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/config").Include(
                       "~/app/app.js",
                       "~/app/config/eMSPConfig.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(                       
                        "~/app/components/dashboard/dashboardController.js",
                        "~/app/components/home/homeController.js",
                        "~/app/components/accounts/login/loginController.js",
                        "~/app/components/accounts/registration/registrationController.js",
                        "~/app/components/accounts/forgotPassword/forgotPasswordController.js",
                        "~/app/components/Company/Controller/searchCompanyController.js",
                        "~/app/components/Company/Controller/createCompanyController.js"                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                        "~/app/services/authService.js",
                        "~/app/services/authInterceptorService.js",
                        "~/app/services/tokensManagerService.js",
                        "~/app/services/ordersService.js",
                        "~/app/directives/eMSPDirectives.js",
                        "~/app/shared/eMSPFactory.js"
                        ));

            //Other code has been removed for clarity
            BundleTable.EnableOptimizations = false;
        }
    }
}
