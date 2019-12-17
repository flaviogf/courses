using System.Collections.Generic;
using System.Threading.Tasks;

namespace Section2.LinqToXml
{
    public class ListSongs
    {
        private readonly ISongRepository _songRepository;

        private readonly IGenreRepository _genreRepository;

        public ListSongs(ISongRepository songRepository, IGenreRepository genreRepository)
        {
            _songRepository = songRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IList<Song>> Execute()
        {
            return await _songRepository.List();
        }
    }
}