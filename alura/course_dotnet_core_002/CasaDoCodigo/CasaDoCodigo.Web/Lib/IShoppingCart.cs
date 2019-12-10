using CasaDoCodigo.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Lib
{
    public interface IShoppingCart
    {
        Task Add(Product product);

        Task<IReadOnlyCollection<Product>> Products();
    }
}
