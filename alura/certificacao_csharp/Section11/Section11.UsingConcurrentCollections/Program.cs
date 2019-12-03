using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Section11.UsingConcurrentCollections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var products = new string[] { "sweet potato", "chicken", "oatmeal" };

            var stock = new ConcurrentDictionary<string, int>();

            var thread1 = new Thread(() =>
            {
                foreach (var product in products)
                {
                    int current;

                    do
                    {
                        current = stock.GetOrAdd(product, 0);
                        Console.WriteLine("{0} trying update {1} {2}", Thread.CurrentThread.Name, product, current + 1);
                    } while (!stock.TryUpdate(product, current + 1, current));
                }
            })
            {
                Name = "Thread 1"
            };

            var thread2 = new Thread(() =>
            {

                foreach (var product in products)
                {
                    int current;

                    do
                    {
                        current = stock.GetOrAdd(product, 0);
                        Console.WriteLine("{0} trying update {1} {2}", Thread.CurrentThread.Name, product, current + 1);
                    } while (!stock.TryUpdate(product, current + 1, current));
                }
            })
            {
                Name = "Thread 2"
            };

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine(new string('*', 100));

            foreach (var (key, value) in stock)
            {
                Console.WriteLine("Product: {0} | Quantity: {1}", key, value);
            }
        }
    }
}
