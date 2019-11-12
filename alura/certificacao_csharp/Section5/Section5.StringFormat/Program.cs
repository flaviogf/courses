using System;

namespace Section5.StringFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account(holder: "Flavio", bank: "Caixa", createdAt: DateTime.Now, balance: 1000);

            Console.WriteLine(account);
        }
    }

    class Account
    {
        public Account(string holder, string bank, DateTime createdAt, decimal balance)
        {
            Holder = holder;
            Bank = bank;
            CreatedAt = createdAt;
            Balance = balance;
        }

        public string Holder { get; private set; }

        public string Bank { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Balance { get; set; }

        public override string ToString() => $"Account[Holder={Holder}, Bank={Bank}, CreatedAt={CreatedAt:D}, Balance={Balance:C}]";
    }
}
