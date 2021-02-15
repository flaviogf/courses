using System;

namespace ArdalisRating.DIP.Core.Model
{
    public class Policy
    {
        public string Type { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsSmoker { get; set; }

        public decimal Amount { get; set; }

        public string Address { get; set; }

        public decimal Size { get; set; }

        public decimal Valuation { get; set; }

        public decimal BondAmount { get; set; }

        public int ElevationAboveSeaLevelFeet { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Miles { get; set; }

        public decimal Deductible { get; set; }
    }
}
