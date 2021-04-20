namespace CreditCardApplications
{
    public class CreditCardApplicationEvaluator
    {
        private const int AutoReferralMaxAge = 20;

        private const int HighIncomeThreshold = 100_00;

        private const int LowIncomeTrheshold = 20_000;

        public CreditCardApplicationDecision Evaluate(CreditCardApplication application)
        {
            if (application.GrossAnnualIncome >= HighIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoAccepted;
            }

            if (application.Age <= AutoReferralMaxAge)
            {
                return CreditCardApplicationDecision.ReferredToHuman;
            }

            if (application.GrossAnnualIncome < LowIncomeTrheshold)
            {
                return CreditCardApplicationDecision.AutoDeclined;
            }

            return CreditCardApplicationDecision.ReferredToHuman;
        }
    }
}