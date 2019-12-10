using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Web.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product && Id == product.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
