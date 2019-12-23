using System;

namespace Bytebank.Api.ViewModels
{
    public class StoreTransactionViewModel
    {
        public Guid? Id { get; set; }

        public string ContactName { get; set; }

        public string ContactAccount { get; set; }

        public int Value { get; set; }

        public DateTime Date { get; set; }
    }
}
