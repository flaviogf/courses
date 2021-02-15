using System.IO;
using ArdalisRating.DIP.Core.Interfaces;

namespace ArdalisRating.DIP.Infrastructure.Loggers
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using var writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"), append: true);

            writer.WriteLine(message);

            writer.Flush();
        }
    }
}
