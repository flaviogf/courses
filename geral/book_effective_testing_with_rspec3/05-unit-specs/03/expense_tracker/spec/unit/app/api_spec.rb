# frozen_string_literal: true

module ExpenseTracker
  RecordResult = Struct.new(:success?, :expense_id, :error)

  RSpec.describe API do
    include Rack::Test::Methods

    let(:ledger) { instance_double('ExpenseTracker::Ledger') }
    let(:expense) { { 'some' => 'data' } }

    before do
      allow(ledger).to receive(:record)
        .with(expense)
        .and_return(RecordResult.new(true, 417, nil))
    end

    describe 'POST /expenses' do
      context 'when the expense is successfully recorded' do
        it 'returns the expense id' do
          post '/expenses', JSON.dump(expense)

          parsed = JSON.parse(last_response.body)
          expect(parsed).to include('expense_id' => 417)
        end

        it 'responds with a 200 (OK)' do
          post '/expenses', JSON.dump(expense)

          expect(last_response.status).to eq(200)
        end
      end
    end

    def app
      described_class.new(ledger: ledger)
    end
  end
end
