using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new Bundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js"));

            bundles.Add(new Bundle("~/bundles/dataTableInit").Include(
                      "~/Scripts/dataTableInit.js"));

            bundles.Add(new Bundle("~/bundles/complementos").Include("~/Scripts/fontawesome/all.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site/default-css.css", "~/Content/Site/metisMenu.css", "~/Content/Site/owl.carousel.min.css", "~/Content/Site/responsive.css", "~/Content/Site/slicknav.min.css",
                      "~/Content/Site/styles.css", "~/Content/Site/themify-icons.css", "~/Content/Site/typography.css"));




            bundles.Add(new StyleBundle("~/Content/tableData").Include(
                      "~/Content/tableData.css"));
        }
    }
}
