# frozen_string_literal: true

require 'json'
require 'rack/test'

module ExpenseTracker
  RSpec.describe 'Expense Tracker API' do
    include Rack::Test::Methods

    it 'records submitted expenses' do
      coffee = {
        payee: 'Starbucks',
        amount: 575,
        date: '2017-06-10'
      }

      post '/expenses', JSON.dump(coffee)
    end
  end
end
