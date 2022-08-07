# frozen_string_literal: true

require 'spec_helper'

module ExpenseTracker
  RSpec.describe 'Expense Tracker API' do
    include Rack::Test::Methods

    it 'records submitted expenses' do
      coffee = {
        payee: 'Starbucks',
        price: 575,
        date: '2017-06-20'
      }

      post '/expenses', JSON.dump(coffee)
    end

    def app
      ExpenseTracker::API.new
    end
  end
end
