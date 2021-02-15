using ArdalisRating.DIP.Core.Interfaces;
using ArdalisRating.DIP.Core.Model;

namespace ArdalisRating.DIP.Core.Raters
{
    public abstract class Rater
    {
        protected readonly ILogger _logger;

        public Rater(ILogger logger)
        {
            _logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}
