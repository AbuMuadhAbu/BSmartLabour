using System.Web;
using System.Web.Optimization;

namespace SmartLabours
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  
                       //"~/Scripts/jquery-{version}.js",
                          //"~/Scripts/jquery-1.11.1.min.js"
                   
                   //  "~/Scripts/jquery-1.9.1.min.js",
                       "~/Content/Admin/js/jquery-1.11.1.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

        //    bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       // "~/Scripts/jquery.unobtrusive*",
                        //"~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
              "~/Scripts/jquery.validate.min.js",
            "~/Scripts/jquery.validate.unobtrusive.min.js",
             "~/Scripts/jquery.unobtrusive-ajax.min.js"
            // ~/Scripts/jquery.unobtrusive-ajax.min.js
                  ));
    //            <script type="text/javascript" src="lib/jquery-1.10.1.min.js"></script>
    //<script type="text/javascript" src="source/jquery.fancybox.js?v=2.1.5"></script>
    //<link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.5" media="screen" />

            //Script For Fancy Box
             bundles.Add(new ScriptBundle("~/Content/Front/js").Include(           
              "~/Content/Front/js/jquery.flexisel.js",   
              // "~/Content/Front/js/jquery.fancybox.js",    
               "~/Content/source/jquery.fancybox.js",    
            //  "https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.js",
               "~/Content/Front/js/jquery.bxslider.js",   
               "~/Content/Front/js/common.js",
               "~/Scripts/signin.js"
              ));

           
            //Styles for Fancy Box
             bundles.Add(new StyleBundle("~/Content/Front/css").Include(
                 "~/Content/Front/css/flexisel.css",
                "~/Content/Front/css/responsive.css" ,
               // "https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.css",
                //"~/Content/Front/css/jquery.fancybox.css",
                "~/Content/source/jquery.fancybox.css",
                "~/Content/Front/css/jquery.bxslider.css" 
                ));

   
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}