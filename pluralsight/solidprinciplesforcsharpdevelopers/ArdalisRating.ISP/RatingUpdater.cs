namespace ArdalisRating.ISP
{
    public class RatingUpdater : IRatingUpdater
    {
        private readonly RatingEngine _ratingEngine;

        public RatingUpdater(RatingEngine ratingEngine)
        {
            _ratingEngine = ratingEngine;
        }

        public void UpdateRating(decimal rating)
        {
            _ratingEngine.Rating = rating;
        }
    }
}
