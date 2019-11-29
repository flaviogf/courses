using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Section11.ParallelTaskIntroduction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UsingParallelInvoke();

            UsingParallelFor();

            UsingParallelLoopResultAndParallelLoopState();
        }

        private static void UsingParallelLoopResultAndParallelLoopState()
        {
            var result = Parallel.For(0, 100, (item, state) =>
            {
                if (item == 75)
                {
                    state.Break();
                }

                Console.WriteLine("Item {0}", item);
            });

            Console.WriteLine("It has been completed without break: {0}", result.IsCompleted);

            Console.WriteLine("Completed count: {0}", result.LowestBreakIteration);
        }

        private static void UsingParallelFor()
        {
            Measure("Sequence", () =>
            {
                foreach (var item in Enumerable.Range(0, 100))
                {
                    Process(item);
                }
            });

            Measure("Parallel For", () =>
            {
                Parallel.For(0, 100, (item) => Process(item));
            });

            Measure("Parallel ForEach", () =>
            {
                Parallel.ForEach(Enumerable.Range(0, 100), (item) => Process(item));
            });
        }

        private static void UsingParallelInvoke()
        {
            Measure("Sequence", () =>
            {
                CookPasta();
                BraiseSauce();
            });

            Measure("Parallel", () =>
            {
                Parallel.Invoke(CookPasta, BraiseSauce);
            });
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

        public static void Process(object item)
        {
            Console.WriteLine("Process {0} was started.", item);
            Thread.Sleep(100);
            Console.WriteLine("Process {0} was ended", item);
        }

        public static void Measure(string title, Action action)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            Console.WriteLine(title);

            Console.WriteLine(new string('*', 100));

            action();

            Console.WriteLine(new string('*', 100));

            stopwatch.Stop();

            Console.WriteLine("It lasted {0} ms", stopwatch.ElapsedMilliseconds);

            Console.WriteLine(new string('*', 100));
        }
    }
}
