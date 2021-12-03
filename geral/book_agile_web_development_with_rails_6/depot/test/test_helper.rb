ENV['RAILS_ENV'] ||= 'test'
require_relative '../config/environment'
require 'rails/test_help'

Capybara.server_host = '0.0.0.0'
Capybara.server_port = 4000
Capybara.app_host = 'http://web:4000'

module AuthenticationHelpers
  def setup
    login_as users(:dave)
  end

  def login_as(user)
    return post login_url, params: { name: user.name, password: 'secret' } unless respond_to? :visit

    visit login_url
    fill_in :name, with: user.name
    fill_in :password, with: 'secret'
    click_on 'Login'
  end

  def logout
    delete logout_url
  end
end

class ActiveSupport::TestCase
  # Run tests in parallel with specified workers
  parallelize(workers: 1)

  # Setup all fixtures in test/fixtures/*.yml for all tests in alphabetical order.
  fixtures :all

  # Add more helper methods to be used by all tests here...
end

class ActionDispatch::IntegrationTest
  include AuthenticationHelpers
end

class ActionDispatch::SystemTestCase
  include AuthenticationHelpers
end
