using System.ComponentModel.DataAnnotations;
using CourseLibrary.Api.ValidationAttributes;

namespace CourseLibrary.Api.Models
{
    [CourseTitleMustBeDifferentFromDescription]
    public class CourseForUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
    }
}
