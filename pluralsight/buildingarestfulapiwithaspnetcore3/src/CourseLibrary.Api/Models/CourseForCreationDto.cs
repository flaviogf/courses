using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseLibrary.Api.Models
{
    public class CourseForCreationDto : IValidatableObject
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.Equals(Description, StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new ValidationResult("The title and description must be different", new string[] { nameof(CourseForCreationDto) });
            }
        }
    }
}
