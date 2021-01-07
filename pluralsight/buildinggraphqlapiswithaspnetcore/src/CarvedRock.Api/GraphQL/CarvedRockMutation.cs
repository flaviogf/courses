using CarvedRock.Api.Entities;
using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockMutation : ObjectGraphType
    {
        public CarvedRockMutation(IProductReviewRepository productReviewRepository)
        {
            Field<ProductReviewType>(
                "createReview",
                arguments: new QueryArguments(new QueryArgument<ProductReviewInputType>() { Name = "review" }),
                resolve: (it) =>
                {
                    var productReview = it.GetArgument<ProductReview>("review");

                    return productReviewRepository.Add(productReview);
                }
            );
        }
    }
}
