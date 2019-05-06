using Store.Domain.ValueObjects;
using Xunit;

namespace Store.Tests.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void ShouldReturnValidTrueWhenFirstNameAndLastNameAreValid()
        {
            var name = new Name("Steve", "Rogers");

            Assert.True(name.Valid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenFirstNameIsInvalid()
        {
            var name = new Name("", "Rogers");

            Assert.True(name.Invalid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenLastNameIsInvalid()
        {
            var name = new Name("Steve", "");

            Assert.True(name.Invalid);
        }
    }
}