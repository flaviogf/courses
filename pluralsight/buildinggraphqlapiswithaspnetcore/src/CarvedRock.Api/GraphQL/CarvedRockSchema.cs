using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockSchema : Schema
    {
        public CarvedRockSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<CarvedRockQuery>();
        }
    }
}
