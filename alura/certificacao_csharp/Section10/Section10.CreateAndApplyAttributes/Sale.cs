using System;

namespace Section10.CreateAndApplyAttributes
{
    [Serializable]
    [DetailedReport("{0,-20} {1,20:C} {2,-20}")]
    [SummarizedReport("{0,20:C} {1,-20}")]
    public class Sale
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public override string ToString() => $"Sale[Id={Id}, Amount={Amount:C3}, Date={Date:dd/MM/yyyy}]";
    }
}
