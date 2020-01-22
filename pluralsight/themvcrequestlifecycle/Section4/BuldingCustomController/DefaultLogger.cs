using System.Diagnostics;

namespace BuldingCustomController
{
    public class DefaultLogger : ILogger
    {
        public void Info(string message)
        {
            Trace.WriteLine(message);
        }
    }
}