using System;
using System.Diagnostics;

namespace Section9.ConditionalCompilation
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if BASIC
            Console.WriteLine("You're on basic mode");
#elif PROFESSIONAL
            Console.WriteLine("You're on professional mode");
#elif ADVANCED
            Console.WriteLine("You're on advanced mode");
#endif

#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            PrintHour();
#pragma warning restore CS0618 // O tipo ou membro é obsoleto

            PrintHourWithMinutes();

            PrintHourWithMinutesAndSeconds();
        }

        [Obsolete("This method is obsolete, try using the new method called 'PrintHourWithMinutes()' or 'PrintHourWithMinutesAndSeconds'")]
        [Conditional("BASIC")]
        public static void PrintHour()
        {
            Console.WriteLine($"{DateTime.Now:HH'h'}");
        }

        [Conditional("PROFESSIONAL")]
        public static void PrintHourWithMinutes()
        {
            Console.WriteLine($"{DateTime.Now:HH'h' mm'm'}");
        }

        [Conditional("ADVANCED")]
        public static void PrintHourWithMinutesAndSeconds()
        {
            Console.WriteLine($"{DateTime.Now:HH'h' mm'm' ss's'}");
        }
    }
}
