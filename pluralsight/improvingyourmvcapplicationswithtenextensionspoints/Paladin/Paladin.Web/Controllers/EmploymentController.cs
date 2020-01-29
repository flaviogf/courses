using AutoMapper;
using Paladin.Web.Infra;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    [Workflow(Current = (int)WorkflowValues.EmploymentInfo, Required = (int)WorkflowValues.AddressInfo)]
    public class EmploymentController : Controller
    {
        private readonly PaladinDbContext _context;

        private readonly IMapper _mapper;

        public EmploymentController(PaladinDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            if (Session["@Tracker"] == null)
            {
                return RedirectToAction("Create", "Applicant");
            }

            var tracker = (Guid)Session["@Tracker"];

            var primary = await _context.Employements.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker && it.IsPrimary);

            if (primary == null)
            {
                return View();
            }

            var previous = await _context.Employements.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker && !it.IsPrimary);

            if (previous == null)
            {
                return View();
            }

            var viewModel = new EmploymentsViewModel
            {
                Primary = _mapper.Map<EmploymentViewModel>(primary),
                Previous = _mapper.Map<EmploymentViewModel>(previous)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmploymentsViewModel viewModel)
        {
            if (Session["@Tracker"] == null)
            {
                return RedirectToAction("Create", "Applicant");
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var tracker = (Guid)Session["@Tracker"];

            var applicant = await _context.Applicant.FirstOrDefaultAsync(it => it.Tracker == tracker);

            var existingPrimary = await _context.Employements.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker && it.IsPrimary);

            if (existingPrimary != null)
            {
                _mapper.Map(viewModel.Primary, existingPrimary);
                _context.Entry(existingPrimary).State = EntityState.Modified;
            }
            else
            {
                var primary = _mapper.Map<Employement>(viewModel.Primary);
                primary.Applicant = applicant;
                primary.IsPrimary = true;
                _context.Employements.Add(primary);
            }

            var existingPrevious = await _context.Employements.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker && !it.IsPrimary);

            if (existingPrevious != null)
            {
                _mapper.Map(viewModel.Previous, existingPrevious);
                _context.Entry(existingPrevious).State = EntityState.Modified;
            }
            else
            {
                var previous = _mapper.Map<Employement>(viewModel.Previous);
                previous.Applicant = applicant;
                previous.IsPrimary = false;
                _context.Employements.Add(previous);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Create", "Vehicle");
        }
    }
}