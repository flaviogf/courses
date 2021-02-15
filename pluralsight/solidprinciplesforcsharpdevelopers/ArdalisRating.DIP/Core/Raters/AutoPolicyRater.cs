using ArdalisRating.DIP.Core.Interfaces;
using ArdalisRating.DIP.Core.Model;

namespace ArdalisRating.DIP.Core.Raters
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ILogger logger) : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");

            _logger.Log("Validatin policy");

            if (string.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");

                return 0;
            }

            if (policy.Make != "BMW")
            {
                return 0;
            }

            if (policy.Deductible < 500)
            {
                return 1000;
            }

            return 900;
        }
    }
}
