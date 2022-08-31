# frozen_string_literal: true

module ExpenseTracker
  RSpec.describe API do
    RecordResult = Struct.new(:success?, :expense_id, :error)

    include Rack::Test::Methods

    let(:ledger) { instance_double('ExpenseTracker::Ledger') }

    let(:expense) { { 'some' => 'data' } }

    describe 'POST /expenses' do
      context 'when the expense is successfully recorded' do
        before do
          allow(ledger).to receive(:record)
            .with(expense)
            .and_return(RecordResult.new(true, 417, ''))
        end

        it 'returns the expense id' do
          post '/expenses', JSON.dump(expense)

          response = JSON.parse(last_response.body)
          expect(response).to include('expense_id' => 417)
        end

        it 'responds with a 200 (OK)' do
          post 'expenses', JSON.dump(expense)

          expect(last_response.status).to eq(200)
        end
      end

      context 'when the expense fails validation' do
        before do
          allow(ledger).to receive(:record)
            .with(expense)
            .and_return(RecordResult.new(false, nil, 'Expense incomplete'))
        end

        it 'returns an error message' do
          post '/expenses', JSON.dump(expense)

          response = JSON.parse(last_response.body)
          expect(response).to include('error' => 'Expense incomplete')
        end

        it 'responds with a 402 (Unprocessable entity)' do
          post '/expenses', JSON.dump(expense)

          expect(last_response.status).to eq(402)
        end
      end
    end

    def app
      ExpenseTracker::API.new(ledger:)
    end
  end
end
