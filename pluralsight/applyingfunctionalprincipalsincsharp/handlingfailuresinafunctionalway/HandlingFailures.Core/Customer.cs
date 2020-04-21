namespace HandlingFailures.Core
{
    public class Customer
    {
        public Customer(string billingInfo, decimal balance)
        {
            BillingInfo = billingInfo;
            Balance = balance;
        }

        public string BillingInfo { get; }

        public decimal Balance { get; }

        public Maybe<Customer> AddBalance(decimal balance)
        {
            if (balance < 100)
            {
                return null;
            }

            return new Customer(BillingInfo, Balance + balance);
        }
    }
}