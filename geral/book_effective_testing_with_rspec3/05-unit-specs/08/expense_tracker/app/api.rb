# frozen_string_literal: true

require 'sinatra'

module ExpenseTracker
  class API < Sinatra::Base
    def initialize(ledger:)
      @ledger = ledger
      super
    end

    post '/expenses' do
      expense = JSON.parse(request.body.read)
      result = @ledger.record(expense)

      if result.success?
        JSON.dump('expense_id' => result.expense_id)
      else
        status 402
        JSON.dump('error' => result.error)
      end
    end
  end
end
