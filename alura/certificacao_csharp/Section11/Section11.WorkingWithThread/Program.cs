using System;
using System.Threading;

namespace Section11.WorkingWithThread
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var thread1 = new Thread(DoWork);
            thread1.Start("Thread 1");

            var thread2 = new Thread(DoWork);
            thread2.Start("Thread 2");

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Application have been finished");
        }

        public static void DoWork(object name)
        {
            Console.WriteLine($"Work {name} have been started");
            Thread.Sleep(500);
            Console.WriteLine($"Work {name} have been finished");
        }
    }
}
