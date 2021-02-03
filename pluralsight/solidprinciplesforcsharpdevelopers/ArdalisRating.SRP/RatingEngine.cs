using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating.SRP
{
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();

        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public decimal Rating { get; set; }

        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            var policyJson = PolicySource.GetPolicyFromSource();

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    Logger.Log("Rating AUTO policy...");

                    Logger.Log("Validating policy.");

                    if (string.IsNullOrEmpty(policy.Make))
                    {
                        Logger.Log("Auto policy must specify make");

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
                    Logger.Log("Rating LAND policy.");

                    Logger.Log("Validating policy.");

                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        Logger.Log("Land policy must specify Bond Amount and Valuation.");

                        return;
                    }

                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        Logger.Log("Insufficient bond amount");

                        return;
                    }

                    Rating = policy.BondAmount * 0.05m;

                    break;
                default:
                    Logger.Log("Unknown policy type.");

                    break;
            }

            Logger.Log("Rating completed.");
        }
    }
}
