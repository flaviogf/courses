using System;
using System.IO;
using System.IO.Compression;

namespace Section8.ReadAndWriteStringsIntoFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Write();

            Read();

            Zip();

            Unzip();

            BinaryWriterAndStreamWriter();
        }

        public static void Write()
        {
            using (var writer = new StreamWriter("File.txt"))
            {
                writer.WriteLine("OK");
            }
        }

        public static void Read()
        {
            using (var reader = new StreamReader("File.txt"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        public static void Zip()
        {
            using (var file = new FileStream("File.zip", FileMode.Create, FileAccess.Write))
            using (var zip = new GZipStream(file, CompressionMode.Compress))
            using (var writer = new StreamWriter(zip))
            {
                writer.WriteLine("OK OK OK");
            }
        }

        public static void Unzip()
        {
            using (var file = new FileStream("File.zip", FileMode.Open, FileAccess.Read))
            using (var zip = new GZipStream(file, CompressionMode.Decompress))
            using (var reader = new StreamReader(zip))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        public static void BinaryWriterAndStreamWriter()
        {
            var number = 691693903;

            using (var stream = new FileStream("Binary.txt", FileMode.Create, FileAccess.Write))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(number);
            }

            using (var stream = new FileStream("Stream.txt", FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(number);
            }
        }
    }
}