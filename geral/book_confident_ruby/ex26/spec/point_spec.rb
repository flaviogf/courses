# frozen_string_literal: true

module Ex26
  RSpec.describe Point do
    it { is_expected.to respond_to(:x) }

    it { is_expected.to respond_to(:y) }

    it { is_expected.to respond_to(:draw_on) }
  end
end
