using AutoMapper;
using CasaDoCodigo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public HomeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var books = _mapper.Map<IList<BookViewModel>>(await _context.Books.ToListAsync());

            return View(books);
        }
    }
}
