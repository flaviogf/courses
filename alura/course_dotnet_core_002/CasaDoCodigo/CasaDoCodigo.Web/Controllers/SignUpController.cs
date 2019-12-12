using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.Lib;
using CasaDoCodigo.Web.Models;
using CasaDoCodigo.Web.ViewModels.SignUp;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IAuth _auth;

        public SignUpController(ApplicationContext context, IAuth auth)
        {
            _context = context;
            _auth = auth;
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Store(StoreSignUpViewModel viewModel)
        {
            var user = new User
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone
            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            await _auth.Login(user);

            return RedirectToAction("Create", "Address");
        }
    }
}
