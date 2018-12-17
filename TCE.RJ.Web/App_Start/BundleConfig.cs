using System.Web;
using System.Web.Optimization;

namespace TCE.RJ.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/jquerydatepicker").Include(
						"~/Scripts/DateTimePicker/jquery.datetimepicker.js"));

			bundles.Add(new StyleBundle("~/Content/jquerydatepicker").Include(
					  "~/Scripts/DateTimePicker/jquery.datetimepicker.css"));

			bundles.Add(new ScriptBundle("~/bundles/jquerymasked").Include(
				"~/Scripts/jquery.maskedinput.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
					  "~/Scripts/moment.js",
					  "~/Scripts/bootstrap-datetimepicker.js",
					  "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/knockout-{version}.js",
					  "~/Scripts/knockout-file-bind.js",
					  "~/Scripts/app.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
