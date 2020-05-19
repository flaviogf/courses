using System.ComponentModel.DataAnnotations.Schema;

namespace AluraMovies.App.Models
{
    [Table("actor")]
    public class Actor
    {
        [Column("actor_id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Actor[Id={Id}, FirstName={FirstName}, LastName={LastName}]";
        }
    }
}
