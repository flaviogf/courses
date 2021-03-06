using System;

namespace School.Domain.Students
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

        public static implicit operator string(Cpf cpf)
        {
            return cpf.Value;
        }

        public static explicit operator Cpf(string value)
        {
            return new Cpf(value);
        }
    }
}
