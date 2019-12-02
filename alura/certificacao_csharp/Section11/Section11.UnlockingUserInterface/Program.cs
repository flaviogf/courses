using System;
using System.Threading;

namespace Section11.UnlockingUserInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopped = false;

            Console.CancelKeyPress += (sender, arguments) =>
            {
                stopped = true;
            };

            var thread = new Thread(() =>
            {
                while (!stopped)
                {
                    Thread.Sleep(100);

                    PrintHour();
                }
            });

            thread.Start();

            thread.Join();
        }

        private static void PrintHour()
        {
            var hour = $"{DateTime.Now:HH:mm:ss}";

            Console.Write(new string('\b', hour.Length));

            Console.Write(hour);
        }
    }
}
