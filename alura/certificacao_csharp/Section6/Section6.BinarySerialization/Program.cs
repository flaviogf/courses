using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Section6.BinarySerialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            WriteBinary();

            ReadBinary();
        }

        static void WriteBinary()
        {
            var formatter = new BinaryFormatter();

            var filename = Path.Join(Directory.GetCurrentDirectory(), "Movies.bin");

            using (var stream = File.OpenWrite(filename))
            {
                formatter.Serialize(stream, Movies().ToList());
            }
        }

        static void ReadBinary()
        {
            var formatter = new BinaryFormatter();

            var filename = Path.Join(Directory.GetCurrentDirectory(), "Movies.bin");

            using (var stream = File.OpenRead(filename))
            {
                var movies = (List<Movie>)formatter.Deserialize(stream);

                movies.ForEach(Console.WriteLine);
            }
        }

        public static IEnumerable<Movie> Movies()
        {
            var dates = new DateTime[] { new DateTime(2019, 10, 10), new DateTime(2018, 10, 10), new DateTime(2017, 10, 10) };
            var names = new string[] { "X", "P", "T", "O" };

            var random = new Random();

            for (var i = 0; i < random.Next(10, 20); i++)
            {
                var date = random.Next(dates.Length);
                var name = random.Next(names.Length);
                yield return new Movie { Name = names[name], Release = dates[date] };
            }
        }
    }

    [Serializable]
    public class Movie
    {
        public string Name { get; set; }

        public DateTime Release { get; set; }

        public override string ToString() => $"Movie=[Name={Name}, Release={Release:D}]";
    }
}
