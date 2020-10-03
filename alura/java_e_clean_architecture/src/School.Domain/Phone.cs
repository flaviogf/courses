using System;

namespace School.Domain
{
    public class Phone
    {
        public Phone(string ddd, string number)
        {
            if (string.IsNullOrWhiteSpace(ddd))
            {
                throw new ArgumentException("DDD must not be null", nameof(ddd));
            }

            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Number must not be null", nameof(number));
            }

            DDD = ddd;
        }

        public string DDD { get; }

        public string Number { get; }
    }
}
