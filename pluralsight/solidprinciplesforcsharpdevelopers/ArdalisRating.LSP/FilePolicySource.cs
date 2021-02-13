using System.IO;

namespace ArdalisRating.LSP
{
    public class FilePolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "policy.json"));
        }
    }
}
