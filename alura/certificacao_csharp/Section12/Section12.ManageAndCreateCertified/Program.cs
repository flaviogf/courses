using System;
using System.Security.Cryptography.X509Certificates;

namespace Section12.ManageAndCreateCertified
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var store = new X509Store(StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            var certificates = store.Certificates;

            var current = certificates.Find(X509FindType.FindBySubjectName, "Flavio", false)[0];

            Console.WriteLine(current);
        }
    }
}
