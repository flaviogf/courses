# frozen_string_literal: true

module Ex12
  module Graphics
    RSpec.describe Conversions do
      describe '.Point' do
        context 'when pass a "Point"' do
          subject { described_class.Point(Point.new(10, 100)) }

          it { is_expected.to be_a(Point) }
        end

        context 'when pass an "Array"' do
          subject { described_class.Point([10, 100]) }

          it { is_expected.to be_a(Point) }
        end

        context 'when pass "Integers"' do
          subject { described_class.Point(10, 100) }

          it { is_expected.to be_a(Point) }
        end

        context 'when pass a "String"' do
          subject { described_class.Point('10:100') }

          it { is_expected.to be_a(Point) }
        end

        context 'when pass an unexpected type' do
          it { expect { described_class.Point({}) }.to raise_error(TypeError) }
        end
      end
    end
  end
end
