using System.Web;
using System.Web.Optimization;

namespace CodeSnippets3
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/AwesomeAngularMVCApp")
            .IncludeDirectory("~/Scripts/Controllers", "*.js")
            .Include("~/Scripts/AwesomeAngularMVCApp.js"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
