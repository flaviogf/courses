using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Section12.SymmetricAndAsymmetricEncryption
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("AES");

            Example01();

            Console.WriteLine("RSA");

            Example02();
        }

        private static void Example02()
        {
            var original = "Nothing is true everything is permitted";

            byte[] encrypted;

            string decrypted;

            byte[] Encrypt(string text, RSAParameters key)
            {
                byte[] encrypted;

                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportParameters(key);

                    encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(text), true);
                }

                return encrypted;
            }

            string Decrypt(byte[] encrypted, RSAParameters key)
            {
                string decrypted;

                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportParameters(key);

                    decrypted = Encoding.UTF8.GetString(rsa.Decrypt(encrypted, true));
                }

                return decrypted;
            }

            using (var rsa = new RSACryptoServiceProvider())
            {
                var publicKey = rsa.ExportParameters(false);
                var privateKey = rsa.ExportParameters(true);

                encrypted = Encrypt(original, publicKey);
                decrypted = Decrypt(encrypted, privateKey);
            }

            Console.WriteLine("Original:\n{0}", original);
            Console.WriteLine("Encrypted:\n{0}", string.Join(' ', encrypted));
            Console.WriteLine("Decrypted:\n{0}", decrypted);
        }

        private static void Example01()
        {
            var original = "Nothing is true everything is permmited";

            byte[] encrypted;

            string decrypted;

            byte[] Encrypt(string text, byte[] key, byte[] iv)
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

            string Decrypt(byte[] encrypted, byte[] key, byte[] iv)
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

            using (var aes = Aes.Create())
            {
                encrypted = Encrypt(original, aes.Key, aes.IV);
                decrypted = Decrypt(encrypted, aes.Key, aes.IV);
            }

            Console.WriteLine("Original:\n{0}", original);
            Console.WriteLine("Encrypted:\n{0}", string.Join(' ', encrypted));
            Console.WriteLine("Decrypted:\n{0}", decrypted);
        }
    }
}
