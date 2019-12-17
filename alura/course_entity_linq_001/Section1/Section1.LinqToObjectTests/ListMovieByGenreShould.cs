using Section1.LinqToObject;
using Xunit;

namespace Section1.LinqToObjectTests
{
    public class ListMovieByGenreShould
    {
        [Fact]
        public async void ReturnMoviesFilteredByGenreId()
        {
            var movieRepository = new InMemoryMovieRepository();

            var genreRepository = new InMemoryGenreRepository();

            var useCase = new ListMovieByGenre(movieRepository, genreRepository);

            var movies = await useCase.Execute(genreId: 1);

            Assert.Collection(movies,
            (it) =>
            {
                Assert.Equal(1, it.Id);
                Assert.Equal(1, it.Genre.Id);
            },
            (it) =>
            {
                Assert.Equal(2, it.Id);
                Assert.Equal(1, it.Genre.Id);
            });
        }
    }
}
