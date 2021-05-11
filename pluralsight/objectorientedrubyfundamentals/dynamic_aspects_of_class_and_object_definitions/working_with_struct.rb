Customer = Struct.new(:first_name, :last_name, keyword_init: true) do
    def full_name
        "#{first_name} #{last_name}"
    end
end

customer = Customer.new first_name: 'Frank', last_name: 'Castle'

puts customer.full_name
