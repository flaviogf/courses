using System;
using System.Linq;
using System.Threading;

namespace Section11.ImplementingLock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var amountLock = new object();

            var amount = 0;

            var firstSlice = Enumerable.Range(0, 10).ToArray();

            var secondSlice = Enumerable.Range(10, 20).ToArray();

            var thread1 = new Thread(() =>
            {
                foreach (var number in firstSlice)
                {
                    lock (amountLock)
                    {
                        amount += number;

                        Console.WriteLine("{0} {1}", Thread.CurrentThread.Name, amount);
                    }
                }
            })
            {
                Name = "Thread 1"
            };

            var thread2 = new Thread(() =>
            {
                foreach (var number in secondSlice)
                {
                    lock (amountLock)
                    {
                        amount += number;

                        Console.WriteLine("{0} {1}", Thread.CurrentThread.Name, amount);
                    }
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
    }
}
