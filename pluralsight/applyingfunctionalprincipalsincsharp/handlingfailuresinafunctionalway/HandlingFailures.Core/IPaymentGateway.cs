namespace HandlingFailures.Core
{
    public interface IPaymentGateway
    {
        Result Charge(string billingInfo, decimal value);

        Result Rollback();
    }
}
