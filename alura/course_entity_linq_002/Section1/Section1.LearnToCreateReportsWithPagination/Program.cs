using System;
using System.Linq;

namespace Section1.LearnToCreateReportsWithPagination
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Context();

            var page = 1;

            var take = 10;

            var skip = (page - 1) * take;

            var pages = Math.Ceiling((double)context.Invoices.Count() / take);

            do
            {
                var query = from invoice in context.Invoices
                            select new
                            {
                                Customer = $"{invoice.Customer.FirstName} {invoice.Customer.LastName}",
                                invoice.Id,
                                invoice.Amount
                            };

                query = query.Skip(skip);

                query = query.Take(take);

                Console.WriteLine(new string('*', 100));

                Console.WriteLine("Page {0}", page);

                Console.WriteLine(new string('*', 100));

                foreach (var item in query)
                {
                    Console.WriteLine("{0,-50} {1,5} {2,20:C}", item.Customer, item.Id, item.Amount);
                }

                page++;

                skip = (page - 1) * take;
            }
            while (page <= pages);
        }
    }
}