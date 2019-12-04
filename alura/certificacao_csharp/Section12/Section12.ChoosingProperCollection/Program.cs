using System;
using System.Collections.Generic;

namespace Section12.ChoosingProperCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Example01();

            Example02();

            Example03();
        }

        private static void Example03()
        {
            Console.WriteLine(new string('*', 100));

            var months = new List<string>
            {
                "january", "february", "march", "april", "may", "july", "august", "september", "october", "november", "december", "nonexistent"
            };

            foreach (var month in months)
            {
                Console.WriteLine(month);
            }

            months.RemoveAt(months.Count - 1);

            Console.WriteLine(new string('*', 100));

            foreach (var month in months)
            {
                Console.WriteLine(month);
            }

            months.Insert(5, "june");

            Console.WriteLine(new string('*', 100));

            foreach (var month in months)
            {
                Console.WriteLine(month);
            }
        }

        private static void Example02()
        {
            var stack = new Stack<string>();

            Console.WriteLine(new string('*', 100));

            stack.Push("http://google.com");
            stack.Push("http://alura.com.br");
            stack.Push("http://cursos.alura.com.br");

            foreach (var website in stack)
            {
                Console.WriteLine(website);
            }

            Console.WriteLine(new string('*', 100));

            stack.Pop();

            foreach (var website in stack)
            {
                Console.WriteLine(website);
            }
        }

        private static void Example01()
        {
            var queue = new Queue<string>();

            Console.WriteLine(new string('*', 100));

            queue.Enqueue("Skyline");
            queue.Enqueue("Lancer");
            queue.Enqueue("Camaro");

            foreach (var car in queue)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine(new string('*', 100));

            queue.Dequeue();

            foreach (var car in queue)
            {
                Console.WriteLine(car);
            }
        }
    }
}
