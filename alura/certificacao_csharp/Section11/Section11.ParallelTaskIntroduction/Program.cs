using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Section11.ParallelTaskIntroduction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UsingParallelInvoke();
        }

        private static void UsingParallelInvoke()
        {
            Console.WriteLine("Sequence");

            Console.WriteLine(new string('*', 100));

            Measure(() =>
            {
                CookPasta();
                BraiseSauce();
            });

            Console.WriteLine(new string('*', 100));

            Console.WriteLine("Parallel");

            Console.WriteLine(new string('*', 100));

            Measure(() =>
            {
                Parallel.Invoke(CookPasta, BraiseSauce);
            });

            Console.WriteLine(new string('*', 100));
        }

        public static void CookPasta()
        {
            Console.WriteLine("It begins to cook pasta");
            Thread.Sleep(2000);
            Console.WriteLine("It ends to cook pasta");
        }

        public static void BraiseSauce()
        {
            Console.WriteLine("It begins to braise sauce");
            Thread.Sleep(1000);
            Console.WriteLine("It ends to braise sauce");
        }

        public static void Measure(Action action)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            action();

            stopwatch.Stop();

            Console.WriteLine("It lasted {0} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}
