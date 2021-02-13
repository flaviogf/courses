using System;

namespace ArdalisRating.LSP
{
    public class Policy
    {
        public PolicyType Type { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsSmoker { get; set; }

        public decimal Amount { get; set; }

        public string Address { get; set; }

        public string Size { get; set; }

        public int Valuation { get; set; }

        public int BondAmount { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Miles { get; set; }

        public decimal Deductible { get; set; }
    }
}
