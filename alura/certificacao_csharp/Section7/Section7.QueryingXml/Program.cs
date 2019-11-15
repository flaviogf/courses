using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Section7.QueryingXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Example01();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Example02();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Example03();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Example04();
        }

        public static void Example01()
        {
            using (var stream = File.OpenRead("Movies.xml"))
            {
                var document = XDocument.Load(stream);

                var movies = from movie in document.Descendants("Movie")
                             select movie;

                foreach (var item in movies)
                {
                    var name = item.Element("Name").FirstNode;
                    var director = item.Element("Director").FirstNode;
                    Console.WriteLine("{0,-20} {1,-20}", name, director);
                }
            }
        }

        public static void Example02()
        {
            using (var stream = File.OpenRead("Movies.xml"))
            {
                var document = XDocument.Load(stream);

                var movies = from movie in document.Descendants("Movie")
                             where (string)movie.Element("Director") == "James Cameron"
                             select movie;

                foreach (var movie in movies)
                {
                    Console.WriteLine("{0,-20} {1,-20}", (string)movie.Element("Director"), (string)movie.Element("Name"));
                }
            }
        }

        public static void Example03()
        {
            using (var stream = File.OpenRead("Movies.xml"))
            {
                var document = XDocument.Load(stream);

                var movies = document.Descendants("Movie").Where(movie => (string)movie.Element("Director") == "Quentin Tarantino");

                foreach (var movie in movies)
                {
                    Console.WriteLine("{0,-20} {1,-20}", (string)movie.Element("Director"), (string)movie.Element("Name"));
                }
            }
        }

        public static void Example04()
        {
            using (var stream = File.OpenRead("Movies.xml"))
            {
                var document = XDocument.Load(stream);

                var movies = from movie in document.Descendants("Movie")
                             where (string)movie.Element("Director") == "Quentin Tarantino"
                             select movie;

                foreach (var movie in movies)
                {
                    Console.WriteLine("{0,-20} {1,-20}", (string)movie.Element("Director"), (string)movie.Element("Name"));
                }

                var pulpFiction = (from movie in movies where (string)movie.Element("Name") == "Pulp Fiction" select movie).First();

                pulpFiction.Add(new XElement("Genre", "Drama"));

                var djangoLibre = movies.Single(movie => (string)movie.Element("Name") == "Django Libre");

                djangoLibre.Add(new XElement("Genre", "Action"));

                foreach (var movie in movies)
                {
                    Console.WriteLine("{0,-20} {1,-20} {2, -20}", (string)movie.Element("Director"), (string)movie.Element("Name"), (string)movie.Element("Genre"));
                }
            }
        }
    }
}