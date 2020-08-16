using CSharpFunctionalExtensions;
using System;

namespace OnlineTheater.Core
{
    public class ExpirationDate
    {
        public static readonly ExpirationDate Infinite = new ExpirationDate(null);

        private readonly DateTime? _value;

        public ExpirationDate(DateTime? value)
        {
            _value = value;
        }

        public static Result<ExpirationDate> Of(DateTime? value)
        {
            return Result.Success(new ExpirationDate(value));
        }

        public static implicit operator DateTime?(ExpirationDate expirationDate)
        {
            return expirationDate._value;
        }

        public static explicit operator ExpirationDate(DateTime? value)
        {
            if (value.HasValue)
            {
                return Of(value).Value;
            }

            return Infinite;
        }
    }
}
