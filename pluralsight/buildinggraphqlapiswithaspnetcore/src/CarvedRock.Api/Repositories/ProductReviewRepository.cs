using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarvedRock.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly CarvedRockDbContext _context;

        public ProductReviewRepository(CarvedRockDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductReview>> GetAll(int productId)
        {
            return await _context.Reviews.Where(it => it.ProductId == productId).ToListAsync();
        }

        public async Task<ProductReview> Add(ProductReview productReview)
        {
            _context.Reviews.Add(productReview);

            await _context.SaveChangesAsync();

            return productReview;
        }
    }
}
