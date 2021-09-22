# frozen_string_literal: true

module Ex27
  RSpec.describe Point do
    it { is_expected.to respond_to(:x) }

    it { is_expected.to respond_to(:y) }

    it { is_expected.to respond_to(:name) }

    it { is_expected.to respond_to(:magnitude) }
  end
end
