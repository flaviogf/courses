using CasaDoCodigo.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasaDoCodigo.Web.Lib
{
    public class SessionShoppingCart : IShoppingCart
    {
        private readonly ISession _session;

        public SessionShoppingCart(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public async Task Add(Product product)
        {
            var products = Get();

            products.Add(product);

            Set(products);
        }

        public async Task Remove(Product product)
        {
            var products = Get();

            products.Remove(product);

            Set(products);
        }

        public async Task<IReadOnlyCollection<Product>> Products()
        {
            var products = Get();

            return products;
        }

        public async Task<int> Total()
        {
            var products = Get();

            var total = products.Sum(it => it.Price);

            return total;
        }

        private List<Product> Get()
        {
            var products = _session.GetString("@products");

            if (products == null)
            {
                return new List<Product>();
            }

            var serializer = new XmlSerializer(typeof(List<Product>));

            var reader = new StringReader(products);

            return (List<Product>)serializer.Deserialize(reader);
        }

        private void Set(List<Product> products)
        {
            var serializer = new XmlSerializer(typeof(List<Product>));

            var writer = new StringWriter();

            serializer.Serialize(writer, products);

            _session.SetString("@products", writer.ToString());
        }
    }
}
