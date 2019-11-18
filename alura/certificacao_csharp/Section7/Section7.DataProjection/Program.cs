using System;
using System.Collections.Generic;
using System.Linq;

namespace Section7.DataProjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var directors = Director.FindAll();

            var movies = Movie.FindAll();

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            directors.Print();

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            movies.Print();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            (from movie in movies
             join director in directors on movie.DirectorId equals director.Id
             select new
             {
                 Movie = movie.Title,
                 Director = director.Name,
                 movie.Year
             }).Print();
        }
    }

    public static class IEnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}