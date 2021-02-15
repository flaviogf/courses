using ArdalisRating.DIP.Core.Interfaces;
using ArdalisRating.DIP.Core.Model;

namespace ArdalisRating.DIP.Core.Raters
{
    public class RaterFactory
    {
        private readonly ILogger _logger;

        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }

        public Rater Create(Policy policy)
        {
            return policy.Type switch
            {
                "Auto" => new AutoPolicyRater(_logger),
                "Land" => new LandPolicyRater(_logger),
                _ => new UnknownPolicyRater(_logger)
            };
        }
    }
}
