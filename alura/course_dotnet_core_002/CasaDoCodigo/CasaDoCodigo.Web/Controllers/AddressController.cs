using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.Lib;
using CasaDoCodigo.Web.Models;
using CasaDoCodigo.Web.ViewModels.Address;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IAuth _auth;

        public AddressController(ApplicationContext context, IAuth auth)
        {
            _context = context;
            _auth = auth;
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Store(StoreAddressViewModel viewModel)
        {
            var user = await _auth.User();

            var address = new Address
            {
                ZipCode = viewModel.ZipCode,
                Street = viewModel.Street,
                District = viewModel.District,
                City = viewModel.City,
                State = viewModel.State,
                UserId = user.Id
            };

            await _context.Addresses.AddAsync(address);

            await _context.SaveChangesAsync();

            return RedirectToAction("Show", "Order");
        }
    }
}
