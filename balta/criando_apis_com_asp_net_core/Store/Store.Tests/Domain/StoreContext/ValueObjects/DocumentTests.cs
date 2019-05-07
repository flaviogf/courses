using Store.Domain.StoreContext.ValueObjects;
using Xunit;

namespace Store.Tests.Domain.StoreContext.ValueObjects
{
    public class DocumentTests
    {
        [Theory]
        [InlineData("543.917.900-33")]
        [InlineData("760.256.710-28")]
        [InlineData("594.948.530-08")]
        public void ShouldReturnValidTrueWhenDocumentIsValid(string value)
        {
            var document = new Document(value);

            Assert.True(document.Valid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("00000000001")]
        [InlineData("000000000000")]
        public void ShouldReturnInvalidTrueWhenDocumentIsInvalid(string value)
        {
            var document = new Document(value);

            Assert.True(document.Invalid);
        }
    }
}