using CasaDoCodigo.Web.Lib;
using CasaDoCodigo.Web.ViewModels.Address;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAuth _auth;

        public AddressController(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Store(StoreAddressViewModel viewModel)
        {
            var user = await _auth.User();

            return RedirectToAction("Index", "Catalog");
        }
    }
}
