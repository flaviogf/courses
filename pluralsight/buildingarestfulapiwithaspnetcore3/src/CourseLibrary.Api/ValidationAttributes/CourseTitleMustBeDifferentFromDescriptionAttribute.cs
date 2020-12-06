using System.ComponentModel.DataAnnotations;

namespace CourseLibrary.Api.ValidationAttributes
{
    public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        public CourseTitleMustBeDifferentFromDescriptionAttribute()
        {
            ErrorMessage = "The title and description must be different";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var target = validationContext.ObjectInstance;

            var title = target.GetType().GetProperty("Title")?.GetValue(target)?.ToString()?.ToLower();

            var description = target.GetType().GetProperty("Description")?.GetValue(target)?.ToString()?.ToLower();

            if (title == description)
            {
                return new ValidationResult(ErrorMessage, new string[] { nameof(CourseTitleMustBeDifferentFromDescriptionAttribute) });
            }

            return ValidationResult.Success;
        }
    }
}
