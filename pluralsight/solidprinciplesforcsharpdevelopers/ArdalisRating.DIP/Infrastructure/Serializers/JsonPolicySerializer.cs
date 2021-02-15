using ArdalisRating.DIP.Core.Interfaces;
using ArdalisRating.DIP.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating.DIP.Infrastructure.Serializers
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString, new StringEnumConverter());
        }
    }
}
