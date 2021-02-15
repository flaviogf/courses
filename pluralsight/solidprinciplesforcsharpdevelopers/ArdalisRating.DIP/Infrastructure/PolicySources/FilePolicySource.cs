using System.IO;
using ArdalisRating.DIP.Core.Interfaces;

namespace ArdalisRating.DIP.Infrastructure.PolicySources
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "policy.json"));
        }
    }
}
