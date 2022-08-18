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
      expense.merge!('expense_id' => result.expense_id)
      JSON.dump(expense)
    end
  end
end
