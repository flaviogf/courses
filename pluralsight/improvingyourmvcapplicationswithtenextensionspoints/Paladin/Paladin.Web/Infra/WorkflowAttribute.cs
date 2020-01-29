using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Paladin.Web.Infra
{
    public class WorkflowAttribute : FilterAttribute, IActionFilter
    {
        public int Current { get; set; }

        public int Required { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logger = DependencyResolver.Current.GetService<ILogger>();

            logger.Debug("|> Workflow => OnActionExecuting()");

            var context = DependencyResolver.Current.GetService<PaladinDbContext>();

            if (filterContext.HttpContext.Session["@Tracker"] == null)
            {
                return;
            }

            var tracker = (Guid)filterContext.HttpContext.Session["@Tracker"];

            var applicant = context.Applicant.FirstOrDefault(it => it.Tracker == tracker);

            var allowed = Required <= applicant.WorkFlowStage;

            if (allowed)
            {
                return;
            }

            var workFlowStage = (WorkflowValues)applicant.WorkFlowStage;

            var routes = new Dictionary<WorkflowValues, RouteValueDictionary>
            {
                [WorkflowValues.Begin] = new RouteValueDictionary(new { controller = "Applicant", action = "Create" }),
                [WorkflowValues.ApplicantInfo] = new RouteValueDictionary(new { controller = "Applicante", action = "Create" }),
                [WorkflowValues.AddressInfo] = new RouteValueDictionary(new { controller = "Address", action = "Create" }),
                [WorkflowValues.EmploymentInfo] = new RouteValueDictionary(new { controller = "Employment", action = "Create" }),
                [WorkflowValues.VehicleInfo] = new RouteValueDictionary(new { controller = "Vehicle", action = "Create" }),
                [WorkflowValues.ProductInfo] = new RouteValueDictionary(new { controller = "Product", action = "Create" }),
                [WorkflowValues.Final] = new RouteValueDictionary(new { controller = "Final", action = "Create" }),
            };

            var response = new RedirectToRouteResult(routes[workFlowStage]);

            filterContext.Result = response;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var logger = DependencyResolver.Current.GetService<ILogger>();

            logger.Debug("|> Workflow => OnActionExecuted()");
        }
    }
}