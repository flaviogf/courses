using System;
using System.Diagnostics;
using System.Web;

namespace PreApplicationStartMethod
{
    public class LoggerModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
            context.EndRequest += Application_EndRequest;
        }

        public void Application_BeginRequest(object sender, EventArgs e)
        {
            Trace.WriteLine("Logger: It's beginning the request,");
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            Trace.WriteLine("Logger: It's ending the request,");
        }

        public void Dispose()
        {
        }
    }
}