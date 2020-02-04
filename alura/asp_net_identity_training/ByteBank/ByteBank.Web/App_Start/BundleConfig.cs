using System.Web.Optimization;

namespace ByteBank.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery"));

            bundles.Add(new StyleBundle("~/Content"));
        }
    }
}
