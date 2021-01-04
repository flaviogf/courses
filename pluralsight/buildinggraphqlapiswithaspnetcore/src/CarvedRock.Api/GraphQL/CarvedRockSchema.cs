using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockSchema : Schema
    {
        public CarvedRockSchema(CarvedRockQuery query)
        {
            Query = query;
        }
    }
}
