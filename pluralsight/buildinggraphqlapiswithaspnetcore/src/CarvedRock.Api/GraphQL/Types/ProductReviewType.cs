using CarvedRock.Api.Entities;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductReviewType : ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(it => it.Id);
            Field(it => it.Title);
            Field(it => it.Review);
        }
    }
}
