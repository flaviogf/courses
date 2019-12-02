using System;
using System.Linq;
using System.Threading;

namespace Section11.WorkingWithThread
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Example01();

            Example02();

            Example03();

            Console.WriteLine("Application has been finished");
        }

        private static void Example01()
        {
            var thread1 = new Thread(DoWork);
            thread1.Start("Thread 1");

            var thread2 = new Thread(DoWork);
            thread2.Start("Thread 2");

            thread1.Join();
            thread2.Join();
        }

        private static void Example02()
        {
            var stopped = false;

            var spinner = new Thread(() =>
            {
                var sequence = new string[] { "+", "x", "+", "x" };

                while (!stopped)
                {
                    foreach (var character in sequence)
                    {
                        var message = $"It's working {character}";
                        Console.Write(new string('\r', message.Length));
                        Console.Write(message);
                        Thread.Sleep(100);
                    }
                }

                Console.WriteLine();
            });

            spinner.Start();

            var thread1 = new Thread(Beep);
            thread1.Start("Thread 1");

            var thread2 = new Thread(Beep);
            thread2.Start("Thread 2");

            thread1.Join();
            thread2.Join();

            stopped = true;

            spinner.Join();
        }

        private static void Example03()
        {
            void Work(int item)
            {
                Console.WriteLine("Thread Id: {0} ==> Item: {1}", Thread.CurrentThread.ManagedThreadId, item);
            }

            foreach (var item in Enumerable.Range(0, 100))
            {
                ThreadPool.QueueUserWorkItem((state) => Work(item));
            }

            while (ThreadPool.PendingWorkItemCount > 0)
            {
                Thread.Sleep(250);
            }
        }

        public static void DoWork(object name)
        {
            Console.WriteLine($"Work {name} have been started");
            Thread.Sleep(2000);
            Console.WriteLine($"Work {name} have been finished");
        }

        public static void Beep(object name)
        {
            Console.Beep();
            Thread.Sleep(2000);
            Console.Beep();
        }
    }
}
