# frozen_string_literal: true

RSpec.describe Ex11 do
  describe '.log_reading' do
    context 'when pass "3.14"' do
      subject do
        described_class.log_reading(3.14)
      end

      it { is_expected.to eq('[READING] 3.14') }
    end
  end
end
