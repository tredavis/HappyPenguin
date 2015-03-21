using System.Web;
using System.Web.Optimization;

namespace HappyPenguin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/searchStyle.css",
                      "~/Content/Site.css"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/app/App.js",
                  "~/app/searchButton.js",
                "~/app/Service/SearchService.js",
                "~/app/Service/ebayService.js",
                "~/app/Service/LoginService.js",
                "~/app/Service/CartService.js",
                "~/app/Service/firebaseService.js",
                "~/app/Service/registrationService.js",
                "~/app/Controller/LoginController.js",
                "~/app/Controller/CartController.js",
                "~/app/Controller/FrontController.js",
                "~/app/Controller/SearchController.js",
                "~/app/Controller/RegistrationController.js"
                ));
        }
    }
}
