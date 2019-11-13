using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace Section6.SerializationWithContracts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Write();

            Read();

            Example01();

            Example02();
        }

        static void Write()
        {
            var filename = Path.Join(Directory.GetCurrentDirectory(), "Movie.xml");

            using (var stream = File.Open(filename, FileMode.Create))
            {
                var serializer = new DataContractSerializer(typeof(Movie));

                var movie = new Movie
                {
                    Name = "Guardians of the galaxy",
                    Release = new DateTime(2019, 7, 14)
                };

                serializer.WriteObject(stream, movie);
            }
        }

        static void Read()
        {
            var filename = Path.Join(Directory.GetCurrentDirectory(), "Movie.xml");

            using (var stream = File.Open(filename, FileMode.Open))
            {
                var serializer = new DataContractSerializer(typeof(Movie));

                var movie = (Movie)serializer.ReadObject(stream);

                Console.WriteLine(movie);
            }
        }

        static void Example01()
        {
            using (var writer = XmlWriter.Create(Console.Out))
            {
                var name = new Name
                {
                    First = "Flavio",
                    Last = "Fernandes"
                };

                var serializer = new DataContractSerializer(typeof(Name));

                serializer.WriteObject(writer, name);
            }
        }

        static void Example02()
        {
            using (var writer = new StreamWriter(Console.OpenStandardOutput()))
            {
                var name = new Name
                {
                    First = "Flavio",
                    Last = "Fernandes"
                };
                var serializer = new DataContractJsonSerializer(typeof(Name));
                serializer.WriteObject(writer.BaseStream, name);
            }
        }
    }

    [DataContract]
    public class Movie
    {
        public string Name { get; set; }

        [DataMember]
        public DateTime Release { get; set; }

        public override string ToString() => $"Movie=[Name={Name}, Release={Release:d}]";
    }

    [DataContract]
    public class Name
    {
        [DataMember(Order = 2)]
        public string First { get; set; }

        [DataMember]
        public string Last { get; set; }
    }
}
