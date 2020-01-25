using System.Web.Optimization;

namespace WiredBrain.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content").Include("~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Scripts").Include("~/Scripts/jquery-3.4.1.js", "~/Scripts/jquery.signalR-2.4.1.js", "~/Scripts/app.js"));
        }
    }
}
