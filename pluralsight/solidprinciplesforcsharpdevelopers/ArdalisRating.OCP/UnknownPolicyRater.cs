namespace ArdalisRating.OCP
{
    public class UnknownPolicyRater : IRater
    {
        private readonly RatingEngine _engine;

        private readonly ConsoleLogger _logger;

        public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public void Rate(Policy policy)
        {
            _logger.Log("Unknown policy type.");
        }
    }
}
