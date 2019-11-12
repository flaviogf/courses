using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Section6.JsonSerialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            WriteJson();

            ReadJson();
        }

        static void WriteJson()
        {
            var sourcename = Path.Join(Directory.GetCurrentDirectory(), "Course.xml");
            var destname = Path.Join(Directory.GetCurrentDirectory(), "Course.json");

            using (var source = File.OpenRead(sourcename))
            using (var dest = File.CreateText(destname))
            {
                var xmlSerializer = new XmlSerializer(typeof(Course));
                var course = (Course)xmlSerializer.Deserialize(source);
                dest.Write(JsonConvert.SerializeObject(course));
            }
        }

        static void ReadJson()
        {
            var filename = Path.Join(Directory.GetCurrentDirectory(), "Course.json");

            using (var stream = File.OpenText(filename))
            {
                var course = JsonConvert.DeserializeObject<Course>(stream.ReadToEnd());

                Console.WriteLine(course);
            }
        }
    }

    [XmlRoot]
    public class Course
    {
        [XmlElement]
        public int Id { get; set; }

        [XmlElement]
        public string Name { get; set; }

        public override string ToString() => $"Course[Id={Id}, Name={Name}]";
    }
}
