using System.Web.Optimization;

namespace PeymanMq
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Styles/MainCss").Include(
                      "~/Content/Styles/reset.css",
                      "~/Content/Styles/bootstrap.css",
                      "~/Content/Styles/font-awesome.css",
                      "~/Content/Styles/main.css"));

            bundles.Add(new ScriptBundle("~/Content/Scripts/MainJs").Include(
                        "~/Content/Scripts/jquery-2.1.1.min.js",
                        "~/Content/Scripts/jquery.easing.1.3.js"));

            bundles.Add(new ScriptBundle("~/Content/Scripts/MainJs2").Include(
                        "~/Content/Scripts/jquery.validate.min.js",
                        "~/Content/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Content/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Content/Scripts/handlebars-v4.0.2.js"));

            bundles.Add(new ScriptBundle("~/Content/Scripts/MainJs3").Include(
                        "~/Content/Scripts/bootstrap.js",
                        "~/Content/Scripts/modernizr-2.6.1.min.js",
                        "~/Content/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/Content/Scripts/IE/IeJs").Include(
                       "~/Content/Scripts/IE/excanvas.min.js",
                       "~/Content/Scripts/IE/html5shiv.min.js",
                       "~/Content/Scripts/IE/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/Plugins/Revolution-Slider/RevolutionSliderCss").Include(
                        "~/Content/Plugins/Revolution-Slider/revolution-slider.css"));
            bundles.Add(new ScriptBundle("~/Content/Plugins/Revolution-Slider/RevolutionSliderJs").Include(
                        "~/Content/Plugins/Revolution-Slider/themepunch.plugins.min.js",
                        "~/Content/Plugins/Revolution-Slider/themepunch.revolution.min.js"));

            bundles.Add(new StyleBundle("~/Content/Plugins/OwlCarousel/OwlCarouselCss").Include(
                        "~/Content/Plugins/OwlCarousel/owlcarousel.css"));
            bundles.Add(new ScriptBundle("~/Content/Plugins/OwlCarousel/OwlCarouselJs").Include(
                        "~/Content/Plugins/OwlCarousel/owlcarousel.js"));

            bundles.Add(new StyleBundle("~/Content/Plugins/FancyBox/FancyBoxCss").Include(
                       "~/Content/Plugins/FancyBox/fancybox.css"));
            bundles.Add(new ScriptBundle("~/Content/Plugins/FancyBox/FancyBoxJs").Include(
                        "~/Content/Plugins/FancyBox/fancybox.js",
                        "~/Content/Plugins/FancyBox/mousewheel-3.0.6.js"));

            bundles.Add(new StyleBundle("~/Content/Plugins/RateIt/RateItCss").Include(
                        "~/Content/Plugins/RateIt/rateit.css"));
            bundles.Add(new ScriptBundle("~/Content/Plugins/RateIt/RateItJs").Include(
                        "~/Content/Plugins/RateIt/jquery.rateit.js"));

            bundles.Add(new StyleBundle("~/Content/Plugins/PersianDatePicker/PersianDatePickerCss").Include(
                        "~/Content/Plugins/PersianDatePicker/PersianDatePicker.css"));
            bundles.Add(new ScriptBundle("~/Content/Plugins/PersianDatePicker/PersianDatePickerJs").Include(
                        "~/Content/Plugins/PersianDatePicker/PersianDatePicker.js"));

            bundles.Add(new ScriptBundle("~/Content/Admin/Scripts/AdminMainJs").Include(
                        "~/Content/Admin/Scripts/NanoScroller/jquery.nanoscroller.js",
                        "~/Content/Admin/Scripts/ImgPreview/imgpreview.full.jquery.js",
                        "~/Content/Admin/Scripts/iCheck/icheck.min.js",
                        "~/Content/Admin/Scripts/Select2/select2.full.js",
                        "~/Content/Admin/Scripts/Select2/i18n/fa.js",
                        "~/Content/Admin/Scripts/bootstrap.min.js",
                        "~/Content/Admin/Scripts/sokhan.js",
                        "~/Content/Admin/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/Admin/Styles/AdminMainCss").Include(
                      "~/Content/Admin/Styles/bootstrap.css",
                      "~/Content/Styles/font-awesome.css",
                      "~/Content/Admin/Styles/NanoScroller/nanoscroller.css",
                      "~/Content/Admin/Styles/Select2/select2.css",
                      "~/Content/Admin/Styles/main.css",
                      "~/Content/Admin/Styles/iCheck/icheck.blue.css"));

            bundles.Add(new StyleBundle("~/Content/Admin/Styles/TagEditor/TagEditorCss").Include(
                        "~/Content/Admin/Styles/TagEditor/jquery.tag-editor.css"));

            bundles.Add(new ScriptBundle("~/Content/Admin/Scripts/TagEditor/TagEditorJs").Include(
                        "~/Content/Admin/Scripts/TagEditor/jquery-ui.min.js",
                        "~/Content/Admin/Scripts/TagEditor/jquery.caret.min.js",
                        "~/Content/Admin/Scripts/TagEditor/jquery.tag-editor.js"));
        }
    }
}