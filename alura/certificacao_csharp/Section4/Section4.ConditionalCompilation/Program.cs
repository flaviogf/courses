#define ADVANCED

using System;
using System.IO;

namespace Section4.ConditionalCompilation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var writer = new StreamWriter("log.txt"))
            {
                Console.SetOut(writer);
#if TRIAL
                Console.WriteLine("TRIAL");
#elif BASIC
                Console.WriteLine("BASIC");
#elif ADVANCED
                Console.WriteLine("ADVANCED");
#endif

                Console.WriteLine("END");
            }
        }
    }
}
