using Xunit;

namespace GameEngine.Test
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorrectPower()
        {
            Enemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.SpecialAttackPower, precision: 3);
        }
    }
}
