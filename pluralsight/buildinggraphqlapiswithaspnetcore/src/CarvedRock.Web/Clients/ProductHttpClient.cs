using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CarvedRock.Web.Models;
using Newtonsoft.Json;

namespace CarvedRock.Web.Clients
{
    public class ProductHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(@"http://localhost:5000/graphql?query={ products { id name } }");

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<Response<ProductContainer>>(await response.Content.ReadAsStringAsync());

            return result.Data.Products;
        }
    }
}
