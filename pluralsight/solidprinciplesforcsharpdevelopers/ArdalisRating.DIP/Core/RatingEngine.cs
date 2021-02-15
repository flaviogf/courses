using ArdalisRating.DIP.Core.Interfaces;
using ArdalisRating.DIP.Core.Raters;

namespace ArdalisRating.DIP.Core
{
    public class RatingEngine
    {
        private readonly ILogger _logger;

        private readonly IPolicySource _policySource;

        private readonly IPolicySerializer _policySerializer;

        private readonly RaterFactory _raterFactory;

        public RatingEngine(ILogger logger, IPolicySource policySource, IPolicySerializer policySerializer, RaterFactory raterFactory)
        {
            _logger = logger;
            _policySource = policySource;
            _policySerializer = policySerializer;
            _raterFactory = raterFactory;
        }

        public decimal Rating { get; set; }

        public void Rate()
        {
            _logger.Log("Starting rate.");

            _logger.Log("Loading policy.");

            var policyJson = _policySource.GetPolicyFromSource();

            var policy = _policySerializer.GetPolicyFromJsonString(policyJson);

            var rater = _raterFactory.Create(policy);

            Rating = rater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
