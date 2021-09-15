# frozen_string_literal: true

module Ex19
  RSpec.describe Account do
    describe '#refresh_transactions' do
      subject(:account) { described_class.new(account_number: account_number, bank: bank) }

      let(:account_number) { Faker::Internet.uuid }

      let(:bank) { instance_double('bank') }

      let(:transactions) { [{ 'amount' => 99.98 }, { 'amount' => 50.50 }] }

      before do
        allow(bank).to receive(:read_transactions).and_return(transactions)
        allow(account).to receive(:cached_transaction).and_call_original
      end

      it 'calls bank#read_transactions' do
        account.refresh_transactions
        expect(bank).to have_received(:read_transactions).with(account_number).once
      end

      context 'when account has two transactions' do
        it 'calls #cached_transaction twice' do
          account.refresh_transactions
          expect(account).to have_received(:cached_transaction).twice
        end
      end
    end
  end
end
