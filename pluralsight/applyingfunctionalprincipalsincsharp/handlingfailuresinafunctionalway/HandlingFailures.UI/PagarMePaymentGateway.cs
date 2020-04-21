using HandlingFailures.Core;
using System;

namespace HandlingFailures.UI
{
    public class PagarMePaymentGateway : IPaymentGateway
    {
        public Result Charge(string billingInfo, decimal value)
        {
            Console.WriteLine("PagarMePaymentGateway: Charging");
            Console.WriteLine("PagarMePaymentGateway: {0}", billingInfo);
            Console.WriteLine("PagarMePaymentGateway: {0:C}", value);

            return Result.Ok();
        }

        public Result Rollback()
        {
            Console.WriteLine("PagarMePaymentGateway: Rollbacking");

            return Result.Ok();
        }
    }
}
