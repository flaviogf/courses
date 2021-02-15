using ArdalisRating.DIP.Core.Model;

namespace ArdalisRating.DIP.Core.Interfaces
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromJsonString(string jsonString);
    }
}
