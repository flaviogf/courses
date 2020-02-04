using System.Web.Optimization;

namespace ByteBank.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content"));

            bundles.Add(new ScriptBundle("~/Scripts").Include("~/Scripts/jquery-3.4.1.min.js", "~/Scripts/jquery.validate.min.js", "~/Scripts/jquery.validate.unobtrusive.min.js"));
        }
    }
}
