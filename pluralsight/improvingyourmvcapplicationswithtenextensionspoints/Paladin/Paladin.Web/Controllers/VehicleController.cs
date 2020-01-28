using AutoMapper;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly PaladinDbContext _context;

        private readonly IMapper _mapper;

        public VehicleController(PaladinDbContext context, IMapper mapper)
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

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker);

            if (vehicle == null)
            {
                return View();
            }

            var viewModel = _mapper.Map<VehicleViewModel>(vehicle);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleViewModel viewModel)
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

            var existingVehicle = await _context.Vehicles.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker);

            if (existingVehicle != null)
            {
                _mapper.Map(viewModel, existingVehicle);
                _context.Entry(existingVehicle).State = EntityState.Modified;
            }
            else
            {
                var vehicle = _mapper.Map<Vehicle>(viewModel);
                vehicle.Applicant = applicant;
                _context.Vehicles.Add(vehicle);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Create", "Product");
        }
    }
}