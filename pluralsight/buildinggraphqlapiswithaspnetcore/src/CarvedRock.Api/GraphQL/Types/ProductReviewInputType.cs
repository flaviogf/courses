using CarvedRock.Api.Entities;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductReviewInputType : InputObjectGraphType<ProductReview>
    {
        public ProductReviewInputType()
        {
            Name = "ProductReviewInputType";

            Field(it => it.Title);
            Field(it => it.Review);
            Field(it => it.ProductId);
        }
    }
}
