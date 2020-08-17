namespace OnlineTheater.Core
{
    public abstract class CustomerStatus
    {
        public static readonly CustomerStatus Regular = new Regular();

        public static readonly CustomerStatus Advanced = new Advanced();

        protected CustomerStatus(ExpirationDate expirationDate, ECustomerStatusType type)
        {
            ExpirationDate = expirationDate;
            Type = type;
        }

        public ExpirationDate ExpirationDate { get; }

        public ECustomerStatusType Type { get; }

        public abstract decimal Discount { get; }

        public abstract CustomerStatus Promote();
    }
}
