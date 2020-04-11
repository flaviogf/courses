using Microsoft.EntityFrameworkCore;
using PSStore.Application;
using PSStore.Domain.Products;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PSStore.Persistence.Products
{
    public class EFProductRepository : IProductRepository
    {
        private readonly PSStoreDbContext _context;

        public EFProductRepository(PSStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Get(Guid id)
        {
            var product = await _context.Products.FirstAsync(it => it.Id == id);

            return product;
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }
    }
}
