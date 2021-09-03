# frozen_string_literal: true

module Ex12
  module Graphics
    RSpec.describe Point do
      subject { described_class.new(10, 100) }

      it { is_expected.to respond_to(:x) }

      it { is_expected.to respond_to(:y) }
    end
  end
end
