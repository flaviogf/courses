using System.Collections.Generic;
using System.Threading.Tasks;
using CarvedRock.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CarvedRockDbContext _context;

        public ProductRepository(CarvedRockDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(it => it.Id == id);
        }
    }
}
