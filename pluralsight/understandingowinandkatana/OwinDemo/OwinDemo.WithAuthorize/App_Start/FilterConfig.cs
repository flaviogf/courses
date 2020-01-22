using System.Web.Mvc;

namespace OwinDemo.WithAuthorize
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilter(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}