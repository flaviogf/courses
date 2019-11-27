using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Section10.SystemReflectionTypes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var current = Assembly.GetExecutingAssembly();

            current.GetTypes().ForEach(Console.WriteLine);

            current.GetTypes().SelectMany((it) => it.GetMembers()).ForEach(Console.WriteLine);
        }
    }

    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}
