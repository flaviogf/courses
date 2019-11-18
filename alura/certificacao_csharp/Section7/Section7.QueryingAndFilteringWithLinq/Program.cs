using System;
using System.Collections.Generic;
using System.Linq;

namespace Section7.QueryingAndFilteringWithLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var movies = Movies();

            var editors = Editors();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            movies.Report();

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            (from movie in movies select movie).Report();

            Console.ForegroundColor = ConsoleColor.DarkRed;

            (from movie in movies where movie.Director.Name == "Tim Burton" select movie).Report();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            (from movie in movies
             join editor in editors on movie.Director.Id equals editor.Id
             select new { editor.Name, movie.Title, movie.Year }).Print();
        }

        public static IList<Director> Editors() => new List<Director>()
        {
            new Director(1, "Quentin Tarantino"),
            new Director(2, "James Cameron"),
            new Director(3, "Tim Burton"),
        };

        public static IList<Movie> Movies() => new List<Movie>
        {
            new Movie(1, "Pulp Fiction", 1994, new Director(1, "Quentin Tarantino")),
            new Movie(2, "Django Livre", 2012, new Director(1, "Quentin Tarantino")),
            new Movie(3, "Kill Bill Volume 1", 2003, new Director(1, "Quentin Tarantino")),
            new Movie(4, "Avatar", 2009, new Director(2, "James Cameron")),
            new Movie(5, "Titanic", 1997, new Director(2, "James Cameron")),
            new Movie(6, "O Exterminador do Futuro", 1984, new Director(2, "James Cameron")),
            new Movie(7, "O Estranho Mundo de Jack", 1993, new Director(3, "Tim Burton")),
            new Movie(8, "Alice no País das Maravilhas", 2010, new Director(3, "Tim Burton")),
            new Movie(9, "A Noiva Cadáver", 2005, new Director(3, "Tim Burton")),
        };
    }

    public class Director
    {
        public Director(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Movie
    {
        public Movie(int id, string title, int year, Director director)
        {
            Id = id;
            Title = title;
            Year = year;
            Director = director;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public Director Director { get; set; }
    }

    public static class IEnumerableExtensions
    {
        public static void Report(this IEnumerable<Movie> movies)
        {
            Console.WriteLine($"{"Title",-40} {"Director",-20} {"Year",4}");

            Console.WriteLine(new string('=', 66));

            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.Title,-40} {movie.Director.Name,-20} {movie.Year,4}");
            }

            Console.WriteLine(new string('=', 66));
        }

        public static void Print<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
