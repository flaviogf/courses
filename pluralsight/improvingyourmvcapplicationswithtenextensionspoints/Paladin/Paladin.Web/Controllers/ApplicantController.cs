using AutoMapper;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly PaladinDbContext _context;

        private readonly IMapper _mapper;

        public ApplicantController(PaladinDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            if (Session["@Tracker"] is Guid tracker)
            {
                var applicant = await _context.Applicant.FirstOrDefaultAsync(it => it.Tracker == tracker);

                var viewModel = _mapper.Map<ApplicantViewModel>(applicant);

                return View(viewModel);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicantViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (Session["@Tracker"] is Guid existingTracker)
            {
                var existingApplicant = await _context.Applicant.FirstOrDefaultAsync(it => it.Tracker == existingTracker);

                _mapper.Map(viewModel, existingApplicant);

                _context.Entry(existingApplicant).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return RedirectToAction("Create", "Address");
            }

            var tracker = Guid.NewGuid();

            Session["@Tracker"] = tracker;

            var applicant = _mapper.Map<Applicant>(viewModel);

            applicant.Tracker = tracker;

            _context.Applicant.Add(applicant);

            await _context.SaveChangesAsync();

            return RedirectToAction("Create", "Address");
        }
    }
}