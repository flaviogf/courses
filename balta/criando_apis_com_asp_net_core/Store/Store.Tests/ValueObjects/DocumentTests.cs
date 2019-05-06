using Store.Domain.ValueObjects;
using Xunit;

namespace Store.Tests.ValueObjects
{
    public class DocumentTests
    {
        [Fact]
        public void ShoudlReturnValidTrueWhenNumberIsValid()
        {
            var document = new Document("434.153.770-91");

            Assert.True(document.Valid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenNumberIsInvalid()
        {
            var document = new Document("");

            Assert.True(document.Invalid);
        }
    }
}