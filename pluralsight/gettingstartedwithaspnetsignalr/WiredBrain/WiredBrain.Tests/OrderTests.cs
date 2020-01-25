using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WiredBrain.Web.Models;

namespace WiredBrain.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Should_Be_Requested_When_An_Order_Is_Created()
        {
            var coffee = new Order(Guid.NewGuid(), "Coffee", 1);

            Assert.IsInstanceOfType(coffee.State, typeof(Requested));
        }

        [TestMethod]
        public void Should_Be_In_Progress_When_An_Order_Is_Processed_For_The_First_Time()
        {
            var coffee = new Order(Guid.NewGuid(), "Coffee", 1);

            var inProgress = coffee.Process();

            Assert.IsInstanceOfType(inProgress.State, typeof(InProgress));
        }

        [TestMethod]
        public void Should_Be_Finished_When_An_Order_Is_Processed_For_The_Twice_Time()
        {

            var coffee = new Order(Guid.NewGuid(), "Coffee", 1);

            var finished = coffee.Process().Process();

            Assert.IsInstanceOfType(finished.State, typeof(Finished));
        }

        [TestMethod]
        [ExpectedException(typeof(OrderAlreadyFinishedException))]
        public void Should_Throw_An_OrderAlreadyFinishedExpection_When_An_Order_Is_Processed_When_That_Is_Already_Finished()
        {
            var coffee = new Order(Guid.NewGuid(), "Coffee", 1);

            coffee.Process().Process().Process();
        }
    }
}