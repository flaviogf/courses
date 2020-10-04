using System;

namespace School.Domain.Students
{
    public class Email
    {
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value must not be null", nameof(value));
            }

            Value = value;
        }

        public string Value { get; }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        public static explicit operator Email(string value)
        {
            return new Email(value);
        }
    }
}
