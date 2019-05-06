using Store.Domain.ValueObjects;
using Xunit;

namespace Store.Tests.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void ShouldReturnValidTrueWhenAddressIsValid()
        {
            var email = new Email("captain@marvel.com.br");

            Assert.True(email.Valid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenAddresIsInvaldi()
        {
            var email = new Email("");

            Assert.True(email.Invalid);
        }
    }
}