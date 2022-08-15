# frozen_string_literal: true

module ExpenseTracker
  RecordResult = Struct.new(:success?, :expense_id, :error_message)

  RSpec.describe API do
    include Rack::Test::Methods

    let(:ledger) { instance_double('ExpenseTracker::Ledger') }

    describe 'POST /expenses' do
      context 'when the expense is successfully recorded' do
        it 'returns the expense id' do
          expense = { 'some' => 'data' }

          allow(ledger).to receive(:record).with(expense).and_return(RecordResult.new(true, 417, ''))

          post '/expenses', JSON.dump(expense)

          expect(last_response.status).to eq(200)

          parsed = JSON.parse(last_response.body)
          expect(parsed).to include('expense_id' => 417)
        end

        it 'responds with a 200 (OK)' do
        end
      end

      context 'when the expense fails validation' do
        it 'returns an error message' do
        end

        it 'responds with a 422 (Unprocessable entity)' do
        end
      end
    end

    def app
      described_class.new(ledger: ledger)
    end
  end
end
