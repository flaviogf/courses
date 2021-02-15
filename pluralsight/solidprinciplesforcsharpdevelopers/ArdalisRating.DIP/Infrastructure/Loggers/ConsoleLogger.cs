using System;
using ArdalisRating.DIP.Core.Interfaces;

namespace ArdalisRating.DIP.Infrastructure.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
