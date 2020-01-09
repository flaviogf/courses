using System;
using System.Linq;

namespace Section1.CustomersThatHaveBoughtTheMostExpensiveProduct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Context();

            var tracks = from track in context.Tracks
                         where track.InvoiceItems.Count() > 0
                         let amount = track.InvoiceItems.Sum(it => it.Price * it.Quantity)
                         orderby amount descending
                         select new
                         {
                             track.Id,
                             track.Name,
                             Amount = amount
                         };

            var theMostExpensive = tracks.First();

            var customersThatBoughtTheMostExpensiveProduct = from invoiceItem in context.InvoiceItems
                                                             where invoiceItem.Track.Id == theMostExpensive.Id
                                                             let customer = invoiceItem.Invoice.Customer
                                                             select new
                                                             {
                                                                 Customer = $"{customer.FirstName} {customer.LastName}"
                                                             };

            Console.WriteLine("{0,-5} {1,-25} {2,5:C}", theMostExpensive.Id, theMostExpensive.Name, theMostExpensive.Amount);

            foreach (var item in customersThatBoughtTheMostExpensiveProduct)
            {
                Console.WriteLine(item.Customer);
            }
        }
    }
}
