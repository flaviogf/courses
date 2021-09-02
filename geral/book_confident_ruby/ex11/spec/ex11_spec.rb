# frozen_string_literal: true

RSpec.describe Ex11 do
  describe '.log_reading' do
    context 'when pass "3.14"' do
      subject do
        described_class.log_reading(3.14)
      end

      it { is_expected.to eq(['[READING] 3.14']) }
    end

    context 'when pass "[]"' do
      subject do
        described_class.log_reading([])
      end

      it { is_expected.to eq([]) }
    end

    context 'when pass "[87.9, 45,8674, 32]"' do
      subject do
        described_class.log_reading([87.9, 45.8674, 32])
      end

      it { is_expected.to eq(['[READING] 87.90', '[READING] 45.87', '[READING] 32.00']) }
    end
  end
end
