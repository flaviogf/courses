using Moq;
using Xunit;

namespace CreditCardApplications.Tests
{
    public class CreditCardApplicationEvaluatorShould
    {
        [Fact]
        public void AcceptHighIncomeApplications()
        {
            Mock<IFrequentFlyerNumberValidator> validator = new();

            CreditCardApplicationEvaluator sut = new(validator.Object);

            CreditCardApplication application = new() { GrossAnnualIncome = 100_000 };

            CreditCardApplicationDecision decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoAccepted, decision);
        }

        [Fact]
        public void ReferYoungApplications()
        {
            Mock<IFrequentFlyerNumberValidator> validator = new();

            CreditCardApplicationEvaluator sut = new(validator.Object);

            CreditCardApplication application = new() { Age = 19 };

            CreditCardApplicationDecision decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
        }

        [Fact]
        public void DeclineLowIncomeApplications()
        {
            Mock<IFrequentFlyerNumberValidator> validator = new();

            validator.Setup(it => it.IsValid(It.IsRegex(@"[a-z]"))).Returns(true);

            CreditCardApplicationEvaluator sut = new(validator.Object);

            CreditCardApplication application = new()
            {
                GrossAnnualIncome = 19_999,
                Age = 49,
                FrequentFlyerNumber = "y"
            };

            CreditCardApplicationDecision decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
        }

        [Fact]
        public void ReferInvalidFrequentFlyerApplication()
        {
            Mock<IFrequentFlyerNumberValidator> validator = new(MockBehavior.Strict);

            validator.Setup(it => it.IsValid(It.IsAny<string>())).Returns(false);

            CreditCardApplicationEvaluator sut = new(validator.Object);

            CreditCardApplication application = new();

            CreditCardApplicationDecision decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
        }
    }
}