using CasaDoCodigo.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasaDoCodigo.Web.Lib
{
    public class ShoppingCartSession : IShoppingCart
    {
        private readonly ISession _session;

        public ShoppingCartSession(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public async Task Add(Product product)
        {
            var products = Get();

            products.Add(product);

            Set(products);
        }

        public async Task<IReadOnlyCollection<Product>> Products()
        {
            var products = Get();

            return products;
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
