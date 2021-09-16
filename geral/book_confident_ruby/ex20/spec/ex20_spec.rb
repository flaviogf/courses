# frozen_string_literal: true

RSpec.describe Ex20 do
  describe '.log_reading' do
    let(:logger) { instance_double('logger') }

    before do
      allow(described_class).to receive(:logger).and_return(logger)
      allow(logger).to receive(:info)
    end

    it 'calls loggger#info' do
      described_class.log_reading([10, 20, 30])
      expect(logger).to have_received(:info).exactly(3).times
    end

    context 'when quiet is informed' do
      it 'does not call logger#info' do
      described_class.log_reading([10, 20, 30], quiet: true)
      expect(logger).not_to have_received(:info)
      end
    end
  end
end
