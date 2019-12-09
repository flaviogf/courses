using System;
using System.Security.Cryptography;
using System.Text;

namespace Section12.ManagingKeys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var original = "Nothing is true, everything is permitted.";

            byte[] encrypted;

            string decrypted;

            encrypted = Encrypt(original);

            decrypted = Decrypt(encrypted);

            Console.WriteLine("Original: {0}", original);

            Console.WriteLine("Encrypted: {0}", string.Join(' ', encrypted));

            Console.WriteLine("Decrypted: {0}", decrypted);
        }

        private static string Decrypt(byte[] encrypted)
        {
            string decrypted;

            var cspParameters = new CspParameters()
            {
                KeyContainerName = "MyKeyContainerName",
                Flags = CspProviderFlags.UseMachineKeyStore
            };

            using (var rsa = new RSACryptoServiceProvider(cspParameters))
            {
                Console.WriteLine("Decrypt Key: {0}", rsa.ToXmlString(true));

                decrypted = Encoding.UTF8.GetString(rsa.Decrypt(encrypted, true));
            }

            return decrypted;
        }

        private static byte[] Encrypt(string original)
        {
            var cspParameters = new CspParameters()
            {
                KeyContainerName = "MyKeyContainerName",
                Flags = CspProviderFlags.UseMachineKeyStore
            };

            byte[] encrypted;

            using (var rsa = new RSACryptoServiceProvider(cspParameters))
            {
                Console.WriteLine("Encrypt Key: {0}", rsa.ToXmlString(true));

                encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(original), true);
            }

            return encrypted;
        }
    }
}
