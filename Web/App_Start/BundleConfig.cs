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
                      "~/Scripts/js/popper.min.js", "~/Scripts/js/bootstrap.min.js"));

            bundles.Add(new Bundle("~/bundles/dataTableInit").Include(
                      "~/Scripts/dataTableInit.js"));

            bundles.Add(new Bundle("~/bundles/complementos").Include("~/Scripts/js/vendor/modernizr-2.8.3.min.js", "~/Scripts/js/bar-chart.js", "~/Scripts/js/jquery.slicknav.min.js",
                "~/Scripts/js/jquery.slimscroll.min.js", "~/Scripts/js/line-chart.js", "~/Scripts/js/metisMenu.min.js", "~/Scripts/js/owl.carousel.min.js", "~/Scripts/js/pie-chart.js", "~/Scripts/js/plugins.js",
                "~/Scripts/js/scripts.js", "~/Scripts/dataTable/responsive.dataTables.min.js", "~/Scripts/dataTable/jquery.dataTables.min.js", "~/Scripts/moment.min.js", "~/Scripts/jquery.datetimepicker.full.js", "~/Scripts/bs-stepper.min.js"));

            bundles.Add(new Bundle("~/bundles/jqueryUI").Include("~/Scripts/jqueryUI/jquery-ui.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css", "~/Content/css/default-css.css", "~/Content/css/metisMenu.css", "~/Content/css/owl.carousel.min.css", "~/Content/css/responsive.css","~/Content/css/slicknav.min.css",
                      "~/Content/css/styles.css", "~/Content/css/typography.css", "~/Content/css/themify-icons.css", "~/Content/dataTable/responsive.dataTables.min.css", "~/Content/dataTable/jquery.dataTables.min.css", "~/Content/bs-stepper.min.css",
                      "~/Content/jquery.datetimepicker.min.css"
                     ));

            bundles.Add(new StyleBundle("~/Content/jqueryUI").Include(
                    "~/Content/jqueryUI/jquery-ui.min.css", "~/Content/jqueryUI/jquery-ui.structure.min.css", "~/Content/jqueryUI/jquery-ui.theme.min.css"
                     ));




            bundles.Add(new StyleBundle("~/Content/tableData").Include(
                      "~/Content/tableData.css"));
        }
    }
}
