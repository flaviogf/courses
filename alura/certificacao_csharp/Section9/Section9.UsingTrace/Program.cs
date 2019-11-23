using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Section9.UsingTrace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var console = new ConsoleTraceListener();

            var file = new TextWriterTraceListener("log.log");

            Trace.Listeners.AddRange(new[] { console, file });

            Trace.AutoFlush = true;

            Trace.WriteLine("Start console application.");

            Trace.Indent();

            using var stream = new FileStream("Movies.xml", FileMode.Open);

            var serializer = new XmlSerializer(typeof(Store));

            Trace.WriteLine("Start read file.");

            var store = (Store)serializer.Deserialize(stream);

            store.Movies.ForEach(Console.WriteLine);

            Trace.WriteLine("End read file");

            Trace.Unindent();

            Trace.WriteLine("End console application.");
        }
    }
}
