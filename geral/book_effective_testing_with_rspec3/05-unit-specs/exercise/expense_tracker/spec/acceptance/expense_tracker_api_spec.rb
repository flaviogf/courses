# frozen_string_literal: true

require 'spec_helper'

RSpec.describe 'ExpenseTracker API' do
  include Rack::Test::Methods

  describe '/expenses (POST)' do
    it 'records an expense' do
      pending 'Not implemented yet'

      coffee = post_expense(
        'payee' => 'Starbucks',
        'amount' => 0.75,
        'date' => '2022-08-01'
      )

      game = post_expense(
        'payee' => 'GameStop',
        'amount' => 50.0,
        'date' => '2022-08-01'
      )

      _ = post_expense(
        'payee' => 'Ikea',
        'amount' => 199.99,
        'date' => '2022-08-02'
      )

      get '/expenses/2022-08-01'

      expect(last_response.status).to eq(200)

      response = JSON.parse(last_response.body)

      expect(response).to contain_exactly(
        [
          a_hash_including('expense_id' => coffee['expense_id']),
          a_hash_including('expense_id' => game['expense_id'])
        ]
      )
    end
  end

  def app
    ExpenseTracker::API.new
  end

  def post_expense(expense)
    post '/expenses', JSON.dump(expense)

    expect(last_response.status).to eq(200)

    response = JSON.parse(last_response.body)

    expect(response).to include('expense_id' => 42)

    expense.merge('expense_id' => response['expense_id'])
  end
end
