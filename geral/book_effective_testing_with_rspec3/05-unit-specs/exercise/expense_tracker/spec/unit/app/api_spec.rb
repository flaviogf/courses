# frozen_string_literal: true

require 'spec_helper'

module ExpenseTracker
  RecordResult = Struct.new(:success?, :expense_id, :error)

  RSpec.describe API do
    include Rack::Test::Methods

    let(:ledger) { instance_double('ExpenseTracker::Ledger') }
    let(:expense) { { 'data' => 'something' } }

    before do
      allow(ledger).to receive(:record)
        .with(expense)
        .and_return(RecordResult.new(true, 457, ''))
    end

    describe '/expenses (POST)' do
      it 'returns status 200 (OK)' do
        post '/expenses', JSON.dump(expense)

        expect(last_response.status).to eq(200)
      end

      it 'returns the recorded expense id' do
        post '/expenses', JSON.dump(expense)

        response = JSON.parse(last_response.body)

        expect(response).to include('expense_id' => 457)
      end

      context 'when the expense is invalid' do
        before do
          allow(ledger).to receive(:record)
            .with(expense)
            .and_return(RecordResult.new(false, nil, 'invalid expense'))
        end

        it 'returns status 422 (Unprocessable Entity' do
          post '/expenses', JSON.dump(expense)

          expect(last_response.status).to eq(422)
        end

        it 'returns the error message' do
          post '/expenses', JSON.dump(expense)

          response = JSON.parse(last_response.body)

          expect(response).to include('error' => 'invalid expense')
        end
      end
    end

    describe '/expenses/:date (GET)' do
      it 'returns status 200 (OK)' do
      end

      it 'returns the expense records as JSON' do
      end
    end

    def app
      ExpenseTracker::API.new(ledger:)
    end
  end
end
