using CarvedRock.Api.Entities;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductTypeEnumType : EnumerationGraphType<EProductType>
    {
        public ProductTypeEnumType()
        {
            Name = "Type";
            Description = "Type of product";
        }
    }
}
