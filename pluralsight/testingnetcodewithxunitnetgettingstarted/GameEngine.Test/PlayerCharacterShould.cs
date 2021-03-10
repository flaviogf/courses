using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
    [Trait("Category", "Player")]
    public class PlayerCharacterShould : IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly PlayerCharacter _sut;

        public PlayerCharacterShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            testOutputHelper.WriteLine("Creating Player Character");

            _sut = new PlayerCharacter();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            _sut.FirstName = "SARAH";
            _sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Contains("ah Sm", _sut.FullName);
        }

        [Fact]
        public void CalculatFullNameWithTitleCase()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.StartsWith("Sarah", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.EndsWith("Smith", _sut.LastName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleep()
        {
            _sut.Sleep();

            Assert.InRange(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNicknameByDefault()
        {
            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, it => it.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new string[] { "Long Bow", "Short Bow", "Short Sword" };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void NotHaveDefaultEmptyWeapons()
        {
            Action<string> isNotEmpty = it => Assert.False(string.IsNullOrWhiteSpace(it));

            Assert.All(_sut.Weapons, isNotEmpty);
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(handler => _sut.PlayerSlept += handler, handler => _sut.PlayerSlept -= handler, () => _sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChanged()
        {
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Disposing Player Character {0}", _sut.FirstName);
        }
    }
}
