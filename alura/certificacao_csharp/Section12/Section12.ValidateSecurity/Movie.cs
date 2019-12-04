using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Section12.ValidateSecurity
{
    public class Movie:IValidatableObject
    {
        public Movie()
        {
        }

        public Movie(int id, string name, string director, int minutes)
        {
            Id = id;
            Name = name;
            Director = director;
            Minutes = minutes;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public int Minutes { get; set; }

        public override string ToString() => $"Movie[Id={Id}, Name={Name}, Director={Director}, Minutes={Minutes}]";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return new ValidationResult("Name doesn't valid.");
        }
    }
}
