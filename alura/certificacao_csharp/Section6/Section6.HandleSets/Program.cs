using System;
using System.Collections.Generic;
using System.Linq;

namespace Section6.HandleSets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            var episode4 = new Movie("Star Wars: Episode IV", 1977);
            var episode5 = new Movie("Star Wars: Episode V", 1980);
            var episode6 = new Movie("Star Wars: Episode VI", 1983);
            var episode1 = new Movie("Star Wars: Episode I", 1999);
            var episode2 = new Movie("Star Wars: Episode II", 2002);
            var episode3 = new Movie("Star Wars: Episode III", 2005);
            var episode7 = new Movie("Star Wars: Episode VII", 2015);
            var episode8 = new Movie("Star Wars: Episode VIII", 2017);

            ISet<Movie> firstTrilogy = new HashSet<Movie>();

            firstTrilogy.Add(episode4);
            firstTrilogy.Add(episode5);
            firstTrilogy.Add(episode6);

            firstTrilogy.Print();

            firstTrilogy.Add(episode4);

            firstTrilogy.Print();

            firstTrilogy.Remove(episode5);

            firstTrilogy.Print();

            firstTrilogy.Add(episode5);

            firstTrilogy.Print();

            firstTrilogy.Add(new Movie("Star Wars: Episode IV", 1977));

            firstTrilogy.Print();

            var sorted = new List<Movie>(firstTrilogy);

            sorted.Sort();

            sorted.Print();

            Console.WriteLine(firstTrilogy.Contains(episode4));
            Console.WriteLine(firstTrilogy.Contains(new Movie("Star Wars: Episode IV", 1977)));
            Console.WriteLine(firstTrilogy.Contains(episode8));
        }
    }

    public class Movie : IComparable<Movie>
    {
        public Movie(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public string Name { get; set; }

        public int Year { get; set; }

        public override string ToString() => $"Movie[Name={Name}, Year={Year}]";

        public override bool Equals(object obj) => obj is Movie movie && Name == movie.Name && Year == movie.Year;

        public override int GetHashCode() => HashCode.Combine(Name, Year);

        public int CompareTo(Movie other) => Name.CompareTo(other.Name);
    }

    public static class IEnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> enumerable) where T : class
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Count {enumerable.Count()}");

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
