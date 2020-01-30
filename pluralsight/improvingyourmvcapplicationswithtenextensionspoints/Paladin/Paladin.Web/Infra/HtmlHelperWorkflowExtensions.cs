using System.Web.Mvc;
using System.Web.Routing;

namespace Paladin.Web.Infra
{
    public static class HtmlHelperWorkflowExtensions
    {
        public static MvcHtmlString ProgressItemActionLink(this HtmlHelper target, string action, string controller, string icon)
        {
            var li = new TagBuilder("li");

            li.AddCssClass("progress__item");

            var a = new TagBuilder("a");

            var href = UrlHelper.GenerateUrl("Default", action, controller, null, RouteTable.Routes, target.ViewContext.RequestContext, false);

            a.MergeAttribute("href", href);

            var i = new TagBuilder("i");

            i.AddCssClass("material-icons");

            i.InnerHtml = icon;

            a.InnerHtml = i.ToString(TagRenderMode.Normal);

            li.InnerHtml = a.ToString(TagRenderMode.Normal);

            return new MvcHtmlString(li.ToString(TagRenderMode.Normal));
        }
    }
}