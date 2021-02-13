namespace ArdalisRating.LSP
{
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();

        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public decimal Rating { get; set; }

        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            var policyJson = PolicySource.GetPolicyFromSource();

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(this, policy);

            rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
