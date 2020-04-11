using PSStore.Domain.Products;
using System;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface IProductRepository
    {
        Task<Product> Get(Guid guid);
    }
}
