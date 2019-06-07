using Xunit;

namespace Section2.ConversionOperators
{
    public class ByteTests
    {
        [Fact]
        public void ShouldConvertDoubleToByte()
        {
            double expected = 10;

            Byte result =  expected;

            Assert.Equal(expected, result.Value);
        }
    }
}