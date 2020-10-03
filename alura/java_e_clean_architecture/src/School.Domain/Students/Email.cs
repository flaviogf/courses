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
    }
}
