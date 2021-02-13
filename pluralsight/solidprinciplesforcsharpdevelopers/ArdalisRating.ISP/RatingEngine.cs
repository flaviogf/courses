namespace ArdalisRating.ISP
{
    public class RatingEngine
    {
        public IRatingContext Context { get; set; }

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
