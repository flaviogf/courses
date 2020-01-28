using AutoMapper;
using Paladin.Web.Models;
using Paladin.Web.ViewModels;
using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly PaladinDbContext _context;

        private readonly IMapper _mapper;

        public ProductController(PaladinDbContext context, IMapper mapper)
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
        public ActionResult Create(ProductViewModel viewModel)
        {
            var product = _mapper.Map<Product>(viewModel);

            return RedirectToAction("Create");
        }
    }
}