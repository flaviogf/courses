using System;

namespace School.Domain
{
    public class Cpf
    {
        public Cpf(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value must not be null", nameof(value));
            }

            Value = value;
        }

        public string Value { get; }
    }
}
