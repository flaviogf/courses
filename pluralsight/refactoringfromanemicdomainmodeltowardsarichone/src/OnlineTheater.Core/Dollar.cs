using CSharpFunctionalExtensions;

namespace OnlineTheater.Core
{
    public class Dollar
    {
        public static readonly Dollar Minimum = new Dollar(0);

        public static readonly Dollar Maximum = new Dollar(1_000_000);

        private readonly decimal _value;

        private Dollar(decimal value)
        {
            _value = value;
        }

        public static Result<Dollar> Of(decimal value)
        {
            if (value < 0)
            {
                return Result.Failure<Dollar>("Dollar cannot be negative");
            }

            if (value > Maximum._value)
            {
                return Result.Failure<Dollar>($"Dollar cannot be greater than {Maximum._value:C}");
            }

            return Result.Success(new Dollar(value));
        }

        public static implicit operator decimal(Dollar dollar)
        {
            return dollar._value;
        }

        public static explicit operator Dollar(decimal value)
        {
            return Of(value).Value;
        }
    }
}
