using System.Web.Optimization;

namespace LetsChatAPI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/site.css",
                "~/Content/sweetalert.css"));

            bundles.Add(new StyleBundle("~/Content/chatClient").Include("~/Content/chatwindow.css"));

            //JS
            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                "~/Scripts/admin/jquery-2.1.1.min.js",
                "~/Scripts/admin/modernizr-2.6.2.js",
                "~/Scripts/admin/knockout-3.2.0.js",
                "~/Scripts/admin/bootstrap.js",
                "~/Scripts/admin/angular.min.js",
                "~/Scripts/admin/angular-resource.js",
                "~/Scripts/admin/angular-route.js",
                "~/Scripts/admin/angular-mocks.js",
                "~/Scripts/admin/sweetalert-dev.js",
                "~/Scripts/admin/respond.js",
                "~/app.admin/app.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/chatClientLib")
                .Include("~/Scripts/client/angular.min.js")
                .Include("~/Scripts/client/angular-route.js")
                .Include("~/Scripts/client/jquery-1.10.2.min.js")
                .Include("~/Scripts/client/jquery-ui-1.10.3.min.js")
                .Include("~/Scripts/client/jquery.signalR-2.0.0.min.js")
                .Include("~/Scripts/client/sweetalert-dev.js")
                .Include("~/Scripts/client/signalr/hubs")
                );

            bundles.Add(new ScriptBundle("~/bundles/chatClientJs")
                .Include("~/app.client/chatModule.js")
            );

            BundleTable.EnableOptimizations = false;
        }
    }
}
