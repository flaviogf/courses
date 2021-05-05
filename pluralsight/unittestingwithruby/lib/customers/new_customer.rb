require 'securerandom'

module Customers
    class NewCustomer
        def initialize(customer_repository)
            @customer_repository = customer_repository
        end

        def execute(request)
            customer = Customer.new SecureRandom.uuid, request[:first_name], request[:last_name], request[:email]

            return nil if @customer_repository.find_by_email request[:email]

            @customer_repository.add customer

            {id: customer.id, first_name: customer.first_name, last_name: customer.last_name, email: customer.email}
        end
    end
end
