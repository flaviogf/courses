# frozen_string_literal: true

require 'rails_helper'

RSpec.describe Recording, type: :model do
  subject { create(:recording) }

  it { is_expected.to validate_presence_of(:temp) }

  it { is_expected.to validate_numericality_of(:temp).is_less_than_or_equal_to(100) }

  it { is_expected.to validate_numericality_of(:temp).is_greater_than_or_equal_to(0) }

  it { is_expected.to validate_presence_of(:status) }
end
