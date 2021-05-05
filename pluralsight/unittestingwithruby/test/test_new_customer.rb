$LOAD_PATH.unshift(File.expand_path('../lib', __dir__))

require 'minitest/autorun'
require 'securerandom'
require 'customers'

class TestNewCustomer < Minitest::Test
    def setup
        @customer_repository = Minitest::Mock.new

        @sut = Customers::NewCustomer.new @customer_repository
    end

    def test_should_return_customer_response
        @customer_repository.expect :find_by_email, nil, [String]

        @customer_repository.expect :add, nil, [Customers::Customer]

        request = {first_name: 'frank', last_name: 'castle', email: 'frank@email.com'}

        response = @sut.execute request

        assert response != nil, 'it should not be nil'
        assert response[:id] != nil, 'it should not be nil'
        assert_equal request[:first_name], response[:first_name], "#{response[:first_name]} should equal #{request[:first_name]}"
        assert_equal request[:last_name], response[:last_name], "#{response[:last_name]} should equal #{request[:last_name]}"
        assert_equal request[:email], response[:email], "#{response[:email]} should equal #{request[:email]}"
    end

    def test_should_add_a_new_customer
        @customer_repository.expect :find_by_email, nil, [String]

        @customer_repository.expect :add, nil, [Customers::Customer]

        request = {first_name: 'frank', last_name: 'castle', email: 'frank@email.com'}

        @sut.execute request

        @customer_repository.verify
    end

    def test_should_return_nil_when_the_email_is_already_taken
        customer = Customers::Customer.new SecureRandom.uuid, 'Frank', 'Castle', 'frank@email.com'

        @customer_repository.expect :find_by_email, customer, [String]

        @customer_repository.expect :add, nil, [Customers::Customer]

        request = {first_name: 'frank', last_name: 'castle', email: 'frank@email.com'}

        response = @sut.execute request

        assert_nil response, 'it should be nil'
    end
end
