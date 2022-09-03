# frozen_string_literal: true

require 'spec_helper'

module ExpenseTracker
  RSpec.describe API do
    include Rack::Test::Methods

    describe '/expenses (POST)' do
      it 'returns status 200 (OK)' do
        expense = { 'data' => 'something' }
        post '/expenses', JSON.dump(expense)

        expect(last_response.status). to eq(200)
      end
    end

    def app
      ExpenseTracker::API.new
    end
  end
end
