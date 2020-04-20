namespace FunctionalPrinciples.AvoidingNulls.Core
{
    public class Customer
    { 
        public Customer(Name name, Email email)
        {
            Name = name;
            Email = email;
        }

        public Name Name { get; }
        
        public Email Email { get; }
    }
}