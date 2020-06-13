using System.Web;
using System.Web.Optimization;

namespace ASP.net_file_version
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include("~/Scripts/App.js"));
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Content/site.css"));
        }
    }
}
