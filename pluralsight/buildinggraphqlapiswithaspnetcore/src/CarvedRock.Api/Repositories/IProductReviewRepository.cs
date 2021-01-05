using System.Collections.Generic;
using System.Threading.Tasks;
using CarvedRock.Api.Entities;

namespace CarvedRock.Api.Repositories
{
    public interface IProductReviewRepository
    {
        Task<IEnumerable<ProductReview>> GetAll(int productId);
    }
}
