using System;
using System.Linq;

namespace Section3.LinqToEntities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new ApplicationContext();

            var query = from track in context.Tracks
                        join genre in context.Genres on track.GenreId equals genre.Id
                        where genre.Id == 1
                        select new
                        {
                            Track = track.Name,
                            Genre = track.Genre.Name
                        };

            foreach (var track in query)
            {
                Console.WriteLine("{0,-50} {1,-50}", track.Track, track.Genre);
            }
        }
    }
}
