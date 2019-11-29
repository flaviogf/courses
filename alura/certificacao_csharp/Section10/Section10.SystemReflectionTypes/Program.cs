using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace Section10.SystemReflectionTypes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var current = Assembly.GetExecutingAssembly();

            current.GetTypes().ForEach(WriteLine);

            current.GetTypes().SelectMany((it) => it.GetMembers()).ForEach(WriteLine);

            WriteLine(current.FullName);

            var name = current.GetName();

            WriteLine("Version: {0}", name.Version);
            WriteLine("Major: {0}", name.Version.Major);
            WriteLine("Minor: {0}", name.Version.Minor);

            var type = typeof(Basket);

            (from propertie in type.GetProperties()
             select new
             {
                 propertie.Name,
                 propertie.CanWrite,
                 propertie.CanRead
             }).ForEach(WriteLine);
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
