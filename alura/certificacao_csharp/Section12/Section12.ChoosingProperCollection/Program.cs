using System;
using System.Collections.Generic;
using System.Linq;

namespace Section12.ChoosingProperCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Example01();

            Example02();

            Example03();

            Example04();

            Example05();

            Example06();

            Example07();

            Example08();
        }

        private static void Example08()
        {
            Console.WriteLine(new string('*', 100));

            var openWith = new SortedList<string, string>()
            {
                [".txt"] = "vscode",
                [".js"] = "vscode"
            };

            foreach (var (ext, app) in openWith)
            {
                Console.WriteLine("{0} => {1}", ext, app);
            }
        }

        private static void Example07()
        {
            Console.WriteLine(new string('*', 100));

            var openWith = new Dictionary<string, string>();

            openWith.Add(".txt", "vscode");
            openWith.Add(".html", "chrome");
            openWith.Add(".js", "vscode");

            foreach (var (ext, app) in openWith)
            {
                Console.WriteLine("{0} => {1}", ext, app);
            }
        }

        private static void Example06()
        {
            Console.WriteLine(new string('*', 100));

            var primes = new List<int> { 1, 2, 3, 5, 7 };

            var odd = new List<int> { 1, 3, 5, 7, 9 };

            var even = new List<int> { 0, 2, 4, 6, 8 };

            var all = new List<List<int>>
            {
                primes,
                odd,
                even
            };

            var integers = new SortedSet<int>(all.SelectMany(it => it));

            foreach (var number in integers)
            {
                Console.WriteLine(number);
            }
        }

        private static void Example05()
        {
            Console.WriteLine(new string('*', 100));

            var week = new LinkedList<string>();
            var monday = week.AddFirst("Monday");
            var sunday = week.AddBefore(monday, "Sunday");
            var tuesday = week.AddAfter(monday, "Tuesday");
            var wednesday = week.AddAfter(tuesday, "Wednesday");
            var thursday = week.AddAfter(wednesday, "Thursday");
            var friday = week.AddAfter(thursday, "Friday");
            var saturday = week.AddAfter(friday, "Saturday");

            foreach (var day in week)
            {
                Console.WriteLine(day);
            }
        }

        private static void Example04()
        {
            Console.WriteLine(new string('*', 100));

            var image = new int[1024];

            image[0] = 0xFFFFFF;

            Console.WriteLine(image[0]);
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
