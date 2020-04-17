using System;

namespace PrimitiveObsession.Core
{
    public class Customer
    {
        public Customer(Name name, Email email)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (email == null)
                throw new ArgumentNullException(nameof(email));

            Name = name;
            Email = email;
        }

        public Name Name { get; }

        public Email Email { get; }
    }
}