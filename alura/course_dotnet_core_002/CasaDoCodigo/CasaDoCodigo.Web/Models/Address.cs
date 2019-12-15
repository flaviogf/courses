using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Web.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MinLength(8)]
        [MaxLength(8)]
        [Required]
        public string ZipCode { get; set; }

        [StringLength(255)]
        [Required]
        public string Street { get; set; }

        [StringLength(255)]
        [Required]
        public string District { get; set; }

        [StringLength(255)]
        [Required]
        public string City { get; set; }

        [MinLength(2)]
        [MaxLength(2)]
        [Required]
        public string State { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Address address && Id == address.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
