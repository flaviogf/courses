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
    [Workflow(Current = (int)WorkflowValues.ProductInfo, Required = (int)WorkflowValues.VehicleInfo)]
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
        public async Task<ActionResult> Create()
        {
            var tracker = (Guid)Session["@Tracker"];

            var product = await _context.Products.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker);

            if (product == null)
            {
                return View();
            }

            var viewModel = _mapper.Map<ProductViewModel>(product);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var tracker = (Guid)Session["@Tracker"];

            var applicant = await _context.Applicant.FirstOrDefaultAsync(it => it.Tracker == tracker);

            var existingProduct = await _context.Products.FirstOrDefaultAsync(it => it.Applicant.Tracker == tracker);

            if (existingProduct != null)
            {
                _mapper.Map(viewModel, existingProduct);
                _context.Entry(existingProduct).State = EntityState.Modified;
            }
            else
            {
                var product = _mapper.Map<Product>(viewModel);
                product.Applicant = applicant;
                _context.Products.Add(product);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Final");
        }
    }
}