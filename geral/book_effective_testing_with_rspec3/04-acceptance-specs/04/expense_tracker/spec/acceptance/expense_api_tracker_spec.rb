# frozen_string_literal: true

RSpec.describe 'Expense Tracker API' do
  include Rack::Test::Methods

  it 'records submitted expenses' do
    coffee = {
      'payee' => 'Starbucks',
      'amount' => 5.15,
      'date' => '2022-08-14'
    }

    post '/expenses', JSON.dump(coffee)
    expect(last_response.status).to eq(200)

    parsed = JSON.parse(last_response.body)
    expect(parsed).to include('expense_id' => kind_of(Integer))
  end

  def app
    ExpenseTracker::API.new
  end
end
