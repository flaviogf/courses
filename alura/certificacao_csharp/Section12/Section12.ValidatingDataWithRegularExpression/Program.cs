using System;
using System.Text.RegularExpressions;

namespace Section12.ValidatingDataWithRegularExpression
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Example01();

            Example02();

            Example03();

            Example04();
        }

        private static void Example04()
        {
            var right = "http://www.google.com";

            var wrong = "http://www.google.wrong.com.br";

            var text = $"{wrong} ${right}";

            var regex = new Regex(@"http://(w{3}\.)?([^\.]+).com", RegexOptions.Compiled);

            Console.WriteLine(regex.IsMatch(right));
            Console.WriteLine(regex.IsMatch(wrong));

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }

        private static void Example03()
        {
            var register = "1000:The Terminator:1984:104";

            Console.WriteLine(Regex.IsMatch(register, @"^[0-9]+:[a-zA-Z\s]+:[0-9]{4}:[0-9]+$"));
        }

        private static void Example02()
        {
            var input = "csharp   javascript      python";

            var output = Regex.Replace(input, @"\s+", ";");

            Console.WriteLine(output);
        }

        private static void Example01()
        {
            var input = "csharp javascript python";

            var output = input.Replace(" ", ";");

            Console.WriteLine(output);
        }
    }
}
