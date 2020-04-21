namespace HandlingFailures.Core
{
    public class RefillBalanceInput : IInput
    {
        public RefillBalanceInput(int customerId, decimal moneyAmount)
        {
            CustomerId = customerId;
            MoneyAmount = moneyAmount;
        }

        public int CustomerId { get; }

        public decimal MoneyAmount { get; }
    }
}