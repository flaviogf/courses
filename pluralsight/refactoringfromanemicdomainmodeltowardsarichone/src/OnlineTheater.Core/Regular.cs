namespace OnlineTheater.Core
{
    public class Regular : CustomerStatus
    {
        public Regular() : base(ExpirationDate.Infinite, ECustomerStatusType.Regular)
        {
        }

        public override decimal Discount => 0;

        public override CustomerStatus Promote()
        {
            return Advanced;
        }
    }
}
