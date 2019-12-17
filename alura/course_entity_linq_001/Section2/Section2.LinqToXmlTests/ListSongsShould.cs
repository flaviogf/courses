using Section2.LinqToXml;
using Xunit;

namespace Section2.LinqToXmlTests
{
    public class ListSoundsShould
    {
        [Fact]
        public async void ReturnSongsWithGenre()
        {
            var songRepository = new XmlSongRepository();

            var genreRepository = new XmlGenreRepository();

            var useCase = new ListSongs(songRepository, genreRepository);

            var songs = await useCase.Execute();

            Assert.Collection(songs,
            (it) =>
            {
                Assert.Equal(900, it.Id);
            },
            (it) =>
            {
                Assert.Equal(1154, it.Id);
            },
            (it) =>
            {
                Assert.Equal(3445, it.Id);
            });
        }
    }
}
