using System;
using ArdalisRating.DIP.Core;
using ArdalisRating.DIP.Core.Raters;
using ArdalisRating.DIP.Infrastructure.Loggers;
using ArdalisRating.DIP.Infrastructure.PolicySources;
using ArdalisRating.DIP.Infrastructure.Serializers;

namespace ArdalisRating.DIP.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new ConsoleLogger();

            var engine = new RatingEngine(
                logger,
                new FilePolicySource(),
                new JsonPolicySerializer(),
                new RaterFactory(logger)
            );

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");

                return;
            }

            Console.WriteLine("No rating produced");
        }
    }
}
