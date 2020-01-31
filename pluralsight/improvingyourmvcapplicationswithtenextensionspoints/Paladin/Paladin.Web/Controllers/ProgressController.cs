using Paladin.Web.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    public class ProgressController : Controller
    {
        private readonly PaladinDbContext _context;

        public ProgressController(PaladinDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index(int current)
        {
            if (Session["@Tracker"] is Guid tracker)
            {
                var applicant = _context.Applicant.FirstOrDefault(it => it.Tracker == tracker);

                return PartialView(new ProgressViewModel { Current = current, Highest = applicant.WorkFlowStage });
            }

            return PartialView(new ProgressViewModel { Current = 10, Highest = 0 });
        }
    }
}