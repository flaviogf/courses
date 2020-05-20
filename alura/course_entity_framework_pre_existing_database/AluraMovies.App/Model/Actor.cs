using System.ComponentModel.DataAnnotations.Schema;

namespace AluraMovies.App.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Actor[Id={Id}, FirstName={FirstName}, LastName={LastName}]";
        }
    }
}
