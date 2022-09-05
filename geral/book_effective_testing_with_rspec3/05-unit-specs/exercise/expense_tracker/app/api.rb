# frozen_string_literal: true

require 'sinatra'

module ExpenseTracker
  class API < Sinatra::Base
    def initialize(ledger: Ledger.new)
      @ledger = ledger
      super
    end

    post '/expenses' do
      expense = JSON.parse(request.body.read)
      result = @ledger.record(expense)

      if result.success?
        JSON.dump('expense_id' => result.expense_id)
      else
        status(422)
      end
    end

    get '/expenses/:date' do
      JSON.dump([])
    end
  end
end
