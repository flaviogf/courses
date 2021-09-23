# frozen_string_literal: true

RSpec.describe Ex28 do
  it { is_expected.to respond_to(:delete_files) }

  describe '.delete_files' do
    context 'when a file does not exits' do
      let(:filename) { 'it_does_not_exist.csv' }

      before { allow(File).to receive(:delete).and_raise(Errno::ENOENT) }

      it 'calls the error policy' do
        described_class.delete_files([filename]) do |file, error|
          expect(file).to eq(filename)
          expect(error).to be_an(Errno::ENOENT)
        end
      end

      context 'when error policy is not give' do
        it 'raises an error' do
          expect { described_class.delete_files([filename]) }.to raise_error(Errno::ENOENT)
        end
      end
    end
  end
end
