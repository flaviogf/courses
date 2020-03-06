using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CasaDoCodigo.Web.ViewModels.Book;
using CasaDoCodigo.Web.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using CasaDoCodigo.Web.Models;
using System;

namespace CasaDoCodigo.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public BookController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = _mapper.Map<IList<BookViewModel>>(await _context.Books.AsNoTracking().ToListAsync());

            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var authorSelectList = _context.Authors.AsNoTracking().Select(it => new SelectListItem
            {
                Value = it.Id.ToString(),
                Text = it.Name
            });

            var viewModel = new CreateBookViewModel
            {
                AuthorSelectList = authorSelectList
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel viewModel)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = viewModel.Title,
            };

            var bookAuthors = viewModel.Authors.Select(it => new BookAuthor
            {
                BookId = book.Id,
                AuthorId = it
            });

            book.Authors = bookAuthors.ToList();

            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", new { id = book.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await _context.Books.Include(it => it.Authors).SingleAsync(it => it.Id.Equals(id));

            var authors = book.Authors.Select(it => it.AuthorId);

            var authorSelectList = _context.Authors.AsNoTracking().Select(it => new SelectListItem
            {
                Selected = authors.Contains(it.Id),
                Value = it.Id.ToString(),
                Text = it.Name
            });

            var viewModel = new EditBookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Authors = authors,
                AuthorSelectList = authorSelectList
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBookViewModel viewModel)
        {
            var book = await _context.Books.Include(it => it.Authors).SingleAsync(it => it.Id == viewModel.Id);

            book.Title = viewModel.Title;

            var bookAuthors = viewModel.Authors.Select(it => new BookAuthor
            {
                BookId = book.Id,
                AuthorId = it
            });

            book.Authors = bookAuthors.ToList();

            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", new { id = book.Id });
        }
    }
}
