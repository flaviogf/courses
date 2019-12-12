using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Web.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        [MinLength(10)]
        [MaxLength(11)]
        [Required]
        public string Phone { get; set; }
    }
}
