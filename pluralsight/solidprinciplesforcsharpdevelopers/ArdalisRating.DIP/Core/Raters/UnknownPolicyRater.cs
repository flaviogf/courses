using ArdalisRating.DIP.Core.Interfaces;
using ArdalisRating.DIP.Core.Model;

namespace ArdalisRating.DIP.Core.Raters
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ILogger logger) : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            _logger.Log("Unknown policy type");

            return 0;
        }
    }
}
