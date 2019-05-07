using Xunit;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests.Domain.StoreContext.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void ShouldReturnValidTrueWhenFirstNameIsValid()
        {
            var name = new Name("Steve", "Rogers");

            Assert.True(name.Valid);
        }

        [Fact]
        public void ShouldReturnValidTrueWhenLastNameIsValid()
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