using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        public void Rate()
        {
            Console.WriteLine("Starting rate.");

            Console.WriteLine("Loading policy.");

            var policyJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "policy.json"));

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    Console.WriteLine("Rating AUTO policy...");

                    Console.WriteLine("Validating policy.");

                    if (string.IsNullOrEmpty(policy.Make))
                    {
                        Console.WriteLine("Auto policy must specify make");

                        return;
                    }

                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }

                        Rating = 900m;
                    }

                    break;
                case PolicyType.Land:
                    Console.WriteLine("Rating LAND policy.");

                    Console.WriteLine("Validating policy.");

                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        Console.WriteLine("Land policy must specify Bond Amount and Valuation.");

                        return;
                    }

                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        Console.WriteLine("Insufficient bond amount");

                        return;
                    }

                    Rating = policy.BondAmount * 0.05m;

                    break;
                default:
                    Console.WriteLine("Unknown policy type.");

                    break;
            }

            Console.WriteLine("Rating completed.");
        }
    }
}
