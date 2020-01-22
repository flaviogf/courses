using System.Reflection;
using System.Web.Mvc;

namespace DecisionMakingWithActionSelectors.Attributes
{
    public class AdminAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return false;
        }
    }
}