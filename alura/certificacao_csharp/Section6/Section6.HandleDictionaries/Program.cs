using System;
using System.Collections.Generic;

namespace Section6.HandleDictionaries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var episode4 = new Movie("Star Wars: Episode IV", 1977);
            var episode5 = new Movie("Star Wars: Episode V", 1980);
            var episode6 = new Movie("Star Wars: Episode VI", 1983);
            var episode1 = new Movie("Star Wars: Episode I", 1999);
            var episode2 = new Movie("Star Wars: Episode II", 2002);
            var episode3 = new Movie("Star Wars: Episode III", 2005);
            var episode7 = new Movie("Star Wars: Episode VII", 2015);
            var episode8 = new Movie("Star Wars: Episode VIII", 2017);

            IDictionary<int, Movie> chronology = new Dictionary<int, Movie>();

            chronology.Add(1, episode4);
            chronology.Add(2, episode5);
            chronology.Add(3, episode6);

            chronology.Print();

            Console.WriteLine($"Contains the key 1? {chronology.ContainsKey(1)}");

            Console.WriteLine($"Key: 1 {chronology[1]}");

            chronology.TryGetValue(4, out Movie movie);

            Console.WriteLine($"Is the movie null? {movie == null}");

            Console.WriteLine();

            chronology[4] = episode1;

            chronology.Print();
        }
    }

    public class Movie
    {
        public Movie(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public string Name { get; set; }

        public int Year { get; set; }

        public override string ToString() => $"Movie=[Name={Name}, Year={Year}]";
    }

    public static class IDictionaryExtensions
    {
        public static void Print<TKey, TValue>(this IDictionary<TKey, TValue> enumerable)
        {
            foreach (var item in enumerable)
            {
                Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
            }

            Console.WriteLine();
        }
    }
}
