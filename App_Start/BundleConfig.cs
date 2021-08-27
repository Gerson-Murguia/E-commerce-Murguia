using System.Web;
using System.Web.Optimization;

namespace Proyecto05ciclo.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));
            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.bundle.min.js"
            ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/PluginsCSS").Include(

                ////FUENTE FONTAWESOME
                //"~/Content/Plugins/fontawesome-free-5.15.2/css/all.min.css",

                ////SWEET ALERT
                //"~/Content/Plugins/sweetalert2/css/sweetalert.css",

                //DATATABLE
                "~/Content/DataTables/css/jquery.dataTables.min.css",
                "~/Content/DataTables/css/responsive.dataTables.min.css"
            ));
            
            bundles.Add(new StyleBundle("~/Content/PluginsJS").Include(

                // //FUENTE FONTAWESOME,
                // "~/Content/Plugins/fontawesome-free-5.15.2/js/all.min.js",

                ////SWEET ALERT
                "~/Scripts/SweetAlert/sweetalert.min.js",
                   
                //DATATABLE JS
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.responsive.min.js",
                ////LOADING OVERLAY
                "~/Scripts/loadingoverlay.min.js"

            ));
        }

    }
}