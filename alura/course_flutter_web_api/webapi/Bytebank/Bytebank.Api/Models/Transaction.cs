using System;

namespace Bytebank.Api.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public int Value { get; set; }

        public Contact Contact { get; set; }

        public DateTime Date { get; set; }
    }
}
