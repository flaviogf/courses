using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Section12.ValidateSecurity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Example01();

            Example02();

            Console.ResetColor();
        }

        private static void Example02()
        {
            string ToXml(Movie movie)
            {
                var serializer = new XmlSerializer(typeof(Movie));

                var writer = new StringWriter();

                serializer.Serialize(writer, movie);

                return writer.ToString();
            }

            Movie FromXml(string xml)
            {
                var serializer = new XmlSerializer(typeof(Movie));

                var reader = new StringReader(xml);

                var movie = (Movie)serializer.Deserialize(reader);

                return movie;
            }

            var lordOfTheRings = new Movie(1, "Lord of the rings", "J.J", 220);

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(ToXml(lordOfTheRings));

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine(FromXml(ToXml(lordOfTheRings)));
        }

        private static void Example01()
        {
            string ToJson(Movie movie)
            {
                return JsonConvert.SerializeObject(movie);
            }

            Movie FromJson(string json)
            {
                return JsonConvert.DeserializeObject<Movie>(json);
            }

            var lordOfTheRings = new Movie(1, "Lord of the rings", "J.J", 220);

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(ToJson(lordOfTheRings));

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine(FromJson(ToJson(lordOfTheRings)));
        }
    }
}
