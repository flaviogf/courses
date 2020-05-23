using System.Collections.Generic;

namespace AluraMovies.App.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ReleaseYear { get; set; }

        public short Length { get; set; }

        public string Rating { get; set; }

        public IList<MovieActor> Actors { get; set; }

        public override string ToString()
        {
            return $"Movie[Title={Title}, ReleaseYear={ReleaseYear}, Length={Length}, Rating={Rating}]";
        }
    }
}
