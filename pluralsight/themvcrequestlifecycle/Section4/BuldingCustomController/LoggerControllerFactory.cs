using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace BuldingCustomController
{
    public class LoggerControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var name = $"BuldingCustomController.Controllers.{controllerName[0].ToString().ToUpper()}{controllerName.Substring(1, controllerName.Length - 1)}Controller";

            var type = assembly.GetType(name);

            if (type.GetConstructors().First().GetParameters().Any())
            {
                return (IController)Activator.CreateInstance(type, new DefaultLogger());
            }

            return (IController)Activator.CreateInstance(type);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
        }
    }
}