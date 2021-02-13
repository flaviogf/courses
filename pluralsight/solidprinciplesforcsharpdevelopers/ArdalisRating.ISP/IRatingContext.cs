namespace ArdalisRating.ISP
{
    public interface IRatingContext : ILogger
    {
        string LoadPolicyFromFile();

        Policy GetPolicyFromJsonString(string jsonString);

        Rater CreateRaterForPolicy(Policy policy);
    }
}
