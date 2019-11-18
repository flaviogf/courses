using System;
using System.IO;
using System.Text;

namespace Section8.ReadAndWriteBytesIntoFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadBytes();

            WriteBytes();

            ReadText();

            ReadNames();

            CopyFile();
        }

        public static void ReadBytes()
        {
            using (var stream = new FileStream("Directors.txt", FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[10];

                stream.Read(bytes, 0, 10);

                foreach (var character in bytes)
                {
                    Console.Write((char)character);
                }

                stream.Seek(5, SeekOrigin.Current);

                stream.Read(bytes, 0, 10);

                foreach (var character in bytes)
                {
                    Console.Write((char)character);
                }
            }
        }

        public static void WriteBytes()
        {
            using (var stream = new FileStream("File.txt", FileMode.Create, FileAccess.Write))
            {
                var text = "Hello World";

                var bytes = Encoding.UTF8.GetBytes(text);

                stream.Write(bytes, 0, bytes.Length);
            }
        }

        public static void ReadText()
        {
            using (var fileStream = new FileStream("File.txt", FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fileStream.Length];

                fileStream.Read(bytes, 0, bytes.Length);

                var text = Encoding.UTF8.GetString(bytes);

                Console.WriteLine(text);
            }
        }

        public static void ReadNames()
        {
            using(var stream = new FileStream("Names.txt", FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[128];

                var readed = -1;

                while(readed != 0)
                {
                    readed = stream.Read(buffer, 0, 128);

                    Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, readed));
                }
            }
        }

        public static void CopyFile()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            using(var oldFile = new FileStream("File.txt", FileMode.Open, FileAccess.Read))
            using(var newFile = new FileStream("File(1).txt", FileMode.Create, FileAccess.Write))
            {
                var buffer = new byte[1024];
                var readed = -1;

                while(readed != 0)
                {
                    readed = oldFile.Read(buffer, 0, 1024);

                    newFile.Write(buffer, 0, readed);
                }
            }

            Console.WriteLine("File was copied");
        }
    }
}