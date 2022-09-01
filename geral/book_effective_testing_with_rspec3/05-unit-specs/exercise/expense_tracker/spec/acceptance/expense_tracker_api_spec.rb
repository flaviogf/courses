# frozen_string_literal: true

require 'spec_helper'

RSpec.describe 'ExpenseTracker API' do
  include Rack::Test::Methods

  describe '/expenses (POST)' do
    it 'records an expense' do
      expense = {
        'payee' => 'Starbucks',
        'amount' => 0.75,
        'date' => '2022-08-01'
      }

      post '/expenses', JSON.dump(expense)

      expect(last_response.status).to eq(200)
    end
  end
end
