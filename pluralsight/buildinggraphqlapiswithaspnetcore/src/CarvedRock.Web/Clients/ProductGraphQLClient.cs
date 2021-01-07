using System.Threading.Tasks;
using CarvedRock.Web.Models;
using GraphQL.Client.Http;

namespace CarvedRock.Web.Clients
{
    public class ProductGraphQLClient
    {
        private readonly GraphQLHttpClient _client;

        public ProductGraphQLClient(GraphQLHttpClient client)
        {
            _client = client;
        }

        public async Task<Product> Get(int productId)
        {
            var query = new GraphQLHttpRequest
            {
                Query = @"
                    query product($productId: ID!)
                    {
                        product(id: $productId)
                        {
                            id
                            name
                            description
                        }
                    }
                ",
                Variables = new { productId }
            };

            var response = await _client.SendMutationAsync<ProductContainer>(query);

            return response.Data.Product;
        }
    }
}
