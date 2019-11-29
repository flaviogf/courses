using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Section11.LinqParallelQuery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var file = new FileStream("Movies.json", FileMode.Open, FileAccess.Read);

            using var reader = new StreamReader(file);

            var movies = JsonConvert.DeserializeObject<List<Movie>>(reader.ReadToEnd());

            Task1(movies);

            Task2(movies);

            Task3(movies);

            var biggestRevenues = (from movie in movies
                                   orderby movie.Revenues descending
                                   select new
                                   {
                                       movie.Title,
                                       movie.Revenues
                                   }).Take(5);

            biggestRevenues.Print();
        }

        private static void Task1(List<Movie> movies)
        {
            var adventure = from movie in movies
                            where movie.Genre == "Adventure"
                            select new { movie.Title };

            adventure.Print();
        }

        private static void Task2(List<Movie> movies)
        {
            var adventure = from movie in movies.AsParallel()
                                                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                                .WithDegreeOfParallelism(4)
                            select new { movie.Title };

            adventure.Print();
        }

        private static void Task3(List<Movie> movies)
        {
            var adventure = from movie in movies.AsParallel()
                                .AsOrdered()
                            select new { movie.Title };

            adventure.Print();
        }
    }

    public static class IEnumerableExtensions
    {
        public static void Print<TSource>(this IEnumerable<TSource> enumerable)
        {
            Console.WriteLine(new string('=', 75));

            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('=', 75));
        }
    }
}
