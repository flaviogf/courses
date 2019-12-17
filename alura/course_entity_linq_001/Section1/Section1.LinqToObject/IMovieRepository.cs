using System.Collections.Generic;
using System.Threading.Tasks;

namespace Section1.LinqToObject
{
    public interface IMovieRepository
    {
        Task<IList<Movie>> List();
    }
}
