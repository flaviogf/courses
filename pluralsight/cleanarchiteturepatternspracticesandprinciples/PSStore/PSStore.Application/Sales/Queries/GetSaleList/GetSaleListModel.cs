using System;

namespace PSStore.Application.Sales.Queries.GetSaleList
{
    public class GetSaleListModel
    {
        public Guid Id { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
