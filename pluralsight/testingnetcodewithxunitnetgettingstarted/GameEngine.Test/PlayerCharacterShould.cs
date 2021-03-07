using Xunit;

namespace GameEngine.Test
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new();

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            PlayerCharacter sut = new();

            sut.FirstName = "SARAH";
            sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            PlayerCharacter sut = new();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Contains("ah Sm", sut.FullName);
        }

        [Fact]
        public void CalculatFullNameWithTitleCase()
        {
            PlayerCharacter sut = new();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.StartsWith("Sarah", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            PlayerCharacter sut = new();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.EndsWith("Smith", sut.LastName);
        }
    }
}
