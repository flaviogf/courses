using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Section6.CustomSerialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            var store = new Store
            {
                Editors = new List<Editor>
                {
                    new Editor
                    {
                        Name = "X",
                        NumberOfMovies = 10
                    },
                    new Editor
                    {
                        Name = "P",
                        NumberOfMovies = 100
                    },
                    new Editor
                    {
                        Name = "T",
                        NumberOfMovies = 1000
                    },
                    new Editor
                    {
                        Name = "O",
                        NumberOfMovies = 10000
                    }
                }
            };

            var filename = Path.Join(Directory.GetCurrentDirectory(), "Store.xml");

            using (var writer = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                var serializer = new DataContractSerializer(typeof(Store));
                serializer.WriteObject(writer, store);
            }
        }
    }

    [DataContract]
    public class Store
    {
        [DataMember]
        public List<Editor> Editors { get; set; }
    }

    [Serializable]
    public class Editor : ISerializable
    {
        public string Name { get; set; }

        public int NumberOfMovies { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Name), Name);
            info.AddValue(nameof(NumberOfMovies), NumberOfMovies);
            info.AddValue("Summary", $"Name: {Name}, Number of movies: {NumberOfMovies}");
        }
    }
}
