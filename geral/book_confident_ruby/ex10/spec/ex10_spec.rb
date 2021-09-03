# frozen_string_literal: true

RSpec.describe Ex10 do
  describe '.pretty_int' do
    context 'when pass "1000"' do
      subject do
        described_class.pretty_int(1000)
      end

      it { is_expected.to eq('1,000') }
    end

    context 'when pass "23"' do
      subject do
        described_class.pretty_int(23)
      end

      it { is_expected.to eq('23') }
    end

    context 'when pass "4567.8"' do
      subject do
        described_class.pretty_int(4567.8)
      end

      it { is_expected.to eq('4,567') }
    end
  end
end
