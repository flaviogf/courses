using System.Web.Optimization;

namespace Paladin.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var content = new string[]
            {
                "~/Content/minireset.css",
                "~/Content/style.css",
                "~/Content/button/button.css",
                "~/Content/form/form.css",
                "~/Content/form/form-group.css",
                "~/Content/form/form-label.css",
                "~/Content/form/form-input.css",
                "~/Content/home/home.css",
                "~/Content/home/home-link.css",
                "~/Content/home/home-subtitle.css",
                "~/Content/home/home-title.css",
                "~/Content/applicant/applicant.css",
                "~/Content/progress/progress.css",
                "~/Content/progress/progress-item.css",
            };

            var scripts = new string[]
            {
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
            };

            bundles.Add(new StyleBundle("~/Content").Include(content));

            bundles.Add(new ScriptBundle("~/Scripts").Include(scripts));
        }
    }
}