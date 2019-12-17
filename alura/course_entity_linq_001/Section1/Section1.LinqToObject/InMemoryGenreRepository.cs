using System.Collections.Generic;
using System.Threading.Tasks;

namespace Section1.LinqToObject
{
    public class InMemoryGenreRepository : IGenreRepository
    {
        public async Task<IList<Genre>> List()
        {
            var genres = new List<Genre>
            {
                new Genre(1, "Action"),
                new Genre(2, "Fantasy")
            };

            return genres;
        }
    }
}
