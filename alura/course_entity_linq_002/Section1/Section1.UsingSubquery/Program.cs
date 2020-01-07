using System;
using System.Linq;

namespace Section1.UsingSubquery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Context();

            var query = from invoice in context.Invoices
                        let average = context.Invoices.Average(it => it.Amount)
                        where invoice.Amount >= average
                        orderby invoice.Id
                        select new
                        {
                            invoice.Id,
                            invoice.Amount,
                            Customer = $"{invoice.Customer.FirstName} {invoice.Customer.LastName}"
                        };

            foreach (var item in query)
            {
                Console.WriteLine("{0,-50} {1,-20} {2,20:C}", item.Customer, item.Id, item.Amount);
            }
        }
    }
}