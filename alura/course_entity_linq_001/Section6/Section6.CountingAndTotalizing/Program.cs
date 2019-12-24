using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Section6.CountingAndTotalizing
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            using var context = new ApplicationContext();

            var count = (from track in context.Tracks
                         where track.Album.Artist.Name == "Clay Block"
                         select track).Count();

            var sum = (from track in context.Tracks
                       where track.Album.Artist.Name == "Clay Block"
                       select track.Price).Sum();

            var sales = (from item in await context.Items
                         .Include(it => it.Track)
                         .ThenInclude(it => it.Album)
                         .ThenInclude(it => it.Artist)
                         .ToListAsync()
                         where item.Track.Album.Artist.Name == "Clay Block"
                         group item by item.Track.Album into grouping
                         let sale = grouping.Sum(it => it.Quantity * it.Price)
                         orderby sale descending
                         select new
                         {
                             Album = grouping.Key.Title,
                             Sale = sale
                         });

            Console.WriteLine("Count: {0}", count);

            Console.WriteLine("Sum: {0}", sum);

            foreach (var sale in sales)
            {
                Console.WriteLine("{0}\t{1}", sale.Album, sale.Sale);
            }
        }
    }
}
