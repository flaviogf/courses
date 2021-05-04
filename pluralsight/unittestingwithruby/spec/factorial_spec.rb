require 'factorial'

RSpec.describe 'recursive factorial should' do
    it 'return 120' do
        expect(Factorial.recursive(5)).to eq(120)
    end

    it 'return 5040' do
        expect(Factorial.recursive(7)).to eq(5040)
    end
end

RSpec.describe 'iterative factorial should' do
    it 'return 120' do
        expect(Factorial.iterative(5)).to eq(120)
    end

    it 'return 5040' do
        expect(Factorial.iterative(7)).to eq(5040)
    end
end
