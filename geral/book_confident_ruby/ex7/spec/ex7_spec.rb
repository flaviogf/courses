# frozen_string_literal: true

module Ex7
  RSpec.describe MyFile do
    describe '.open' do
      subject do
        MyFile.open(filename)
      end

      context 'when pass a object like a String' do
        let(:filename) do
          'passwd'
        end

        it { is_expected.to eq('passwd') }
      end

      context 'when pass a object like a Pathname' do
        let(:filename) do
          Pathname('passwd')
        end

        it { is_expected.to eq('passwd') }
      end
    end
  end
end
