namespace ArdalisRating.ISP
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine ratingEngine)
        {
            return policy.Type switch
            {
                "Auto" => new AutoPolicyRater(new RatingUpdater(ratingEngine)),
                "Land" => new LandPolicyRater(new RatingUpdater(ratingEngine)),
                _ => new UnknownPolicyRater(new RatingUpdater(ratingEngine))
            };
        }
    }
}
