using System;
using CasaDoCodigo.Web.Infrastrucutre;
using CasaDoCodigo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CasaDoCodigo.Web.Controllers
{
    public class BasketControllerTests : IDisposable
    {
        private readonly BasketController _basketController;

        private ApplicationContext _context;

        private readonly Product _produt;

        public BasketControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("basket.db").Options;

            _context = new ApplicationContext(options);

            _produt = new Product
            {
                Code = "100",
                Name = "Xbox",
                Price = 190000
            };

            _context.Products.Add(_produt);

            _context.SaveChanges();

            _basketController = new BasketController(_context);
        }

        [Fact]
        public void StoreShouldReturnCorrectViewWhenAccessIt()
        {
            var response = _basketController.Store(_produt.Id);

            Assert.IsType<ViewResult>(response);
        }

        [Fact]
        public void StoreShouldReturnACart()
        {
            var response = _basketController.Store(_produt.Id);

            var result = Assert.IsType<ViewResult>(response);

            Assert.IsAssignableFrom<Cart>(result.ViewData.Model);
        }

        [Fact]
        public void StoreShouldReturnACartWithOnItem()
        {
            var response = _basketController.Store(_produt.Id);

            var result = Assert.IsType<ViewResult>(response);

            var model = Assert.IsAssignableFrom<Cart>(result.ViewData.Model);

            Assert.Single(model.Items);
        }

        [Fact]
        public void StoreShouldAddCartOnDatabase()
        {
            _basketController.Store(_produt.Id);

            Assert.Single(_context.Carts);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
