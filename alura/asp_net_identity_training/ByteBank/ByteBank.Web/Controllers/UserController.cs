using AutoMapper;
using ByteBank.Web.Infra;
using ByteBank.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(ApplicationUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var users = _mapper.Map<IList<UserViewModel>>(_userManager.Users.ToList());

            return View(users);
        }
    }
}