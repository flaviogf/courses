using System;
using System.Linq;

namespace Section4.AssociatingAndFilteringTheModelEntities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new ApplicationContext();

            Console.WriteLine(new string('*', 100));

            var query1 = from album in context.Albums
                         where album.Artist.Name.Contains("Bahringer")
                         select new 
                         {
                             Album = album.Name,
                             Artist = album.Artist.Name
                         };

            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('*', 100));

            var query2 = from album in context.Albums
                         join artist in context.Artists on album.ArtistId equals artist.Id
                         where artist.Name.Contains("Bahringer")
                         select new 
                         {
                             Album = album.Name,
                             Artist = album.Artist.Name
                         };

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
