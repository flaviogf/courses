using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Section12.DoingHash
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var message = "Nothing is true, everything is permitted";

            Console.WriteLine("Checksum");

            Console.WriteLine(Checksum(message));

            Console.WriteLine("HashCode");

            Console.WriteLine("{0:X}", string.Join(' ', HashCode(message)));

            Console.WriteLine("Hash");

            Console.WriteLine("{0:X}", string.Join(' ', Hash(message)));
        }

        public static int Checksum(string text)
        {
            return text.Sum(it => it);
        }

        public static IEnumerable<int> HashCode(string text)
        {
            return text.Select(it => it.GetHashCode());
        }

        public static byte[] Hash(string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);

            using var algorithm = SHA256.Create();

            return algorithm.ComputeHash(buffer);
        }
    }
}
