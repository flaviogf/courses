using System;
using System.Linq;

namespace Section6.CountingAndTotalizing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new ApplicationContext();

            var count = (from track in context.Tracks
                         where track.Album.Artist.Name == "Christie Corkery"
                         select track).Count();

            var sum = (from track in context.Tracks
                       where track.Album.Artist.Name == "Christie Corkery"
                       select track.Price).Sum();

            var sales = (from item in context.Items
                         where item.Track.Album.Artist.Name == "Christie Corkery"
                         group item by item.Track.AlbumId into grouping
                         select new
                         {
                             Album = grouping.Key,
                             Sale = grouping.Sum(it => it.Track.Price)
                         }).ToList();

            Console.WriteLine("Count: {0}", count);
            Console.WriteLine("Sum: {0}", sum);

            foreach (var sale in sales)
            {
                Console.WriteLine("{0}\t{1}", sale.Album, sale.Sale);
            }
        }
    }
}
