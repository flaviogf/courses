using FilterExecutingOrder.Filters;
using System.Web.Mvc;

namespace FilterExecutingOrder
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ThirthFilterAttribute());
        }
    }
}
