using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Cli.Models;

namespace Store.Cli
{
    public class EntityFrameworkProductDatabaseGateway : IProductDatabaseGateway
    {
        private readonly Context _context;

        public EntityFrameworkProductDatabaseGateway(Context context)
        {
            _context = context;
        }

        public async Task<Product> Save(Product product)
        {
            await _context.AddAsync(product);

            return product;
        }

        public async Task<IList<Product>> All()
        {
            var products = await Task<IList<Product>>.Run(() => _context.Products.ToList());

            return products;
        }

        public void Dispose()
        {
            _context.SaveChanges();
        }
    }
}
