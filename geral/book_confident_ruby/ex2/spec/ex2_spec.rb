# frozen_string_literal: true

require 'spec_helper'
require 'csv'
require 'ex2'

RSpec.describe Ex2 do
  describe '.import_legacy_purchase_data' do
    let(:data) do
      CSV.read('data.csv').to_a
    end

    it 'executes successfully' do
      logger = double('logger')

      allow(logger).to receive(:log)

      allow(described_class).to receive(:logger).and_return(logger)

      described_class.import_legacy_purchase_data(data)

      expect(logger).to have_received(:log).exactly(data.size).times
    end
  end
end
