using System;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.Api.Models;

namespace CourseLibrary.Api.ValidationAttributes
{
    public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var course = (CourseForCreationDto)validationContext.ObjectInstance;

            if (course.Title.Equals(course.Description, StringComparison.InvariantCultureIgnoreCase))
            {
                return new ValidationResult("The title and description must be different", new string[] { nameof(CourseTitleMustBeDifferentFromDescriptionAttribute) });
            }

            return ValidationResult.Success;
        }
    }
}
