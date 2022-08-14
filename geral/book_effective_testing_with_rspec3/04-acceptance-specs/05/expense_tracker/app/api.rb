# frozen_string_literal: true

require 'sinatra'
require 'json'

module ExpenseTracker
  class API < Sinatra::Base
    post '/expenses' do
      JSON.dump('expense_id' => 42)
    end

    get '/expenses/:date' do
      JSON.dump([])
    end
  end
end
