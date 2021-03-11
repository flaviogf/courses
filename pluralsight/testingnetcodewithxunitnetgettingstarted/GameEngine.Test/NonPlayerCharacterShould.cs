using Xunit;

namespace GameEngine.Test
{
    [Trait("Category", "NonPlayer")]
    public class NonPlayerCharacterShould
    {
        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        public void TakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}
