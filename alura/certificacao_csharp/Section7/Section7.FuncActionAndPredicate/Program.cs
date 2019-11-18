using static System.Console;
using static System.Array;
using System;

namespace Section7.FuncActionAndPredicate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<int> print = (value) => WriteLine(value);

            Func<int, int, int> sum = (x, y) => x + y;

            Func<int, Predicate<int>> divisibleBy = (x) => (y) => y % x == 0;

            Predicate<int> divisibleBy2 = divisibleBy(2);

            Predicate<int> divisibleBy3 = divisibleBy(3);

            var natural = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            ForEach(FindAll(natural, divisibleBy2), print);
            ForEach(FindAll(natural, divisibleBy3), print);
            print(sum(10, 10));
        }
    }
}
