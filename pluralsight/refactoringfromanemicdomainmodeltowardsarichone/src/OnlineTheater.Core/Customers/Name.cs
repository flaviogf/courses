using CSharpFunctionalExtensions;

namespace OnlineTheater.Core.Customers
{
    public class Name
    {
        private readonly string _value;

        private Name(string value)
        {
            _value = value;
        }

        public static Result<Name> Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Name>("Name should not be empty");
            }

            if (value.Length > 50)
            {
                return Result.Failure<Name>("Name is too long");
            }

            return Result.Success(new Name(value));
        }

        public static implicit operator string(Name name)
        {
            return name._value;
        }

        public static explicit operator Name(string value)
        {
            return Of(value).Value;
        }
    }
}
