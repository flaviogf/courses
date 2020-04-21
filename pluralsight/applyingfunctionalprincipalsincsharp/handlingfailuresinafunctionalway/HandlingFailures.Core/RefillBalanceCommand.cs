namespace HandlingFailures.Core
{
    public class RefillBalanceCommand : ICommand<RefillBalanceInput>
    {
        private readonly IUnitOfWork _uow;

        private readonly ICustomerRepository _customerRepository;

        private readonly IPaymentGateway _paymentGateway;

        private readonly ILog _log;

        public RefillBalanceCommand(IUnitOfWork uow, ICustomerRepository customerRepository, IPaymentGateway paymentGateway, ILog log)
        {
            _uow = uow;
            _customerRepository = customerRepository;
            _paymentGateway = paymentGateway;
            _log = log;
        }

        public Result Execute(RefillBalanceInput input)
        {
            Result<MoneyToCharge> moneyToCharge = MoneyToCharge.Create(input.MoneyAmount);

            Result<Customer> customer = _customerRepository.Get(input.CustomerId).ToResult("Customer doesn't exist.");

            return Result.Combine(moneyToCharge, customer)
                .OnSuccess(() => customer.Value.AddBalance(moneyToCharge.Value.Value).ToResult("For increment the current balance the value at increment must be greater than 100"))
                .OnSuccess(() => _paymentGateway.Charge(customer.Value.BillingInfo, moneyToCharge.Value.Value))
                .OnSuccess(() => _uow.Commit().OnFailure(() => _paymentGateway.Rollback()))
                .OnBoth(() => _log.Info("RefillBalanceCommand has been executed."));
        }
    }
}
