module Customers
    class Customer
        attr_accessor :id, :first_name, :last_name, :email

        def initialize(id, first_name, last_name, email)
            @id = id
            @first_name = first_name
            @last_name = last_name
            @email = email
        end
    end
end
