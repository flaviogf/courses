using CasaDoCodigo.Web.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using MFile = CasaDoCodigo.Web.Models.File;

namespace CasaDoCodigo.Web.Controllers
{
    public class BookCoverController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IFileUpload _fileUpload;

        public BookCoverController(ApplicationContext context, IFileUpload fileUpload)
        {
            _context = context;
            _fileUpload = fileUpload;
        }

        public async Task<IActionResult> Create(Guid id, IFormFile file)
        {
            var path = await _fileUpload.Upload(file);

            var image = new MFile
            {
                Id = Guid.NewGuid(),
                Path = path,
                Ext = Path.GetExtension(file.FileName)
            };

            await _context.Files.AddAsync(image);

            var book = await _context.Books.SingleAsync(it => it.Id == id);

            book.Cover = image;

            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", "Book", new { id });
        }
    }
}
