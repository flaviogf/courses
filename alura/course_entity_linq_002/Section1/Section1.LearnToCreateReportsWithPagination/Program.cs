using System;
using System.Linq;

namespace Section1.LearnToCreateReportsWithPagination
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Context();

            var query = from invoice in context.Invoices
                        select new
                        {
                            Customer = $"{invoice.Customer.FirstName} {invoice.Customer.LastName}",
                            invoice.Amount
                        };

            foreach (var item in query)
            {
                Console.WriteLine("{0,-50} {1,25:C}", item.Customer, item.Amount);
            }
        }
    }
}