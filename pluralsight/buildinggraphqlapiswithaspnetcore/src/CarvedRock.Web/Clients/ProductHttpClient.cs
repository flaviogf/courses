using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CarvedRock.Web.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CarvedRock.Web.Clients
{
    public class ProductHttpClient
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductHttpClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["CarvedRockApiUrl"]);

            var response = await client.GetAsync("?query={ products { id name } }");

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<Response<ProductsContainer>>(await response.Content.ReadAsStringAsync());

            return result.Data.Products;
        }
    }
}
