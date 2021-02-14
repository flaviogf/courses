namespace ArdalisRating.ISP
{
    public class RatingEngine
    {
        public RatingEngine()
        {
            Context.Engine = this;
        }

        public IRatingContext Context { get; set; } = new DefaultRatingContext();

        public decimal Rating { get; set; }

        public void Rate()
        {
            Context.Log("Starting rate.");

            Context.Log("Loading policy.");

            var policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            var rater = Context.CreateRaterForPolicy(policy);

            rater.Rate(policy);

            Context.Log("Rating completed.");
        }
    }
}
