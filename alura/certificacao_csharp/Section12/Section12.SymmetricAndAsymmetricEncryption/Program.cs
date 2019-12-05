using System;
using System.IO;
using System.Security.Cryptography;

namespace Section12.SymmetricAndAsymmetricEncryption
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = "Nothing is true, everything is permitted";

            var encrypted = new byte[0];

            var key = new byte[0];

            using var aes = Aes.Create();

            key = aes.Key;

            using var encryptor = aes.CreateEncryptor();

            using var memoryStream = new MemoryStream();

            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            using var streamWriter = new StreamWriter(cryptoStream);

            streamWriter.Write(text);

            streamWriter.Flush();

            encrypted = memoryStream.ToArray();

            Console.WriteLine(new string('*', 100));

            Console.WriteLine("Text");

            Console.WriteLine(text);

            Console.WriteLine(new string('*', 100));

            Console.WriteLine("Key");

            foreach (var b in key)
            {
                Console.Write("{0:X} ", b);
            }

            Console.WriteLine();

            Console.WriteLine(new string('*', 100));

            Console.WriteLine("Encrypted");

            foreach (var b in encrypted)
            {
                Console.Write("{0:X}", b);
            }

            Console.WriteLine();

            Console.WriteLine(new string('*', 100));
        }
    }
}
