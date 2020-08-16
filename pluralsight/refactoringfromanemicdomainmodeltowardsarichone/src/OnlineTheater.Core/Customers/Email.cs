using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace OnlineTheater.Core.Customers
{
    public class Email
    {
        private readonly string _value;

        private Email(string value)
        {
            _value = value;
        }

        public static Result<Email> Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Email>("Email should not be empty");
            }

            if (value.Length > 150)
            {
                return Result.Failure<Email>("Email is too long");
            }

            if (!Regex.IsMatch(value, @"^(.+)@(.+)$"))
            {
                return Result.Failure<Email>("Email is invalid");
            }

            return Result.Success(new Email(value));
        }

        public static implicit operator string(Email email)
        {
            return email._value;
        }

        public static explicit operator Email(string value)
        {
            return Of(value).Value;
        }
    }
}
