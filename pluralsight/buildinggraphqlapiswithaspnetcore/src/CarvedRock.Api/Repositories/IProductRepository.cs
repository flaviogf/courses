using System.Collections.Generic;
using System.Threading.Tasks;
using CarvedRock.Api.Entities;

namespace CarvedRock.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
