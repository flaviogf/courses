using System;
using System.Diagnostics;

namespace Section9.StoringMessageOnEventLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!EventLog.SourceExists("StoringMessageOnEventLog"))
            {
                EventLog.CreateEventSource("StoringMessageOnEventLog", "Application");
                return;
            }

            using var log = new EventLog
            {
                Source = "StoringMessageOnEventLog"
            };

            log.WriteEntry($"Time: {DateTime.Now:HH:mm:ss}", EventLogEntryType.Information);
        }
    }
}
