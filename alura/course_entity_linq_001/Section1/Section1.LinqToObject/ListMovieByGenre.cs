using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Section1.LinqToObject
{
    public class ListMovieByGenre
    {
        private readonly IMovieRepository _movieRepository;

        private readonly IGenreRepository _genreRepository;

        public ListMovieByGenre
        (
            IMovieRepository movieRepository,
            IGenreRepository genreRepository
        )
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IList<Movie>> Execute(int genreId)
        {
            var movies = (from movie in await _movieRepository.List()
                          join genre in await _genreRepository.List() on movie.GenreId equals genre.Id
                          where movie.GenreId == genreId
                          orderby movie.Id ascending
                          select new Movie(movie.Id, movie.Name, genre)).ToList();

            return movies;
        }
    }
}
