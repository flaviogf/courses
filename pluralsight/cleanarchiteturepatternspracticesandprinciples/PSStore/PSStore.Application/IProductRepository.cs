using PSStore.Domain.Products;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();

        Task<Product> Get(Guid guid);
    }
}
