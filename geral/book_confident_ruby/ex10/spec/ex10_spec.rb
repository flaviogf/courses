# frozen_string_literal: true

RSpec.describe Ex10 do
  describe '.pretty_int' do
    context 'when pass "1000"' do
      subject do
        described_class.pretty_int(1000)
      end

      it { is_expected.to eq('1,000') }
    end
  end
end
