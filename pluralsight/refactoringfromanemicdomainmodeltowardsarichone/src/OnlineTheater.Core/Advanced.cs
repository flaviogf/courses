using System;

namespace OnlineTheater.Core
{
    public class Advanced : CustomerStatus
    {
        public Advanced() : base((ExpirationDate)DateTime.UtcNow.AddYears(1), ECustomerStatusType.Advanced)
        {
        }

        public override decimal Discount => 0.25m;

        public override CustomerStatus Promote()
        {
            throw new InvalidOperationException("Advanced status cannot be promoted");
        }
    }
}
