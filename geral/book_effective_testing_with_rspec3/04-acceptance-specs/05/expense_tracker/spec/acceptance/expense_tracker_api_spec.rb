# frozen_string_literal: true

RSpec.describe 'Expense Tracker API' do
  include Rack::Test::Methods

  it 'records submitted expenses' do
    pending 'Need to persist expenses'

    coffee = post_expense(
      'payee' => 'Starbucks',
      'amount' => 5.75,
      'date' => '2017-06-10'
    )

    zoo = post_expense(
      'payee' => 'Zoo',
      'amount' => 15.25,
      'date' => '2017-06-10'
    )

    _ = post_expense(
      'payee' => 'Whole Foods',
      'amount' => 95.20,
      'date' => '2017-06-11'
    )

    get '/expenses/2017-06-10'
    expect(last_response.status).to eq(200)

    parsed = JSON.parse(last_response.body)
    expect(parsed).to contain_exactly(coffee, zoo)
  end

  def app
    ExpenseTracker::API.new
  end

  def post_expense(expense)
    post '/expenses', JSON.dump(expense)
    expect(last_response.status).to eq(200)

    parsed = JSON.parse(last_response.body)
    expect(parsed).to include('expense_id' => kind_of(Integer))

    expense.merge('expense_id' => parsed['expense_id'])
  end
end
