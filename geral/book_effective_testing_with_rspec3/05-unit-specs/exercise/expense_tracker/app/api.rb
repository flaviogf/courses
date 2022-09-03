# frozen_string_literal: true

require 'sinatra'

module ExpenseTracker
  class API < Sinatra::Base
    post '/expenses' do
      JSON.dump('expense_id' => 42)
    end
  end
end
