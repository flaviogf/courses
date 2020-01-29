using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Paladin.Web.Infra
{
    public class WorkflowAttribute : FilterAttribute, IActionFilter
    {
        public int Current { get; set; }

        public int Required { get; set; }

        public int _highestCompletedStage { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var applicantId = filterContext.HttpContext.Session["@Tracker"];
            if (applicantId != null)
            {
                Guid tracker;
                if (Guid.TryParse(applicantId.ToString(), out tracker))
                {
                    var context = DependencyResolver.Current.GetService<PaladinDbContext>();
                    var _highestCompletedStage = context.Applicant.FirstOrDefault(x => x.Tracker == tracker).WorkFlowStage;
                    if (Required > _highestCompletedStage)
                    {

                        switch (_highestCompletedStage)
                        {
                            case (int)WorkflowValues.ApplicantInfo:
                                filterContext.Result = GenerateRedirectUrl("Create", "Applicant");
                                break;

                            case (int)WorkflowValues.AddressInfo:
                                filterContext.Result = GenerateRedirectUrl("Create", "Address");
                                break;

                            case (int)WorkflowValues.EmploymentInfo:
                                filterContext.Result = GenerateRedirectUrl("Create", "Employment");
                                break;

                            case (int)WorkflowValues.VehicleInfo:
                                filterContext.Result = GenerateRedirectUrl("Create", "Vehicle");
                                break;

                            case (int)WorkflowValues.ProductInfo:
                                filterContext.Result = GenerateRedirectUrl("Create", "Product");
                                break;
                        }
                    }
                }
            }
            else
            {
                if (Current != (int)WorkflowValues.ApplicantInfo)
                {
                    filterContext.Result = GenerateRedirectUrl("Create", "Applicant");
                }
            }
        }


        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var context = DependencyResolver.Current.GetService<PaladinDbContext>();
            var sessionId = filterContext.HttpContext.Session["@Tracker"];
            if (sessionId != null)
            {
                Guid tracker;
                if (Guid.TryParse(sessionId.ToString(), out tracker))
                {
                    if (filterContext.HttpContext.Request.RequestType == "POST" && Current >= _highestCompletedStage)
                    {
                        var applicant = context.Applicant.FirstOrDefault(x => x.Tracker == tracker);
                        applicant.WorkFlowStage = Current;
                        context.SaveChanges();
                    }
                }
            }
        }

        private RedirectToRouteResult GenerateRedirectUrl(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { action, controller }));
        }
    }
}