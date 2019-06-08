using Xunit;
using Section3.ExplicitInterface;
using System;

namespace Section3.ExplicitInterface.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void ShouldEmployeeContainsEmployeeWorkload()
        {
            IEmployee peter = new Employee();

            peter.Workload = 40;

            Assert.Equal(40, peter.Workload);
        }

        [Fact]
        public void ShouldGenerateBadgeForEmployee()
        {
            IEmployee peter = new Employee();

            peter.BadgeGenerate += (sender, args) => Assert.Equal("employee badge generate", args.Message);

            peter.GenerateBadge();
        }

        [Fact]
        public void ShouldEmployeeContainsOnCallWorkload()
        {
            IOnCall peter = new Employee();

            peter.Workload = 20;

            Assert.Equal(20, peter.Workload);
        }

        [Fact]
        public void ShouldGenerateBadgeForOnCall()
        {
            IOnCall peter = new Employee();

            peter.BadgeGenerate += (sender, args) => Assert.Equal("on call badge generate", args.Message);

            peter.GenerateBadge();
        }
    }
}
