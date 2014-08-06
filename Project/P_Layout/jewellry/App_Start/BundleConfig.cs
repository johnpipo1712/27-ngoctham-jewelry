using System.Web;
using System.Web.Optimization;

namespace jewellry
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/css/fonts.googleapis.css",
                    "~/Content/plugins/bootstrap/css/bootstrap.min.css",
                    "~/Content/css/font-awesome.css",
                    "~/Content/css/sky-forms.css",
                    "~/Content/css/weather-icons.min.css",
                    "~/Content/css/line-icons.css",
                    "~/Content/plugins/owl-carousel/owl.pack.css",
                    "~/Content/plugins/magnific-popup/magnific-popup.css",
                    "~/Content/css/animate.css",
                    "~/Content/css/flexslider.css",
                    "~/Content/css/revolution-slider.css",
                    "~/Content/css/layerslider.css",
                    "~/Content/css/layout-shop.css",
                    "~/Content/css/essentials.css",
                    "~/Content/css/layout.css",
                    "~/Content/css/header-3.css",
                    "~/Content/css/footer-default.css",
                    "~/Content/css/color_scheme/red.css",
                    "~/Content/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/Script/js/modernize").Include(
                    "~/Content/plugins/modernizr.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Script/js/ie8").Include(
                    "~/Content/plugins/respond.js"
                ));

            bundles.Add(new ScriptBundle("~/Script/js").Include(
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
                    "~/Scripts/revolution_slider.js",
                    "~/Scripts/scripts.js"
                ));
        }
    }
}
