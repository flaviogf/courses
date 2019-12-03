using System;
using System.Linq;
using System.Threading;

namespace Section11.UsingMonitorToLockThreads
{
    public class Program
    {
        public static object amountLock = new object();

        public static int amount;

        public static void Main(string[] args)
        {
            var firstSlice = Enumerable.Range(0, 10);

            var secondSlice = Enumerable.Range(10, 20);

            var thread1 = new Thread(() =>
            {
                foreach (var quantity in firstSlice)
                {
                    Increase(quantity);
                }
            })
            {
                Name = "Thread 1"
            };

            var thread2 = new Thread(() =>
            {
                foreach (var quantity in secondSlice)
                {
                    Increase(quantity);
                }
            })
            {
                Name = "Thread 2"
            };

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Final result {0}", amount);
        }

        public static void Increase(int quantity)
        {
            Console.WriteLine("{0} increasing amount in {1} quantity", Thread.CurrentThread.Name, quantity);
            Monitor.Enter(amountLock);
            amount += quantity;
            Monitor.Exit(amountLock);
        }
    }
}
