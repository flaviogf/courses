using CreatingCustomHttpModule.Configuration;
using System;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CreatingCustomHttpModule
{
    public class RedirectHttpModule : IHttpModule
    {
        public HttpApplication _context { get; set; }

        public void Init(HttpApplication context)
        {
            _context = context;

            context.MapRequestHandler += Application_RequestHandler;
        }

        public void Application_RequestHandler(object sender, EventArgs args)
        {
            var section = (RedirectSection)WebConfigurationManager.GetWebApplicationSection("redirect");

            foreach (RedirectElement item in section.Elements)
            {
                if (item.Old == _context.Request.Url.AbsolutePath)
                {
                    _context.Response.Redirect(item.Current);
                }
            }
        }

        public void Dispose()
        {
        }
    }
}