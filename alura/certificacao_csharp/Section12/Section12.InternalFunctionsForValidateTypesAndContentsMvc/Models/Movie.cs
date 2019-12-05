using System.ComponentModel.DataAnnotations;

namespace Section12.InternalFunctionsForValidateTypesAndContentsMvc.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string Director { get; set; }

        [Range(30, 240)]
        public int Minutes { get; set; }
    }
}
