using MediatR;

namespace Store.Domain.StoreContext.Commands
{
    public class CreateCustomerCommand : IRequest
    {
        public CreateCustomerCommand(string firstName, string lastName, string document, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}