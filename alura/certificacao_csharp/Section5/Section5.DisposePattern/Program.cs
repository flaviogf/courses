using System;
using System.IO;

namespace Section5.DisposePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new Reader("test.txt"))
            {
                Console.WriteLine(reader.Read());
            }
        }
    }

    class Reader : IDisposable
    {
        private readonly StreamReader _streamReader;

        private readonly string _filename;

        public Reader(string filename)
        {
            _streamReader = new StreamReader(filename);
            _filename = filename;
            Console.WriteLine($"Opening {_filename}");
        }

        public string Read()
        {
            var text = _streamReader.ReadToEnd();
            Console.WriteLine($"Reading {_filename}");
            return text;
        }

        public void Dispose()
        {
            _streamReader.Dispose();
            Console.WriteLine($"Closing {_filename}");
        }
    }
}
