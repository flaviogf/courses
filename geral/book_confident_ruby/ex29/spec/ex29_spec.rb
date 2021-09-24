# frozen_string_literal: true

RSpec.describe Ex29 do
  it { is_expected.to respond_to(:find_words) }

  describe '.find_words' do
    context 'when it finds a word' do
      let(:words) { %w[GNU LINUX APACHE RUBY] }

      before { allow(described_class).to receive(:words).and_return(words) }

      it 'returns an array' do
        result = described_class.find_words('g')

        expect(result).to be_an(Array)
      end

      it 'returns an array that contains a word' do
        result = described_class.find_words('g')

        expect(result.size).to eq(1)
      end

      it 'returns an array that contains the word "GNU"' do
        result = described_class.find_words('g')

        expect(result).to include('GNU')
      end
    end
  end
end
