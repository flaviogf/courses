namespace FunctionalPrinciples.AvoidingNulls.Core
{
    public class CreateCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Result Execute(string name, string email)
        {
            var nameResult = Name.Create(name);

            if (nameResult.IsFailure)
            {
                return Result.Fail(nameResult.Error);
            }

            var emailResult = Email.Create(email);

            if (emailResult.IsFailure)
            {
                return Result.Fail(emailResult.Error);
            }

            var customer = _customerRepository.FindOneByEmail(emailResult.Value.ToString());

            if (customer.HasValue)
            {
                return Result.Fail("Email already taken");
            }

            var addResult = _customerRepository.Add(new Customer(nameResult.Value, emailResult.Value));

            if (addResult.IsFailure)
            {
                return Result.Fail(addResult.Error);
            }

            return Result.Ok();
        }
    }
}