using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Web.Models
{
    public class OrderProduct
    {
        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OrderProduct product && OrderId == product.OrderId && ProductId == product.ProductId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId, ProductId);
        }
    }
}
