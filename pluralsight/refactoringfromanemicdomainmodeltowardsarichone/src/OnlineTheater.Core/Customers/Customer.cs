namespace OnlineTheater.Core.Customers
{
    public class Customer
    {
        public Customer(Name name, Email email)
        {
            Name = name;
            Email = email;
            MoneySpent = Dollar.Minimum;
        }

        public Name Name { get; }

        public Email Email { get; }

        public Dollar MoneySpent { get; }
    }
}
