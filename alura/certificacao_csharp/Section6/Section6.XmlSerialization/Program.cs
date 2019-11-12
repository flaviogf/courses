using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Section6.XmlSerialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            FirstSystem();

            SecondSystem();
        }

        static void FirstSystem()
        {
            var store = new Store();

            store.AddMovie(new Movie
            {
                Name = "Guardians of the Galaxy",
                Release = new DateTime(year: 2014, month: 7, day: 31)
            });

            store.AddEditor(new Editor
            {
                Name = "James Gunn"
            });

            Console.WriteLine(store);

            var serializer = new XmlSerializer(typeof(Store));

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, store);
                Console.WriteLine(writer.ToString());
            }

            var filename = Path.Join(Directory.GetCurrentDirectory(), "Store.xml");

            using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, store);
            }
        }

        static void SecondSystem()
        {
            var filename = Path.Join(Directory.GetCurrentDirectory(), "Store.xml");

            var serializer = new XmlSerializer(typeof(Store));

            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                var store = (Store)serializer.Deserialize(stream);
                Console.WriteLine(store);
            }
        }
    }

    [XmlType("movie")]
    public class Movie
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public DateTime Release { get; set; }

        public override string ToString() => $"Movie[Name={Name}, Release={Release:D}]";
    }

    [XmlType("editor")]
    public class Editor
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        public override string ToString() => $"Editor[Name={Name}]";
    }

    [XmlRoot("store")]
    public class Store
    {
        public Store()
        {
            Movies = new List<Movie>();
            Editors = new List<Editor>();
        }

        [XmlArray("movies")]
        public List<Movie> Movies { get; set; }

        [XmlArray("editors")]
        public List<Editor> Editors { get; set; }

        public Movie AddMovie(Movie movie)
        {
            Movies.Add(movie);

            return movie;
        }

        public Editor AddEditor(Editor editor)
        {
            Editors.Add(editor);

            return editor;
        }

        public override string ToString() => $"Store[Movies=[{string.Join(',', Movies.Select(it => it.ToString()))}], Editors=[{string.Join(',', Editors.Select(it => it.ToString()))}]";
    }
}
