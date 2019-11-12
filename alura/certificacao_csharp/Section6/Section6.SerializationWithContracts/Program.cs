using System;
using System.IO;
using System.Runtime.Serialization;

namespace Section6.SerializationWithContracts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Write();

            var filename = Path.Join(Directory.GetCurrentDirectory(), "Movie.xml");

            using (var stream = File.Open(filename, FileMode.Open))
            {
                var serializer = new DataContractSerializer(typeof(Movie));

                var movie = (Movie)serializer.ReadObject(stream);

                Console.WriteLine(movie);
            }
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
    }

    [DataContract]
    public class Movie
    {
        public string Name { get; set; }

        [DataMember]
        public DateTime Release { get; set; }

        public override string ToString() => $"Movie=[Name={Name}, Release={Release:d}]";
    }
}
