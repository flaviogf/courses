namespace ArdalisRating.ISP
{
    public interface IRatingContext : ILogger
    {
        RatingEngine Engine { get; set; }

        string LoadPolicyFromFile();

        Policy GetPolicyFromJsonString(string jsonString);

        Rater CreateRaterForPolicy(Policy policy);
    }
}
