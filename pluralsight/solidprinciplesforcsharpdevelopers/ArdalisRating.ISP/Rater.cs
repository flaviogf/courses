namespace ArdalisRating.ISP
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater _ratingUpdater;

        public Rater(IRatingUpdater ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }

        public ILogger Logger { get; set; } = new ConsoleLogger();

        public abstract void Rate(Policy policy);
    }
}
