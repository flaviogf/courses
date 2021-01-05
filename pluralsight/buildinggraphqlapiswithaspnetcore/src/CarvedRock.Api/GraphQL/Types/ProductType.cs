using CarvedRock.Api.Entities;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(it => it.Id);
            Field(it => it.Name);
            Field(it => it.Description);
            Field(it => it.IntroducedAt);
            Field(it => it.PhotoFileName);
            Field(it => it.Price);
            Field(it => it.Rating);
            Field(it => it.Stock);
            Field<ProductTypeEnumType>("Type", "The type of product");
        }
    }
}
