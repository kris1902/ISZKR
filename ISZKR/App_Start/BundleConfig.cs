using System.Web;
using System.Web.Optimization;

namespace ISZKR
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
             ));

            // Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                      "~/Scripts/moment.js",
                      "~/Scripts/PersonEdit.js",
                      "~/Scripts/PhotoEdit.js",
                      "~/Scripts/EventsEdit.js",
                      "~/Scripts/SettingsEdit.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/edit-style.css",
                      "~/Content/family-tree-style.css",
                      "~/Content/gallery-style.css",
                      "~/Content/navigation-style.css",
                      "~/Content/search-gallery-style.css",
                      "~/Content/funky-radio.css",
                      "~/Content/assets/summernote/summernote.css"));

            bundles.Add(new ScriptBundle("~/Content/TableEdit").Include(
                      "~/Scripts/TablesEdit.js",
                      "~/Scripts/Moment.js"));

            bundles.Add(new ScriptBundle("~/Content/Summernote").Include(
                    "~/Content/assets/summernote/summernote.js"));
        }
    }
}
