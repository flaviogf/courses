using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Cli.Models;

namespace Store.Cli
{
    public interface IProductDatabaseGateway : IDisposable
    {
        Task<Product> Save(Product product);

        Task<IList<Product>> All();
    }
}
