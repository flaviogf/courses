using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(IProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>("products", resolve: (it) => productRepository.GetAll());
        }
    }
}
