using AutoMapper;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicantViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var applicant = _mapper.Map<Applicant>(viewModel);

            return RedirectToAction("Create");
        }
    }
}