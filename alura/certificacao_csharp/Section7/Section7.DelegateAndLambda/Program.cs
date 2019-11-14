using static System.Array;
using static System.Console;
using System;

namespace Section7.DelegateAndLambda
{
    public delegate int Operation(int x, int y);

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            var operations = new Operation[] { Sum, Sub, (x, y) => x * y, (x, y) => x / y };

            ForEach(operations, (operation) => WriteLine(operation(10, 10)));
        }

        public static int Sum(int x, int y) => x + y;

        public static int Sub(int x, int y) => x - y;
    }
}
