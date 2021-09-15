# frozen_string_literal: true

require 'logger'

module Ex19
  class Account
    def initialize(account_number:, bank:, **options)
      @account_number = account_number
      @bank = bank
      @logger = options.fetch(:logger) { Logger.new($stdout) }
    end

    def refresh_transactions
      transactions = @bank.read_transactions(@account_number)
      transactions.each do |transaction|
        amount = transaction.fetch('amount')
        amount_cents = (Float(amount) * 100).to_i
        cached_transaction(amount: amount_cents)
      end
    end

    def cached_transaction(transaction)
      @logger.info("caching transaction with amount of #{transaction[:amount]}")
    end
  end
end
