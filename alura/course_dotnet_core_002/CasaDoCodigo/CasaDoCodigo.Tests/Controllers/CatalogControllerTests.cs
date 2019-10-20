using System;
using System.Collections.Generic;
using System.Linq;
using CasaDoCodigo.Web.Infrastrucutre;
using CasaDoCodigo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CasaDoCodigo.Web.Controllers
{
    public class CatalogControllerTests : IDisposable
    {
        private readonly CatalogController _catalogController;

        private readonly ApplicationContext _context;

        public CatalogControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("catalog.db").Options;

            _context = new ApplicationContext(options);

            _catalogController = new CatalogController(_context);
        }

        [Fact]
        public void IndexShouldReturnCorrectViewWhenAccessIt()
        {
            var produt = new Product
            {
                Code = "100",
                Name = "Xbox",
                Price = 190000
            };

            _context.Products.Add(produt);

            _context.SaveChanges();

            var response = _catalogController.Index();

            Assert.IsType<ViewResult>(response);
        }

        [Fact]
        public void IndexShouldReturnAListOfProductWhenIt()
        {
            var produt = new Product
            {
                Code = "100",
                Name = "Xbox",
                Price = 190000
            };

            _context.Products.Add(produt);

            _context.SaveChanges();

            var response = _catalogController.Index();

            var result = Assert.IsType<ViewResult>(response);

            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(result.ViewData.Model);

            Assert.Single(model);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
