using System.Web;
using System.Web.Optimization;

namespace jewellry
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Scripts/ie8").Include(
                    "~/Scripts/respond.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/bottom").Include(
                    "~/Content/plugins/jquery-2.1.1.min.js",
                    "~/Content/plugins/jquery.isotope.js",
                    "~/Content/plugins/masonry.js",
                    "~/Content/plugins/bootstrap/js/bootstrap.min.js",
                    "~/Content/plugins/magnific-popup/jquery.magnific-popup.min.js",
                    "~/Content/plugins/owl-carousel/owl.carousel.min.js",
                    "~/Content/plugins/knob/js/jquery.knob.js",
                    "~/Content/plugins/flexslider/jquery.flexslider-min.js",
                    "~/Content/plugins/revolution-slider/js/jquery.themepunch.plugins.min.js",
                    "~/Content/plugins/revolution-slider/js/jquery.themepunch.revolution.min.js",
                    "~/Content/plugins/revolution_slider.js",
                    "~/Scripts/revolution_slider.js",
                    "~/Scripts/scripts.js"
                ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/plugins").Include(
                    "~/Content/plugins/bootstrap/css/bootstrap.min.css",
                    "~/Content/plugins/owl-carousel/owl.pack.css",
                    "~/Content/plugins/magnific-popup/magnific-popup.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/css/font-awesome.css",
                    "~/Content/css/sky-forms.css",
                    "~/Content/css/weather-icons.min.css",
                    "~/Content/css/line-icons.css",
                    "~/Content/css/animate.css",
                    "~/Content/css/flexslider.css",
                    "~/Content/css/revolution-slider.css",
                    "~/Content/css/layerslider.css",
                    "~/Content/css/essentials.css",
                    "~/Content/css/layout.css",
                    "~/Content/css/header-default.css",
                    "~/Content/css/footer-default.css",
                    "~/Content/css/color_scheme/red.css"
                ));
        }
    }
}
