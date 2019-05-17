using System.Threading;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using Store.Domain.StoreContext.Commands;
using Store.Domain.StoreContext.Repositories;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var emailAvailable = _customerRepository.CheckEmail(command.Email);

            if (!emailAvailable)
            {
                AddNotification("Email", "Email not is available");
            }

            return Task.FromResult(Unit.Value);
        }
    }
}