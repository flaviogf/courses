using AutoMapper;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly PaladinDbContext _context;

        private readonly IMapper _mapper;

        public AddressController(PaladinDbContext context, IMapper mapper)
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

            var main = await _context.Addresses.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker && !it.IsMailing);

            if (main == null)
            {
                return View();
            }

            var mailing = await _context.Addresses.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker && it.IsMailing);

            if (mailing == null)
            {
                return View();
            }

            var viewModel = new AddressesViewModel
            {
                Main = _mapper.Map<AddressViewModel>(main),
                Mailing = _mapper.Map<AddressViewModel>(mailing)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddressesViewModel viewModel)
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

            var existingMain = await _context.Addresses.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker && !it.IsMailing);

            if (existingMain != null)
            {
                _mapper.Map(viewModel.Main, existingMain);
                _context.Entry(existingMain).State = EntityState.Modified;
            }
            else
            {
                var main = _mapper.Map<Address>(viewModel.Main);
                main.Applicant = applicant;
                main.IsMailing = false;
                _context.Addresses.Add(main);
            }

            var existingMailing = await _context.Addresses.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker && it.IsMailing);

            if (existingMailing != null)
            {
                _mapper.Map(viewModel.Mailing, existingMailing);
                _context.Entry(existingMailing).State = EntityState.Modified;
            }
            else
            {
                var mailing = _mapper.Map<Address>(viewModel.Mailing);
                mailing.Applicant = applicant;
                mailing.IsMailing = true;
                _context.Addresses.Add(mailing);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Create", "Employment");
        }
    }
}