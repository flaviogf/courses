using System;

namespace Bank
{
    public class Program
    {
        public static void Main()
        {
            var account = new Account
            {
                Holder = "Frank"
            };

            Console.WriteLine(account);
        }
    }
}
