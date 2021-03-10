using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
    [Trait("Category", "Boss")]
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public BossEnemyShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void HaveCorrectPower()
        {
            _testOutputHelper.WriteLine("Creating Boss Enemy");

            Enemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.SpecialAttackPower, precision: 3);
        }
    }
}
