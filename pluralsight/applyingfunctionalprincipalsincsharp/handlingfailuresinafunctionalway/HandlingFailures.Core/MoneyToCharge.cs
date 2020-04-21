namespace HandlingFailures.Core
{
    public class MoneyToCharge
    {
        private MoneyToCharge(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; }

        public static Result<MoneyToCharge> Create(decimal value)
        {
            if (value <= 0)
            {
                return Result.Fail<MoneyToCharge>("Value must be greater than zero.");
            }

            return Result.Ok<MoneyToCharge>(new MoneyToCharge(value));
        }
    }
}
