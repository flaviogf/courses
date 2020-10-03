using System;
using School.Domain.Students;
using Xunit;

namespace School.Test
{
    public class EmailTest
    {
        [Fact]
        public void It_Should_Throw_An_Exception_When_The_Passed_Value_Is_Not_Valid()
        {
            Assert.Throws<ArgumentException>(() => new Email(null));

            Assert.Throws<ArgumentException>(() => new Email(""));
        }
    }
}
