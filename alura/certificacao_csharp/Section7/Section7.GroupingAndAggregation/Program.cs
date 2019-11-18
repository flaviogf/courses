using System;
using System.Linq;
using System.Threading.Tasks;

namespace Section7.GroupingAndAggregation
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            var directors = await Director.All();

            var movies = await Movie.All();

            var report = from movie in movies
                         join director in directors
                         on movie.DirectorId equals director.Id
                         group movie by director
                         into grouped
                         select new
                         {
                             grouped.Key.Name,
                             Movies = grouped.Count(),
                             Minutes = grouped.Sum(it => it.Minutes),
                             Min = grouped.Min(it => it.Minutes),
                             Max = grouped.Max(it => it.Minutes),
                             Average = grouped.Average(it => it.Minutes)
                         };

            foreach (var item in report)
            {
                Console.WriteLine(item);
            }
        }
    }
}