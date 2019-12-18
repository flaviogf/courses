using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Song>> Execute()
        {
            var songs = from song in await _songRepository.List()
                        join genre in await _genreRepository.List() on song.GenreId equals genre.Id
                        select new Song
                        (
                            id: song.Id,
                            name: song.Name,
                            author: song.Autor,
                            miliseconds: song.Miliseconds,
                            bytes: song.Bytes,
                            price: song.Price,
                            genre: genre
                        );

            return songs;
        }
    }
}