using HandlingFailures.Core;
using System;

namespace HandlingFailures.UI
{
    public class ConsoleLog : ILog
    {
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
