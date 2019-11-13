using System;

namespace Section6.HandleArrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            // var one = "ONE";
            // var two = "TWO";
            // var three = "THREE";
            // var companies = new string[3];
            // companies[0] = one;
            // companies[1] = two;
            // companies[2] = three;
            // Console.WriteLine(companies);

            var one = "ONE";
            var two = "TWO";
            var three = "THREE";

            var companies = new string[]
            {
                one, two, three
            };

            companies.Print();

            three = "FOUR";

            companies.Print();

            companies[2] = "FOUR";

            companies.Print();

            Array.Reverse(companies);

            companies.Print();

            Array.Reverse(companies);

            companies.Print();

            Array.Resize(ref companies, 2);

            companies.Print();

            Array.Resize(ref companies, 3);

            companies.Print();

            companies[2] = "THREE";

            companies.Print();

            var copy = new string[2];

            Array.Copy(companies, 1, copy, 0, 2);

            copy.Print();

            var clone = (string[])companies.Clone();

            clone.Print();

            Array.Sort(companies);

            companies.Print();

            Array.Clear(clone, 1, 2);

            clone.Print();
        }

    }

    public static class ArrayExtensions
    {
        public static void Print(this string[] companies)
        {
            Array.ForEach(companies, Console.WriteLine);

            Console.WriteLine();
        }
    }
}
