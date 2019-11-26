using System;

namespace Section10.CreateAndApplyAttributes
{
    [Serializable]
    [SummarizedReport("{0} | {1}")]
    [DetailedReport("{0} | {1} | {2}")]
    public class Sale
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public override string ToString() => $"Sale[Id={Id}, Amount={Amount:C3}, Date={Date:dd/MM/yyyy}]";
    }
}
