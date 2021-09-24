# frozen_string_literal: true

RSpec.describe Ex29 do
  it { is_expected.to respond_to(:find_words) }

  describe '.find_words' do
    context 'when it finds a word' do
      it 'returns an array' do
        result = described_class.find_words('g')

        expect(result).to be_an(Array)
      end
    end
  end
end
