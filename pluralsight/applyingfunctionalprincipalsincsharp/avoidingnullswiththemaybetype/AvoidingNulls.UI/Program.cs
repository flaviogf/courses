using System;
using FunctionalPrinciples.AvoidingNulls.Core;

namespace FunctionalPrinciples.AvoidingNulls.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var command = new CreateCustomer(new InMemoryCustomerRepository());

            var result = command.Execute("Flavio", "flavio@email.com");

            if (result.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("AvoidingNulls: has been finished successfully");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("AvoidingNulls: has been finished unsuccessfully");
                Console.WriteLine(result.Error);
            }

            Console.ResetColor();
        }
    }
}