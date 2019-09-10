using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Course.Chapter1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // WithoutThread(); // 00:00:09.9214564
            // TwoThreads(); // 00:00:10.4325231
            // FourThreads(); // 00:00:10.2037292

            Console.WriteLine("End.");
        }

        private static void WithoutThread()
        {
            var begin = DateTime.Now;

            var numbers = new List<int>();

            var quantity = 1000000;

            for (int i = -0; i < quantity; i++)
            {
                numbers.Add(i);
            }

            foreach (var number in numbers)
            {
                Operation(number);
            }

            var end = DateTime.Now;

            var duration = end - begin;

            Console.WriteLine($"Duration: {duration}.");
        }

        private static void TwoThreads()
        {
            var begin = DateTime.Now;

            var numbers = new List<int>();

            var quantity = 1000000;

            for (int i = -0; i < quantity; i++)
            {
                numbers.Add(i);
            }

            var half = quantity / 2;

            var firstHalf = numbers.Take(half);
            var secondHalf = numbers.Skip(half).Take(half);

            var threadOne = new Thread(() =>
            {
                foreach (var number in firstHalf)
                {
                    Operation(number);
                }
            });

            var threadTwo = new Thread(() =>
            {
                foreach (var number in secondHalf)
                {
                    Operation(number);
                }
            });

            threadOne.Start();
            threadTwo.Start();

            threadOne.Join();
            threadTwo.Join();

            var end = DateTime.Now;

            var duration = end - begin;

            Console.WriteLine($"Duration: {duration}.");
        }

        private static void FourThreads()
        {
            var begin = DateTime.Now;

            var numbers = new List<int>();

            var quantity = 1000000;

            for (int i = -0; i < quantity; i++)
            {
                numbers.Add(i);
            }

            var quartile = quantity / 4;

            var firstQuartile = numbers.Take(quartile);
            var secondQuartile = numbers.Skip(quartile).Take(quartile);
            var thirdQuartile = numbers.Skip(quartile * 2).Take(quartile);
            var fourthQuartile = numbers.Skip(quartile * 3).Take(quartile);

            var threadOne = new Thread(() =>
            {
                foreach (var number in firstQuartile)
                {
                    Operation(number);
                }
            });

            var threadTwo = new Thread(() =>
            {
                foreach (var number in secondQuartile)
                {
                    Operation(number);
                }
            });

            var threadThree = new Thread(() =>
            {
                foreach (var number in thirdQuartile)
                {
                    Operation(number);
                }
            });

            var threadFour = new Thread(() =>
            {
                foreach (var number in fourthQuartile)
                {
                    Operation(number);
                }
            });

            threadOne.Start();
            threadTwo.Start();
            threadThree.Start();
            threadFour.Start();

            threadOne.Join();
            threadTwo.Join();
            threadThree.Join();
            threadFour.Join();

            var end = DateTime.Now;

            var duration = end - begin;

            Console.WriteLine($"Duration: {duration}.");
        }

        public static void Operation(int x)
        {
            Console.WriteLine(x * 2000 / 5 * 2000 / 5);
        }
    }
}
