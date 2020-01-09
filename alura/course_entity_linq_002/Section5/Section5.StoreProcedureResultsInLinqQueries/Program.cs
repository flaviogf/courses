using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Section5.StoreProcedureResultsInLinqQueries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Context();

            var invoices = context.InvoiceItem.FromSqlRaw("EXEC [dbo].[ItemsByCustomer] {0}", 1).ToList();

            foreach (var it in invoices)
            {
                Console.WriteLine(it.TrackId);
            }
        }
    }
}
