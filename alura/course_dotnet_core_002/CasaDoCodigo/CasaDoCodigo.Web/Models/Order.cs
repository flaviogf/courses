using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Web.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public List<OrderProduct> Products { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Order order && Id == order.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
