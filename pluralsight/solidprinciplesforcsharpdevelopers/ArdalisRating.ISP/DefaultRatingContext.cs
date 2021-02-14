namespace ArdalisRating.ISP
{
    public class DefaultRatingContext : IRatingContext
    {
        public RatingEngine Engine { get; set; }

        public Rater CreateRaterForPolicy(Policy policy)
        {
            return new RaterFactory().Create(policy, Engine);
        }

        public Policy GetPolicyFromJsonString(string jsonString)
        {
            return new JsonPolicySerializer().GetPolicyFromJsonString(jsonString);
        }

        public string LoadPolicyFromFile()
        {
            return new FilePolicySource().GetPolicyFromSource();
        }

        public void Log(string message)
        {
            new ConsoleLogger().Log(message);
        }
    }
}
