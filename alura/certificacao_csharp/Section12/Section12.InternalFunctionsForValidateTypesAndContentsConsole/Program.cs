using System;
using System.Globalization;

namespace Section12.InternalFunctionsForValidateTypesAndContentsConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Example01();

            Example02();
        }

        private static void Example02()
        {
            DateTime.TryParse("2019-12-06", CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal, out var date);

            Console.WriteLine(date);
        }

        private static void Example01()
        {
            var number = default(int);

            void Read()
            {
                Console.WriteLine("Enter a valid number");

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return;
                }

                Read();
            }

            Read();

            Console.WriteLine($"Readed {number}");
        }
    }
}
