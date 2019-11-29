using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Section11.WaitContinuationAndTaskHierarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Number of threads in the beginning: {0}", Process.GetCurrentProcess().Threads.Count);

            Example01();

            Example02();

            Example03();

            Example04();

            Console.WriteLine("Number of threads in the end: {0}", Process.GetCurrentProcess().Threads.Count);
        }

        private static void Example01()
        {
            var task1 = new Task(Work("Task-1"));

            task1.Start();

            var task2 = new Task(Work("Task-2"));

            task2.Start();

            var task3 = Task.Run(Calculate("Task-3"));

            task1.Wait();
            task2.Wait();
            task3.Wait();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Task-3->Result = {0:F2}", task3.Result);
            Console.ResetColor();

            Console.WriteLine("Application was finished");
        }

        private static void Example02()
        {
            var runners = from runner in Enumerable.Range(0, 10) select Task.Run(Run(runner.ToString()));

            Task.WaitAll(runners.ToArray());
        }

        private static void Example03()
        {
            void Begin()
            {
                Console.WriteLine("Begin");

                throw new InvalidOperationException("Unhandled error.");
            }

            void EndWithoutError()
            {
                Console.WriteLine("End without error");
            }

            void EndWithError()
            {
                Console.WriteLine("End with error");
            }

            try
            {
                var task = Task.Run(() => Begin());
                task.ContinueWith((previous) => EndWithoutError(), TaskContinuationOptions.NotOnFaulted);
                task.ContinueWith((previous) => EndWithError(), TaskContinuationOptions.OnlyOnFaulted);
                task.Wait();
            }
            catch (AggregateException ex)
            {
                ex.Print();
            }
        }

        private static void Example04()
        {
            void Parent()
            {
                var children = from i in Enumerable.Range(0, 10) select i;

                foreach (var child in children)
                {
                    Task.Factory.StartNew((name) => Child(name.ToString()), child, TaskCreationOptions.AttachedToParent);
                }
            }

            void Child(string name)
            {
                Console.WriteLine("Child: {0}", name);
            }

            var parent = Task.Factory.StartNew(Parent);

            parent.Wait();
        }

        public static Action Work(string name)
        {
            return () =>
            {
                Console.WriteLine("Work {0} was started", name);
                Console.WriteLine("Work {0} was ended", name);
            };
        }

        public static Func<int> Calculate(string name)
        {
            return () =>
            {
                Console.WriteLine("Calculation {0} was started", name);
                var result = 1000;
                Console.WriteLine("Calculation {0} was ended", name);
                return result;
            };
        }

        public static Action Run(string name)
        {
            var random = new Random();

            return () =>
            {
                Console.WriteLine($"Runner {name} started run");

                var duration = random.Next(1, 5) * 1000;

                Thread.Sleep(duration);

                Console.WriteLine($"Runner {name} stopped run");

                Console.WriteLine($"Runner {name} took {duration} ms to finish the course.");
            };
        }
    }

    public static class AggregateExceptionExtensions
    {
        public static void Print(this AggregateException current)
        {
            Console.WriteLine(new string('.', 100));

            Console.WriteLine("{0,-50} {1,-50}", "Name", "Message");

            Console.WriteLine(new string('.', 100));

            foreach (var ex in current.InnerExceptions)
            {
                Console.WriteLine("{0,-50} {1,-50}", ex.GetType().Name, ex.Message);
            }

            Console.WriteLine(new string('.', 100));
        }
    }
}
