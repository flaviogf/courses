using AutoMapper;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressesViewModel viewModel)
        {
            var main = _mapper.Map<Address>(viewModel.Main);

            var mailing = _mapper.Map<Address>(viewModel.Mailing);

            return RedirectToAction("Create");
        }
    }
}