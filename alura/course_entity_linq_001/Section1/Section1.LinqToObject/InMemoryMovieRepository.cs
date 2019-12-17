using System.Collections.Generic;
using System.Threading.Tasks;

namespace Section1.LinqToObject
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        public async Task<IList<Movie>> List()
        {
            var movies = new List<Movie>
            {
                new Movie(1, "Lord of the rings", 1),
                new Movie(2, "Harry Potter", 1),
                new Movie(3, "Rambo", 2),
                new Movie(4, "The Mercenaries", 2),
            };

            return movies;
        }
    }
}
