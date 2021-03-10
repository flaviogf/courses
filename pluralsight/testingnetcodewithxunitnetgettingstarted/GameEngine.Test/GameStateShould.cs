using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
    [Trait("Category", "Game")]
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly GameStateFixture _gameStateFixture;

        public GameStateShould(ITestOutputHelper testOutputHelper, GameStateFixture gameStateFixture)
        {
            _testOutputHelper = testOutputHelper;

            _gameStateFixture = gameStateFixture;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _testOutputHelper.WriteLine("GameState ID: {0}", _gameStateFixture.State.Id);

            PlayerCharacter player1 = new();

            PlayerCharacter player2 = new();

            _gameStateFixture.State.Add(player1);

            _gameStateFixture.State.Add(player2);

            int expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            _gameStateFixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);

            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            _testOutputHelper.WriteLine("GameState ID: {0}", _gameStateFixture.State.Id);

            PlayerCharacter player1 = new();

            PlayerCharacter player2 = new();

            _gameStateFixture.State.Add(player1);

            _gameStateFixture.State.Add(player2);

            _gameStateFixture.State.Reset();

            Assert.Empty(_gameStateFixture.State.Players);
        }
    }
}
