using Store.Domain.StoreContext.ValueObjects;
using Xunit;

namespace Store.Tests.Domain.StoreContext.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void ShoudlReturnValidTrueWhenEmailAddressIsValid()
        {
            var email = new Email("captain@marvel.com.br");

            Assert.True(email.Valid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenEmailAddressIsInvalid()
        {
            var email = new Email("");

            Assert.True(email.Invalid);
        }
    }
}