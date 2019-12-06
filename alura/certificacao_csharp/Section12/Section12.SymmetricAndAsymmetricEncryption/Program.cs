using System;
using System.IO;
using System.Security.Cryptography;

namespace Section12.SymmetricAndAsymmetricEncryption
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var original = "Nothing is true everything is permmited";

            byte[] encrypted;

            string decrypted;

            using (var aes = Aes.Create())
            {
                encrypted = Encrypt(original, aes.Key, aes.IV);
                decrypted = Decrypt(encrypted, aes.Key, aes.IV);
            }

            Console.WriteLine("Original:\n{0}", original);
            Console.WriteLine("Encrypted:\n{0}", string.Join(' ', encrypted));
            Console.WriteLine("Decrypted:\n{0}", decrypted);
        }

        public static byte[] Encrypt(string text, byte[] key, byte[] iv)
        {
            byte[] encrypted;

            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                var encryptor = aes.CreateEncryptor();

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(text);
                        }

                        encrypted = memoryStream.ToArray();
                    }
                }
            }

            return encrypted;
        }

        public static string Decrypt(byte[] encrypted, byte[] key, byte[] iv)
        {
            string decrypted;

            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                var decryptor = aes.CreateDecryptor();

                using (var memoryStream = new MemoryStream(encrypted))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            decrypted = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }
    }
}
