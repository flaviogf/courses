using System;
using System.Linq;
using System.Reflection;

namespace Section10.AdvancingWithReflection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var current = Assembly.GetExecutingAssembly();

            var types = current.GetTypes();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            foreach (var type in types)
            {
                Console.WriteLine(type);
            }

            var interfaces = from type in types where type.IsInterface select type;

            Console.ForegroundColor = ConsoleColor.DarkRed;

            foreach (var type in interfaces)
            {
                Console.WriteLine(type);
            }

            var reports = from type in types where typeof(IReport).IsAssignableFrom(type) select type;

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            foreach (var type in reports)
            {
                Console.WriteLine(type);
            }

            Console.ResetColor();
        }
    }
}